using System.IO;

namespace StreamCompress {
	public static class FileExtensions {
		public static void SaveToFile(this byte[] bytes, string filename) {
			File.WriteAllBytes(filename, bytes);
		}
		public static byte[] ReadAllBytes(string filename) {
			return File.ReadAllBytes(filename);
		}
	}
}
