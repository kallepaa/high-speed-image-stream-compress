using System.IO;

namespace StreamCompress {

	/// <summary>
	/// Operations for file manipulations
	/// </summary>
	public static class FileExtensions {

		/// <summary>
		/// Save byte array to file
		/// </summary>
		/// <param name="bytes">Byte array</param>
		/// <param name="filename">Filename</param>
		public static void SaveToFile(this byte[] bytes, string filename) {
			File.WriteAllBytes(filename, bytes);
		}

		/// <summary>
		/// Reads all bytes from file
		/// </summary>
		/// <param name="filename">Filename</param>
		/// <returns>Byte array of file content</returns>
		public static byte[] ReadAllBytes(string filename) {
			return File.ReadAllBytes(filename);
		}

		/// <summary>
		/// Combines single path from given parameter values
		/// </summary>
		/// <param name="paths">Paths</param>
		/// <returns>Valid path</returns>
		public static string PathCombine(params string[] paths) {
			return Path.Combine(paths);
		}
	}
}
