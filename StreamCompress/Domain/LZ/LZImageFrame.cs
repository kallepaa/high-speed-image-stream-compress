
using StreamCompress.Utils;

namespace StreamCompress.Domain.LZ {

	/// <summary>
	/// Presents single image frame in LZ compressed form
	/// </summary>
	public class LZImageFrame : ISaveable<LZImageFrame> {

		/// <summary>
		/// Byte array which contains compressed image
		/// </summary>
		public byte[] Codes { get; internal set; }

		/// <summary>
		/// Parametless constructor
		/// </summary>
		public LZImageFrame() {

		}

		/// <summary>
		/// Constructor to create frame from byte array
		/// </summary>
		/// <param name="codes"></param>
		public LZImageFrame (byte[] codes) {
			Codes = codes;
		}

		private void _fromBytes(byte[] codes) {
			Codes = codes;
		}

		/// <summary>
		/// Saves compressed image frame to file
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public LZImageFrame Save(string path) {
			Codes.SaveToFile(path);
			return this;
		}

		/// <summary>
		/// Reads comressed image frame from file
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public LZImageFrame Open(string path) {
			_fromBytes(FileExtensions.ReadAllBytes(path));
			return this;
		}
	}
}
