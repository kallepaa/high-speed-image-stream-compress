namespace StreamCompress.Domain.Huffman {

	/// <summary>
	/// Presents one node in huffman tree
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class HuffmanTreeNode<T> {

		/// <summary>
		/// Node left child
		/// </summary>
		public HuffmanTreeNode<T> LeftChild { get; internal set; }

		/// <summary>
		/// Node right child
		/// </summary>
		public HuffmanTreeNode<T> RightChild { get; internal set; }

		/// <summary>
		/// internal cursor to keep track which bit in code value has not been set yet
		/// </summary>
		private int _codeBitPos = 0;
		/// <summary>
		/// Code numeric value
		/// </summary>
		public int Code { get; internal set; }
		public int CodeBits => _codeBitPos - 1;
		/// <summary>
		/// Total bits used for symbol
		/// </summary>
		public int TotalBits => CodeBits * Frequency;
		/// <summary>
		/// Contains code bits in array and most significant bit is last one
		/// </summary>
		public bool[] CodeBitTable { get; internal set; }

		/// <summary>
		/// Populates bits code in array using order so that last index has most significant bit
		/// </summary>
		public void PopulateBitTable() {
			CodeBitTable = new bool[CodeBits];
			var code = Code;
			var i = 0;
			while (code > 0) {
				var bit = (code & 1) == 1;
				CodeBitTable[i++] = bit;
				code = code >> 1;
			}
		}

		/// <summary>
		/// Is node or internal node
		/// </summary>
		public bool Leaf { get; }
		/// <summary>
		/// Is right child of this node parent
		/// </summary>
		public bool IsRightChild { get; internal set; }
		/// <summary>
		/// Symbol
		/// </summary>
		public T Symbol { get; }
		/// <summary>
		/// Node frequency / priority
		/// </summary>
		public int Frequency { get; internal set; }
		/// <summary>
		/// Node parent
		/// </summary>
		public HuffmanTreeNode<T> Parent { get; internal set; }
		/// <summary>
		/// To create leaf
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="frequency"></param>
		public HuffmanTreeNode(T symbol) {
			Symbol = symbol;
			Leaf = true;
		}

		/// <summary>
		/// To create leaf when decoding
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="frequency"></param>
		public HuffmanTreeNode(T symbol, int code, int codeBits) {
			Symbol = symbol;
			Leaf = true;
			Code = code;
			_codeBitPos = codeBits + 1;
		}

		/// <summary>
		/// To create internal node when decoding
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="frequency"></param>
		public HuffmanTreeNode() {
			Leaf = false;
		}


		/// <summary>
		/// To create internal node
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="frequency"></param>
		public HuffmanTreeNode(int frequency, HuffmanTreeNode<T> leftChild, HuffmanTreeNode<T> rightChild) {
			Frequency = frequency;
			Leaf = false;
			leftChild.SetParent(this, false);
			rightChild.SetParent(this, true);
		}

		/// <summary>
		/// Sets child as child node to this node
		/// </summary>
		/// <param name="childNode"></param>
		public void SetChild(HuffmanTreeNode<T> childNode) {
			if (childNode.IsRightChild) {
				RightChild = childNode;
			} else {
				LeftChild = childNode;
			}
		}

		/// <summary>
		/// Sets given node as parent to this node and defines if this node is left or right of parent
		/// </summary>
		/// <param name="parent">Parent node</param>
		/// <param name="isRightChild">Is right child</param>
		/// <returns></returns>
		public HuffmanTreeNode<T> SetParent(HuffmanTreeNode<T> parent, bool isRightChild) {
			Parent = parent;
			IsRightChild = isRightChild;
			return this;
		}

		/// <summary>
		/// Combines left node and right node as new internal node and sets new node as parent node to both nodes.
		/// </summary>
		/// <param name="leftNode">left node</param>
		/// <param name="rightNode">right node</param>
		/// <returns>new internal node</returns>
		public static HuffmanTreeNode<T> InternalNodeCreate(HuffmanTreeNode<T> leftNode, HuffmanTreeNode<T> rightNode) {
			var internalNodeKey = leftNode.Frequency + rightNode.Frequency;
			var internalNode = new HuffmanTreeNode<T>(internalNodeKey, leftNode, rightNode);
			return internalNode;
		}

		/// <summary>
		/// Increase node symbol frequency
		/// </summary>
		public void IncreaseFrequency() {
			Frequency++;
		}

		/// <summary>
		/// Resets code value and code bit position
		/// </summary>
		public void ResetCode() {
			Code = 0;
			_codeBitPos = 0;
		}

		/// <summary>
		/// Sets code value bit value in current bit position to zero when node is left and 1 when node is right child
		/// </summary>
		public void SetCodeNextBit(int bit) {
			if (bit == 1) {
				//right side child node 
				var bitToAdd = (1 << _codeBitPos);//power by 2
				Code += bitToAdd;
			}
			_codeBitPos++;
		}
	}
}
