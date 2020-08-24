using System;
using System.IO;

namespace StreamCompress.Utils {

	/// <summary>
	/// Wraps MemoryStream 
	/// </summary>
	public sealed class ByteMemoryStream : IDisposable {

		public readonly MemoryStream MemoryStream;
		private int Count { get; set; }

		/// <summary>
		/// Constructor for new memory stream
		/// </summary>
		/// <param name="initialSize">Initial buffer size</param>
		public ByteMemoryStream(int initialSize) {
			MemoryStream = new MemoryStream(initialSize);
		}

		/// <summary>
		/// Constructor for new memory stream
		/// </summary>
		/// <param name="buffer">Initial data</param>
		public ByteMemoryStream(byte[] buffer) {
			MemoryStream = new MemoryStream(buffer);
			Count = buffer.Length;
		}

		/// <summary>
		/// Adds bytes to memory stream
		/// </summary>
		/// <param name="bytes">Bytes to add</param>
		public void AddBytes(byte[] bytes) {
			MemoryStream.Write(bytes, 0, bytes.Length);
			Count += bytes.Length;
		}

		/// <summary>
		/// Reads all bytes from memory stream
		/// </summary>
		/// <returns></returns>
		public byte[] ReadBytes() {
			var bytes = new byte[Count];
			MemoryStream.Position = 0;
			MemoryStream.Flush();
			MemoryStream.Read(bytes,0, bytes.Length);
			return bytes;
		}

		/// <summary>
		/// Finalize intance and release resources
		/// </summary>
		public void Dispose() {
			MemoryStream.Dispose();
			// Suppress finalization.
			GC.SuppressFinalize(this);
		}
	}
}
