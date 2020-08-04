﻿using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.CommandLine.IO;
using System.Diagnostics;
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

		public class CommandLineArgs {
			public string SourcePath { get; set; }
			public string SourceFileSuffix { get; set; }
			public int StartIndex { get; set; }
			public int Count { get; set; }
			public string DestinationPath { get; set; }
			public string DestinationFileSuffix { get; set; }
			public Method? Method { get; set; }
			public int? CropLeftPx { get; set; }
			public int? CropRightPx { get; set; }
			public int? CropTopPx { get; set; }
			public int? CropBottomPx { get; set; }
			public GrayScaleColors? GrayScaleColors { get; set; }
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
					description:"Image crop px bottom")};

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

					 if (cmdArgs.CropLeftPx.Value < 0) {
						 throw new ArgumentException($"Invalid argument {nameof(cmdArgs.CropLeftPx)} '{cmdArgs.CropLeftPx}'!");
					 }

					 if (cmdArgs.CropRightPx.Value < 0) {
						 throw new ArgumentException($"Invalid argument {nameof(cmdArgs.CropRightPx)} '{cmdArgs.CropRightPx}'!");
					 }

					 if (cmdArgs.CropTopPx.Value < 0) {
						 throw new ArgumentException($"Invalid argument {nameof(cmdArgs.CropTopPx)} '{cmdArgs.CropTopPx}'!");
					 }
					 if (cmdArgs.CropBottomPx.Value < 0) {
						 throw new ArgumentException($"Invalid argument {nameof(cmdArgs.CropBottomPx)} '{cmdArgs.CropBottomPx}'!");
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
								 .AsCroppedImage(new CropSetup { LeftPx = a.CropLeftPx.Value, RightPx = a.CropRightPx.Value, TopPx = a.CropTopPx.Value, BottomPx = a.CropBottomPx.Value })
								 .AsGrayScale((int)a.GrayScaleColors.GetValueOrDefault(GrayScaleColors.Full));
							 });
							 break;
						 case Method.AsGrayScaleAsHuffmanEncoded:
							 SourceLooper<ImageFrame, HuffmanImageFrame>(cmdArgs, (index, a, image) => {
								 return image
								 .AsCroppedImage(new CropSetup { LeftPx = a.CropLeftPx.Value, RightPx = a.CropRightPx.Value, TopPx = a.CropTopPx.Value, BottomPx = a.CropBottomPx.Value })
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
								 return image.AsLZEncodedUsingHashTable(12289);
							 });
							 break;
						 case Method.AsLZ78Decoded:
							 SourceLooper<LZImageFrame, ImageFrame>(cmdArgs, (index, a, image) => {
								 return image.AsImageFrameUsingHashTable<ImageFrame>(12289);
							 });
							 break;
						 case Method.AsGrayScaleAsLZ78Encoded:
							 SourceLooper<ImageFrame, LZImageFrame>(cmdArgs, (index, a, image) => {
								 return image
								 .AsCroppedImage(new CropSetup { LeftPx = a.CropLeftPx.Value, RightPx = a.CropRightPx.Value, TopPx = a.CropTopPx.Value, BottomPx = a.CropBottomPx.Value })
								 .AsGrayScale((int)a.GrayScaleColors.GetValueOrDefault(GrayScaleColors.Full))
								 .AsLZEncodedUsingHashTable(12289);
							 });
							 break;
						 case Method.AsGrayScaleAsLZ78Decoded:
							 SourceLooper<LZImageFrame, ImageFrameGrayScale>(cmdArgs, (index, a, image) => {
								 return image.AsImageFrameUsingHashTable<ImageFrameGrayScale>(12289);
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

			for (int i = cmdArgs.StartIndex; i < cmdArgs.Count; i++) {
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
