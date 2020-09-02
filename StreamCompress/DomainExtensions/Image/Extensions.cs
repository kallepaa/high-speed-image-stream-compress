using StreamCompress.Domain.GZip;
using StreamCompress.Domain.Huffman;
using StreamCompress.Domain.Image;
using StreamCompress.Domain.LZ;
using StreamCompress.Utils;
using System;
using System.IO;
using System.IO.Compression;

namespace StreamCompress.DomainExtensions.Image {

	/// <summary>
	/// Domain extensions for domain objects manipulation
	/// </summary>
	public static class Extensions {

		/// <summary>
		/// Converts 24 bit color image to gray scale image
		/// </summary>
		/// <param name="image">Color image</param>
		/// <param name="colors">How many gray colors are used in gray image</param>
		/// <returns></returns>
		public static ImageFrameGrayScale AsGrayScale(this ImageFrame image, int colors = 256) {

			//--------- write gray scale image header -----------------

			const int headerSize = ImageFrame.HEADER_BYTES;
			const int colorTableSize = ImageFrame.HEADER_256_COLOR_TABLE_SIZE;
			var headerAndColorTable = headerSize + colorTableSize;
			var newImage = new byte[image.ImageWidthPx * image.ImageHeightPx + headerAndColorTable];

			//magic bits
			image.Image.CopyBytesTo(0, newImage, 0, 2);

			//file size
			((uint)(newImage.Length)).AsBytes().CopyBytesTo(newImage, 2);

			//pixel data offset 54 (old header) + 1024 (color table) = 1078
			newImage[10] = 54;
			newImage[11] = 4;

			//header size
			newImage[14] = 40;

			//image width and height
			image.Image.CopyBytesTo(18, newImage, 18, 4);
			image.Image.CopyBytesTo(22, newImage, 22, 4);

			//planes
			image.Image.CopyBytesTo(26, newImage, 26, 2);

			//bits per pixel
			newImage[28] = 8;

			//--------- convert rgb pixels to gray scale

			//linear conversion consts
			const double redLinear = 0.2126;
			const double greenLinear = 0.7152;
			const double blueLinear = 0.0722;

			var colorCount = 256 / colors;

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
					var mod = (grayIndex % colorCount);
					grayIndex -= mod;
					var grayIndexByte = (byte)grayIndex;
					newImage[destIndex++] = grayIndexByte;
				}
			}

			var ret = new ImageFrameGrayScale(newImage);

			//color table
			ret.SetColorTable();

