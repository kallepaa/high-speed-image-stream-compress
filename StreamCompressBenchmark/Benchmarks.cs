using BenchmarkDotNet.Attributes;
using StreamCompress.Domain.Huffman;
using StreamCompress.Domain.Image;
using StreamCompress.Domain.LZ;
using StreamCompress.DomainExtensions.Image;
using StreamCompress.Shared;
using BenchmarkDotNet.Engines;
using StreamCompress.DomainExtensions.LZ;
using StreamCompress.DomainExtensions.Huffman;

namespace StreamCompressBenchmark {

	[SimpleJob(RunStrategy.ColdStart, launchCount: 3, warmupCount: 1, targetCount: 1, id: "EncodeAndDecode")]
	[MarkdownExporterAttribute.GitHub]
	[MemoryDiagnoser]
	public class EncodeAndDecode {

		const int imageIndex = 0;
		private ImageFrame image;
		private LZImageFrame LZEncoded;

		[GlobalSetup]
		public void GlobalSetup() {
			var sourceFile = Common.GetSourceImagePath(imageIndex);
			image = ImageFrame.FromFile(sourceFile);
			LZEncoded = image.AsLZEncodedUsingHashTable(12289);
		}

		[Benchmark(Description = "Encode LZ HashTable - Prime 12289")]
		public LZImageFrame EncodeHashTable() => image.AsLZEncodedUsingHashTable(12289);
		[Benchmark(Description = "Encode LZ Trie - Initial capacity 1")]
		public LZImageFrame EncodeTrie() => image.AsLZEncodedUsingTrie(1);
		[Benchmark(Description = "Encode LZ Trie256")]
		public LZImageFrame EncodeTrie256() => image.AsLZEncodedUsingTrie256();

		[Benchmark(Description = "Decode LZ HashTable - Prime 12289")]
		public ImageFrame DecodeHashTable() => LZEncoded.AsImageFrameUsingHashTable<ImageFrame>(12289);
		[Benchmark(Description = "Decode LZ Trie - Initial capacity 1")]
		public ImageFrame DecodeTrie() => LZEncoded.AsImageFrameUsingTrie<ImageFrame>(1);
		[Benchmark(Description = "Decode LZ Trie256")]
		public ImageFrame DecodeTrie256() => LZEncoded.AsImageFrameUsingTrie256<ImageFrame>();
	}

	[SimpleJob(RunStrategy.ColdStart, launchCount: 3, warmupCount: 1, targetCount: 1, id: "EncodeAndDecodeGrayScale")]
	[MarkdownExporterAttribute.GitHub]
	[MemoryDiagnoser]
	public class EncodeAndDecodeGrayScale {

		[Params(256, 128, 64, 32)]
		public int Colors;

		const int imageIndex = 0;
		private ImageFrameGrayScale image;
		private LZImageFrame LZEncoded;
		private HuffmanImageFrame HuffmanEncoded;

		[GlobalSetup]
		public void GlobalSetup() {
			var sourceFile = Common.GetSourceImagePath(imageIndex);
			image = ImageFrame.FromFile(sourceFile).AsGrayScale(Colors);
			LZEncoded = image.AsLZEncodedUsingHashTable(12289);
			HuffmanEncoded = image.AsHuffmanEncoded();
		}

		[Benchmark(Description = "Encode LZ HashTable - Prime 12289")]
		public LZImageFrame EncodeHashTable() => image.AsLZEncodedUsingHashTable(12289);
		[Benchmark(Description = "Encode LZ Trie - Initial capacity 1")]
		public LZImageFrame EncodeTrie() => image.AsLZEncodedUsingTrie(1);
		[Benchmark(Description = "Encode LZ Trie256")]
		public LZImageFrame EncodeTrie256() => image.AsLZEncodedUsingTrie256();
		[Benchmark(Description = "Encode Huffman")]
		public HuffmanImageFrame EncodeHuffman() => image.AsHuffmanEncoded();

