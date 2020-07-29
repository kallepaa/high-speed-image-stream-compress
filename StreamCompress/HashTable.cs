using System;

namespace StreamCompress {

	/// <summary>
	/// Hash table impl
	/// </summary>
	public class HashTable<T>  {

		public HashTableItem<T>[] HashTableItems { get; internal set; }
		public decimal FillRatio => Math.Round(Count / (decimal)HashTableItems.Length, 2);
		public int Count { get; internal set; }
		public int CollisionCount { get; internal set; }

		public HashTable(int m) {
			HashTableItems = new HashTableItem<T>[m];
		}

		public HashTableItem<T> Insert(byte[] searchKey, T codeWord) {

			var item = new HashTableItem<T>(searchKey, codeWord, HashTableItems.Length);

			if (HashTableItems[item.Hash] == null) {
				HashTableItems[item.Hash] = item;
				Count++;
			} else {
				var existingItem = Search(searchKey);
				if (existingItem == null) {
					HashTableItems[item.Hash].SetLinkedItem(item);
					Count++;
					CollisionCount++;
				} else {
					item = existingItem;
				}
			}

			return item;
		}

		public HashTableItem<T> Search(byte[] searchKey) {

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

		public class HashTableItem<TT> : IComparable<HashTableItem<TT>> {

			const int p = 16777619;
			private readonly int _key;

			public readonly int Hash;
			public readonly TT CodeWord;
			public readonly byte[] SearchKey;

			public HashTableItem<TT> LinkedItem { get; internal set; }

			public HashTableItem(byte[] searchKey, TT codeWord, int m) {

				//FNV Hash
				//https://stackoverflow.com/questions/16340/how-do-i-generate-a-hashcode-from-a-byte-array-in-c/16381

				unchecked {

					var hash = (int)2166136161;

					for (int i = 0; i < searchKey.Length; i++) {
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

			public void SetLinkedItem(HashTableItem<TT> item) {
				if (LinkedItem == null) {
					LinkedItem = item;
				} else {
					LinkedItem.SetLinkedItem(item);
				}
			}

			public int CompareTo(HashTableItem<TT> other) {

				if (SearchKey.Length != other.SearchKey.Length) {
					return -1;
				}

				for (int i = 0; i < SearchKey.Length; i++) {
					if (SearchKey[i] != other.SearchKey[i]) {
						return -1;
					}
				}

				return 0;
			}
		}
	}
}
