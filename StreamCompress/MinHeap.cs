using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreamCompress {

	/// <summary>
	/// Min heap implementation
	/// </summary>
	/// <typeparam name="T">Data to store into node</typeparam>
	public class MinHeap<T> where T : class {

		/// <summary>
		/// heap table
		/// </summary>
		private readonly int?[] _heap;
		/// <summary>
		/// nodes data
		/// </summary>
		private readonly T[] _heapData;

		/// <summary>
		/// Heap current size
		/// </summary>
		private int _heapSize;
		public int HeapSize { get => _heapSize;}

		/// <summary>
		/// Constructor for new heap
		/// </summary>
		/// <param name="n">Maximum size of nodes in tree</param>
		public MinHeap(int n) {
			_heap = new int?[n];
			_heapData = new T[n];
		}

		public void Insert(int nodeKey, T nodeData) {

			_heapSize++;//increase heap size

			var i = _heapSize - 1; //empty slot for new node from end of heap

			var parentNodeIndex = _getParentIndex(i);//new node parent index
			var parentNodeKey = _heap[parentNodeIndex];//parent key value
			var parentNodeData = _heapData[parentNodeIndex];//parent data

			//moving new node up in tree until it's in correct location
			while (i > 0 && parentNodeKey > nodeKey) {

				_heap[i] = parentNodeKey;//siirretään parent tasoa alemmas
				_heapData[i] = parentNodeData;

				i = parentNodeIndex;//tukitaan seuraava parent

				parentNodeIndex = _getParentIndex(i);
				parentNodeKey = _heap[parentNodeIndex];
				parentNodeData = _heapData[parentNodeIndex];
			}

			_heap[i] = nodeKey;//when corrent location has found then new node is into it.
			_heapData[i] = nodeData;

		}


		/// <summary>
		/// Removes smallest key from heap and returns node data
		/// </summary>
		/// <returns>Smallest key and node data</returns>
		public T DelMin() {
			var max = _heapData[0];
			if (max != null) {
				_swapNodeLocations(0, --_heapSize); //move last node to root
				_heap[_heapSize] = null;//clean last node index
				_heapData[_heapSize] = null;
				_heapify(0);//do heapify from root
			}
			return max;
		}

		/// <summary>
		/// Heapify routine
		/// </summary>
		/// <param name="i">Start index</param>
		private void _heapify(int i) {

			var leftChildIndex = _leftChildNodeIndex(i);
			var rightChildIndex = _rightChildNodeIndex(i);
			var smallerChildIndex = 0;

			if (rightChildIndex < _heapSize) {
				//i has child also on right side
				if (_heap[leftChildIndex] < _heap[rightChildIndex]) {
					smallerChildIndex = leftChildIndex; //left child has smaller key
				} else {
					smallerChildIndex = rightChildIndex; //right child has smaller key
				}

				if (_heap[i] > _heap[smallerChildIndex]) {
					//given index (node) has greater key than smaller child so then move node down
					_swapNodeLocations(i, smallerChildIndex);
					//then do heapify from new location
					_heapify(smallerChildIndex);
				}
			} else if (leftChildIndex == _heapSize - 1 && _heap[i] > _heap[leftChildIndex]) {
				//when node has only left child then and child value is smaller than given node key then swap nodes location
				_swapNodeLocations(i, leftChildIndex);
			}
		}

		/// <summary>
		/// Resolves given index parent node index
		/// </summary>
		/// <param name="i"></param>
		/// <returns>Parent index</returns>
		private int _getParentIndex(int i) {
			return (i - 1) / 2;
		}

		/// <summary>
		/// Resolves given index left child node index
		/// </summary>
		/// <param name="i">Node index</param>
		/// <returns>Left child index</returns>
		private int _leftChildNodeIndex(int i) => (2 * i) + 1;

		/// <summary>
		/// Resolves given index right child node index
		/// </summary>
		/// <param name="i">Node index</param>
		/// <returns>Right child index</returns>
		private int _rightChildNodeIndex(int i) => _leftChildNodeIndex(i) + 1;

		/// <summary>
		/// Switch two node index locations in table
		/// </summary>
		/// <param name="i">Index 1</param>
		/// <param name="j">Index 2</param>
		private void _swapNodeLocations(int i, int j) {
			var t = _heap[i];
			var tData = _heapData[i];

			_heap[i] = _heap[j];
			_heapData[i] = _heapData[j];

			_heapData[j] = tData;
			_heap[j] = t;
		}

	}
}
