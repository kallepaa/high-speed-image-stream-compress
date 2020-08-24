using StreamCompress;
using StreamCompress.Domain.Huffman;
using StreamCompress.Domain.Image;
using StreamCompress.Domain.LZ;
using StreamCompress.DomainExtensions.Huffman;
using StreamCompress.DomainExtensions.Image;
using StreamCompress.DomainExtensions.LZ;
using StreamCompress.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;
using StreamCompress.Shared;

namespace StreamCompressTest {
	public class StreamCompressTests {

		private readonly static CropSetup _cropSetupCorrect = new CropSetup { LeftPx = 27 * 16, RightPx = 29 * 16, TopPx = 1 * 16, BottomPx = 6 * 16 };

		public class TriesTests {

			[Fact]
			public void InsertAndExists() {

				var words = new[] { "Car", "Cat" };
				var strEncoder = Encoding.GetEncoding("iso-8859-1");

				var sut = new Tries<string>(10);

				for (int i = 0; i < words.Length; i++) {
					var b = strEncoder.GetBytes(words[i]);
					sut.Insert(b, words[i]);
				}

				for (int i = 0; i < words.Length; i++) {
					var b = strEncoder.GetBytes(words[i]);
					var match = sut.Search(b);
					Assert.True(match != null && match.CodeWord == words[i]);
				}
			}

			[Fact]
			public void InsertAndCount() {

				var words = new[] { "Car", "Cat", "Car", "Cat" };
				var strEncoder = Encoding.GetEncoding("iso-8859-1");

				var sut = new Tries<string>(10);

				for (int i = 0; i < words.Length; i++) {
					var b = strEncoder.GetBytes(words[i]);
					sut.Insert(b, words[i]);
				}

				Assert.True(sut.Count == words.Distinct().Count());
			}


			[Fact]
			public void InsertAndExistsAndNotExists() {

				var words = new[] { "Car", "Cat" };
				var strEncoder = Encoding.GetEncoding("iso-8859-1");

				var sut = new Tries<string>(10);

				for (int i = 0; i < words.Length; i++) {
					var b = strEncoder.GetBytes(words[i]);
					sut.Insert(b, words[i]);
				}

				for (int i = 0; i < words.Length; i++) {
					var b = strEncoder.GetBytes(words[i]);
					var match = sut.Search(b);
					Assert.True(match != null && match.CodeWord == words[i]);
				}

				var wordsNotExist = new[] { "car", "cat", "tac", "rac", "r", "ca", "catastrophe" };

				for (int i = 0; i < wordsNotExist.Length; i++) {
					var b = strEncoder.GetBytes(wordsNotExist[i]);
					var match = sut.Search(b);
					Assert.True(match == null);
				}

			}
		}

		public class Tries256Tests {

			[Fact]
			public void InsertAndExists() {

				var words = new[] { "Car", "Cat" };
				var strEncoder = Encoding.GetEncoding("iso-8859-1");

				var sut = new Tries256<string>();

				for (int i = 0; i < words.Length; i++) {
					var b = strEncoder.GetBytes(words[i]);
					sut.Insert(b, words[i]);
				}

				for (int i = 0; i < words.Length; i++) {
					var b = strEncoder.GetBytes(words[i]);
					var match = sut.Search(b);
					Assert.True(match != null && match.CodeWord == words[i]);
				}
			}

			[Fact]
			public void InsertAndCount() {

				var words = new[] { "Car", "Cat", "Car", "Cat" };
				var strEncoder = Encoding.GetEncoding("iso-8859-1");

				var sut = new Tries256<string>();

				for (int i = 0; i < words.Length; i++) {
					var b = strEncoder.GetBytes(words[i]);
					sut.Insert(b, words[i]);
				}

				Assert.True(sut.Count == words.Distinct().Count());
			}


