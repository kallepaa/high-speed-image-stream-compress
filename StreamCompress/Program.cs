using System;

namespace StreamCompress {
	class Program {

		static void Main(string[] args) {

			_imageConversion();

			Console.ReadKey();
		}

		private static void _imageConversion() {

			var sourcePath = @"T:\Kalle\Videos\WebCamStreams\1\source";
			var destPath = @"T:\Kalle\Videos\WebCamStreams\1\tmp";

			var cropSetup = new CropSetup {
				LeftPx = 27 * 16,
				RightPx = 29 * 16,
				TopPx = 1 * 16,
				BottomPx = 6 * 16
			};

			for (int i = 401; i < 402; i++) {

				var sourceFile = FileExtensions.PathCombine(sourcePath, $"{i.ToString("00000")}-first-frame-color.bmp");

				var originalFile = FileExtensions.PathCombine(destPath, $"000-{i.ToString("00000")}-original.bmp");
				var croppedFile = FileExtensions.PathCombine(destPath, $"001-{i.ToString("00000")}-cropped.bmp");
				var grayFile = FileExtensions.PathCombine(destPath, $"002-{i.ToString("00000")}-gray.bmp");
				var grayEncodedFile = FileExtensions.PathCombine(destPath, $"003-{i.ToString("00000")}-gray-encoded");
				var grayDecodedFile = FileExtensions.PathCombine(destPath, $"004-{i.ToString("00000")}-gray-decoded.bmp");
				var plantedFile = FileExtensions.PathCombine(destPath, $"005-{i.ToString("00000")}-planted.bmp");
				var plantedEncodedFile = FileExtensions.PathCombine(destPath, $"006-{i.ToString("00000")}-planted-encoded");

				var image = 
					ImageFrame.FromFile(sourceFile).Save<ImageFrame>(originalFile)
					.AsCroppedImage(cropSetup).Save<ImageFrame>(croppedFile)
					.AsGrayScale(64).Save<ImageFrameGrayScale>(grayFile)
					.AsHuffmanEncoded().Save(grayEncodedFile)
					.AsImageFrame().Save<ImageFrameGrayScale>(grayDecodedFile)
					.AsPlanted(1280, 720).Save<ImageFrameGrayScale>(plantedFile)
					.AsHuffmanEncoded().Save(plantedEncodedFile);

			}
		}

	}
}
