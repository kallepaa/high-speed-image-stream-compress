using StreamCompress.Utils;
using System;

namespace StreamCompress.Domain.LZ {

	/// <summary>
	/// Hash table impl
	/// </summary>
	public class HashTable<T> : ILZ78CodingTable<T> {

		/// <summary>
		/// Hash table items
		/// </summary>
		public HashTableItem<T>[] HashTableItems { get; internal set; }
		/// <summary>
		/// Items count
		/// </summary>
		public int Count { get; internal set; }

		/// <summary>
		/// Constructor for new HashTable
		/// </summary>
		/// <param name="m">Hash table size</param>
		public HashTable(int m) {
			HashTableItems = new HashTableItem<T>[m];
		}

		private void _insert(byte[] searchKey, T codeWord) {

			var item = new HashTableItem<T>(searchKey, codeWord, HashTableItems.Length);

			if (HashTableItems[item.Hash] == null) {
				HashTableItems[item.Hash] = item;
				Count++;
			} else {
				var existingItem = _search(searchKey);
				if (existingItem == null) {
					HashTableItems[item.Hash].SetLinkedItem(item);
					Count++;
				}
			}
		}

		public HashTableItem<T> _search(byte[] searchKey) {

			var hashTableItem = new HashTableItem<T>(searchKey, default(T), HashTableItems.Length);

			var itemFound = HashTableItems[hashTableItem.Hash];
			if (itemFound != null) {
				while (itemFound != null) {
					if (hashTableItem.CompareTo(itemFound) == 0) {
						break;
					}
					itemFound = itemFound.LinkedItem;
				}
			}
			return itemFound;
		}

		/// <summary>
		/// Inserts new item to HashTable if it does not already exists
		/// </summary>
		/// <param name="searchKey">Key</param>
		/// <param name="codeWord">Value</param>
		public void Insert(byte[] searchKey, T codeWord) {
			_insert(searchKey, codeWord);
		}

		/// <summary>
		/// Serach method for hash table items
		/// </summary>
		/// <param name="searchKey">Key</param>
		/// <returns>Item if it does exists, otherwise null</returns>
		public ILZ78CodingTableItem<T> Search(byte[] searchKey) {
			var htItem = _search(searchKey);
			return htItem == null ? null : new ILZ78CodingTableItem<T>(htItem.CodeWord);
		}

		/// <summary>
		/// Hash table item
		/// </summary>
		/// <typeparam name="TT">CodeWord type</typeparam>
		public class HashTableItem<TT> : IComparable<HashTableItem<TT>> {

			const int p = 16777619;
			private readonly int _key;

			public readonly int Hash;
			public readonly TT CodeWord;
			public readonly byte[] SearchKey;

			public HashTableItem<TT> LinkedItem { get; internal set; }

			/// <summary>
			/// Constructor to create new item. Method will also calculate key and hash
			/// </summary>
			/// <param name="searchKey"></param>
			/// <param name="codeWord"></param>
			/// <param name="m"></param>
			public HashTableItem(byte[] searchKey, TT codeWord, int m) {

				//FNV Hash
				//https://stackoverflow.com/questions/16340/how-do-i-generate-a-hashcode-from-a-byte-array-in-c/16381

				unchecked {

					var hash = (int)2166136161;

					for (int i = 0; i < searchKey.Length; i += 1) {
						hash = (hash ^ searchKey[i]) * p;
					}

					hash += hash << 13;
					hash ^= hash >> 7;
					hash += hash << 3;
					hash ^= hash >> 17;
					hash += hash << 5;

					_key = Math.Abs(hash);

					Hash = _key % m;
					SearchKey = searchKey;
					CodeWord = codeWord;
				}
			}

			/// <summary>
			/// Ser given item as linked item to this item
			/// </summary>
			/// <param name="item"></param>
			public void SetLinkedItem(HashTableItem<TT> item) {
				if (LinkedItem == null) {
					LinkedItem = item;
				} else {
					LinkedItem.SetLinkedItem(item);
				}
			}

			/// <summary>
			/// Compares this item to given one
			/// </summary>
			/// <param name="other">Other item</param>
			/// <returns>zero when items are equal, otherwise -1</returns>
			public int CompareTo(HashTableItem<TT> other) {
				return SearchKey.Compare(other.SearchKey) ? 0 : -1;
			}
		}
	}
}