			[Fact]
			public void InsertAndExistsAndNotExists() {

				var words = new[] { "Car", "Cat" };
				var strEncoder = Encoding.GetEncoding("iso-8859-1");

				var sut = new Tries256<string>();

				for (int i = 0; i < words.Length; i++) {
					var b = strEncoder.GetBytes(words[i]);
					sut.Insert(b, words[i]);
				}

				for (int i = 0; i < words.Length; i++) {
					var b = strEncoder.GetBytes(words[i]);
					var match = sut.Search(b);
					Assert.True(match != null && match.CodeWord == words[i]);
				}

				var wordsNotExist = new[] { "car", "cat", "tac", "rac", "r", "ca", "catastrophe" };

				for (int i = 0; i < wordsNotExist.Length; i++) {
					var b = strEncoder.GetBytes(wordsNotExist[i]);
					var match = sut.Search(b);
					Assert.True(match == null);
				}

			}
		}


		public class LZCompressionUsingHashTableTests {

			[Theory]
			[InlineData("babaabaaa")]
			public void AsLZEncodedAndDecoded(string val) {
				var strEncoder = Encoding.GetEncoding("iso-8859-1");
				var b = strEncoder.GetBytes(val);
				var encoded = b.BytesAsLZEncodedUsingHashTable(389);
				var decoded = encoded.AsLZDecodedUsingHashTable(389);
				var valDecoded = strEncoder.GetString(decoded);
				Assert.Equal(val, valDecoded);
			}

			[Theory]
			[InlineData(10, 389)]
			[InlineData(100, 389)]
			[InlineData(1000, 389)]
			[InlineData(10000, 389)]
			[InlineData(100000, 389)]
			public void AsLZEncodedAndDecodedRandom(int length, int prime) {
				var strEncoder = Encoding.GetEncoding("iso-8859-1");
				var b = new byte[length];
				var rand = new Random();
				for (int i = 0; i < length; i++) {
					b[i] = (byte)rand.Next(0, 255);
				}
				var val = strEncoder.GetString(b);
				var encoded = b.BytesAsLZEncodedUsingHashTable(prime);
				var decoded = encoded.AsLZDecodedUsingHashTable(prime);
				var valDecoded = strEncoder.GetString(decoded);
				Assert.Equal(val, valDecoded);
			}
		}


		public class LZCompressionUsingTrieTests {

			[Theory]
			[InlineData("babaabaaa")]
			public void AsLZEncodedAndDecoded(string val) {
				var strEncoder = Encoding.GetEncoding("iso-8859-1");
				var b = strEncoder.GetBytes(val);
				var encoded = b.BytesAsLZEncodedUsingTrie(10);
				var decoded = encoded.AsLZDecodedUsingTrie(10);
				var valDecoded = strEncoder.GetString(decoded);
				Assert.Equal(val, valDecoded);
			}

			[Theory]
			[InlineData(10, 1)]
			[InlineData(100, 2)]
			[InlineData(1000, 5)]
			[InlineData(10000, 10)]
			[InlineData(100000, 20)]
			public void AsLZEncodedAndDecodedRandom(int length, int nodeInitialCapacity) {
				var strEncoder = Encoding.GetEncoding("iso-8859-1");
				var b = new byte[length];
				var rand = new Random();
				for (int i = 0; i < length; i++) {
					b[i] = (byte)rand.Next(0, 255);
				}
				var val = strEncoder.GetString(b);
				var encoded = b.BytesAsLZEncodedUsingTrie(nodeInitialCapacity);
				var decoded = encoded.AsLZDecodedUsingTrie(nodeInitialCapacity);
				var valDecoded = strEncoder.GetString(decoded);
				Assert.Equal(val, valDecoded);
			}
		}


		public class LZCompressionUsingTrie256Tests {

