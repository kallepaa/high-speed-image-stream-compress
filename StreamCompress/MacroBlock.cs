using System;
using System.Collections.Generic;
using System.Text;

namespace StreamCompress {
	public class MacroBlock {

		public byte[] Blocks { get;}

		public MacroBlock(byte[] blocks) {
			Blocks = blocks;
		}
	}
}
