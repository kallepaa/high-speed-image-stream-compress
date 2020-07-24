using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace StreamCompress {
	class Program {

		static void Main(string[] args) {

			_imageConversion();

			Console.ReadKey();
		}


		//private static void _huffmanCode() {
		//	var symbolCount = 256;
		//	var input = "A_DEAD_DAD_CEDED_A_BAD_BABE_A_BEADED_ABACA_BED";

		//	var symbols = new Dictionary<char, int>();

		//	for (int i = 0; i < input.Length; i++) {
		//		var inputChar = input[i];
		//		if (!symbols.ContainsKey(inputChar)) {
		//			symbols[inputChar] = 0;
		//		}
		//		symbols[inputChar]++;
		//	}

		//	var minHeap = new MinHeap<HuffmanTreeNode<string>>(symbolCount);
		//	var leafTable = new HuffmanTreeNode<string>[symbols.Count];

		//	var leadIndex = 0;

		//	foreach (var symbol in symbols) {
		//		var leafNode = new HuffmanTreeNode<string>(symbol.Key.ToString(), symbol.Value);
		//		minHeap.Insert(symbol.Value, leafNode);
		//		leafTable[leadIndex++] = leafNode;
		//	}

		//	while (minHeap.HeapSize > 1) {
		//		var leftNode = minHeap.DelMin();
		//		var rightNode = minHeap.DelMin();
		//		var internalNode = HuffmanTreeNode<string>.InternalNodeCreate(leftNode, rightNode);
		//		minHeap.Insert(internalNode.Frequency, internalNode);
		//	}

		//	for (int i = 0; i < leafTable.Length; i++) {

		//		var node = leafTable[i];
		//		var leafNode = node;
		//		var code = 0;
		//		var bitPos = 0;

		//		while (node != null) {
		//			if (node.IsRightChild) {
		//				var bitToAdd = (1 << bitPos);
		//				code += bitToAdd;
		//			}
		//			bitPos++;
		//			node = node.Parent;
		//		}

		//	}

		//}

		private static void _imageConversion() {
			var cropSetup = new CropSetup {
				LeftPx = 20 * 16,
				RightPx = 25 * 16,
				TopPx = 0,
				BottomPx = 6 * 16
			};

			for (int i = 0; i < 1; i++) {

				var inputFileName = $@"T:\Kalle\Videos\WebCamStreams\1\source\{i.ToString("00000")}-first-frame-color.bmp";
				var iFrameOutputFile = $@"T:\Kalle\Videos\WebCamStreams\1\tmp\{i.ToString("00000")}-iframe.bmp";
				var pFrameOutputFile = $@"T:\Kalle\Videos\WebCamStreams\1\tmp\{i.ToString("00000")}-pframe.bmp";

				var croppedOutputFile = $@"T:\Kalle\Videos\WebCamStreams\1\tmp\{i.ToString("00000")}-first-frame-cropped.bmp";

				var image = ImageFrame.FromFile(inputFileName);

				var croppedImage = image
					.AsCroppedImage(cropSetup);

				var grayImage = croppedImage
					.AsGrayScale();

				var huffmanEncoded = grayImage.AsHuffmanEncoded();
			}
		}

	}
}
