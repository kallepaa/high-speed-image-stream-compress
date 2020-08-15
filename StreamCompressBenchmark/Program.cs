using System;
using StreamCompress;
using StreamCompress.Domain.Huffman;
using StreamCompress.Domain.Image;
using StreamCompress.Domain.LZ;
using StreamCompress.DomainExtensions.Huffman;
using StreamCompress.DomainExtensions.Image;
using StreamCompress.DomainExtensions.LZ;
using StreamCompress.Utils;
using StreamCompress.Shared;

namespace StreamCompressBenchmark {
	class Program {


		static void Main(string[] args) {


		}

		public void AsLZEncodedByHashTable(int prime) {
			var i = 2;
			var sourceFile = Common.GetSourceImagePath(i);
			var image = ImageFrame.FromFile(sourceFile);
			var encoded = image.AsLZEncodedUsingHashTable(prime);
			var decoded = encoded.AsImageFrameUsingHashTable<ImageFrame>(prime);
		}

		public void AsLZDecodedByHashTable(int prime) {
			var i = 2;
			var sourceFile = Common.GetSourceImagePath(i);
			var image = ImageFrame.FromFile(sourceFile);
			var encoded = image.AsLZEncodedUsingHashTable(prime);
			var decoded = encoded.AsImageFrameUsingHashTable<ImageFrame>(prime);
		}

		public void AsLZEncodedAndDecoded(int nodeInitialCapacity) {
			var i = 2;
			var sourceFile = Common.GetSourceImagePath(i);
			var image = ImageFrame.FromFile(sourceFile);
			var encoded = image.AsLZEncodedUsingTrie(nodeInitialCapacity);
			var decoded = encoded.AsImageFrameUsingTrie<ImageFrame>(nodeInitialCapacity);
			Assert.True(image.Image.Compare(decoded.Image));
		}

		public void AsLZEncodedAndDecoded() {
			var i = 2;
			var sourceFile = Common.GetSourceImagePath(i);
			var image = ImageFrame.FromFile(sourceFile);
			var encoded = image.AsLZEncodedUsingTrie256();
			var decoded = encoded.AsImageFrameUsingTrie256<ImageFrame>();
			Assert.True(image.Image.Compare(decoded.Image));
		}


	}
}
