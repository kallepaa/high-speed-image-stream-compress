using StreamCompress.Domain.GZip;
using StreamCompress.Domain.Huffman;
using StreamCompress.Domain.Image;
using StreamCompress.Domain.LZ;
using StreamCompress.DomainExtensions.Huffman;
using StreamCompress.DomainExtensions.Image;
using StreamCompress.DomainExtensions.LZ;
using StreamCompress.DomainExtensions.GZip;
using StreamCompress.Utils;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;

namespace StreamCompress {
	/// <summary>
	/// Main program
	/// </summary>
	public class Program {

		/// <summary>
		/// Supported methods
		/// </summary>
		public enum Method {
			/// <summary>
			/// Converts image as gray scale
			/// </summary>
			AsGrayScale,
			/// <summary>
			/// Converts image as gray scale and encode it using Huffman coding
			/// </summary>
			AsGrayScaleAsHuffmanEncoded,
			/// <summary>
			/// Decodes huffman encoded gray scale image
			/// </summary>
			AsGrayScaleAsHuffmanDecoded,
			/// <summary>
			/// Encodes image using LZ78 compression
			/// </summary>
			AsLZ78Encoded,
			/// <summary>
			/// Decodes image using LZ78 compression
			/// </summary>
			AsLZ78Decoded,
			/// <summary>
			/// Converts image as gray scale and encodes image using LZ78 compression
			/// </summary>
			AsGrayScaleAsLZ78Encoded,
			/// <summary>
			/// Decodes gray scale image using LZ78 compression
			/// </summary>
			AsGrayScaleAsLZ78Decoded,
			/// <summary>
			/// Encodes image using GZip compression
			/// </summary>
			AsGZipEncoded,
			/// <summary>
			/// Decodes image using GZip compression
			/// </summary>
			AsGZipDecoded,
			/// <summary>
			/// Converts image as gray scale and encodes image using GZip compression
			/// </summary>
			AsGrayScaleAsGZipEncoded,
			/// <summary>
			/// Decodes gray scale image using GZip compression
			/// </summary>
			AsGrayScaleAsGZipDecoded

		}

		/// <summary>
		/// Gray scale image color counts
		/// </summary>
		public enum GrayScaleColors {
			/// <summary>
			/// 256 colors
			/// </summary>
			Full = 256,
			/// <summary>
			/// 128 colors
			/// </summary>
			Half = 128,
			/// <summary>
			/// 64 colors
			/// </summary>
			Quarter = 64
		}

		/// <summary>
		/// LZ compression dictionary types
		/// </summary>
		public enum LZCompressionDictionary {
			/// <summary>
			/// Hash table implementation
			/// </summary>
			HashTable,
			/// <summary>
			/// Trie dynamic size node table implementation
			/// </summary>
			Trie,
			/// <summary>
			/// Trie fixed size node table implementation
			/// </summary>
			Trie256
		}

		/// <summary>
		/// Command line arguments
		/// </summary>
		public class CommandLineArgs {
			/// <summary>
			/// Source data path
			/// </summary>
			public string SourcePath { get; set; }
			/// <summary>
			/// Sourcefiles filename suffix with extension
			/// </summary>
			public string SourceFileSuffix { get; set; }
			/// <summary>
			/// Source files start index
			/// </summary>
			public int StartIndex { get; set; }
			/// <summary>
			/// How many source files are proceed
			/// </summary>
			public int Count { get; set; }
			/// <summary>
			/// Output folder
			/// </summary>
			public string DestinationPath { get; set; }
			/// <summary>
			/// Output file suffix
			/// </summary>
			public string DestinationFileSuffix { get; set; }
			/// <summary>
			/// Compression method
			/// </summary>
			public Method? Method { get; set; }
			/// <summary>
			/// Image crop left
			/// </summary>
			public int CropLeftPx { get; set; }
			/// <summary>
			/// Image crop right
			/// </summary>
			public int CropRightPx { get; set; }
			/// <summary>
			/// Image crop top
			/// </summary>
			public int CropTopPx { get; set; }
			/// <summary>
			/// Image crop bottom
			/// </summary>
			public int CropBottomPx { get; set; }
			/// <summary>
			/// How many colors are used in gray scale image
			/// </summary>
			public GrayScaleColors? GrayScaleColors { get; set; }
			/// <summary>
			/// Dictionary implementation used in LZ78 compression
			/// </summary>
			public LZCompressionDictionary LZCompressionDictionary { get; set; }
			/// <summary>
			/// Hash table dictionary prime number 
			/// </summary>
			public int LZCompressionHashTablePrime { get; set; }
			/// <summary>
			/// Dynamic trie implementation node tables initial size 
			/// </summary>
			public int LZCompressionTrieInitialCapacity { get; set; }
		}

		/// <summary>
		/// Program start method
		/// </summary>
		/// <param name="args">Command line arguments</param>
		/// <returns>0 when OK</returns>
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
			var commandResults = new List<CommandResult>();


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

