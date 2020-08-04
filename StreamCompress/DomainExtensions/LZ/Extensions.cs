using StreamCompress.Domain.Image;
using StreamCompress.Domain.LZ;
using StreamCompress.Utils;


namespace StreamCompress.DomainExtensions.LZ {

	/// <summary>
	/// Domain extensions for domain objects manipulation
	/// </summary>
	public static class Extensions {

		/// <summary>
		/// Decodes LZ compressed bytes
		/// </summary>
		/// <param name="codes">Compressed bytes</param>
		/// <param name="decoderDic">Dictionary to use in decoding</param>
		/// <returns>Decompressed data</returns>
		private static byte[] _asLZDecoded(byte[] codes, ILZ78CodingTable<byte[]> decoderDic) {

			for (int i = 0; i < 256; i++) {
				var searchKey = i.AsBytes();
				var codeWord = new[] { (byte)i };
				decoderDic.Insert(searchKey, codeWord);
			}

			using (var decodedOutPut = new ByteMemoryStream(codes.Length * 2)) {

				var O = codes.AsInt(0).AsBytes();
				var S = new byte[0];
				var C2 = new byte[0];

				var item = decoderDic.Search(O);

				decodedOutPut.AddBytes(item.CodeWord);

				for (int i = 4; i < codes.Length; i += 4) {

					var N = codes.AsInt(i).AsBytes();

					var itemN = decoderDic.Search(N);
					var itemO = decoderDic.Search(O);

					if (itemN == null) {
						S = itemO.CodeWord.Concatenate(C2);
					} else {
						S = itemN.CodeWord;
					}

					decodedOutPut.AddBytes(S);

					C2 = new byte[] { S[0] };

					var C3 = itemO.CodeWord.Concatenate(C2);

					decoderDic.Insert(((decoderDic.Count)).AsBytes(), C3);

					O = N;
				}

				return decodedOutPut.ReadBytes();
			}

		}

		#region LZ78 Using Hash Table as dictionary

		/// <summary>
		/// Decodes compressed bytes
		/// </summary>
		/// <param name="codes">Compressed bytes</param>
		/// <param name="hashPrime">m value used in hash table</param>
		/// <returns>Decompressed data</returns>
		public static byte[] AsLZDecodedUsingHashTable(this byte[] codes, int hashPrime) {
			var decoderDic = new HashTable<byte[]>(hashPrime);
			return _asLZDecoded(codes, decoderDic);
		}

		/// <summary>
		/// Decodes LZ compressed data
		/// </summary>
		/// <typeparam name="T">Type of image</typeparam>
		/// <param name="encodedImage">LZ encoded image frame</param>
		/// <param name="hashPrime">m value used in hash table</param>
		/// <returns>Decompressed data</returns>
		public static T AsImageFrameUsingHashTable<T>(this LZImageFrame encodedImage, int hashPrime) where T : ImageFrame, new() {
			var ret = new T();
			ret.FromBytes(encodedImage.Codes.AsLZDecodedUsingHashTable(hashPrime));
			return ret;
		}

		#endregion

		#region LZ78 Using Trie as dictionary

		/// <summary>
		/// Decodes compressed bytes
		/// </summary>
		/// <param name="codes">Compressed bytes</param>
		/// <param name="nodeInitialCapacity">Node table initial size</param>
		/// <returns>Decompressed data</returns>
		public static byte[] AsLZDecodedUsingTrie(this byte[] codes, int nodeInitialCapacity) {
			var decoderDic = new Tries<byte[]>(nodeInitialCapacity);
			return _asLZDecoded(codes, decoderDic);
		}

		/// <summary>
		/// Decodes LZ compressed data
		/// </summary>
		/// <typeparam name="T">Type of image</typeparam>
		/// <param name="encodedImage">LZ encoded image frame</param>
		/// <param name="nodeInitialCapacity">Node table initial size</param>
		/// <returns>Return image frame of type T</returns>
		public static T AsImageFrameUsingTrie<T>(this LZImageFrame encodedImage, int nodeInitialCapacity) where T : ImageFrame, new() {
			var ret = new T();
			ret.FromBytes(encodedImage.Codes.AsLZDecodedUsingTrie(nodeInitialCapacity));
			return ret;
		}

		#endregion

	}
}
