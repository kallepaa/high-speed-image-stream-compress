﻿
namespace StreamCompress.Domain.Image {

	/// <summary>
	/// Presents image crop information
	/// </summary>
	public class CropSetup {
		/// <summary>
		/// Pixels to crop from left
		/// </summary>
		public int LeftPx { get; set; }
		/// <summary>
		/// Pixels to crop from right
		/// </summary>
		public int RightPx { get; set; }
		/// <summary>
		/// Pixels to crop from top
		/// </summary>
		public int TopPx { get; set; }
		/// <summary>
		/// Pixels to crop from bottom
		/// </summary>
		public int BottomPx { get; set; }

		public bool IsAnyCropSet() {
			return LeftPx > 0 || RightPx > 0 || TopPx > 0 || BottomPx > 0;
		}
	}
}