			[Theory]
			[InlineData("babaabaaa")]
			public void AsLZEncodedAndDecoded(string val) {
				var strEncoder = Encoding.GetEncoding("iso-8859-1");
				var b = strEncoder.GetBytes(val);
				var encoded = b.BytesAsLZEncodedUsingTrie256();
				var decoded = encoded.AsLZDecodedUsingTrie256();
				var valDecoded = strEncoder.GetString(decoded);
				Assert.Equal(val, valDecoded);
			}

			[Theory]
			[InlineData(10)]
			[InlineData(100)]
			[InlineData(1000)]
			[InlineData(10000)]
			[InlineData(100000)]
			public void AsLZEncodedAndDecodedRandom(int length) {
				var strEncoder = Encoding.GetEncoding("iso-8859-1");
				var b = new byte[length];
				var rand = new Random();
				for (int i = 0; i < length; i++) {
					b[i] = (byte)rand.Next(0, 255);
				}
				var val = strEncoder.GetString(b);
				var encoded = b.BytesAsLZEncodedUsingTrie256();
				var decoded = encoded.AsLZDecodedUsingTrie256();
				var valDecoded = strEncoder.GetString(decoded);
				Assert.Equal(val, valDecoded);
			}
		}



		public class ImageFrameLZCompressionHashTableTests {
			[Theory]
			[InlineData(12289)]
			public void AsLZEncodedAndDecoded(int prime) {
				var i = 2;
				var sourceFile = Common.GetSourceImagePath(i);
				var image = ImageFrame.FromFile(sourceFile);
				var encoded = image.AsLZEncodedUsingHashTable(prime);
				var decoded = encoded.AsImageFrameUsingHashTable<ImageFrame>(prime);
				Assert.True(image.Image.Compare(decoded.Image));
			}
		}

		public class ImageFrameLZCompressionTrieTests {
			[Theory]
			[InlineData(1)]
			public void AsLZEncodedAndDecoded(int nodeInitialCapacity) {
				var i = 2;
				var sourceFile = Common.GetSourceImagePath(i);
				var image = ImageFrame.FromFile(sourceFile);
				var encoded = image.AsLZEncodedUsingTrie(nodeInitialCapacity);
				var decoded = encoded.AsImageFrameUsingTrie<ImageFrame>(nodeInitialCapacity);
				Assert.True(image.Image.Compare(decoded.Image));
			}
		}

		public class ImageFrameLZCompressionTrie256Tests {
			[Fact]
			public void AsLZEncodedAndDecoded() {
				var i = 2;
				var sourceFile = Common.GetSourceImagePath(i);
				var image = ImageFrame.FromFile(sourceFile);
				var encoded = image.AsLZEncodedUsingTrie256();
				var decoded = encoded.AsImageFrameUsingTrie256<ImageFrame>();
				Assert.True(image.Image.Compare(decoded.Image));
			}
		}

		public class ImageFrameGrayScaleHuffmanCodeCompressionTests {

			[Theory]
			[InlineData(1)]
			public void AsHuffmanEncodedAndDecoded(int imageIndex) {
				var i = imageIndex;
				var sourceFile = Common.GetSourceImagePath(i);
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
				var sourceFile = Common.GetSourceImagePath(i);
				var image = ImageFrame.FromFile(sourceFile).AsCroppedImage(cropSetup).AsGrayScale();
				var encodedFilename = Common.GetSaveImagePath(i, "gray-huffman-encoded");
				image.AsHuffmanEncoded().Save(encodedFilename);
				var encoded = new HuffmanImageFrame().Open(encodedFilename);
				var decodedFilename = Common.GetSaveImagePath(i, "gray-huffman-decoded.bmp");
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
				var sourceFile = Common.GetSourceImagePath(i);
				var image = ImageFrame.FromFile(sourceFile).AsGrayScale();
				((ushort)(24)).AsBytes().CopyBytesTo(image.Image, 28);

				Assert.Throws<NotSupportedException>(() => image.AsHuffmanEncoded());
			}

