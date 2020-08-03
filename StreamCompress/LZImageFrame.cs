
namespace StreamCompress {
	public class LZImageFrame : ISaveable<LZImageFrame> {

		public byte[] Codes { get; internal set; }

		public LZImageFrame() {

		}

		public LZImageFrame (byte[] codes) {
			Codes = codes;
		}

		private void _fromBytes(byte[] codes) {
			Codes = codes;
		}

		public LZImageFrame Save(string path) {
			Codes.SaveToFile(path);
			return this;
		}

		public LZImageFrame Open(string path) {
			_fromBytes(FileExtensions.ReadAllBytes(path));
			return this;
		}
	}
}