		[Benchmark(Description = "Decode LZ HashTable - Prime 12289")]
		public ImageFrameGrayScale DecodeHashTable() => LZEncoded.AsImageFrameUsingHashTable<ImageFrameGrayScale>(12289);
		[Benchmark(Description = "Decode LZ Trie - Initial capacity 1")]
		public ImageFrameGrayScale DecodeTrie() => LZEncoded.AsImageFrameUsingTrie<ImageFrameGrayScale>(1);
		[Benchmark(Description = "Decode LZ Trie256")]
		public ImageFrameGrayScale DecodeTrie256() => LZEncoded.AsImageFrameUsingTrie256<ImageFrameGrayScale>();
		[Benchmark(Description = "Decode Huffman")]
		public ImageFrameGrayScale DecodeHuffman() => HuffmanEncoded.AsImageGrayScaleFrame();
	}

	[SimpleJob(RunStrategy.ColdStart, launchCount: 3, warmupCount: 1, targetCount: 1, id: "EncodeAndDecodeCroppedGrayScale")]
	[MarkdownExporterAttribute.GitHub]
	[MemoryDiagnoser]
	public class EncodeAndDecodeCroppedGrayScale {

		const int imageIndex = 0;
		private ImageFrameGrayScale image;
		private LZImageFrame LZEncoded;
		private HuffmanImageFrame HuffmanEncoded;


		[Params(0, 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22)]
		public int Crop;

		[GlobalSetup]
		public void GlobalSetup() {
			var sourceFile = Common.GetSourceImagePath(imageIndex);
			image = ImageFrame.FromFile(sourceFile).AsCroppedImage(new CropSetup { LeftPx = Crop * 16, RightPx = Crop * 16, TopPx = Crop * 16, BottomPx = Crop * 16 }).AsGrayScale();
			LZEncoded = image.AsLZEncodedUsingHashTable(12289);
			HuffmanEncoded = image.AsHuffmanEncoded();
		}

		[Benchmark(Description = "Encode LZ HashTable - Prime 12289")]
		public LZImageFrame EncodeHashTable() => image.AsLZEncodedUsingHashTable(12289);
		[Benchmark(Description = "Encode LZ Trie - Initial capacity 1")]
		public LZImageFrame EncodeTrie() => image.AsLZEncodedUsingTrie(1);
		[Benchmark(Description = "Encode LZ Trie256")]
		public LZImageFrame EncodeTrie256() => image.AsLZEncodedUsingTrie256();
		[Benchmark(Description = "Encode Huffman")]
		public HuffmanImageFrame EncodeHuffman() => image.AsHuffmanEncoded();

		[Benchmark(Description = "Decode LZ HashTable - Prime 12289")]
		public ImageFrameGrayScale DecodeHashTable() => LZEncoded.AsImageFrameUsingHashTable<ImageFrameGrayScale>(12289);
		[Benchmark(Description = "Decode LZ Trie - Initial capacity 1")]
		public ImageFrameGrayScale DecodeTrie() => LZEncoded.AsImageFrameUsingTrie<ImageFrameGrayScale>(1);
		[Benchmark(Description = "Decode LZ Trie256")]
		public ImageFrameGrayScale DecodeTrie256() => LZEncoded.AsImageFrameUsingTrie256<ImageFrameGrayScale>();
		[Benchmark(Description = "Decode Huffman")]
		public ImageFrameGrayScale DecodeHuffman() => HuffmanEncoded.AsImageGrayScaleFrame();
	}

	[SimpleJob(RunStrategy.ColdStart, launchCount: 3, warmupCount: 1, targetCount: 1, id: "EncodeAndDecodeCropped")]
	[MarkdownExporterAttribute.GitHub]
	[MemoryDiagnoser]
	public class EncodeAndDecodeCropped {

