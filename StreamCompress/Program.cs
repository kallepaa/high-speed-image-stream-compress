using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;

namespace StreamCompress {
	public class Program {

		public enum Method {
			AsGrayScale,
			AsGrayScaleAsHuffmanEncoded,
			AsGrayScaleAsHuffmanDecoded,
			AsLZ78Encoded,
			AsLZ78Decoded,
			AsGrayScaleAsLZ78Encoded,
			AsGrayScaleAsLZ78Decoded
		}

		public enum GrayScaleColors {
			Full = 256,
			Half = 128,
			Quarter = 64
		}

		public enum LZCompressionDictionary {
			HashTable,
			Trie
		}

		public class CommandLineArgs {
			public string SourcePath { get; set; }
			public string SourceFileSuffix { get; set; }
			public int StartIndex { get; set; }
			public int Count { get; set; }
			public string DestinationPath { get; set; }
			public string DestinationFileSuffix { get; set; }
			public Method? Method { get; set; }
			public int CropLeftPx { get; set; }
			public int CropRightPx { get; set; }
			public int CropTopPx { get; set; }
			public int CropBottomPx { get; set; }
			public GrayScaleColors? GrayScaleColors { get; set; }
			public LZCompressionDictionary LZCompressionDictionary { get; set; }
			public int LZCompressionHashTablePrime { get; set; }
			public int LZCompressionTrieInitialCapacity { get; set; }
		}


