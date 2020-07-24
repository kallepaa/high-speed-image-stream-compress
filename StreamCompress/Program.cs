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