			[Theory]
			[InlineData(1)]
			public void AsCroppedInCorrectWidth(int imageIndex) {
				var i = imageIndex;
				var cropSetup = new CropSetup { LeftPx = 27 * 7, RightPx = 29 * 16, TopPx = 1 * 16, BottomPx = 6 * 16 };
				var sourceFile = Common.GetSourceImagePath(i);
				var image = ImageFrame.FromFile(sourceFile);
				Assert.Throws<ArgumentException>(() => image.AsCroppedImage(cropSetup));
			}

			[Theory]
			[InlineData(1)]
			public void AsCroppedInCorrectHeight(int imageIndex) {
				var i = imageIndex;
				var cropSetup = new CropSetup { LeftPx = 27 * 16, RightPx = 29 * 16, TopPx = 1 * 7, BottomPx = 6 * 16 };
				var sourceFile = Common.GetSourceImagePath(i);
				var image = ImageFrame.FromFile(sourceFile);
				Assert.Throws<ArgumentException>(() => image.AsCroppedImage(cropSetup));
			}


			[Theory]
			[InlineData(1)]
			public void AsCroppedAsGrayScaleAsPlanted(int imageIndex) {
				var i = imageIndex;
				var sourceFile = Common.GetSourceImagePath(i);
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
				var sourceFile = Common.GetSourceImagePath(i);
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
				var sourceFile = Common.GetSourceImagePath(i);
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
				var sourceFile = Common.GetSourceImagePath(i);
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

			[Fact]
			public void AsInt24BitByteArray() {
				var b1 = new byte[] { 1, 0, 0, 1 };
				Assert.True(b1.AsInt(0, 3) == 1);
			}

			[Fact]
			public void CodesCompressionRoundTrip() {

				var intArray = new int[] { 500, 7, 100 };
				var intArrayAsBytes = new byte[intArray.Length * 4];
				for (int i = 0; i < intArray.Length; i++) {
					intArray[i].AsBytes().CopyBytesTo(intArrayAsBytes, i * 4);
				}

				var compressed = intArrayAsBytes.AsCompressed(500, intArray.Length);
				var decompressed = compressed.AsDecompressed();

				Assert.True(decompressed.Compare(intArrayAsBytes));

			}


			[Theory]
			[InlineData(7)]
			[InlineData(128)]
			[InlineData(257)]
			[InlineData(int.MinValue)]
			[InlineData(int.MaxValue)]
			public void IntAs24BitRoundTrip(int val) {

				if (!(val == int.MinValue || val == int.MaxValue)) {
					var b = val.AsBytes(3);
					var test = b.AsInt(0);
					Assert.True(test == val);
				} else {
					Assert.Throws<ArgumentException>(() => val.AsBytes(3));
				}

			}

		}

		public class CLITests {

