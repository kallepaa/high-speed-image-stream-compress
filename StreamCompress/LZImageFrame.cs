using System;
using System.Collections.Generic;
using System.Text;

namespace StreamCompress {
	public class LZImageFrame {

		public byte[] Codes { get;}

		public long MaxHashTableSearchMs { get; set; }
		public long MinHashTableSearchMs { get; set; }
		public long TotalHashTableSearchMs { get; set; }

		public long MaxHashTableInsertMs { get; set; }
		public long MinHashTableInsertMs { get; set; }
		public long TotalHashTableInsertMs { get; set; }


		public long TotalHashTableSearchCount { get; set; }
		public long TotalHashTableSearchCompareCount { get; set; }

		public long HashTableCount { get; set; }
		public long HashTableCollisionCount { get; set; }
		public long HashTableLongestSearchKey { get; set; }
		public int[] HashTableSearchKeyLengthDistr { get; set; }
		public int[] HashTableSearchKeyLengthSearchCount { get; set; }

		public long CompressionRation { get; set; }


		public LZImageFrame (byte[] codes) {
			Codes = codes;
		}
	}
}
