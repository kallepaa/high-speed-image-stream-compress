using System;
using System.Text;

namespace StreamCompress {

	/// <summary>
	/// Extensions for byte and bit manipulation
	/// </summary>
	public static class BitAndByteExtensions {

		/// <summary>
		/// Set bit value to 1 in byte using given index
		/// </summary>
		/// <param name="b">Byte</param>
		/// <param name="bitIndex">Bit index</param>
		/// <returns>Modified byte</returns>
		public static byte SetBitToByte(this byte b, int bitIndex) {
			//shift bit to left to get value for addition
			var bitToAdd = (1 << bitIndex);
			var byteVal = (int)b;
			//add bit existing byte
			byteVal += bitToAdd;
			return (byte)byteVal;
		}

		/// <summary>
		/// Reads bit from byte using given index
		/// </summary>
		/// <param name="b">Byte</param>
		/// <param name="bitIndex">Bit index</param>
		/// <returns>True when bit is set to 1, otherwise false</returns>
		public static bool GetBitFromByte(this byte b, int bitIndex) {
			return (b & (1 << bitIndex)) != 0;
		}

		/// <summary>
		/// Converts 32 bit integer to byte array
		/// </summary>
		/// <param name="val">Value</param>
		/// <returns>Value as byte array</returns>
		public static byte[] AsBytes(this int val) {
			return BitConverter.GetBytes(val);
		}

		/// <summary>
		/// Converts 32 bit unsigned integer to byte array
		/// </summary>
		/// <param name="val">Value</param>
		/// <returns>Value as byte array</returns>
		public static byte[] AsBytes(this uint val) {
			return BitConverter.GetBytes(val);
		}

		/// <summary>
		/// Converts 16 bit unsigned integer to byte array
		/// </summary>
		/// <param name="val">Value</param>
		/// <returns>Value as byte array</returns>
		public static byte[] AsBytes(this ushort val) {
			return BitConverter.GetBytes(val);
		}


		/// <summary>
		/// Converts 4 bytes as 32 bit integer
		/// </summary>
		/// <param name="bytes">Source bytes</param>
		/// <param name="offset">Source offset</param>
		/// <returns>4 bytes as 32 bit integer</returns>
		public static int AsInt(this byte[] bytes, int offset) {
			if (bytes.Length < 4) {
				var b = new byte[4];
				bytes.CopyBytesTo(b, 0);
				return BitConverter.ToInt32(b, offset);
			}
			return BitConverter.ToInt32(bytes, offset);
		}

		/// <summary>
		/// Converts 2 bytes as 16 bit integer
		/// </summary>
		/// <param name="bytes">Source bytes</param>
		/// <param name="offset">Source offset</param>
		/// <returns>4 bytes as 16 bit integer</returns>
		public static ushort AsUInt16(this byte[] bytes, int offset) {
			return BitConverter.ToUInt16(bytes, offset);
		}

		/// <summary>
		/// Copies bytes from source to destionation array
		/// </summary>
		/// <param name="val">Source array</param>
		/// <param name="srcOffSet">Source offset</param>
		/// <param name="dest">Destination array</param>
		public static void CopyBytesTo(this byte[] val, int srcOffSet, byte[] dest) {
			Buffer.BlockCopy(val, srcOffSet, dest, 0, dest.Length);
		}

		/// <summary>
		/// Copies bytes from source to destionation array
		/// </summary>
		/// <param name="val">Source array</param>
		/// <param name="srcOffSet">Source offset</param>
		/// <param name="dest">Destination array</param>
		/// <param name="destOffSet">Destination offset</param>
		/// <param name="count">Copied bytes count</param>
		public static void CopyBytesTo(this byte[] val, int srcOffSet, byte[] dest, int destOffSet, int count) {
			Buffer.BlockCopy(val, srcOffSet, dest, destOffSet, count);
		}

		/// <summary>
		/// Copies bytes from source to destionation array
		/// </summary>
		/// <param name="val">Source array</param>
		/// <param name="dest">Destination array</param>
		/// <param name="destOffSet">Destination offset</param>
		public static void CopyBytesTo(this byte[] val, byte[] dest, int destOffSet) {
			Buffer.BlockCopy(val, 0, dest, destOffSet, val.Length);
		}

		public static byte[] Concatenate(this byte[] bytes1, byte[] bytes2) {
			var ret = new byte[bytes1.Length + bytes2.Length];
			bytes1.CopyBytesTo(ret, 0);
			bytes2.CopyBytesTo(ret, bytes1.Length);
			return ret;
		}

		public static bool Compare(this byte[] b1, byte[] b2) {
			if (b2 == null || b1.Length != b2.Length) {
				return false;
			}

			for (int i = 0; i < b1.Length; i++) {
				if(b1[i] != b2[i]) {
					return false;
				}
			}

			return true;
		}

	}
}
