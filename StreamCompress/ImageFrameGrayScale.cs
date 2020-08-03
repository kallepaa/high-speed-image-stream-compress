
namespace StreamCompress {

	/// <summary>
	/// Present image frame which image is gray scale image
	/// </summary>
	public class ImageFrameGrayScale : ImageFrame, ISaveable<ImageFrameGrayScale> {

		public ImageFrameGrayScale() {

		}

		/// <summary>
		/// Constructor to create image frame from byte array
		/// </summary>
		/// <param name="image">Bitmap image byte array</param>
		public ImageFrameGrayScale(byte[] image) : base(image) {
		}

		/// <summary>
		/// Generates color table to image header
		/// </summary>
		public void SetColorTable() {
			for (int i = 0; i < 255; i++) {
				var bytes = new byte[4] { (byte)i, (byte)i, (byte)i, 0 };
				bytes.CopyBytesTo(0, Image, i * 4 + HEADER_BYTES, 4);
			}
		}

		ImageFrameGrayScale ISaveable<ImageFrameGrayScale>.Open(string path) {
			Open(path);
			return this;
		}

		ImageFrameGrayScale ISaveable<ImageFrameGrayScale>.Save(string path) {
			Save(path);
			return this;
		}
	}
}
