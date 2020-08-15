namespace StreamCompress.Domain.LZ {

	/// <summary>
	/// Implements trie algoritm using fixed length node table
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class Tries256<T> : ILZ78CodingTable<T> {

		private TriesContainer256<T> Root { get; }
		/// <summary>
		/// Nodes count
		/// </summary>
		public int Count { get; internal set; }

		/// <summary>
		/// Constructor
		/// </summary>
		public Tries256() {
			Root = new TriesContainer256<T>();
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
		/// <returns>Item if it exists</returns>
		public ILZ78CodingTableItem<T> Search(byte[] searchKey) {
			var match = _search(searchKey);
			return match == null ? null : new ILZ78CodingTableItem<T>(match.ChildContainer.CodeWord);
		}

		private void _insert(byte[] searchKey, T codeWord) {

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

		private TriesNode256<T> _search(byte[] searchKey) {

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

		/// <summary>
		/// Container node, which contains nodes
		/// </summary>
		/// <typeparam name="TT">Type of code word</typeparam>
		public class TriesContainer256<TT> {

			/// <summary>
			/// Nodes saved to this container
			/// </summary>
			public TriesNode256<TT>[] Nodes { get; } = new TriesNode256<TT>[256];
			/// <summary>
			/// Is container node that contains full word
			/// </summary>
			public bool IsSet { get; internal set; }
			/// <summary>
			/// Word saved to this container
			/// </summary>
			public TT CodeWord { get; internal set; }

			/// <summary>
			/// Sets code word to container
			/// </summary>
			/// <param name="codeWord"></param>
			public void SetCodeWord(TT codeWord) {
				CodeWord = codeWord;
				IsSet = true;
			}

			/// <summary>
			/// Adds byte to container
			/// </summary>
			/// <param name="b">byte</param>
			/// <returns>Added node</returns>
			public TriesNode256<TT> Add(byte b) {
				var ret = new TriesNode256<TT>(b);
				Nodes[b] = ret;
				return ret;
			}

			/// <summary>
			/// Return byte from container if it is set
			/// </summary>
			/// <param name="b">Byte to look up</param>
			/// <returns>Node if it's set else null</returns>
			public TriesNode256<TT> Get(byte b) {
				return Nodes[b];
			}
		}

		/// <summary>
		/// Node that contains byte value and links to child containers
		/// </summary>
		/// <typeparam name="TTT"></typeparam>
		public class TriesNode256<TTT> {

			/// <summary>
			/// Byte
			/// </summary>
			public byte Byte { get; }
			/// <summary>
			/// Child container
			/// </summary>
			public TriesContainer256<TTT> ChildContainer { get; }
			/// <summary>
			/// Node constructor
			/// </summary>
			/// <param name="b">Byte value</param>
			public TriesNode256(byte b) {
				Byte = b;
				ChildContainer = new TriesContainer256<TTT>();
			}

		}
	}
}
