using System;
using System.IO;

namespace StreamCompress.Utils {

	/// <summary>
	/// Wraps MemoryStream 
	/// </summary>
	public sealed class ByteMemoryStream : IDisposable {

		private readonly MemoryStream _memoryStream;
		private int Count { get; set; }

		/// <summary>
		/// Constructor for new memory stream
		/// </summary>
		/// <param name="initialSize">Initial buffer size</param>
		public ByteMemoryStream(int initialSize) {
			_memoryStream = new MemoryStream(initialSize);
		}

		/// <summary>
		/// Adds bytes to memory stream
		/// </summary>
		/// <param name="bytes">Bytes to add</param>
		public void AddBytes(byte[] bytes) {
			_memoryStream.Write(bytes, 0, bytes.Length);
			Count += bytes.Length;
		}

		/// <summary>
		/// Reads all bytes from memory stream
		/// </summary>
		/// <returns></returns>
		public byte[] ReadBytes() {
			var bytes = new byte[Count];
			_memoryStream.Position = 0;
			_memoryStream.Flush();
			_memoryStream.Read(bytes,0, bytes.Length);
			return bytes;
		}

		/// <summary>
		/// Finalize intance and release resources
		/// </summary>
		public void Dispose() {
			_memoryStream.Dispose();
			// Suppress finalization.
			GC.SuppressFinalize(this);
		}
	}
}