		const int imageIndex = 0;
		private ImageFrame image;
		private LZImageFrame LZEncoded;

		[Params(0, 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22)]
		public int Crop;

		[GlobalSetup]
		public void GlobalSetup() {
			var sourceFile = Common.GetSourceImagePath(imageIndex);
			image = ImageFrame.FromFile(sourceFile).AsCroppedImage(new CropSetup { LeftPx = Crop * 16, RightPx = Crop * 16, TopPx = Crop * 16, BottomPx = Crop * 16 });
			LZEncoded = image.AsLZEncodedUsingHashTable(12289);
		}

		[Benchmark(Description = "Encode LZ HashTable - Prime 12289")]
		public LZImageFrame EncodeHashTable() => image.AsLZEncodedUsingHashTable(12289);
		[Benchmark(Description = "Encode LZ Trie - Initial capacity 1")]
		public LZImageFrame EncodeTrie() => image.AsLZEncodedUsingTrie(1);
		[Benchmark(Description = "Encode LZ Trie256")]
		public LZImageFrame EncodeTrie256() => image.AsLZEncodedUsingTrie256();

		[Benchmark(Description = "Decode LZ HashTable - Prime 12289")]
		public ImageFrame DecodeHashTable() => LZEncoded.AsImageFrameUsingHashTable<ImageFrame>(12289);
		[Benchmark(Description = "Decode LZ Trie - Initial capacity 1")]
		public ImageFrame DecodeTrie() => LZEncoded.AsImageFrameUsingTrie<ImageFrame>(1);
		[Benchmark(Description = "Decode LZ Trie256")]
		public ImageFrame DecodeTrie256() => LZEncoded.AsImageFrameUsingTrie256<ImageFrame>();
	}

	[SimpleJob(RunStrategy.ColdStart, launchCount: 3, warmupCount: 1, targetCount: 1, id: "EncodeAndDecodeHashTablePrime")]
	[MarkdownExporterAttribute.GitHub]
	[MemoryDiagnoser]
	public class EncodeAndDecodeHashTablePrime {

		const int imageIndex = 0;
		private ImageFrame image;
		private LZImageFrame LZEncoded;


		[Params(6151, 12289, 24593, 49157, 98317, 196613, 393241, 786469, 1572869)]
		public int Prime { get; set; }


		[GlobalSetup]
		public void GlobalSetup() {
			var sourceFile = Common.GetSourceImagePath(imageIndex);
			image = ImageFrame.FromFile(sourceFile);
			LZEncoded = image.AsLZEncodedUsingHashTable(12289);
		}

		[Benchmark]
		public LZImageFrame EncodeHashTable() => image.AsLZEncodedUsingHashTable(Prime);
		[Benchmark()]
		public ImageFrame DecodeHashTable() => LZEncoded.AsImageFrameUsingHashTable<ImageFrame>(Prime);
	}

	[SimpleJob(RunStrategy.ColdStart, launchCount: 3, warmupCount: 1, targetCount: 1, id: "EncodeAndDecodeTrieCapacity")]
	[MarkdownExporterAttribute.GitHub]
	[MemoryDiagnoser]
	public class EncodeAndDecodeTrieCapacity {

		const int imageIndex = 0;
		private ImageFrame image;
		private LZImageFrame LZEncoded;

		[Params(1, 32, 64, 128)]
		public int Capacity { get; set; }


		[GlobalSetup]
		public void GlobalSetup() {
			var sourceFile = Common.GetSourceImagePath(imageIndex);
			image = ImageFrame.FromFile(sourceFile);
			LZEncoded = image.AsLZEncodedUsingTrie(1);
		}

		[Benchmark]
		public LZImageFrame EncodeTrie() => image.AsLZEncodedUsingTrie(Capacity);
		[Benchmark]
		public ImageFrame DecodeTrie() => LZEncoded.AsImageFrameUsingTrie<ImageFrame>(Capacity);
	}

}
