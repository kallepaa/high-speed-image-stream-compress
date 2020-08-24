using StreamCompress.Domain.GZip;
using StreamCompress.Domain.Image;
using StreamCompress.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace StreamCompress.DomainExtensions.GZip {

	/// <summary>
	/// GZip extensions
	/// </summary>
	public static class Extensions {

		/// <summary>
		/// Decodes compressed image
		/// </summary>
		/// <typeparam name="T">Type of image</typeparam>
		/// <param name="encodedImage">Image encoded bytes</param>
		/// <returns></returns>
		public static T AsImageFrame<T>(this GZipImageFrame encodedImage) where T : ImageFrame, new() {
			var ret2 = new T();
			var ret = default(byte[]);
			using (var inputMs = new ByteMemoryStream(encodedImage.Data))
			using (var outputMs = new ByteMemoryStream(encodedImage.Data.Length * 2))
			using (GZipStream decompressionStream = new GZipStream(inputMs.MemoryStream, CompressionMode.Decompress)) {
				decompressionStream.CopyTo(outputMs.MemoryStream);
				ret = outputMs.ReadBytes();
			}
			ret2.FromBytes(ret);
			return ret2;
		}		
	}
}
