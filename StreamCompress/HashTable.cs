using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace StreamCompress {

	/// <summary>
	/// Hash table impl
	/// </summary>
	public class HashTable<T> {

		private Stopwatch _searchStopwatch = new Stopwatch();
		private Stopwatch _insertStopwatch = new Stopwatch();

		public HashTableItem<T>[] HashTableItems { get; internal set; }
		public decimal FillRatio => Math.Round(Count / (decimal)HashTableItems.Length, 2);
		public int Count { get; internal set; }
		public int CollisionCount { get; internal set; }

		public int SearchCount { get; internal set; }
		public int LongestSearchKey { get; internal set; }

		public int SearchCompareCount { get; internal set; }
		public long SearchMinMs { get; internal set; } = long.MaxValue;
		public long SearchMaxMs { get; internal set; }
		public long SearchTotalMs { get; internal set; }

		private Dictionary<int, T>[] _intHashTables = new Dictionary<int, T>[4];
		private Dictionary<long, T>[] _longHashTables = new Dictionary<long, T>[4];

		public long InsertMinMs { get; internal set; } = long.MaxValue;
		public long InsertMaxMs { get; internal set; }
		public long InsertTotalMs { get; internal set; }

		public int[] SearchKeyLengths { get; set; } = new int[512];
		public int[] SearchKeySearch { get; set; } = new int[512];

		public HashTable(int m) {
			HashTableItems = new HashTableItem<T>[m];

			for (int i = 0; i < 4; i++) {
				_intHashTables[i] = new Dictionary<int, T>();
				_longHashTables[i] = new Dictionary<long, T>();
			}
		}

		public void Insert(byte[] searchKey, T codeWord) {

			SearchKeyLengths[searchKey.Length]++;

			_insertStopwatch.Restart();

			//if (searchKey.Length < 5) {
			//	var hashTable = _intHashTables[searchKey.Length - 1];
			//	var key = searchKey.AsInt(0);
			//	if (!hashTable.ContainsKey(key)) {
			//		hashTable[key] = codeWord;
			//		Count++;
			//	}
			//	return;
			//} else if (searchKey.Length < 9) {
			//	var hashTable = _longHashTables[searchKey.Length - 4];
			//	var key = searchKey.AsLong(0);
			//	if (!hashTable.ContainsKey(key)) {
			//		hashTable[key] = codeWord;
			//		Count++;
			//	}
			//	return;
			//}

			var item = new HashTableItem<T>(searchKey, codeWord, HashTableItems.Length);

			if (HashTableItems[item.Hash] == null) {
				HashTableItems[item.Hash] = item;
				Count++;
				LongestSearchKey = Math.Max(LongestSearchKey, item.SearchKey.Length);
			} else {
				var existingItem = Search(searchKey);
				if (existingItem == null) {
					HashTableItems[item.Hash].SetLinkedItem(item);
					Count++;
					CollisionCount++;
					LongestSearchKey = Math.Max(LongestSearchKey, item.SearchKey.Length);
				} else {
					item = existingItem;
				}
			}

			_insertStopwatch.Stop();

			InsertTotalMs += _insertStopwatch.ElapsedMilliseconds;

			if (_insertStopwatch.ElapsedMilliseconds < InsertMinMs) {
				InsertMinMs = _insertStopwatch.ElapsedMilliseconds;
			}

			if (_insertStopwatch.ElapsedMilliseconds > InsertMaxMs) {
				InsertMaxMs = _insertStopwatch.ElapsedMilliseconds;
			}

		}

		public HashTableItem<T> Search(byte[] searchKey) {

			SearchKeySearch[searchKey.Length]++;

			SearchCount++;

			_searchStopwatch.Restart();

			//if (searchKey.Length < 5) {
			//	var hashTable = _intHashTables[searchKey.Length - 1];
			//	var key = searchKey.AsInt(0);
			//	if (hashTable.ContainsKey(key)) {
			//		return new HashTableItem<T>(searchKey, hashTable[key]);
			//	}
			//	return null;
			//} else if (searchKey.Length < 9) {
			//	var hashTable = _longHashTables[searchKey.Length - 5];
			//	var key = searchKey.AsLong(0);
			//	if (hashTable.ContainsKey(key)) {
			//		return new HashTableItem<T>(searchKey, hashTable[key]);
			//	}
			//	return null;
			//}

			var hashTableItem = new HashTableItem<T>(searchKey, default(T), HashTableItems.Length);

			var itemFound = HashTableItems[hashTableItem.Hash];
			if (itemFound != null) {
				while (itemFound != null) {
					SearchCompareCount++;
					if (hashTableItem.CompareTo(itemFound) == 0) {
						break;
					}
					itemFound = itemFound.LinkedItem;
				}
			}

			_searchStopwatch.Stop();
			SearchTotalMs += _searchStopwatch.ElapsedMilliseconds;
			if (_searchStopwatch.ElapsedMilliseconds < SearchMinMs) {
				SearchMinMs = _searchStopwatch.ElapsedMilliseconds;
			}
			if (_searchStopwatch.ElapsedMilliseconds > SearchMaxMs) {
				SearchMaxMs = _searchStopwatch.ElapsedMilliseconds;
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

			public HashTableItem(byte[] searchKey, TT codeWord) {
				SearchKey = searchKey;
				CodeWord = codeWord;
			}
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
