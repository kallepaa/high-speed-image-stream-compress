using System;
using System.Collections.Generic;

namespace StreamCompress {
	class Program {

		static void Main(string[] args) {


			Console.ReadKey();
		}

		private static void _LZCompression() {

			var encoderDic = new Dictionary<string, int>();
			for (int i = 0; i < 256; i++) {
				encoderDic[((char)i).ToString()] = i;
			}

			var input = "babaabaaa".ToUpper();
			var encodedOutput = new List<int>();

			var P = input[0].ToString();

			for (int i = 1; i < input.Length; i++) {
				var C = input[i].ToString();
				var PC = P + C;
				if (encoderDic.ContainsKey(PC)) {
					P = PC;
				} else {
					encodedOutput.Add(encoderDic[P]);
					encoderDic[PC] = encoderDic.Count;
					P = C;
				}
			}

			encodedOutput.Add(encoderDic[P]);

			var decoderDic = new Dictionary<int, string>();
			for (int i = 0; i < 256; i++) {
				decoderDic[i] = ((char)i).ToString();
			}

			var decodedOutPut = new List<string>();
			var O = encodedOutput[0];
			var S = string.Empty;
			var C2 = string.Empty;

			decodedOutPut.Add(decoderDic[O]);

			for (int i = 1; i < encodedOutput.Count; i++) {
				var N = encodedOutput[i];
				if (!decoderDic.ContainsKey(N)) {
					S = decoderDic[O];
					S = S + C2;
				} else {
					S = decoderDic[N];
				}
				decodedOutPut.Add(S);
				C2 = S[0].ToString();

				decoderDic[decoderDic.Count] = decoderDic[O] + C2;

				O = N;
			}


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
