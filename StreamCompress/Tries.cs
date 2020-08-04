namespace StreamCompress {
	public class Tries {

		public TriesContainer Root { get; }
		private readonly int _initialCapacity;

		public Tries(int containerCapacity) {
			Root = new TriesContainer(containerCapacity);
			_initialCapacity = containerCapacity;
		}

		public void Insert(byte[] word) {

			var container = Root;
			var n = default(TriesNode);

			for (int i = 0; i < word.Length; i++) {
				var b = word[i];
				n = container.Get(b);
				if (n == null) {
					n = container.Add(b);
				}
				container = n.ChildContainer;
			}

			if (n != null) {
				n.ChildContainer.IsWord = true;
			}
		}

		public bool Exists(byte[] word) {

			var container = Root;
			var n = default(TriesNode);

			for (int i = 0; i < word.Length; i++) {
				var b = word[i];
				n = container.Get(b);
				if (n == null) {
					return false;
				}
				container = n.ChildContainer;
			}

			return n != null && container.IsWord;
		}

		public class TriesContainer {

			public TriesNode[] Nodes { get; internal set; }
			public int NodesCount { get; internal set; }
			public bool IsWord { get; internal set; }

			private readonly int _initialCapacity;

			public TriesContainer(int capacity) {
				Nodes = new TriesNode[capacity];
				_initialCapacity = capacity;
			}

			public TriesNode Add(byte b) {

				if (NodesCount == Nodes.Length) {
					var newNodes = new TriesNode[Nodes.Length + _initialCapacity];
					for (int i = 0; i < Nodes.Length; i++) {
						newNodes[i] = Nodes[i];
					}
				}

				var ret = new TriesNode(b, _initialCapacity);
				Nodes[NodesCount++] = ret;
				return ret;
			}

			public TriesNode Get(byte b) {
				for (int i = 0; i < NodesCount; i++) {
					if (Nodes[i].Byte == b) {
						return Nodes[i];
					}
				}
				return null;
			}
		}

		public class TriesNode {

			public byte Byte { get; }
			public TriesContainer ChildContainer { get; }
			public TriesContainer Container { get; set; }
			public TriesNode(byte b, int capacity) {
				Byte = b;
				ChildContainer = new TriesContainer(capacity);
			}

		}
	}
}
