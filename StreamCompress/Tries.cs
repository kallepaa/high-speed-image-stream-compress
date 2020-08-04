namespace StreamCompress {
	public class Tries<T> : ILZ78CodingTable<T> {

		public TriesContainer<T> Root { get; }
		public int Count { get; internal set; }

		private readonly int _initialCapacity;

		public Tries(int containerCapacity) {
			Root = new TriesContainer<T>(containerCapacity);
			_initialCapacity = containerCapacity;
		}

		public void Insert(byte[] searchKey, T codeWord) {
			_insert(searchKey, codeWord);
		}

		public ILZ78CodingTableItem<T> Search(byte[] searchKey) {
			var match = _search(searchKey);
			return match == null ? null : new ILZ78CodingTableItem<T>(searchKey, match.ChildContainer.CodeWord);
		}

		public void _insert(byte[] searchKey, T codeWord) {

			var container = Root;
			var n = default(TriesNode<T>);

			for (int i = 0; i < searchKey.Length; i++) {
				var b = searchKey[i];
				n = container.Get(b);
				if (n == null) {
					n = container.Add(b);
				}
				container = n.ChildContainer;
			}

			if (n != null && !n.ChildContainer.IsSet) {
				n.ChildContainer.CodeWord = codeWord;
				n.ChildContainer.IsSet = true;
				Count++;
			}
		}

		public TriesNode<T> _search(byte[] searchKey) {

			var container = Root;
			var n = default(TriesNode<T>);

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


		public class TriesContainer<TT> {

			public TriesNode<TT>[] Nodes { get; internal set; }
			public int NodesCount { get; internal set; }
			public bool IsSet { get; internal set; }
			public TT CodeWord { get; internal set; }

			private readonly int _initialCapacity;

			public TriesContainer(int capacity) {
				Nodes = new TriesNode<TT>[capacity];
				_initialCapacity = capacity;
			}

			public TriesNode<TT> Add(byte b) {

				while (NodesCount >= Nodes.Length) {
					var newNodes = new TriesNode<TT>[Nodes.Length + _initialCapacity];
					for (int i = 0; i < Nodes.Length; i++) {
						newNodes[i] = Nodes[i];
					}
					Nodes = newNodes;
				}

				var ret = new TriesNode<TT>(b, _initialCapacity);
				Nodes[NodesCount++] = ret;
				return ret;
			}

			public TriesNode<TT> Get(byte b) {
				for (int i = 0; i < NodesCount; i++) {
					if (Nodes[i].Byte == b) {
						return Nodes[i];
					}
				}
				return null;
			}
		}

		public class TriesNode<TTT> {

			public byte Byte { get; }
			public TriesContainer<TTT> ChildContainer { get; }
			public TriesNode(byte b, int capacity) {
				Byte = b;
				ChildContainer = new TriesContainer<TTT>(capacity);
			}

		}
	}
}
