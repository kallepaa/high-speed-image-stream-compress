using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreamCompress {
	public static class Extensions {

		public static ImageFrame AsGrayScale(this ImageFrame image) {

			const int headerSize = 54;
			const int colorTableSize = 4 * 256;//for bytes per color and 256 color from 0 - 255
			var headerAndColorTable = headerSize + colorTableSize;
			var newImage = new byte[image.ImageWidthPx * image.ImageHeightPx + headerAndColorTable];

			Buffer.BlockCopy(image.Image, 0, newImage, 0, 2);

			//file size
			var fileSize = BitConverter.GetBytes((uint)newImage.Length);
			Buffer.BlockCopy(fileSize, 0, newImage, 2, fileSize.Length);

			//pixel data offset 54 (old header) + 1024 (color table) = 1078
			Buffer.SetByte(newImage, 10, 0x36);
			Buffer.SetByte(newImage, 11, 0x04);

			//header size
			Buffer.SetByte(newImage, 14, 0x28);//40

			//image width and height
			Buffer.BlockCopy(image.Image, 18, newImage, 18, 4);
			Buffer.BlockCopy(image.Image, 22, newImage, 22, 4);

			//planes
			Buffer.BlockCopy(image.Image, 26, newImage, 26, 2);

			//bits per pixel
			Buffer.SetByte(newImage, 28, 0x08);

			//color table
			for (int i = 0; i < 255; i++) {
				var bytes = new byte[4] { (byte)i, (byte)i, (byte)i, 0 };
				Buffer.BlockCopy(bytes, 0, newImage, i * 4 + headerSize, 4);
			}

			//linear conversion consts
			const double redLinear = 0.2126;
			const double greenLinear = 0.7152;
			const double blueLinear = 0.0722;

			var destIndex = image.HeaderBytesLength + 1024;

			for (int r = 0; r < image.ImageHeightPx; r++) {
				var rowStartPos = (r * image.ImageWidthPx * 3) + image.HeaderBytesLength;

				//read each pixel in row
				for (int p = 0; p < image.ImageWidthPx; p++) {
					//pixel is presented as 24 bit (3 bytes)
					var pixelPos = rowStartPos + p * 3;
					var green = image.Image[pixelPos + 1];
					var blue = image.Image[pixelPos];
					var red = image.Image[pixelPos + 2];
					var grayIndex = (int)(red * redLinear + green * greenLinear + blue * blueLinear);
					grayIndex -= (grayIndex % 16);
					var grayIndexByte = (byte)grayIndex;
					newImage[destIndex++] = grayIndexByte;
				}
			}

			return new ImageFrame(newImage);
		}

		public static ImageFrame AsCroppedImage(this ImageFrame image, CropSetup cropSetup) {
			var newWidthPx = image.ImageWidthPx - cropSetup.LeftPx - cropSetup.RightPx;
			var newHeightPx = image.ImageHeightPx - cropSetup.TopPx - cropSetup.BottomPx;

			var widthCheck = newWidthPx % 16;

			if (widthCheck != 0) {
				throw new ArgumentException("New width is not divisible by 16!");
			}

			var heightCheck = newHeightPx % 16;

			if (heightCheck != 0) {
				throw new ArgumentException("New height is not divisible by 16!");
			}

			var newImage = new byte[(newWidthPx * 3 * newHeightPx) + image.HeaderBytesLength];

			//copy header from source and ...
			Buffer.BlockCopy(image.Image, 0, newImage, 0, image.HeaderBytesLength);

			//.. adjust header with new width and size
			var headerNewFileSize = BitConverter.GetBytes((uint)newImage.Length);
			var headerNewWidth = BitConverter.GetBytes(newWidthPx);
			var headerNewHeight = BitConverter.GetBytes(newHeightPx);

			Buffer.BlockCopy(headerNewFileSize, 0, newImage, 2, headerNewFileSize.Length);
			Buffer.BlockCopy(headerNewWidth, 0, newImage, 18, headerNewWidth.Length);
			Buffer.BlockCopy(headerNewHeight, 0, newImage, 22, headerNewHeight.Length);

			//copy image bytes from source to new image
			var leftCropBytes = (cropSetup.LeftPx * 3);
			var imageWidthBytes = image.ImageWidthPx * 3;
			var newImageWidthBytes = (newWidthPx * 3);

			var destRow = 0;
			//read rows
			for (var i = cropSetup.BottomPx; i < newHeightPx + cropSetup.BottomPx; i++) {
				var srcOffSet = (leftCropBytes + (i * imageWidthBytes) + image.HeaderBytesLength);
				var destOffSet = (destRow++ * newImageWidthBytes + image.HeaderBytesLength);
				Buffer.BlockCopy(image.Image, srcOffSet, newImage, destOffSet, newImageWidthBytes);
			}

			return new ImageFrame(newImage);

		}

		public static byte[] AsHuffmanEncoded(this ImageFrame image) {

			if (image.BitsPerPixel != 8) {
				throw new NotSupportedException("Only 8 bit per pixel images are supported");
			}

			var colors = (1 << image.BitsPerPixel);
			var minHeap = new MinHeap<HuffmanTreeNode<int>>(colors);
			var leafTable = new HuffmanTreeNode<int>[colors];

			//iterate through all bytes in image data and calculates color frequency
			for (int i = image.HeaderBytesLength; i < image.Image.Length; i++) {
				var colorCode = (int)image.Image[i];//between 0 - 255
				if (leafTable[colorCode] == null) {
					leafTable[colorCode] = new HuffmanTreeNode<int>(colorCode);
				}
				leafTable[colorCode].IncreaseFrequency();
			}

			//add leaf nodes to minheap
			for (int i = 0; i < leafTable.Length; i++) {
				var leafNode = leafTable[i];
				if (leafNode != null) {
					minHeap.Insert(leafNode.Frequency, leafNode);
				}
			}

			//create huffman tree from leaf nodes and internal nodes
			while (minHeap.HeapSize > 1) {
				var internalNode = HuffmanTreeNode<int>.InternalNodeCreate(minHeap.DelMin(), minHeap.DelMin());
				minHeap.Insert(internalNode.Frequency, internalNode);
			}

			//traverse huffman tree from leaf to root and calculate code for node symbol
			for (int i = 0; i < leafTable.Length; i++) {
				var node = leafTable[i];
				if (node != null) {
					var leafNode = node;
					leafNode.ResetCode();
					while (node != null) {
						leafNode.SetCodeNextBit(node.IsRightChild ? 1 : 0);
						node = node.Parent;
					}
				}
			}

			var compressedBits = 0;

			for (int i = 0; i < leafTable.Length; i++) {
				if (leafTable[i] != null) {
					//creates simple array of code bits which is easy iterate in encoding
					leafTable[i].PopulateBitTable();
					compressedBits += leafTable[i].TotalBits;
				}
			}

			//calculate how many bytes is needed for compressed bits
			var totalBytes = (compressedBits / 8);
			if (totalBytes * 8 != compressedBits) {
				//add extra byte for uneven bits
				totalBytes += 1;
			}

			var ret = new byte[totalBytes];

			var retBitIndex = 7; //read bits from left to right
			var retByteIndex = 0;//start begin of return bytes array

			//encode image bytes per byte using huffman code
			for (int i = image.HeaderBytesLength; i < image.Image.Length; i++) {

				//get color encoding info node from leafs table by index
				var colorCode = (int)image.Image[i];
				var leafNode = leafTable[colorCode];

				//read bits from bits table from left to right
				for (int j = leafNode.CodeBitTable.Length - 1; j >= 0; j--) {

					//write bits to byte from left to right
					if (retBitIndex == -1) {
						//switch to next byte and start writing from left of byte (most significant bit)
						retBitIndex = 7;
						retByteIndex++;
					}

					//dest byte bits are set initally to 0 only change byte value when bit is set to 1
					if (leafNode.CodeBitTable[j]) {
						//shift bit to left to get value for addition
						var bitToAdd = (1 << retBitIndex);
						var byteVal = (int)ret[retByteIndex];
						//add bit existing byte
						byteVal += bitToAdd;
						ret[retByteIndex] = (byte)byteVal;
					}
					retBitIndex--;
				}
			}

			return ret;
		}
	}
}
