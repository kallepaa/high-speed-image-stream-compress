using System;
using System.IO;

namespace StreamCompress.Shared {
	public static class Common {

		public const string SOURCE_FILE_SUFFIX = "original.bmp";

		private static string _getTestDataPath() {

			var dirInfo = new DirectoryInfo(Environment.CurrentDirectory);
			var exists = false;
			while (dirInfo != null) {
				if (Directory.Exists(Path.Combine(dirInfo.FullName, "TestData"))) {
					exists = true;
					break;
				}
				dirInfo = dirInfo.Parent;
			}
			if (exists) {
				return Path.Combine(dirInfo.FullName, "TestData");
			}

			throw new DirectoryNotFoundException("TestData directory could not be solved!");
		}

		public static string GetSourcePath() {
			var basePath = _getTestDataPath();
			var sourcePath = Path.Combine(basePath, "Source");
			var dirInfo = new DirectoryInfo(sourcePath);
			return dirInfo.FullName;
		}
		public static string GetDestinationPath() {
			var basePath = _getTestDataPath();
			var sourcePath = Path.Combine(basePath, "Destination");
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
