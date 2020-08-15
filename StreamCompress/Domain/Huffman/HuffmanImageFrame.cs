using StreamCompress.Utils;

namespace StreamCompress.Domain.Huffman {

	/// <summary>
	/// Presents single image frame as Huffman encoded
	/// </summary>
	public class HuffmanImageFrame : ISaveable<HuffmanImageFrame> {

		/// <summary>
		/// Compressed bits header field length in bytes
		/// </summary>
		public const int HEADER_COMPRESSED_BITS_BYTES = 4;
		/// <summary>
		/// Compressed bits header field position
		/// </summary>
		public const int HEADER_COMPRESSED_BITS_BYTES_POS = 0;

		/// <summary>
		/// Max code length header field length in bytes
		/// </summary>
		public const int HEADER_MAX_CODE_BITS_BYTES = 4;
		/// <summary>
		/// Max code length  header field position
		/// </summary>
		public const int HEADER_MAX_CODE_BITS_BYTES_POS = 4;

		/// <summary>
		/// Color code count header field length in bytes
		/// </summary>
		public const int HEADER_COLOR_CODE_COUNT_BYTES = 4;

		/// <summary>
		/// Color code count  header field position
		/// </summary>
		public const int HEADER_COLOR_CODE_COUNT_BYTES_POS = 8;

		/// <summary>
		/// Original image header header field length in bytes
		/// </summary>
		public const int HEADER_ORIGINAL_IMAGE_HEADER_BYTES = 4;

		/// <summary>
		/// Original image header  header field position
		/// </summary>
		public const int HEADER_ORIGINAL_IMAGE_HEADER_BYTES_POS = 12;

		/// <summary>
		/// Original image data header field length in bytes
		/// </summary>
		public const int HEADER_ORIGINAL_IMAGE_DATA_BYTES = 4;

		/// <summary>
		/// Original image data header field position
		/// </summary>
		public const int HEADER_ORIGINAL_IMAGE_DATA_BYTES_POS = 16;

		/// <summary>
		/// Total size of header
		/// </summary>
		public int FixedHeaderLength => HEADER_COMPRESSED_BITS_BYTES + HEADER_MAX_CODE_BITS_BYTES + HEADER_COLOR_CODE_COUNT_BYTES + HEADER_ORIGINAL_IMAGE_HEADER_BYTES + HEADER_ORIGINAL_IMAGE_DATA_BYTES;
		/// <summary>
		/// Total size of color header
		/// </summary>
		public int ColorCodeHeaderLength => ColorCodeCount * HeaderColorItem.GetBytesLength();
		/// <summary>
		/// Image off set
		/// </summary>
		public int ImageDataOffSet => FixedHeaderLength + ColorCodeHeaderLength + OriginalImageHeaderLength;

		/// <summary>
		/// Frame data header + image
		/// </summary>
		public byte[] Data { get; internal set; }
		/// <summary>
		/// Compressed bits count
		/// </summary>
		public int CompressedBits { get; internal set; }
		/// <summary>
		/// Longest bit length
		/// </summary>
		public int MaxCodeBitsLength { get; internal set; }
		/// <summary>
		/// Count of color codes
		/// </summary>
		public int ColorCodeCount { get; internal set; }
		/// <summary>
		/// Original image header length
		/// </summary>
		public int OriginalImageHeaderLength { get; internal set; }
		/// <summary>
		/// Original image data length
		/// </summary>
		public int OriginalImageDataLength { get; internal set; }

		/// <summary>
		/// Constructor for huffamn encoded image frame
		/// </summary>
		/// <param name="compressedBits">Compressed bits count</param>
		/// <param name="colorCodes">Color code count</param>
		/// <param name="maxCodeBitsLength">Longest bit length</param>
		/// <param name="originalImageDataLength">Original image header length</param>
		/// <param name="originalImageHeader">Original image header</param>
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

		/// <summary>
		/// New huffman image frame from given data
		/// </summary>
		/// <param name="data"></param>
		public HuffmanImageFrame(byte[] data) {
			_fromBytes(data);
		}

