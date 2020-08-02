using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;

namespace StreamCompress {
	public class Program {

		public enum Method {
			AsGrayScale,
			AsGrayScaleCropped
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
			public Method? Method { get; set; }
			public int CropLeftPx { get; set; }
			public int CropRightPx { get; set; }
			public int CropTopPx { get; set; }
			public int CropBottomPx { get; set; }
			public GrayScaleColors? GrayScaleColors { get; set; }
		}


		public static int Main(string[] args) {


			var command = new RootCommand(){
				new Option<string>(
					"--source-path",
					description: "Stream images source folder"),
				new Option<string>(
					"--source-file-suffix",
					description: "Stream images filename suffix"),
				new Option<string>(
					"--destination-path",
					description: "Stream images destination folder"),
				new Option<int>(
					"--start-index",
					getDefaultValue: () => 0,
					description: "Image stream first image index"),
				new Option<int>(
					"--count",
					getDefaultValue: () => 1,
					description: "Count of images to handle"),
				new Option<Method>(
					"--method",
					getDefaultValue: () => Method.AsGrayScale,
					description: "Image handling method"),
				new Option<GrayScaleColors>(
					"--gray-scale-colors",
					getDefaultValue: () => GrayScaleColors.Full,
					description: "Gray scale image color count"),
				new Option<int>(
					"--crop-left-px",
					"Image crop px left"),
				new Option<int>(
					"--crop-right-px",
					"Image crop px right"),
				new Option<int>(
					"--crop-top-px",
					"Image crop px top"),
				new Option<int>(
					"--crop-bottom-px",
					"Image crop px bottom")};

			command.Description = "Stream Compress App";

			command.Handler = CommandHandler.Create(
				 (CommandLineArgs cmdArgs) => {

					 if (!cmdArgs.Method.HasValue) {
						 throw new ArgumentException($"Invalid argument {nameof(cmdArgs.Method)} '{cmdArgs.Method}'!");
					 }

					 if (!Directory.Exists(cmdArgs.SourcePath)) {
						 throw new ArgumentException($"Invalid argument {nameof(cmdArgs.SourcePath)} '{cmdArgs.SourcePath}'!");
					 }

					 if (!string.IsNullOrEmpty(cmdArgs.DestinationPath) && !Directory.Exists(cmdArgs.DestinationPath)) {
						 throw new ArgumentException($"Invalid argument {nameof(cmdArgs.DestinationPath)} '{cmdArgs.DestinationPath}'!");
					 }

					 if (cmdArgs.StartIndex < 0) {
						 throw new ArgumentException($"Invalid argument {nameof(cmdArgs.StartIndex)} '{cmdArgs.StartIndex}'!");
					 }

					 if (cmdArgs.Count < 1) {
						 throw new ArgumentException($"Invalid argument {nameof(cmdArgs.Count)} '{cmdArgs.Count}'!");
					 }

					 for (int i = cmdArgs.StartIndex; i < cmdArgs.Count; i++) {
						 var sourceFile = _sourceFile(i, cmdArgs.SourcePath, cmdArgs.SourceFileSuffix);

						 if (!File.Exists(sourceFile)) {
							 throw new ArgumentException($"Source file '{sourceFile}' not exist!");
						 }
					 }

					 var method = cmdArgs.Method.Value;

					 switch (method) {
						 case Method.AsGrayScale:
							 SourceLooper<ImageFrameGrayScale>(cmdArgs, (index, a, image) => {
								 return image.AsGrayScale((int)a.GrayScaleColors.GetValueOrDefault(GrayScaleColors.Full));
							 });
							 break;
						 case Method.AsGrayScaleCropped:
							 SourceLooper<ImageFrameGrayScale>(cmdArgs, (index, a, image) => {
								 return image
								 .AsCroppedImage(new CropSetup{ LeftPx = a.CropLeftPx, RightPx = a.CropRightPx, TopPx = a.CropTopPx, BottomPx = a.CropBottomPx})
								 .AsGrayScale((int)a.GrayScaleColors.GetValueOrDefault(GrayScaleColors.Full));
							 });
							 break;
						 default:
							 throw new NotSupportedException("Method not supported!");
					 }
				 });

			return command.InvokeAsync(args).Result;
		}


		private static string _sourceFile(int i, string path, string suffix) {
			return FileExtensions.PathCombine(path, $"{i.ToString("00000")}-{suffix}");
		}

		private static void SourceLooper<T>(
			CommandLineArgs cmdArgs,
			Func<int, CommandLineArgs, ImageFrame, ISaveable<T>> func) {

			for (int i = cmdArgs.StartIndex; i < cmdArgs.Count; i++) {
				var sourceFile = _sourceFile(i, cmdArgs.SourcePath, cmdArgs.SourceFileSuffix);
				var image = ImageFrame.FromFile(sourceFile);
				var ret = func(i, cmdArgs, image);
				var destFile = FileExtensions.PathCombine(cmdArgs.DestinationPath, $"{i.ToString("00000")}-{cmdArgs.Method.ToString().ToLower()}");
				ret.Save(destFile);
			}
		}

	}
}