			return ret;
		}

		/// <summary>
		/// Crops given image
		/// </summary>
		/// <param name="image">Image to crop</param>
		/// <param name="cropSetup">Crop setup</param>
		/// <returns>Cropped image</returns>
		public static ImageFrame AsCroppedImage(this ImageFrame image, CropSetup cropSetup) {

			if (!cropSetup.IsAnyCropSet()) {
				return image;
			}

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
			image.Image.CopyBytesTo(0, newImage, 0, image.HeaderBytesLength);

			//copy image bytes from source to new image
			var leftCropBytes = (cropSetup.LeftPx * 3);
			var imageWidthBytes = image.ImageWidthPx * 3;
			var newImageWidthBytes = (newWidthPx * 3);

			var destRow = 0;
			//read rows
			for (var i = cropSetup.BottomPx; i < newHeightPx + cropSetup.BottomPx; i++) {
				var srcOffSet = (leftCropBytes + (i * imageWidthBytes) + image.HeaderBytesLength);
				var destOffSet = (destRow++ * newImageWidthBytes + image.HeaderBytesLength);
				image.Image.CopyBytesTo(srcOffSet, newImage, destOffSet, newImageWidthBytes);
			}

			var ret = new ImageFrame(newImage);
			//.. adjust header with new width and size
			ret.SetSizeInfo((uint)newImage.Length, newWidthPx, newHeightPx);
			return ret;
		}

		/// <summary>
		/// Encodes gray scale image using huffman coding
		/// </summary>
		/// <param name="image">Image to encode</param>
		/// <returns>Huffman image frame</returns>
		public static HuffmanImageFrame AsHuffmanEncoded(this ImageFrameGrayScale image) {

			if (image.BitsPerPixel != 8) {
				throw new NotSupportedException("Only 8 bits per pixel images are supported");
			}

			var colors = (1 << image.BitsPerPixel);
			var minHeap = new MinHeap<HuffmanTreeNode<int>>(colors);
			var leafTable = new HuffmanTreeNode<int>[colors];

			var leafNodeCount = 0;

			//iterate through all bytes in image data and calculates color frequency
			for (int i = image.HeaderBytesLength; i < image.Image.Length; i++) {
				var colorCode = (int)image.Image[i];//between 0 - 255
				if (leafTable[colorCode] == null) {
					leafTable[colorCode] = new HuffmanTreeNode<int>(colorCode);
					leafNodeCount++;
				}
				leafTable[colorCode].IncreaseFrequency();
			}

			var leafTableShrink = new HuffmanTreeNode<int>[leafNodeCount];

			var shrinkIndex = 0;
			//add leaf nodes to minheap and shrink table
			for (int i = 0; i < leafTable.Length; i++) {
				var leafNode = leafTable[i];
				if (leafNode != null) {
					leafTableShrink[shrinkIndex++] = leafNode;
					minHeap.Insert(leafNode.Frequency, leafNode);
				}
			}

			var internalNodesCount = 0;
			//create huffman tree from leaf nodes and internal nodes
			while (minHeap.HeapSize > 1) {
				var internalNode = HuffmanTreeNode<int>.InternalNodeCreate(minHeap.DelMin(), minHeap.DelMin());
				minHeap.Insert(internalNode.Frequency, internalNode);
				internalNodesCount++;
			}

			//traverse huffman tree from leaf to root and calculate code for node symbol
			for (int i = 0; i < leafTableShrink.Length; i++) {
				var node = leafTableShrink[i];
				var leafNode = node;
				leafNode.ResetCode();
				while (node != null) {
					leafNode.SetCodeNextBit(node.IsRightChild ? 1 : 0);
					node.Parent?.SetChild(node);
					node = node.Parent;
				}
			}

			var compressedBits = 0;
			var maxCodeBits = 0;
			var headerColorItems = new HuffmanImageFrame.HeaderColorItem[leafTableShrink.Length];

			for (int i = 0; i < leafTableShrink.Length; i++) {
				//creates simple array of code bits which is easy iterate in encoding
				leafTableShrink[i].PopulateBitTable();
				compressedBits += leafTableShrink[i].TotalBits;
				maxCodeBits = leafTableShrink[i].CodeBits > maxCodeBits ? leafTableShrink[i].CodeBits : maxCodeBits;
				headerColorItems[i] = new HuffmanImageFrame.HeaderColorItem(
							leafTableShrink[i].Symbol,
							leafTableShrink[i].CodeBits,
							leafTableShrink[i].Code);
			}

			//------------------ Build return starts --------------------------------------

			var originalImageHeader = new byte[ImageFrame.HEADER_BYTES];
			image.Image.CopyBytesTo(0, originalImageHeader);

			var originalImageDataLength = image.Image.Length - image.HeaderBytesLength;

			var ret = new HuffmanImageFrame(compressedBits, headerColorItems, maxCodeBits, originalImageDataLength, originalImageHeader);

			var retBitIndex = 7; //read bits from left to right
			var retByteIndex = ret.ImageDataOffSet;//start begin of image section

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
						ret.Data[retByteIndex] = ret.Data[retByteIndex].SetBitToByte(retBitIndex);
					}

					retBitIndex--;
				}
			}

			return ret;
		}

		/// <summary>
		/// Adds given image in the center of the given plant area and return new image instance
		/// </summary>
		/// <param name="image">Image to plant inside new image</param>
		/// <param name="plantWidthPx">New image width</param>
		/// <param name="plantHeightPx">New image height</param>
		/// <returns></returns>
		public static ImageFrameGrayScale AsPlanted(this ImageFrameGrayScale image, int plantWidthPx, int plantHeightPx) {


			var widthCheck = plantWidthPx % 16;

			if (widthCheck != 0) {
				throw new ArgumentException("New width is not divisible by 16!");
			}

			var heightCheck = plantHeightPx % 16;

			if (heightCheck != 0) {
				throw new ArgumentException("New height is not divisible by 16!");
			}

			if (image.BitsPerPixel != 8) {
				throw new NotSupportedException("Only 8 bits per pixel images are supported");
			}

			var newImage = new byte[image.HeaderBytesLength + plantWidthPx * plantHeightPx];

			//copy header from source and ...
			image.Image.CopyBytesTo(0, newImage, 0, image.HeaderBytesLength);

			var leftPx = plantWidthPx / 2 - image.ImageWidthPx / 2;
			var bottomPx = (plantHeightPx / 2 - image.ImageHeightPx / 2);

			//fill image into plant center
			for (int ir = 0; ir < image.ImageHeightPx; ir++) {
				var rowOffSet = ir * image.ImageWidthPx + image.HeaderBytesLength;
				var newImageRowOffSet = (bottomPx + ir) * plantWidthPx + image.HeaderBytesLength + leftPx;
				for (int ipx = 0; ipx < image.ImageWidthPx; ipx++) {
					var pxIndex = rowOffSet + ipx;
					var px = image.Image[pxIndex];
					var newPxIndex = newImageRowOffSet + ipx;
					newImage[newPxIndex] = px;
				}
			}

			var ret = new ImageFrameGrayScale(newImage);
			//.. adjust header with new width and size
			ret.SetSizeInfo((uint)newImage.Length, plantWidthPx, plantHeightPx);

			return ret;
		}

		/// <summary>
		/// Encode given data using LZ coding and given dictionary
		/// </summary>
		/// <param name="input">Byte array to encode</param>
		/// <param name="encoderDic">Dictionary implementation</param>
		/// <returns>Encoded byte array</returns>
		private static byte[] _asLZEncoded(this byte[] input, ILZ78CodingTable<int> encoderDic) {

			var twoPass = true;

			for (int i = 0; i < 256; i++) {
				var searchKey = new[] { (byte)i };
				var codeWord = i;
				encoderDic.Insert(searchKey, codeWord);
			}

			var addedCodeWords = 0;

			using (var encodedOutput = new ByteMemoryStream((int)(input.Length / 0.6))) {

				var P = new byte[] { input[0] };

				for (int i = 1; i < input.Length; i++) {

					var C = new byte[] { input[i] };
					var PC = P.Concatenate(C);

					var item = encoderDic.Search(PC);

					if (item != null) {
						P = PC;
					} else {
						var item2 = encoderDic.Search(P);

						encodedOutput.AddBytes(item2.CodeWord.AsBytes());
						addedCodeWords++;
						encoderDic.Insert(PC, encoderDic.Count);
						P = C;
					}
				}

				var item3 = encoderDic.Search(P);
				encodedOutput.AddBytes(item3.CodeWord.AsBytes());
				addedCodeWords++;

				var encodedBytes = encodedOutput.ReadBytes();

				if (twoPass) {
					return encodedBytes.AsCompressed(encoderDic.Count - 1, addedCodeWords);
				} else {
					return encodedBytes;
				}
			}



		}


		#region LZ78 Using Hash Table as dictionary

		/// <summary>
		/// Encodes bytes using LZ and hash table as dictionary
		/// </summary>
		/// <param name="input">Byte array</param>
		/// <param name="hashPrime">m value in hash table</param>
		/// <returns>Encoded byte array</returns>
		public static byte[] BytesAsLZEncodedUsingHashTable(this byte[] input, int hashPrime) {
			var encoderDic = new HashTable<int>(hashPrime);
			return _asLZEncoded(input, encoderDic);
		}

		/// <summary>
		/// Encodes image using LZ and hash table as dictionary
		/// </summary>
		/// <typeparam name="T">Type of image</typeparam>
		/// <param name="image">Image to encode</param>
		/// <param name="hashPrime">m value in hash table</param>
		/// <returns></returns>
		public static LZImageFrame AsLZEncodedUsingHashTable<T>(this T image, int hashPrime) where T : ImageFrame {
			return new LZImageFrame(image.Image.BytesAsLZEncodedUsingHashTable(hashPrime));
		}

		#endregion

		#region LZ78 Using Trie as dictionary

		/// <summary>
		/// Encodes bytes using LZ and trie as dictionary
		/// </summary>
		/// <param name="input">Byte array</param>
		/// <param name="nodeInitialCapacity">Node table initial size</param>
		/// <returns></returns>
		public static byte[] BytesAsLZEncodedUsingTrie(this byte[] input, int nodeInitialCapacity) {
			var encoderDic = new Tries<int>(nodeInitialCapacity);
			return _asLZEncoded(input, encoderDic);
		}

		/// <summary>
		/// Encodes image using LZ and trie as dictionary
		/// </summary>
		/// <typeparam name="T">Type of image</typeparam>
		/// <param name="image">Image to encode</param>
		/// <param name="nodeInitialCapacity">Node table initial size</param>
		/// <returns></returns>
		public static LZImageFrame AsLZEncodedUsingTrie<T>(this T image, int nodeInitialCapacity) where T : ImageFrame {
			return new LZImageFrame(image.Image.BytesAsLZEncodedUsingTrie(nodeInitialCapacity));
		}

		#endregion

		#region LZ78 Using fixed length Trie as dictionary

		/// <summary>
		/// Encodes bytes using LZ and fixed length trie as dictionary
		/// </summary>
		/// <param name="input">Byte array</param>
		/// <returns></returns>
		public static byte[] BytesAsLZEncodedUsingTrie256(this byte[] input) {
			var encoderDic = new Tries256<int>();
			return _asLZEncoded(input, encoderDic);
		}

		/// <summary>
		/// Encodes image using LZ and fixed length trie as dictionary
		/// </summary>
		/// <typeparam name="T">Type of image</typeparam>
		/// <param name="image">Image to encode</param>
		/// <returns></returns>
		public static LZImageFrame AsLZEncodedUsingTrie256<T>(this T image) where T : ImageFrame {
			return new LZImageFrame(image.Image.BytesAsLZEncodedUsingTrie256());
		}

		#endregion


		/// <summary>
		/// Create crop setup from command line arguments
		/// </summary>
		/// <param name="a">Command line arguments</param>
		/// <returns>Crop setup</returns>
		public static CropSetup AsCropSetup(this Program.CommandLineArgs a) {
			return new CropSetup { LeftPx = a.CropLeftPx, RightPx = a.CropRightPx, TopPx = a.CropTopPx, BottomPx = a.CropBottomPx };
		}

		/// <summary>
		/// Compress bytes using .Net Core impl. of GZip 
		/// Just for benchmark reason
		/// </summary>
		/// <param name="image"></param>
		/// <returns></returns>
		public static GZipImageFrame AsGZipEncoded<T>(this T image) where T : ImageFrame {
			var ret = default(byte[]);
			using (var outputMs = new ByteMemoryStream(1024)) {
				using (GZipStream compressionStream = new GZipStream(outputMs.MemoryStream, CompressionMode.Compress))
				using (var inputMs = new ByteMemoryStream(image.Image)) {
					inputMs.MemoryStream.CopyTo(compressionStream);
				}
				ret = outputMs.ReadBytes();
			}
			return new GZipImageFrame(ret);
		}


	}
}
