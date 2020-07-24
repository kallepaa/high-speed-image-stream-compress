using System;
using System.Collections.Generic;
using System.Text;

namespace StreamCompress {
	public class PFrame {

		public const int BLOCK_PIXELS = 256;
		public const int BLOCK_PIXEL_DIFF = 10;

		public List<int> ChangedBlockIndexes { get; }
		public byte[] Blocks { get; }

		

		private PFrame(List<int> changedBlockIndexes, byte[] blocks) {
			ChangedBlockIndexes = changedBlockIndexes;
			Blocks = blocks;
		}

		public static PFrame Create(MacroBlock IFrameblocks, MacroBlock PFrameBlocks) {

			var blockCount = IFrameblocks.Blocks.Length / BLOCK_PIXELS;
			var indexes = new List<int>();

			for (int b = 0; b < blockCount; b++) {

				var blockOffSet = b * BLOCK_PIXELS;

				for (int i = 0; i < BLOCK_PIXELS; i++) {
					var iFrameByteVal = (int)IFrameblocks.Blocks[i + blockOffSet];
					var pFrameByteVal = (int)PFrameBlocks.Blocks[i + blockOffSet];
					var diff = Math.Abs(iFrameByteVal - pFrameByteVal);

					if (diff >= BLOCK_PIXEL_DIFF) {
						indexes.Add(i);
						break;
					}
				}
			}

			var changedBlocks = new byte[indexes.Count * BLOCK_PIXELS];
			var changedBlockPos = 0;

			for (int i = 0; i < indexes.Count; i++) {
				var pos = BLOCK_PIXELS * indexes[i];
				Buffer.BlockCopy(PFrameBlocks.Blocks, pos, changedBlocks, changedBlockPos, BLOCK_PIXELS);
				changedBlockPos += BLOCK_PIXELS;
			}

			return new PFrame(indexes, changedBlocks);
		}
	}
}
