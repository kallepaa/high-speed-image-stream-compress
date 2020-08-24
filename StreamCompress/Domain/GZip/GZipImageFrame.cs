using StreamCompress.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace StreamCompress.Domain.GZip {


	/// <summary>
	/// Presents single image frame in GZip compressed form
	/// </summary>
	public class GZipImageFrame : ISaveable<GZipImageFrame> {

		/// <summary>
		/// Byte array which contains compressed image
		/// </summary>
		public byte[] Data { get; internal set; }

		/// <summary>
		/// Constructor to create frame from byte array
		/// </summary>
		/// <param name="data"></param>
		public GZipImageFrame(byte[] data) {
			Data = data;
		}

		private void _fromBytes(byte[] data) {
			Data = data;
		}

		/// <summary>
		/// Parametless constructor
		/// </summary>
		public GZipImageFrame() {

		}
		/// <summary>
		/// Saves compressed image frame to file
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public GZipImageFrame Save(string path) {
			Data.SaveToFile(path);
			return this;
		}

		/// <summary>
		/// Reads comressed image frame from file
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public GZipImageFrame Open(string path) {
			_fromBytes(FileExtensions.ReadAllBytes(path));
			return this;
		}

	}
}
