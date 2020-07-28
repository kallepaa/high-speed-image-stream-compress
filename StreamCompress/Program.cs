using System;

namespace StreamCompress {
	class Program {

		static void Main(string[] args) {

			_imageConversion();

			Console.ReadKey();
		}

		private static void _imageConversion() {
			var cropSetup = new CropSetup {
				LeftPx = 27 * 16,
				RightPx = 29 * 16,
				TopPx = 1 * 16,
				BottomPx = 6 * 16
			};

			for (int i = 401; i < 402; i++) {

				var inputFileName = $@"T:\Kalle\Videos\WebCamStreams\1\source\{i.ToString("00000")}-first-frame-color.bmp";

				var croppedOutputFile = $@"T:\Kalle\Videos\WebCamStreams\1\tmp\{i.ToString("00000")}-cropped.bmp";
				var grayOutputFile = $@"T:\Kalle\Videos\WebCamStreams\1\tmp\{i.ToString("00000")}-cropped-gray.bmp";
				var grayEncodedOutputFile = $@"T:\Kalle\Videos\WebCamStreams\1\tmp\{i.ToString("00000")}-cropped-gray-encoded";
				var grayRoundTripOutputFile = $@"T:\Kalle\Videos\WebCamStreams\1\tmp\{i.ToString("00000")}-cropped-gray-round-trip.bmp";

				var image = ImageFrame.FromFile(inputFileName);

				var croppedImage = image
					.AsCroppedImage(cropSetup);

				var grayImage = croppedImage
					.AsGrayScale(64);

				var grayImageAs1280x720 = grayImage.AsSize(1280, 720);

			}
		}

	}
}
