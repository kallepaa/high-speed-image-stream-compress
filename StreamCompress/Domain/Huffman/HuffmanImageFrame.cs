using StreamCompress.Utils;

namespace StreamCompress.Domain.Huffman {

	/// <summary>
	/// Presents single image frame as Huffman encoded
	/// </summary>
	public class HuffmanImageFrame : ISaveable<HuffmanImageFrame> {


		public const int HEADER_COMPRESSED_BITS_BYTES = 4;
		public const int HEADER_COMPRESSED_BITS_BYTES_POS = 0;

		public const int HEADER_MAX_CODE_BITS_BYTES = 4;
		public const int HEADER_MAX_CODE_BITS_BYTES_POS = 4;

		public const int HEADER_COLOR_CODE_COUNT_BYTES = 4;
		public const int HEADER_COLOR_CODE_COUNT_BYTES_POS = 8;

		public const int HEADER_ORIGINAL_IMAGE_HEADER_BYTES = 4;
		public const int HEADER_ORIGINAL_IMAGE_HEADER_BYTES_POS = 12;

		public const int HEADER_ORIGINAL_IMAGE_DATA_BYTES = 4;
		public const int HEADER_ORIGINAL_IMAGE_DATA_BYTES_POS = 16;


		public int FixedHeaderLength => HEADER_COMPRESSED_BITS_BYTES + HEADER_MAX_CODE_BITS_BYTES + HEADER_COLOR_CODE_COUNT_BYTES + HEADER_ORIGINAL_IMAGE_HEADER_BYTES + HEADER_ORIGINAL_IMAGE_DATA_BYTES;
		public int ColorCodeHeaderLength => ColorCodeCount * HeaderColorItem.GetBytesLength();
		public int ImageDataOffSet => FixedHeaderLength + ColorCodeHeaderLength + OriginalImageHeaderLength;

		public byte[] Data { get; internal set; }
		public int CompressedBits { get; internal set; }
		public int MaxCodeBitsLength { get; internal set; }
		public int ColorCodeCount { get; internal set; }
		public int OriginalImageHeaderLength { get; internal set; }
		public int OriginalImageDataLength { get; internal set; }

		public HuffmanImageFrame(int compressedBits, HeaderColorItem[] colorCodes, int maxCodeBitsLength, int originalImageDataLength, byte[] originalImageHeader) {

			var imageDataTotalLength = _calculateImageDataTotalSize(compressedBits);

			CompressedBits = compressedBits;
			MaxCodeBitsLength = maxCodeBitsLength;
			ColorCodeCount = colorCodes.Length;
			OriginalImageHeaderLength = originalImageHeader.Length;
			OriginalImageDataLength = originalImageDataLength;

			var totalBytes = FixedHeaderLength + ColorCodeHeaderLength + OriginalImageHeaderLength + imageDataTotalLength;

			Data = new byte[totalBytes];

			CompressedBits.AsBytes().CopyBytesTo(Data, HEADER_COMPRESSED_BITS_BYTES_POS);
			MaxCodeBitsLength.AsBytes().CopyBytesTo(Data, HEADER_MAX_CODE_BITS_BYTES_POS);
			ColorCodeCount.AsBytes().CopyBytesTo(Data, HEADER_COLOR_CODE_COUNT_BYTES_POS);
			OriginalImageHeaderLength.AsBytes().CopyBytesTo(Data, HEADER_ORIGINAL_IMAGE_HEADER_BYTES_POS);
			OriginalImageDataLength.AsBytes().CopyBytesTo(Data, HEADER_ORIGINAL_IMAGE_DATA_BYTES_POS);

			for (int i = 0; i < colorCodes.Length; i++) {
				var colorCode = colorCodes[i];
				var headerIndex = i * HeaderColorItem.GetBytesLength() + FixedHeaderLength;
				Data[headerIndex++] = (byte)colorCode.Symbol;
				Data[headerIndex++] = (byte)colorCode.CodeBitsCount;
				((uint)(colorCode.Code)).AsBytes().CopyBytesTo(Data, headerIndex);
			}

			originalImageHeader.CopyBytesTo(Data, FixedHeaderLength + ColorCodeHeaderLength);
		}

		public HuffmanImageFrame(byte[] data) {
			_fromBytes(data);
		}

		public HuffmanImageFrame() {

		}

		private void _fromBytes(byte[] data) {
			Data = data;
			CompressedBits = data.AsInt(HEADER_COMPRESSED_BITS_BYTES_POS);
			MaxCodeBitsLength = data.AsInt(HEADER_MAX_CODE_BITS_BYTES_POS);
			ColorCodeCount = data.AsInt(HEADER_COLOR_CODE_COUNT_BYTES_POS);
			OriginalImageHeaderLength = data.AsInt(HEADER_ORIGINAL_IMAGE_HEADER_BYTES_POS);
			OriginalImageDataLength = data.AsInt(HEADER_ORIGINAL_IMAGE_DATA_BYTES_POS);
		}


		public HeaderColorItem GetColorCodeItemFromHeader(int index) {
			var colorStartIndex = index * HeaderColorItem.GetBytesLength() + FixedHeaderLength;
			return new HeaderColorItem(Data, colorStartIndex);
		}

		private static int _calculateImageDataTotalSize(int compressedBits) {
			var imageDataTotalBytes = (compressedBits / 8);
			if (imageDataTotalBytes * 8 != compressedBits) {
				imageDataTotalBytes += 1;
			}
			return imageDataTotalBytes;
		}

		public bool GetBit(int index) {
			var byteIndex = index / 8;
			//read byte from left to right
			var bitPos = 7 - index % 8;
			var b = Data[byteIndex + ImageDataOffSet];
			return b.GetBitFromByte(bitPos);
		}

		public class HeaderColorItem {

			public const int HEADER_COLOR_SYMBOL_BYTES = 1;
			public const int HEADER_COLOR_CODE_BIT_COUNT_BYTES = 1;
			public const int HEADER_COLOR_CODE_BIT_CODE_BYTES = 2;

			public int Symbol { get; }
			public int CodeBitsCount { get; }
			public int Code { get; }

			public HeaderColorItem(byte[] bytes, int startIndex) {
				Symbol = bytes[startIndex++];
				CodeBitsCount = bytes[startIndex++];
				Code = (int)bytes.AsUInt16(startIndex);
			}

			public HeaderColorItem(int symbol, int codeBitsCount, int code) {
				Symbol = symbol;
				CodeBitsCount = codeBitsCount;
				Code = code;
			}

			public static int GetBytesLength() {
				return HEADER_COLOR_SYMBOL_BYTES + HEADER_COLOR_CODE_BIT_COUNT_BYTES + HEADER_COLOR_CODE_BIT_CODE_BYTES;
			}
		}

		public HuffmanImageFrame Save(string path) {
			Data.SaveToFile(path);
			return this;
		}

		public static HuffmanImageFrame FromFile(string path) {
			return new HuffmanImageFrame(FileExtensions.ReadAllBytes(path));
		}

		public HuffmanImageFrame Open(string path) {
			_fromBytes(FileExtensions.ReadAllBytes(path));
			return this;
		}


	}
}