		public static int Main(string[] args) {

			var command = new RootCommand(){
				new Option<string>(
					"--source-path",
					description: "Stream images source folder"),
				new Option<string>(
					"--source-file-suffix",
					description: "Source filename suffix"),
				new Option<string>(
					"--destination-path",
					description: "Destination folder"),
				new Option<string>(
					"--destination-file-suffix",
					description: "Destination filename suffix"),
				new Option<int?>(
					"--start-index",
					getDefaultValue: () => 0,
					description: "Image stream first image index"),
				new Option<int?>(
					"--count",
					getDefaultValue: () => 1,
					description: "Count of images to handle"),
				new Option<Method?>(
					"--method",
					description: "Image handling method"),
				new Option<GrayScaleColors?>(
					"--gray-scale-colors",
					getDefaultValue: () => GrayScaleColors.Full,
					description: "Gray scale image color count"),
				new Option<int?>(
					"--crop-left-px",
					getDefaultValue: () => 0,
					description:"Image crop px left"),
				new Option<int?>(
					"--crop-right-px",
					getDefaultValue: () => 0,
					description:"Image crop px right"),
				new Option<int?>(
					"--crop-top-px",
					getDefaultValue: () => 0,
					description:"Image crop px top"),
				new Option<int?>(
					"--crop-bottom-px",
					getDefaultValue: () => 0,
					description:"Image crop px bottom"),
				new Option<LZCompressionDictionary?>(
					"--lz-compression-dictionary",
					getDefaultValue: () => LZCompressionDictionary.HashTable,
					description: "LZ compression dictionary type"),
				new Option<int?>(
					"--lz-compression-hash-table-prime",
					getDefaultValue: () => 12289,
					description: "LZ compression hash table prime"),
				new Option<int?>(
					"--lz-compression-trie-initial-capacity",
					getDefaultValue: () => 1,
					description: "LZ compression trie node container initial capacity")};

			command.Description = "Stream Compress App";



			command.Handler = CommandHandler.Create(
				 (CommandLineArgs cmdArgs) => {

					 if (!cmdArgs.Method.HasValue) {
						 throw new ArgumentException($"Invalid argument {nameof(cmdArgs.Method)} '{cmdArgs.Method}'!");
					 }

					 if (!Directory.Exists(cmdArgs.SourcePath)) {
						 throw new ArgumentException($"Invalid argument {nameof(cmdArgs.SourcePath)} '{cmdArgs.SourcePath}'!");
					 }

					 if (!Directory.Exists(cmdArgs.DestinationPath)) {
						 throw new ArgumentException($"Invalid argument {nameof(cmdArgs.DestinationPath)} '{cmdArgs.DestinationPath}'!");
					 }

					 if (cmdArgs.StartIndex < 0) {
						 throw new ArgumentException($"Invalid argument {nameof(cmdArgs.StartIndex)} '{cmdArgs.StartIndex}'!");
					 }

					 if (cmdArgs.Count < 1) {
						 throw new ArgumentException($"Invalid argument {nameof(cmdArgs.Count)} '{cmdArgs.Count}'!");
					 }

					 if (cmdArgs.CropLeftPx < 0) {
						 throw new ArgumentException($"Invalid argument {nameof(cmdArgs.CropLeftPx)} '{cmdArgs.CropLeftPx}'!");
					 }

					 if (cmdArgs.CropRightPx < 0) {
						 throw new ArgumentException($"Invalid argument {nameof(cmdArgs.CropRightPx)} '{cmdArgs.CropRightPx}'!");
					 }

					 if (cmdArgs.CropTopPx < 0) {
						 throw new ArgumentException($"Invalid argument {nameof(cmdArgs.CropTopPx)} '{cmdArgs.CropTopPx}'!");
					 }

					 if (cmdArgs.CropBottomPx < 0) {
						 throw new ArgumentException($"Invalid argument {nameof(cmdArgs.CropBottomPx)} '{cmdArgs.CropBottomPx}'!");
					 }

					 if (cmdArgs.LZCompressionHashTablePrime < 1) {
						 throw new ArgumentException($"Invalid argument {nameof(cmdArgs.LZCompressionHashTablePrime)} '{cmdArgs.LZCompressionHashTablePrime}'!");
					 }

					 if (cmdArgs.LZCompressionTrieInitialCapacity < 1) {
						 throw new ArgumentException($"Invalid argument {nameof(cmdArgs.LZCompressionTrieInitialCapacity)} '{cmdArgs.LZCompressionTrieInitialCapacity}'!");
					 }

					 for (int i = cmdArgs.StartIndex; i < cmdArgs.Count; i++) {
						 var sourceFile = _filePath(i, cmdArgs.SourcePath, cmdArgs.SourceFileSuffix);

						 if (!File.Exists(sourceFile)) {
							 throw new ArgumentException($"Source file '{sourceFile}' not exist!");
						 }
					 }

					 var method = cmdArgs.Method.Value;

					 switch (method) {
						 case Method.AsGrayScale:
							 SourceLooper<ImageFrame, ImageFrameGrayScale>(cmdArgs, (index, a, image) => {
								 return image
								 .AsCroppedImage(a.AsCropSetup())
								 .AsGrayScale((int)a.GrayScaleColors.GetValueOrDefault(GrayScaleColors.Full));
							 });
							 break;
						 case Method.AsGrayScaleAsHuffmanEncoded:
							 SourceLooper<ImageFrame, HuffmanImageFrame>(cmdArgs, (index, a, image) => {
								 return image
								 .AsCroppedImage(a.AsCropSetup())
								 .AsGrayScale((int)a.GrayScaleColors.GetValueOrDefault(GrayScaleColors.Full))
								 .AsHuffmanEncoded();
							 });
							 break;
						 case Method.AsGrayScaleAsHuffmanDecoded:
							 SourceLooper<HuffmanImageFrame, ImageFrameGrayScale>(cmdArgs, (index, a, image) => {
								 return image.AsImageGrayScaleFrame();
							 });
							 break;
						 case Method.AsLZ78Encoded:
							 SourceLooper<ImageFrame, LZImageFrame>(cmdArgs, (index, a, image) => {
								 switch (a.LZCompressionDictionary) {
									 case LZCompressionDictionary.HashTable:
										 return image.AsLZEncodedUsingHashTable(a.LZCompressionHashTablePrime);
									 case LZCompressionDictionary.Trie:
										 return image.AsLZEncodedUsingTrie(a.LZCompressionTrieInitialCapacity);
									 default:
										 throw new NotSupportedException();
								 }
							 });
							 break;
						 case Method.AsLZ78Decoded:
							 SourceLooper<LZImageFrame, ImageFrame>(cmdArgs, (index, a, image) => {
								 switch (a.LZCompressionDictionary) {
									 case LZCompressionDictionary.HashTable:
										 return image.AsImageFrameUsingHashTable<ImageFrame>(a.LZCompressionHashTablePrime);
									 case LZCompressionDictionary.Trie:
										 return image.AsImageFrameUsingTrie<ImageFrame>(a.LZCompressionTrieInitialCapacity);
									 default:
										 throw new NotSupportedException();
								 }
							 });
							 break;
						 case Method.AsGrayScaleAsLZ78Encoded:
							 SourceLooper<ImageFrame, LZImageFrame>(cmdArgs, (index, a, image) => {
								 var retData = image
								 .AsCroppedImage(a.AsCropSetup())
								 .AsGrayScale((int)a.GrayScaleColors.GetValueOrDefault(GrayScaleColors.Full));

								 switch (a.LZCompressionDictionary) {
									 case LZCompressionDictionary.HashTable:
										 return retData.AsLZEncodedUsingHashTable(a.LZCompressionHashTablePrime);
									 case LZCompressionDictionary.Trie:
										 return retData.AsLZEncodedUsingTrie(a.LZCompressionTrieInitialCapacity);
									 default:
										 throw new NotSupportedException();
								 }
							 });
							 break;
						 case Method.AsGrayScaleAsLZ78Decoded:
							 SourceLooper<LZImageFrame, ImageFrameGrayScale>(cmdArgs, (index, a, image) => {
								 switch (a.LZCompressionDictionary) {
									 case LZCompressionDictionary.HashTable:
										 return image.AsImageFrameUsingHashTable<ImageFrameGrayScale>(a.LZCompressionHashTablePrime);
									 case LZCompressionDictionary.Trie:
										 return image.AsImageFrameUsingTrie<ImageFrameGrayScale>(a.LZCompressionTrieInitialCapacity);
									 default:
										 throw new NotSupportedException();
								 }
							 });
							 break;
					 }
				 });

			return command.InvokeAsync(args).Result;
		}

		private static string _filePath(int i, string path, string suffix) {
			return FileExtensions.PathCombine(path, $"{i.ToString("00000")}-{suffix}");
		}

		private static void SourceLooper<T, R>(
			CommandLineArgs cmdArgs,
			Func<int, CommandLineArgs, T, ISaveable<R>> func) where T : ISaveable<T>, new() {

			for (int i = cmdArgs.StartIndex; i < cmdArgs.Count + cmdArgs.StartIndex; i++) {
				var sourceFile = _filePath(i, cmdArgs.SourcePath, cmdArgs.SourceFileSuffix);
				var image = new T();
				((ISaveable<T>)image).Open(sourceFile);
				var ret = func(i, cmdArgs, image);
				var destFile = _filePath(i, cmdArgs.DestinationPath, cmdArgs.DestinationFileSuffix);
				ret.Save(destFile);
			}
		}

	}
}
