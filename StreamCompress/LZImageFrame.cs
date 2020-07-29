using System;
using System.Collections.Generic;
using System.Text;

namespace StreamCompress {
	public class LZImageFrame {

		public byte[] Codes { get;}

		public LZImageFrame(byte[] codes) {
			Codes = codes;
		}
	}
}
