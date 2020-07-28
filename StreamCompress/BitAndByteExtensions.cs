using System;
using System.Text;

namespace StreamCompress {
	public static class BitAndByteExtensions {

		/// <summary>
		/// For debuging reasons to get code as string presentation
		/// </summary>
		/// <returns></returns>
		public static string GetCodeBitsAsString<T>(this HuffmanTreeNode<T> node) {

			var sb = new StringBuilder();
			var code = node.Code;

			while (code > 0) {
				sb.Append(code & 1);
				code = code >> 1;
			}

			var str = new char[sb.Length];
			//reverse order
			var j = 0;

			for (int i = sb.Length - 1; i >= 0; i--) {
				str[j++] = sb[i];
			}

			return new string(str).PadLeft(node.CodeBits, '0');
		}

		public static byte SetBitToByte(this byte b, int bitIndex) {
			//shift bit to left to get value for addition
			var bitToAdd = (1 << bitIndex);
			var byteVal = (int)b;
			//add bit existing byte
			byteVal += bitToAdd;
			return (byte)byteVal;
		}

		public static bool GetBitFromByte(this byte b, int bitIndex) {
			return (b & (1 << bitIndex)) != 0;
		}

		public static byte[] AsBytes(this int val) {
			return BitConverter.GetBytes(val);
		}

		public static byte[] AsBytes(this uint val) {
			return BitConverter.GetBytes(val);
		}

		public static int AsInt(this byte[] bytes, int offset) {
			return BitConverter.ToInt32(bytes, offset);
		}

		public static uint AsUInt16(this byte[] bytes, int offset) {
			return BitConverter.ToUInt16(bytes, offset);
		}

		public static void CopyBytesTo(this byte[] val, int srcOffSet, byte[] dest) {
			Buffer.BlockCopy(val, srcOffSet, dest, 0, dest.Length);
		}

		public static void CopyBytesTo(this byte[] val, int srcOffSet, byte[] dest, int destOffSet, int count) {
			Buffer.BlockCopy(val, srcOffSet, dest, destOffSet, count);
		}

		public static void CopyBytesTo(this byte[] val, byte[] dest, int destOffSet) {
			Buffer.BlockCopy(val, 0, dest, destOffSet, val.Length);
		}

	}
}