		/// <summary>
		/// Parametless constructor
		/// </summary>
		public HuffmanImageFrame() {}

		private void _fromBytes(byte[] data) {
			Data = data;
			CompressedBits = data.AsInt(HEADER_COMPRESSED_BITS_BYTES_POS);
			MaxCodeBitsLength = data.AsInt(HEADER_MAX_CODE_BITS_BYTES_POS);
			ColorCodeCount = data.AsInt(HEADER_COLOR_CODE_COUNT_BYTES_POS);
			OriginalImageHeaderLength = data.AsInt(HEADER_ORIGINAL_IMAGE_HEADER_BYTES_POS);
			OriginalImageDataLength = data.AsInt(HEADER_ORIGINAL_IMAGE_DATA_BYTES_POS);
		}

		/// <summary>
		/// Reads color code item from header from given index
		/// </summary>
		/// <param name="index">Color code index</param>
		/// <returns>Color code from given index</returns>
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

		/// <summary>
		/// Check if bit is set in byte in given index. Read direction is from left to right.
		/// </summary>
		/// <param name="index">Bit position in byte</param>
		/// <returns>If bit is set then true otherwise false</returns>
		public bool GetBit(int index) {
			var byteIndex = index / 8;
			//read byte from left to right
			var bitPos = 7 - index % 8;
			var b = Data[byteIndex + ImageDataOffSet];
			return b.GetBitFromByte(bitPos);
		}

		/// <summary>
		/// Header color item
		/// </summary>
		public class HeaderColorItem {

			/// <summary>
			/// Bytes used for color symbol
			/// </summary>
			public const int HEADER_COLOR_SYMBOL_BYTES = 1;
			/// <summary>
			/// Bytes used for color code bit count
			/// </summary>
			public const int HEADER_COLOR_CODE_BIT_COUNT_BYTES = 1;
			/// <summary>
			/// Bytes used for color code
			/// </summary>
			public const int HEADER_COLOR_CODE_BIT_CODE_BYTES = 2;

			/// <summary>
			/// Symbole
			/// </summary>
			public int Symbol { get; }
			/// <summary>
			/// Bits
			/// </summary>
			public int CodeBitsCount { get; }
			/// <summary>
			/// Code
			/// </summary>
			public int Code { get; }

			/// <summary>
			/// Init color item using given byte array and reading data from it from given index
			/// </summary>
			/// <param name="bytes">Byte array, which contains header item</param>
			/// <param name="startIndex">Item start index in byte array</param>
			public HeaderColorItem(byte[] bytes, int startIndex) {
				Symbol = bytes[startIndex++];
				CodeBitsCount = bytes[startIndex++];
				Code = bytes.AsUInt16(startIndex);
			}

			/// <summary>
			/// Init new item using given values
			/// </summary>
			/// <param name="symbol"></param>
			/// <param name="codeBitsCount"></param>
			/// <param name="code"></param>
			public HeaderColorItem(int symbol, int codeBitsCount, int code) {
				Symbol = symbol;
				CodeBitsCount = codeBitsCount;
				Code = code;
			}

			/// <summary>
			/// Header item length in header
			/// </summary>
			/// <returns></returns>
			public static int GetBytesLength() {
				return HEADER_COLOR_SYMBOL_BYTES + HEADER_COLOR_CODE_BIT_COUNT_BYTES + HEADER_COLOR_CODE_BIT_CODE_BYTES;
			}
		}

		/// <summary>
		/// Saves data to given file
		/// </summary>
		/// <param name="path">Path</param>
		/// <returns></returns>
		public HuffmanImageFrame Save(string path) {
			Data.SaveToFile(path);
			return this;
		}

		/// <summary>
		/// Open huffman image frmae from file
		/// </summary>
		/// <param name="path">Path</param>
		/// <returns></returns>
		public HuffmanImageFrame Open(string path) {
			_fromBytes(FileExtensions.ReadAllBytes(path));
			return this;
		}


	}
}
