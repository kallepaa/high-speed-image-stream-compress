namespace StreamCompress.Domain.LZ {

	public class Tries256<T> : ILZ78CodingTable<T> {

		public TriesContainer256<T> Root { get; }
		public int Count { get; internal set; }

		public Tries256() {
			Root = new TriesContainer256<T>();
		}

		public void Insert(byte[] searchKey, T codeWord) {
			_insert(searchKey, codeWord);
		}

		public ILZ78CodingTableItem<T> Search(byte[] searchKey) {
			var match = _search(searchKey);
			return match == null ? null : new ILZ78CodingTableItem<T>(match.ChildContainer.CodeWord);
		}

		public void _insert(byte[] searchKey, T codeWord) {

			var container = Root;
			var n = default(TriesNode256<T>);

			for (int i = 0; i < searchKey.Length; i++) {
				var b = searchKey[i];
				n = container.Get(b);
				if (n == null) {
					n = container.Add(b);
				}
				container = n.ChildContainer;
			}

			if (n != null && !n.ChildContainer.IsSet) {
				n.ChildContainer.SetCodeWord(codeWord);
				Count++;
			}
		}

		public TriesNode256<T> _search(byte[] searchKey) {

			var container = Root;
			var n = default(TriesNode256<T>);

			for (int i = 0; i < searchKey.Length; i++) {
				var b = searchKey[i];
				n = container.Get(b);
				if (n == null) {
					return null;
				}
				container = n.ChildContainer;
			}

			if (n != null && container.IsSet) {
				return n;
			}

			return null;
		}


		public class TriesContainer256<TT> {

			public TriesNode256<TT>[] Nodes { get; } = new TriesNode256<TT>[256];
			public bool IsSet { get; internal set; }
			public TT CodeWord { get; internal set; }

			public void SetCodeWord(TT codeWord) {
				CodeWord = codeWord;
				IsSet = true;
			}

			public TriesNode256<TT> Add(byte b) {
				var ret = new TriesNode256<TT>(b);
				Nodes[b] = ret;
				return ret;
			}

			public TriesNode256<TT> Get(byte b) {
				return Nodes[b];
			}
		}

		public class TriesNode256<TTT> {

			public byte Byte { get; }
			public TriesContainer256<TTT> ChildContainer { get; }
			public TriesNode256(byte b) {
				Byte = b;
				ChildContainer = new TriesContainer256<TTT>();
			}

		}
	}
}
