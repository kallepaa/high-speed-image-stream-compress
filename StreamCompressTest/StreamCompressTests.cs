using StreamCompress;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace StreamCompressTest {
	public class StreamCompressTests {

		const string sourcePath = @"T:\Kalle\Videos\WebCamStreams\1\source";
		const string destPath = @"T:\Kalle\Videos\WebCamStreams\1\tmp";
		const string sourceFileSuffix = "first-frame-color.bmp";

		private readonly static CropSetup _cropSetupCorrect = new CropSetup { LeftPx = 27 * 16, RightPx = 29 * 16, TopPx = 1 * 16, BottomPx = 6 * 16 };

		public static string GetSourceImagePath(int i) {
			return FileExtensions.PathCombine(sourcePath, $"{i.ToString("00000")}-{sourceFileSuffix}");
		}

		public static string GetSaveImagePath(int i, string suffix) {
			return FileExtensions.PathCombine(sourcePath, $"{i.ToString("00000")}-{suffix}");
		}

		public class LZCompressionTests {
			[Theory]
			[InlineData("babaabaaa")]
			public void AsLZEncodedAndDecoded(string val) {
				var strEncoder = Encoding.GetEncoding("iso-8859-1");
				var b = strEncoder.GetBytes(val);
				var encoded = b.AsLZEncoded(389);
				var decoded = encoded.AsLZDecoded(389);
				var valDecoded = strEncoder.GetString(decoded);
				Assert.Equal(val, valDecoded);
			}

			[Theory]
			[InlineData(10, 389)]
			[InlineData(100, 389)]
			[InlineData(1000, 389)]
			[InlineData(10000, 389)]
			[InlineData(100000, 389)]
			//[InlineData(1000000, 12289)]
			//[InlineData(10000000, 393241)]
			public void AsLZEncodedAndDecodedRandom(int length, int prime) {
				var strEncoder = Encoding.GetEncoding("iso-8859-1");
				var b = new byte[length];
				var rand = new Random();
				for (int i = 0; i < length; i++) {
					b[i] = (byte)rand.Next(0, 255);
				}
				var val = strEncoder.GetString(b);
				var encoded = b.AsLZEncoded(prime);
				var decoded = encoded.AsLZDecoded(prime);
				var valDecoded = strEncoder.GetString(decoded);
				Assert.Equal(val, valDecoded);
			}
		}

		public class ImageFrameLZCompressionTests {
			[Theory]
			[InlineData(12289)]
			public void AsLZEncodedAndDecoded(int hastablePrime) {
				var i = 1;
				var sourceFile = GetSourceImagePath(i);
				var image = ImageFrame.FromFile(sourceFile);
				var encoded = image.AsLZEncoded(hastablePrime);
				var decoded = encoded.AsImageFrame(hastablePrime);
				Assert.True(image.Image.Compare(decoded.Image));
			}
		}

		public class ImageFrameGrayScaleHuffmanCodeCompressionTests {

			[Theory]
			[InlineData(1)]
			public void AsHuffmanEncodedAndDecoded(int imageIndex) {
				var i = imageIndex;
				var sourceFile = GetSourceImagePath(i);
				var image = ImageFrame.FromFile(sourceFile).AsCroppedImage(_cropSetupCorrect).AsGrayScale();
				var encoded = image.AsHuffmanEncoded();
				var decoded = encoded.AsImageGrayScaleFrame();
				Assert.True(image.Image.Compare(decoded.Image));
			}

			[Theory]
			[InlineData(1)]
			public void AsHuffmanEncodedAndDecodedWithSave(int imageIndex) {
				var i = imageIndex;
				var cropSetup = new CropSetup { LeftPx = 27 * 16, RightPx = 29 * 16, TopPx = 1 * 16, BottomPx = 6 * 16 };
				var sourceFile = GetSourceImagePath(i);
				var image = ImageFrame.FromFile(sourceFile).AsCroppedImage(cropSetup).AsGrayScale();
				var encodedFilename = GetSaveImagePath(i, "gray-huffman-encoded");
				image.AsHuffmanEncoded().Save(encodedFilename);
				var encoded = HuffmanImageFrame.FromFile(encodedFilename);
				var decodedFilename = GetSaveImagePath(i, "gray-huffman-decoded.bmp");
				encoded.AsImageGrayScaleFrame().Save(decodedFilename);
				var decoded = ImageFrame.FromFile(decodedFilename);
				Assert.True(image.Image.Compare(decoded.Image));
			}


		}

		public class ImageFrameTests {

			[Theory]
			[InlineData(1)]
			public void AsGrayScaleInCorrectBits(int imageIndex) {
				var i = imageIndex;
				var sourceFile = GetSourceImagePath(i);
				var image = ImageFrame.FromFile(sourceFile).AsGrayScale();
				((ushort)(24)).AsBytes().CopyBytesTo(image.Image, 28);

				Assert.Throws<NotSupportedException>(() => image.AsHuffmanEncoded());
			}

			[Theory]
			[InlineData(1)]
			public void AsCroppedInCorrectWidth(int imageIndex) {
				var i = imageIndex;
				var cropSetup = new CropSetup { LeftPx = 27 * 7, RightPx = 29 * 16, TopPx = 1 * 16, BottomPx = 6 * 16 };
				var sourceFile = GetSourceImagePath(i);
				var image = ImageFrame.FromFile(sourceFile);
				Assert.Throws<ArgumentException>(() => image.AsCroppedImage(cropSetup));
			}

			[Theory]
			[InlineData(1)]
			public void AsCroppedInCorrectHeight(int imageIndex) {
				var i = imageIndex;
				var cropSetup = new CropSetup { LeftPx = 27 * 16, RightPx = 29 * 16, TopPx = 1 * 7, BottomPx = 6 * 16 };
				var sourceFile = GetSourceImagePath(i);
				var image = ImageFrame.FromFile(sourceFile);
				Assert.Throws<ArgumentException>(() => image.AsCroppedImage(cropSetup));
			}


			[Theory]
			[InlineData(1)]
			public void AsCroppedAsGrayScaleAsPlanted(int imageIndex) {
				var i = imageIndex;
				var sourceFile = GetSourceImagePath(i);
				var image = ImageFrame
					.FromFile(sourceFile)
					.AsCroppedImage(_cropSetupCorrect)
					.AsGrayScale()
					.AsPlanted(1280, 720);

				Assert.True(image.ImageWidthPx == 1280);
				Assert.True(image.ImageHeightPx == 720);
			}

			[Theory]
			[InlineData(1)]
			public void AsCroppedAsGrayScaleAsPlantedInCorrectWidth(int imageIndex) {
				var i = imageIndex;
				var sourceFile = GetSourceImagePath(i);
				var image = ImageFrame
					.FromFile(sourceFile)
					.AsCroppedImage(_cropSetupCorrect)
					.AsGrayScale();

				Assert.Throws<ArgumentException>(() => image.AsPlanted(1279, 720));

			}

			[Theory]
			[InlineData(1)]
			public void AsCroppedAsGrayScaleAsPlantedInCorrectHeight(int imageIndex) {
				var i = imageIndex;
				var sourceFile = GetSourceImagePath(i);
				var image = ImageFrame
					.FromFile(sourceFile)
					.AsCroppedImage(_cropSetupCorrect)
					.AsGrayScale();

				Assert.Throws<ArgumentException>(() => image.AsPlanted(1280, 719));
			}

			[Theory]
			[InlineData(1)]
			public void AsCroppedAsGrayScaleAsPlantedInCorrectBits(int imageIndex) {
				var i = imageIndex;
				var sourceFile = GetSourceImagePath(i);
				var image = ImageFrame
					.FromFile(sourceFile)
					.AsCroppedImage(_cropSetupCorrect)
					.AsGrayScale();

				((ushort)(24)).AsBytes().CopyBytesTo(image.Image, 28);

				Assert.Throws<NotSupportedException>(() => image.AsPlanted(1280, 720));
			}


		}

		public class ByteAndBitOperationTests {


			[Fact]
			public void ByteArraysCompare() {
				var b1 = new byte[] { 1, 2 };
				var b2 = new byte[] { 1, 2 };
				Assert.True(b1.Compare(b2));
			}

			[Fact]
			public void ByteArraysCompareNull() {
				var b1 = new byte[] { 1 };
				Assert.False(b1.Compare(null));
			}


			[Fact]
			public void ByteArraysCompareLengthMismatch() {
				var b1 = new byte[] { 1 };
				var b2 = new byte[] { 1, 2 };
				Assert.False(b1.Compare(b2));
			}

			[Fact]
			public void ByteArraysCompareDataMismatch() {
				var b1 = new byte[] { 2, 1 };
				var b2 = new byte[] { 1, 2 };
				Assert.False(b1.Compare(b2));
			}

			[Fact]
			public void AsInt() {
				var b1 = new byte[] { 1, 0, 0, 0 };
				Assert.True(b1.AsInt(0) == 1);
			}

			[Fact]
			public void AsIntShorterByteArray() {
				var b1 = new byte[] { 1 };
				Assert.True(b1.AsInt(0) == 1);
			}


		}

		public class CLITests {

			[Theory]
			[InlineData(Program.Method.AsGrayScale)]
			//[InlineData(Program.Method.AsGrayScaleCropped)]
			public void AllMethods(Program.Method method) {

				var args = new List<string> {
					"--source-path",
					sourcePath,
					"--source-file-suffix",
					sourceFileSuffix,
					"--destination-path",
					destPath,
					"--start-index",
					"0",
					"--count",
					"1",
					"--method",
					method.ToString()
				};

				switch (method) {
					case Program.Method.AsGrayScale:
						break;
					case Program.Method.AsGrayScaleCropped:
						args.AddRange(new string[] {
							"--crop-left-px", _cropSetupCorrect.LeftPx.ToString(),
							"--crop-right-px", _cropSetupCorrect.RightPx.ToString(),
							"--crop-top-px", _cropSetupCorrect.TopPx.ToString(),
							"--crop-bottom-px", _cropSetupCorrect.BottomPx.ToString()
						});
						break;
					default:
						throw new ArgumentException();
				}

				var ret = Program.Main(args.ToArray());

				Assert.True(ret == 0);
			}


		}
	}
}
