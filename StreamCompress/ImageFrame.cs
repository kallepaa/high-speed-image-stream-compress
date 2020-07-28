using System;

namespace StreamCompress {

	/// <summary>
	/// Presents single image frame 
	/// </summary>
	public class ImageFrame {

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
		public byte[] Image { get; }
		/// <summary>
		/// Header total bytes
		/// </summary>
		public int HeaderBytesLength { get; }
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
		public int BitsPerPixel { get; }
		/// <summary>
		/// Image bit count without header
		/// </summary>
		public int ImageBits => ImageWidthPx * ImageHeightPx * BitsPerPixel;

		/// <summary>
		/// Constructor to create image frame from byte array
		/// </summary>
		/// <param name="image">Bitmap image byte array</param>
		public ImageFrame(byte[] image) {
			Image = image;
			HeaderBytesLength = (int)BitConverter.ToUInt32(image, 10);
			ImageWidthPx = (int)BitConverter.ToUInt32(image, 18);
			ImageHeightPx = (int)BitConverter.ToUInt32(image, 22);
			BitsPerPixel = (int)BitConverter.ToUInt16(image, 28);
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
		/// Saves image frame image to file
		/// </summary>
		/// <typeparam name="T">Image frame type</typeparam>
		/// <param name="path">Filename</param>
		/// <returns>Image frame</returns>
		public T Save<T>(string path) where T : ImageFrame {
			Image.SaveToFile(path);
			return (T)this;
		}
	}
}
