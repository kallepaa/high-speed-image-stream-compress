using StreamCompress.Domain.Huffman;
using StreamCompress.Domain.Image;
using StreamCompress.Utils;
using System;

namespace StreamCompress.DomainExtensions.Huffman {

	/// <summary>
	/// Domain extensions for domain objects manipulation
	/// </summary>
	public static class Extensions {

		/// <summary>
		/// Decodes Huffman encoded image back to gray scale image
		/// </summary>
		/// <param name="encodedImage"></param>
		/// <returns></returns>
		public static ImageFrameGrayScale AsImageGrayScaleFrame(this HuffmanImageFrame encodedImage) {

			//---------- generate tree from color codes -----------------

			var maxNodes = 0;
			for (int i = 0; i <= encodedImage.MaxCodeBitsLength + 1; i++) {
				maxNodes = 1 << i;
			}

			//simple help table for tree generation
			var nodeTree = new HuffmanTreeNode<int>[maxNodes - 1];
			var rootNode = new HuffmanTreeNode<int>();
			nodeTree[0] = rootNode;

			for (int i = 0; i < encodedImage.ColorCodeCount; i++) {

				var colorCodeItem = encodedImage.GetColorCodeItemFromHeader(i);
				var huffmanNode = new HuffmanTreeNode<int>(colorCodeItem.Symbol, colorCodeItem.Code, colorCodeItem.CodeBitsCount);
				huffmanNode.PopulateBitTable();

				//start always from root bit and go to leaf
				var parentPos = 0;
				var parent = nodeTree[0];

				for (int j = huffmanNode.CodeBitTable.Length - 1; j >= 0; j--) {

					var childPos = 0;
					var isRightChild = huffmanNode.CodeBitTable[j];

					if (isRightChild) {
						childPos = ((parentPos + 1) * 2 + 1) - 1;
					} else {
						childPos = ((parentPos + 1) * 2) - 1;
					}

					if (j == 0) {
						//leaf node
						nodeTree[childPos] = huffmanNode;
					} else if (nodeTree[childPos] == null) {
						//create internal node
						nodeTree[childPos] = new HuffmanTreeNode<int>();
					}

					nodeTree[childPos].SetParent(parent, isRightChild);
					parent.SetChild(nodeTree[childPos]);
					parent = nodeTree[childPos];
					parentPos = childPos;
				}
			}

			var imageHeaderSize = encodedImage.OriginalImageHeaderLength + ImageFrame.HEADER_256_COLOR_TABLE_SIZE;
			var imageData = new byte[imageHeaderSize + encodedImage.OriginalImageDataLength];

			//-------------   set header ------------------------

			//copy original image non-encoded header to image
			encodedImage.Data.CopyBytesTo(
				encodedImage.FixedHeaderLength + encodedImage.ColorCodeHeaderLength,
				imageData,
				0,
				encodedImage.OriginalImageHeaderLength);

			//--------------- decode image -----------------------

			var node = rootNode;
			var destIndex = imageHeaderSize;

			//read encoded stream bit by bit and travel tree using bit value
			//until leaf node is reached. read original color code from leaf node
			for (int i = 0; i < encodedImage.CompressedBits; i++) {
				//read right or left child based bit in stream
				node = encodedImage.GetBit(i) ? node.RightChild : node.LeftChild;
				if (node.Leaf) {
					//set decoded byte to image
					imageData[destIndex++] = (byte)node.Symbol;
					//move back to root node
					node = rootNode;
				}
			}

			var ret =  new ImageFrameGrayScale(imageData);
			//generate color table
			ret.SetColorTable();

			return ret;
		}
	}
}
