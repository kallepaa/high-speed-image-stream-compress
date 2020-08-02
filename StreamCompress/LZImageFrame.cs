
namespace StreamCompress {
	public class LZImageFrame : ISaveable<LZImageFrame> {

		public byte[] Codes { get;}
		public LZImageFrame (byte[] codes) {
			Codes = codes;
		}

		public LZImageFrame Save(string path) {
			Codes.SaveToFile(path);
			return this;
		}
	}
}