					 for (int i = cmdArgs.StartIndex; i < cmdArgs.StartIndex + cmdArgs.Count; i++) {
						 var sourceFile = _filePath(i, cmdArgs.SourcePath, cmdArgs.SourceFileSuffix);

						 if (!File.Exists(sourceFile)) {
							 throw new ArgumentException($"Source file '{sourceFile}' not exist!");
						 }
					 }

					 var method = cmdArgs.Method.Value;

					 switch (method) {
						 case Method.AsGrayScale:
							 commandResults = SourceLooper<ImageFrame, ImageFrameGrayScale>(cmdArgs, (index, a, image) => {
								 return image
								 .AsCroppedImage(a.AsCropSetup())
								 .AsGrayScale((int)a.GrayScaleColors.GetValueOrDefault(GrayScaleColors.Full));
							 });
							 break;
						 case Method.AsGrayScaleAsHuffmanEncoded:
							 commandResults = SourceLooper<ImageFrame, HuffmanImageFrame>(cmdArgs, (index, a, image) => {
								 return image
								 .AsCroppedImage(a.AsCropSetup())
								 .AsGrayScale((int)a.GrayScaleColors.GetValueOrDefault(GrayScaleColors.Full))
								 .AsHuffmanEncoded();
							 });
							 break;
						 case Method.AsGrayScaleAsHuffmanDecoded:
							 commandResults = SourceLooper<HuffmanImageFrame, ImageFrameGrayScale>(cmdArgs, (index, a, image) => {
								 return image.AsImageGrayScaleFrame();
							 });
							 break;
						 case Method.AsLZ78Encoded:
							 commandResults = SourceLooper<ImageFrame, LZImageFrame>(cmdArgs, (index, a, image) => {

								 var retData = image
								 .AsCroppedImage(a.AsCropSetup());

								 switch (a.LZCompressionDictionary) {
									 case LZCompressionDictionary.HashTable:
										 return retData.AsLZEncodedUsingHashTable(a.LZCompressionHashTablePrime);
									 case LZCompressionDictionary.Trie:
										 return retData.AsLZEncodedUsingTrie(a.LZCompressionTrieInitialCapacity);
									 case LZCompressionDictionary.Trie256:
										 return retData.AsLZEncodedUsingTrie256();
									 default:
										 throw new NotSupportedException();
								 }
							 });
							 break;
						 case Method.AsLZ78Decoded:
							 commandResults = SourceLooper<LZImageFrame, ImageFrame>(cmdArgs, (index, a, image) => {
								 switch (a.LZCompressionDictionary) {
									 case LZCompressionDictionary.HashTable:
										 return image.AsImageFrameUsingHashTable<ImageFrame>(a.LZCompressionHashTablePrime);
									 case LZCompressionDictionary.Trie:
										 return image.AsImageFrameUsingTrie<ImageFrame>(a.LZCompressionTrieInitialCapacity);
									 case LZCompressionDictionary.Trie256:
										 return image.AsImageFrameUsingTrie256<ImageFrame>();
									 default:
										 throw new NotSupportedException();
								 }
							 });
							 break;
						 case Method.AsGrayScaleAsLZ78Encoded:
							 commandResults = SourceLooper<ImageFrame, LZImageFrame>(cmdArgs, (index, a, image) => {
								 var retData = image
								 .AsCroppedImage(a.AsCropSetup())
								 .AsGrayScale((int)a.GrayScaleColors.GetValueOrDefault(GrayScaleColors.Full));

								 switch (a.LZCompressionDictionary) {
									 case LZCompressionDictionary.HashTable:
										 return retData.AsLZEncodedUsingHashTable(a.LZCompressionHashTablePrime);
									 case LZCompressionDictionary.Trie:
										 return retData.AsLZEncodedUsingTrie(a.LZCompressionTrieInitialCapacity);
									 case LZCompressionDictionary.Trie256:
										 return retData.AsLZEncodedUsingTrie256();
									 default:
										 throw new NotSupportedException();
								 }
							 });
							 break;
						 case Method.AsGrayScaleAsLZ78Decoded:
							 commandResults = SourceLooper<LZImageFrame, ImageFrameGrayScale>(cmdArgs, (index, a, image) => {
								 switch (a.LZCompressionDictionary) {
									 case LZCompressionDictionary.HashTable:
										 return image.AsImageFrameUsingHashTable<ImageFrameGrayScale>(a.LZCompressionHashTablePrime);
									 case LZCompressionDictionary.Trie:
										 return image.AsImageFrameUsingTrie<ImageFrameGrayScale>(a.LZCompressionTrieInitialCapacity);
									 case LZCompressionDictionary.Trie256:
										 return image.AsImageFrameUsingTrie256<ImageFrameGrayScale>();
									 default:
										 throw new NotSupportedException();
								 }
							 });
							 break;
						 case Method.AsGZipEncoded:
							 commandResults = SourceLooper<ImageFrame, GZipImageFrame>(cmdArgs, (index, a, image) => {
								 return image
								 .AsCroppedImage(a.AsCropSetup())
								 .AsGZipEncoded();
							 });
							 break;
						 case Method.AsGZipDecoded:
							 commandResults = SourceLooper<GZipImageFrame, ImageFrame>(cmdArgs, (index, a, image) => {
								 return image.AsImageFrame<ImageFrame>();
							 });
							 break;
						 case Method.AsGrayScaleAsGZipEncoded:
							 commandResults = SourceLooper<ImageFrame, GZipImageFrame>(cmdArgs, (index, a, image) => {
								 return image
								 .AsCroppedImage(a.AsCropSetup())
								 .AsGrayScale((int)a.GrayScaleColors.GetValueOrDefault(GrayScaleColors.Full))
								 .AsGZipEncoded();
							 });
							 break;
						 case Method.AsGrayScaleAsGZipDecoded:
							 commandResults = SourceLooper<GZipImageFrame, ImageFrameGrayScale>(cmdArgs, (index, a, image) => {
								 return image.AsImageFrame<ImageFrameGrayScale>();
							 });
							 break;

					 }
				 });


			var commandRet = command.Invoke(args);

			if (commandRet == 0) {
				commandResults.ForEach(cr => {
					Console.WriteLine($"{cr.SourceBytesLenght};{cr.DestinationBytesLenght};{Math.Round(cr.CalculatePercent().GetValueOrDefault(), 2)} %");
				});
			}

			return commandRet;
		}

		/// <summary>
		/// Builds full path to file
		/// </summary>
		/// <param name="i">File index</param>
		/// <param name="path">File path</param>
		/// <param name="suffix">File suffix</param>
		/// <returns>Full path</returns>
		private static string _filePath(int i, string path, string suffix) {
			return FileExtensions.PathCombine(path, $"{i.ToString("00000")}-{suffix}");
		}

		/// <summary>
		/// Iterates over source folder and reads file using index. 
		/// Executes given function and then saves return value to file.
		/// </summary>
		/// <typeparam name="T">Type of domain object</typeparam>
		/// <typeparam name="R">Type of domain object</typeparam>
		/// <param name="cmdArgs">Command line arguments</param>
		/// <param name="func">Executing function</param>
		private static List<CommandResult> SourceLooper<T, R>(
			CommandLineArgs cmdArgs,
			Func<int, CommandLineArgs, T, ISaveable<R>> func) where T : ISaveable<T>, new() {

			var commandRet = new List<CommandResult>();

			for (int i = cmdArgs.StartIndex; i < cmdArgs.Count + cmdArgs.StartIndex; i++) {
				var sourceFile = _filePath(i, cmdArgs.SourcePath, cmdArgs.SourceFileSuffix);
				var image = new T();
				//open file and creates domain object
				((ISaveable<T>)image).Open(sourceFile);
				//executes given function
				var ret = func(i, cmdArgs, image);
				var destFile = _filePath(i, cmdArgs.DestinationPath, cmdArgs.DestinationFileSuffix);
				//saves file
				ret.Save(destFile);

				switch (cmdArgs.Method.Value) {
					case Method.AsGrayScale:
					case Method.AsLZ78Encoded:
					case Method.AsGrayScaleAsLZ78Encoded:
					case Method.AsGrayScaleAsHuffmanEncoded:
					case Method.AsGZipEncoded:
					case Method.AsGrayScaleAsGZipEncoded:
						var sfInfo = new FileInfo(sourceFile);
						var dfInfo = new FileInfo(destFile);
						var commandResult = new CommandResult {
							SourceFileName = sfInfo.Name,
							SourceBytesLenght = sfInfo.Length,
							DestinationFileName = dfInfo.Name,
							DestinationBytesLenght = dfInfo.Length
						};
						commandRet.Add(commandResult);
						break;
					case Method.AsGrayScaleAsHuffmanDecoded:
					case Method.AsLZ78Decoded:
					case Method.AsGrayScaleAsLZ78Decoded:
					case Method.AsGZipDecoded:
					case Method.AsGrayScaleAsGZipDecoded:
					default:
						break;
				}
			}

			return commandRet;
		}

		private class CommandResult {
			public string SourceFileName { get; set; }
			public string DestinationFileName { get; set; }
			public long SourceBytesLenght { get; set; }
			public long DestinationBytesLenght { get; set; }
			public long BytesLenghtDiff => Math.Abs(SourceBytesLenght - DestinationBytesLenght);
			public decimal? CalculatePercent() {
				var min = Math.Min(SourceBytesLenght, DestinationBytesLenght);
				var max = Math.Max(SourceBytesLenght, DestinationBytesLenght);
				if (max > 0) {
					return Math.Round(((1.00m - min / (decimal)max) * 100.00m), 2);
				}
				return null;
			}

		}

	}
}
