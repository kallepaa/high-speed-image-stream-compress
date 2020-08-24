using System;
using System.Text;

namespace StreamCompress.Utils {

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
		/// Converts 1 - 4 bytes as 32 bit integer
		/// </summary>
		/// <param name="bytes">Source bytes</param>
		/// <param name="offset">Source offset</param>
		/// <param name="count">Source bytes count</param>
		/// <returns>4 bytes as 32 bit integer</returns>
		public static int AsInt(this byte[] bytes, int offset, int count = 4) {
			if (bytes.Length < 4) {
				var b = new byte[4];
				bytes.CopyBytesTo(b, 0);
				return BitConverter.ToInt32(b);
			} else if (count < 4) {
				var b = new byte[4];
				bytes.CopyBytesTo(offset, b, 0, count);
				return BitConverter.ToInt32(b);
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

		public static byte[] AsBytes(this int val, int countOfBytes) {

			if (val < 0) {
				throw new ArgumentException("Value out of range");
			}

			var b = val.AsBytes();
			var ret = new byte[countOfBytes];

			for (int i = 0; i < countOfBytes; i++) {
				ret[i] = b[i];
			}

			for (int i = countOfBytes; i < b.Length; i++) {
				if (b[i] != 0) {
					throw new ArgumentException("Value out of range");
				}
			}

			return ret;
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

		/// <summary>
		/// Concatenates this byte array with given one
		/// </summary>
		/// <param name="bytes1">This</param>
		/// <param name="bytes2">Bytes to add</param>
		/// <returns></returns>
		public static byte[] Concatenate(this byte[] bytes1, byte[] bytes2) {
			var ret = new byte[bytes1.Length + bytes2.Length];
			bytes1.CopyBytesTo(ret, 0);
			bytes2.CopyBytesTo(ret, bytes1.Length);
			return ret;
		}

		/// <summary>
		/// Compares to byte arrays
		/// </summary>
		/// <param name="b1">this</param>
		/// <param name="b2">other</param>
		/// <returns>true when arrays are equal otherwise false</returns>
		public static bool Compare(this byte[] b1, byte[] b2) {

			if (b2 == null || b1.Length != b2.Length) {
				return false;
			}

			for (int i = 0; i < b1.Length; i++) {
				if (b1[i] != b2[i]) {
					return false;
				}
			}

			return true;
		}

		/// <summary>
		/// Populates bits code in array using order so that last index has most significant bit
		/// </summary>
		/// <param name="val">Input value</param>
		/// <param name="bits">How many bits</param>
		/// <returns></returns>
		public static bool[] GetBitTable(this int val, int bits) {
			var ret = new bool[bits];
			var code = val;
			var i = 0;
			while (code > 0) {
				var bit = (code & 1) == 1;
				ret[i++] = bit;
				code = code >> 1;
			}
			return ret;
		}

		/// <summary>
		/// Compress byte array of int values to byte array, which use minimum amount space based max int value
		/// </summary>
		/// <param name="val">Byte array of 32 bit integers</param>
		/// <param name="maxValue"></param>
		/// <param name="valueCount"></param>
		/// <returns></returns>
		public static byte[] AsCompressed(this byte[] val, int maxValue, int valueCount) {

			var maxCodeWordValue = maxValue;
			var maxValueUsingBits = 2;
			var maxBits = 1;

			while (maxValueUsingBits < maxCodeWordValue) {
				maxValueUsingBits *= 2;
				maxBits++;
			}

			var totalBits = valueCount * maxBits;
			var mod = totalBits % 8;

			if (mod != 0) {
				totalBits += 8 - mod;
			}

			var retBytes = new byte[totalBits / 8 + 5];
			retBytes[0] = (byte)maxBits;
			valueCount.AsBytes().CopyBytesTo(retBytes, 1);

			var retByteIndex = 5;
			var retBitIndex = 0; //read bits from right to left

			//write bit by bit values to ret array
			for (int i = 0; i < val.Length; i += 4) {
				var bitTable = val.AsInt(i).GetBitTable(maxBits);
				for (int j = 0; j < bitTable.Length; j++) {
					//write bits to byte from right to left
					if (retBitIndex == 8) {
						//switch to next byte and start writing from left of byte (most significant bit)
						retBitIndex = 0;
						retByteIndex++;
					}
					if (bitTable[j]) {
						retBytes[retByteIndex] = retBytes[retByteIndex].SetBitToByte(retBitIndex);
					}
					retBitIndex++;
				}
			}

			return retBytes;
		}

		public static byte[] AsDecompressed(this byte[] val) {

			var bitsPerValue = val[0];
			var valueCount = val.AsInt(1);

			var ret = new byte[valueCount * 4];
			var compressedBits = bitsPerValue * valueCount;

			var intByteIndex = 0;
			var valByteIndex = 5;
			var valBitIndex = 0;

			for (int i = 0; i < compressedBits; i += bitsPerValue) {

				var intBitIndex = 0;

				for (int j = 0; j < bitsPerValue; j++) {

					if (val[valByteIndex].GetBitFromByte(valBitIndex)) {
						ret[intByteIndex] = ret[intByteIndex].SetBitToByte(intBitIndex);
					}

					intBitIndex++;
					if (intBitIndex % 8 == 0) {
						intBitIndex = 0;
						intByteIndex++;
					}

					valBitIndex++;
					if (valBitIndex % 8 == 0) {
						valBitIndex = 0;
						valByteIndex++;
					}
				}
				intByteIndex += 4 - intByteIndex % 4;
			}




			return ret;
		}
	}
}
