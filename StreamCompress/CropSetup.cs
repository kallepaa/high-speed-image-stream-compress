
namespace StreamCompress {

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
	}
}
