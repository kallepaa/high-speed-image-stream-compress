using System;
using System.IO;

namespace StreamCompress.Shared {
	public static class Common {

		public const string SOURCE_FILE_SUFFIX = "original.bmp";

		public static string GetSourcePath() {
			var sourcePath = Path.Combine(Environment.CurrentDirectory, @"..\..\..\TestData\Source");
			var dirInfo = new DirectoryInfo(sourcePath);
			return dirInfo.FullName;
		}
		public static string GetDestinationPath() {
			var sourcePath = Path.Combine(Environment.CurrentDirectory, @"..\..\..\TestData\Destination");
			var dirInfo = new DirectoryInfo(sourcePath);
			return dirInfo.FullName;
		}

		public static string GetSourceImagePath(int i) {
			return Path.Combine(GetSourcePath(), $"{i.ToString("00000")}-{SOURCE_FILE_SUFFIX}");
		}

		public static string GetSaveImagePath(int i, string suffix) {
			return Path.Combine(GetDestinationPath(), $"{i.ToString("00000")}-{suffix}");
		}


	}
}
