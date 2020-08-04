using StreamCompress.Utils;
using System;

namespace StreamCompress.Domain.Image {

	/// <summary>
	/// Presents single image frame 
	/// </summary>
	public class ImageFrame : ISaveable<ImageFrame> {

		/// <summary>
		/// Bitmap image fixed header size
		/// </summary>
		public const int HEADER_BYTES = 54;
		/// <summary>
		/// Color table size when it contains 256 colors
		/// </summary>
		public const int HEADER_256_COLOR_TABLE_SIZE = 256 * 4;

		/// <summary>
		/// Image data with header
		/// </summary>
		public byte[] Image { get; internal set; }
		/// <summary>
		/// Header total bytes
		/// </summary>
		public int HeaderBytesLength { get; internal set; }
		/// <summary>
		/// Image width in pixels
		/// </summary>
		public int ImageWidthPx { get; internal set; }
		/// <summary>
		/// Image height in pixels
		/// </summary>
		public int ImageHeightPx { get; internal set; }
		/// <summary>
		/// How many bits is used to prsent single pixel
		/// </summary>
		public int BitsPerPixel => BitConverter.ToUInt16(Image, 28);

		public ImageFrame() {

		}

		/// <summary>
		/// Constructor to create image frame from byte array
		/// </summary>
		/// <param name="image">Bitmap image byte array</param>
		public ImageFrame(byte[] image) {
			FromBytes(image);
		}

		public void FromBytes(byte[] image) {
			Image = image;
			HeaderBytesLength = (int)BitConverter.ToUInt32(image, 10);
			ImageWidthPx = (int)BitConverter.ToUInt32(image, 18);
			ImageHeightPx = (int)BitConverter.ToUInt32(image, 22);
		}

		/// <summary>
		/// Sets size information to header
		/// </summary>
		/// <param name="length">Image total length</param>
		/// <param name="widthPx">Image width in pixels</param>
		/// <param name="heightPx">Image height in pixels</param>
		public void SetSizeInfo(uint length, int widthPx, int heightPx) {
			ImageHeightPx = heightPx;
			ImageWidthPx = widthPx;
			length.AsBytes().CopyBytesTo(Image, 2);
			widthPx.AsBytes().CopyBytesTo(Image, 18);
			heightPx.AsBytes().CopyBytesTo(Image, 22);
		}

		/// <summary>
		/// Reads image frame from file
		/// </summary>
		/// <param name="path">Filename</param>
		/// <returns>Image frame with image data</returns>
		public static ImageFrame FromFile(string path) {
			return new ImageFrame(FileExtensions.ReadAllBytes(path));
		}

		/// <summary>
		/// Saves image frame to file
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public ImageFrame Save(string path) {
			Image.SaveToFile(path);
			return this;
		}

		/// <summary>
		/// Reads image frame from file
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public ImageFrame Open(string path) {
			FromBytes(FileExtensions.ReadAllBytes(path));
			return this;
		}
	}
}
