namespace StreamCompress.Domain.LZ {


	/// <summary>
	/// Implements trie algoritmin using dynamic size node table
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class Tries<T> : ILZ78CodingTable<T> {

		private TriesContainer<T> Root { get; }
		/// <summary>
		/// Items count
		/// </summary>
		public int Count { get; internal set; }

		private readonly int _initialCapacity;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="containerCapacity"></param>
		public Tries(int containerCapacity) {
			Root = new TriesContainer<T>(containerCapacity);
			_initialCapacity = containerCapacity;
		}

		/// <summary>
		/// Adds new item to dictionary
		/// </summary>
		/// <param name="searchKey">Key</param>
		/// <param name="codeWord">Value</param>
		public void Insert(byte[] searchKey, T codeWord) {
			_insert(searchKey, codeWord);
		}

		/// <summary>
		/// Search item from dictionary
		/// </summary>
		/// <param name="searchKey">Key</param>
		/// <returns>Existing key value or null</returns>
		public ILZ78CodingTableItem<T> Search(byte[] searchKey) {
			var match = _search(searchKey);
			return match == null ? null : new ILZ78CodingTableItem<T>(match.ChildContainer.CodeWord);
		}

		private void _insert(byte[] searchKey, T codeWord) {

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

		private TriesNode<T> _search(byte[] searchKey) {

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

		/// <summary>
		/// Container node, which contains nodes
		/// </summary>
		/// <typeparam name="TT">Type of code word</typeparam>
		public class TriesContainer<TT> {

			/// <summary>
			/// Nodes saved to this container
			/// </summary>
			public TriesNode<TT>[] Nodes { get; internal set; }
			/// <summary>
			/// Count of nodes
			/// </summary>
			public int NodesCount { get; internal set; }
			/// <summary>
			/// Is container node that contains full word
			/// </summary>
			public bool IsSet { get; internal set; }
			/// <summary>
			/// Word saved to this container
			/// </summary>
			public TT CodeWord { get; internal set; }

			private readonly int _initialCapacity;

			/// <summary>
			/// Container constructor
			/// </summary>
			/// <param name="capacity">Nodes tabel intiial capacity</param>
			public TriesContainer(int capacity) {
				Nodes = new TriesNode<TT>[capacity];
				_initialCapacity = capacity;
			}

			/// <summary>
			/// Adds byte to container
			/// </summary>
			/// <param name="b">byte</param>
			/// <returns>Added node</returns>
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

			/// <summary>
			/// Return byte from container if it is set
			/// </summary>
			/// <param name="b">Byte to look up</param>
			/// <returns>Node if it's set else null</returns>
			public TriesNode<TT> Get(byte b) {
				for (int i = 0; i < NodesCount; i++) {
					if (Nodes[i].Byte == b) {
						return Nodes[i];
					}
				}
				return null;
			}
		}

		/// <summary>
		/// Node that contains byte value and links to child containers
		/// </summary>
		/// <typeparam name="TTT"></typeparam>
		public class TriesNode<TTT> {

			/// <summary>
			/// Byte
			/// </summary>
			public byte Byte { get; }

			/// <summary>
			/// Child container
			/// </summary>
			public TriesContainer<TTT> ChildContainer { get; }

			/// <summary>
			/// Node constructor
			/// </summary>
			/// <param name="b">Byte value</param>
			/// <param name="capacity">Child container initial capacity</param>
			public TriesNode(byte b, int capacity) {
				Byte = b;
				ChildContainer = new TriesContainer<TTT>(capacity);
			}

		}
	}
}
