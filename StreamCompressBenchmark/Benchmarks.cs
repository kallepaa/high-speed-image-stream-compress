using BenchmarkDotNet.Attributes;
using StreamCompress.Domain.Huffman;
using StreamCompress.Domain.Image;
using StreamCompress.Domain.LZ;
using StreamCompress.DomainExtensions.Image;
using StreamCompress.Shared;
using BenchmarkDotNet.Engines;

namespace StreamCompressBenchmark {

	[SimpleJob(RunStrategy.ColdStart, launchCount: 3, warmupCount: 1, targetCount: 1, id: "EncodeJob")]
	[MarkdownExporterAttribute.GitHub]
	[MemoryDiagnoser]
	public class Encode {

		const int imageIndex = 0;
		private ImageFrame image;

		[GlobalSetup]
		public void GlobalSetup() {
			var sourceFile = Common.GetSourceImagePath(imageIndex);
			image = ImageFrame.FromFile(sourceFile);
		}

		[Benchmark(Description = "HashTable - Prime 12289")]
		public LZImageFrame HashTable() => image.AsLZEncodedUsingHashTable(12289);
		[Benchmark(Description = "Trie - Initial capacity 1")]
		public LZImageFrame Trie() => image.AsLZEncodedUsingTrie(1);
		[Benchmark]
		public LZImageFrame Trie256() => image.AsLZEncodedUsingTrie256();
	}

	[SimpleJob(RunStrategy.ColdStart, launchCount: 3, warmupCount: 1, targetCount: 1, id: "EncodeGrayScaleJob")]
	[MarkdownExporterAttribute.GitHub]
	[MemoryDiagnoser]
	public class EncodeGrayScale {

		[Params(256, 128, 64, 32)]
		public int Colors;

		const int imageIndex = 0;
		private ImageFrameGrayScale image;

		[GlobalSetup]
		public void GlobalSetup() {
			var sourceFile = Common.GetSourceImagePath(imageIndex);
			image = ImageFrame.FromFile(sourceFile).AsGrayScale(Colors);
		}

		[Benchmark(Description = "HashTable - Prime 12289")]
		public LZImageFrame HashTable() => image.AsLZEncodedUsingHashTable(12289);
		[Benchmark(Description = "Trie - Initial capacity 1")]
		public LZImageFrame Trie() => image.AsLZEncodedUsingTrie(1);
		[Benchmark]
		public LZImageFrame Trie256() => image.AsLZEncodedUsingTrie256();
		[Benchmark]
		public HuffmanImageFrame Huffman() => image.AsHuffmanEncoded();

	}

	[SimpleJob(RunStrategy.ColdStart, launchCount: 3, warmupCount: 1, targetCount: 1, id: "EncodeCroppedGrayScaleJob")]
	[MarkdownExporterAttribute.GitHub]
	[MemoryDiagnoser]
	public class EncodeCroppedGrayScale {

		const int imageIndex = 0;
		private ImageFrameGrayScale image;

		[Params(0, 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22)]
		public int Crop;

		[GlobalSetup]
		public void GlobalSetup() {
			var sourceFile = Common.GetSourceImagePath(imageIndex);
			image = ImageFrame.FromFile(sourceFile).AsCroppedImage(new CropSetup { LeftPx = Crop * 16, RightPx = Crop * 16, TopPx = Crop * 16, BottomPx = Crop * 16 }).AsGrayScale();
		}

		[Benchmark]
		public LZImageFrame HashTable() => image.AsLZEncodedUsingHashTable(12289);
		[Benchmark]
		public LZImageFrame Trie() => image.AsLZEncodedUsingTrie(1);
		[Benchmark]
		public LZImageFrame Trie256() => image.AsLZEncodedUsingTrie256();
		[Benchmark]
		public HuffmanImageFrame Huffman() => image.AsHuffmanEncoded();
	}

	[SimpleJob(RunStrategy.ColdStart, launchCount: 3, warmupCount: 1, targetCount: 1, id: "EncodeCroppedJob")]
	[MarkdownExporterAttribute.GitHub]
	[MemoryDiagnoser]
	public class EncodeCropped {

		const int imageIndex = 0;
		private ImageFrame image;

		[Params(0, 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22)]
		public int Crop;

		[GlobalSetup]
		public void GlobalSetup() {
			var sourceFile = Common.GetSourceImagePath(imageIndex);
			image = ImageFrame.FromFile(sourceFile).AsCroppedImage(new CropSetup { LeftPx = Crop * 16, RightPx = Crop * 16, TopPx = Crop * 16, BottomPx = Crop * 16 });
		}

		[Benchmark]
		public LZImageFrame HashTable() => image.AsLZEncodedUsingHashTable(12289);
		[Benchmark]
		public LZImageFrame Trie() => image.AsLZEncodedUsingTrie(1);
		[Benchmark]
		public LZImageFrame Trie256() => image.AsLZEncodedUsingTrie256();

	}

	[SimpleJob(RunStrategy.ColdStart, launchCount: 3, warmupCount: 1, targetCount: 1, id: "EncodeHashTablePrimeJob")]
	[MarkdownExporterAttribute.GitHub]
	[MemoryDiagnoser]
	public class EncodeHashTablePrime {

		const int imageIndex = 0;
		private ImageFrame image;

		[Params(6151, 12289, 24593, 49157, 98317, 196613, 393241, 786469, 1572869)]
		public int Prime { get; set; }


		[GlobalSetup]
		public void GlobalSetup() {
			var sourceFile = Common.GetSourceImagePath(imageIndex);
			image = ImageFrame.FromFile(sourceFile);
		}

		[Benchmark]
		public LZImageFrame HashTable() => image.AsLZEncodedUsingHashTable(Prime);

	}

	[SimpleJob(RunStrategy.ColdStart, launchCount: 3, warmupCount: 1, targetCount: 1, id: "EncodeTrieCapacityJob")]
	[MarkdownExporterAttribute.GitHub]
	[MemoryDiagnoser]
	public class EncodeTrieCapacity {

		const int imageIndex = 0;
		private ImageFrame image;

		[Params(1, 32, 64, 128)]
		public int Capacity { get; set; }


		[GlobalSetup]
		public void GlobalSetup() {
			var sourceFile = Common.GetSourceImagePath(imageIndex);
			image = ImageFrame.FromFile(sourceFile);
		}

		[Benchmark]
		public LZImageFrame Trie() => image.AsLZEncodedUsingTrie(Capacity);

	}

}