			[Theory]
			[InlineData(Program.Method.AsGrayScale, Common.SOURCE_FILE_SUFFIX, "as-gray-scale.bmp")]
			[InlineData(Program.Method.AsGrayScale, Common.SOURCE_FILE_SUFFIX, "as-gray-scale-cropped.bmp", true)]
			[InlineData(Program.Method.AsGrayScaleAsHuffmanEncoded, Common.SOURCE_FILE_SUFFIX, "as-gray-scale-as-huffman-encoded", false, Program.Method.AsGrayScaleAsHuffmanDecoded)]
			[InlineData(Program.Method.AsGrayScaleAsHuffmanEncoded, Common.SOURCE_FILE_SUFFIX, "as-gray-scale-cropped-as-huffman-encoded", true, Program.Method.AsGrayScaleAsHuffmanDecoded)]
			[InlineData(Program.Method.AsLZ78Encoded, Common.SOURCE_FILE_SUFFIX, "as-lz78-encoded", false, Program.Method.AsLZ78Decoded)]
			[InlineData(Program.Method.AsLZ78Encoded, Common.SOURCE_FILE_SUFFIX, "cropped-as-lz78-encoded", true, Program.Method.AsLZ78Decoded)]
			[InlineData(Program.Method.AsGrayScaleAsLZ78Encoded, Common.SOURCE_FILE_SUFFIX, "as-gray-scale-as-lz78-encoded", false, Program.Method.AsGrayScaleAsLZ78Decoded)]
			[InlineData(Program.Method.AsGrayScaleAsLZ78Encoded, Common.SOURCE_FILE_SUFFIX, "as-gray-scale-cropped-as-lz78-encoded", true, Program.Method.AsGrayScaleAsLZ78Decoded)]
			[InlineData(Program.Method.AsLZ78Encoded, Common.SOURCE_FILE_SUFFIX, "as-lz78-dic-trie-encoded", false, Program.Method.AsLZ78Decoded, Program.LZCompressionDictionary.Trie)]
			[InlineData(Program.Method.AsLZ78Encoded, Common.SOURCE_FILE_SUFFIX, "cropped-as-lz78-dic-trie-encoded", true, Program.Method.AsLZ78Decoded, Program.LZCompressionDictionary.Trie)]
			[InlineData(Program.Method.AsLZ78Encoded, Common.SOURCE_FILE_SUFFIX, "as-lz78-dic-trie-256-encoded", false, Program.Method.AsLZ78Decoded, Program.LZCompressionDictionary.Trie256)]
			[InlineData(Program.Method.AsLZ78Encoded, Common.SOURCE_FILE_SUFFIX, "cropped-as-lz78-dic-trie-256-encoded", true, Program.Method.AsLZ78Decoded, Program.LZCompressionDictionary.Trie256)]
			public void AllMethods(
				Program.Method method,
				string sourceFileSuffix,
				string destinationFileSuffix,
				bool crop = false,
				Program.Method? decodeMethod = null,
				Program.LZCompressionDictionary? compDic = null) {

				var sourcePath = Common.GetSourcePath();
				var destinationPath = Common.GetDestinationPath();


				_allMethods(method, sourcePath, sourceFileSuffix, destinationPath, destinationFileSuffix, crop, compDic);

				if (decodeMethod.HasValue) {
					_allMethods(decodeMethod.Value, destinationPath, destinationFileSuffix, destinationPath, destinationFileSuffix + "-decoded.bmp", false, compDic);
				}
			}

			private void _allMethods(
				Program.Method method,
				string sourcePath,
				string sourceFileSuffix,
				string destinationPath,
				string destinationFileSuffix,
				bool crop = false,
				Program.LZCompressionDictionary? compDic = null
				) {

				var args = new List<string> {
					"--source-path",
					sourcePath,
					"--source-file-suffix",
					sourceFileSuffix,
					"--destination-path",
					destinationPath,
					"--destination-file-suffix",
					destinationFileSuffix,
					"--start-index",
					"1",
					"--count",
					"1",
					"--method",
					method.ToString()
				};

				if (compDic.HasValue) {
					args.AddRange(new[] { "--lz-compression-dictionary", compDic.Value.ToString() });

					switch (compDic.Value) {
						case Program.LZCompressionDictionary.HashTable:
							args.AddRange(new[] { "--lz-compression-dictionary", "12289" });
							break;
						case Program.LZCompressionDictionary.Trie:
							args.AddRange(new[] { "--lz-compression-trie-initial-capacity", "1" });
							break;
						case Program.LZCompressionDictionary.Trie256:
							break;
						default:
							throw new ArgumentException();
					}

				}

				switch (method) {
					case Program.Method.AsGrayScale:
					case Program.Method.AsGrayScaleAsHuffmanEncoded:
					case Program.Method.AsLZ78Encoded:
					case Program.Method.AsGrayScaleAsLZ78Encoded:
						if (crop) {
							args.AddRange(new string[] {
							"--crop-left-px", _cropSetupCorrect.LeftPx.ToString(),
							"--crop-right-px", _cropSetupCorrect.RightPx.ToString(),
							"--crop-top-px", _cropSetupCorrect.TopPx.ToString(),
							"--crop-bottom-px", _cropSetupCorrect.BottomPx.ToString()
						});
						}
						break;
					case Program.Method.AsGrayScaleAsHuffmanDecoded:
					case Program.Method.AsLZ78Decoded:
					case Program.Method.AsGrayScaleAsLZ78Decoded:
						break;
					default:
						throw new ArgumentException();
				}

				var ret = Program.Main(args.ToArray());

				Assert.True(ret == 0);
			}

