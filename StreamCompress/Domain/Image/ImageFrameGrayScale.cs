
using StreamCompress.Utils;

namespace StreamCompress.Domain.Image {

	/// <summary>
	/// Present image frame which image is gray scale image
	/// </summary>
	public class ImageFrameGrayScale : ImageFrame, ISaveable<ImageFrameGrayScale> {

		/// <summary>
		/// Parametless constructor
		/// </summary>
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

		/// <summary>
		/// Saves image frame to file
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		ImageFrameGrayScale ISaveable<ImageFrameGrayScale>.Open(string path) {
			Open(path);
			return this;
		}

		/// <summary>
		/// Reads image frame from file
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		ImageFrameGrayScale ISaveable<ImageFrameGrayScale>.Save(string path) {
			Save(path);
			return this;
		}
	}
}