			public enum InCorrectArgumentTests {
				Method,
				MissingMethod,
				SourcePath,
				NonExistingFiles,
				DestinationPath,
				StartIndex,
				Count,
				CropLeftPx,
				CropRightPx,
				CropTopPx,
				CropBottomPx,
				LZCompressionHashTablePrime,
				LZCompressionTrieInitialCapacity
			}

			[Theory]
			[InlineData(InCorrectArgumentTests.Method)]
			[InlineData(InCorrectArgumentTests.MissingMethod)]
			[InlineData(InCorrectArgumentTests.SourcePath)]
			[InlineData(InCorrectArgumentTests.NonExistingFiles)]
			[InlineData(InCorrectArgumentTests.DestinationPath)]
			[InlineData(InCorrectArgumentTests.StartIndex)]
			[InlineData(InCorrectArgumentTests.Count)]
			[InlineData(InCorrectArgumentTests.CropLeftPx)]
			[InlineData(InCorrectArgumentTests.CropRightPx)]
			[InlineData(InCorrectArgumentTests.CropTopPx)]
			[InlineData(InCorrectArgumentTests.CropBottomPx)]
			[InlineData(InCorrectArgumentTests.LZCompressionHashTablePrime)]
			[InlineData(InCorrectArgumentTests.LZCompressionTrieInitialCapacity)]
			public void InCorrectArguments(InCorrectArgumentTests test) {

				var args = new List<string> {
					"--source-path",
					test != InCorrectArgumentTests.SourcePath ? Common.GetSourcePath() : "x:\non-exist",
					"--source-file-suffix",
					test != InCorrectArgumentTests.NonExistingFiles ? Common.SOURCE_FILE_SUFFIX : "non-exists",
					"--destination-path",
					test != InCorrectArgumentTests.DestinationPath ? Common.GetDestinationPath() : "x:\non-exist",
					"--destination-file-suffix",
					"dest-file-suffix",
					"--start-index",
					test != InCorrectArgumentTests.StartIndex ? "0" : "-1",
					"--count",
					test != InCorrectArgumentTests.Count ? "1" : "0",
					"--crop-left-px",
					test != InCorrectArgumentTests.CropLeftPx ? _cropSetupCorrect.LeftPx.ToString() : "-1",
					"--crop-right-px",
					test != InCorrectArgumentTests.CropRightPx ? _cropSetupCorrect.RightPx.ToString(): "-1",
					"--crop-top-px",
					test != InCorrectArgumentTests.CropTopPx ? _cropSetupCorrect.TopPx.ToString(): "-1",
					"--crop-bottom-px",
					test != InCorrectArgumentTests.CropBottomPx ? _cropSetupCorrect.BottomPx.ToString(): "-1",
					"--lz-compression-hash-table-prime",
					test != InCorrectArgumentTests.LZCompressionHashTablePrime ? "12289": "-1",
					"--lz-compression-trie-initial-capacity",
					test != InCorrectArgumentTests.LZCompressionTrieInitialCapacity ? "1": "-1"
				};

				if (test != InCorrectArgumentTests.MissingMethod) {
					args.AddRange(new[] { "--method", test != InCorrectArgumentTests.Method ? Program.Method.AsGrayScale.ToString() : "NonExistMethod" });
				}

				var ret = Program.Main(args.ToArray());

				Assert.False(ret == 0);

			}

		}
	}
}
