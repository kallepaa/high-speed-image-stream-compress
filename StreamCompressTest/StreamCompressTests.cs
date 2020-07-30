using StreamCompress;
using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Xunit;

namespace StreamCompressTest {
	public class StreamCompressTests {

		const string sourcePath = @"T:\Kalle\Videos\WebCamStreams\1\source";
		const string destPath = @"T:\Kalle\Videos\WebCamStreams\1\tmp";
		const int sourceFrameStartIndex = 0;
		const int sourceFrameCount = 1;
		const int minExpectedFPS = 240;

		public class SimpleTests {

			[Theory]
			[InlineData("babaabaaa")]
			public void AsLZEncodedAndDecoded(string val) {
				var strEncoder = Encoding.GetEncoding("iso-8859-1");
				var b = strEncoder.GetBytes(val);
				var encoded = b.AsLZEncoded(389);
				var decoded = encoded.AsLZDecoded(389);
				var valDecoded = strEncoder.GetString(decoded);
				Assert.Equal(val, valDecoded);
			}

			[Theory]
			[InlineData(10, 389)]
			[InlineData(100, 389)]
			[InlineData(1000, 389)]
			[InlineData(10000, 389)]
			[InlineData(100000, 389)]
			[InlineData(1000000, 12289)]
			[InlineData(10000000, 393241)]
			public void AsLZEncodedAndDecodedRandom(int length, int prime) {
				var strEncoder = Encoding.GetEncoding("iso-8859-1");
				var b = new byte[length];
				var rand = new Random();
				for (int i = 0; i < length; i++) {
					b[i] = (byte)rand.Next(0, 255);
				}
				var val = strEncoder.GetString(b);
				var encoded = b.AsLZEncoded(prime);
				var decoded = encoded.AsLZDecoded(prime);
				var valDecoded = strEncoder.GetString(decoded);
				Assert.Equal(val, valDecoded);
			}
		}

		public class LZImageFrameTests {
			[Theory]
			//[InlineData(389)]
			//[InlineData(769)]
			//[InlineData(1543)]
			//[InlineData(3079)]
			//[InlineData(6151)]
			[InlineData(12289)]
			//[InlineData(24593)]
			//[InlineData(49157)]
			//[InlineData(98317)]
			//[InlineData(196613)]
			//[InlineData(393241)]
			//[InlineData(786469)]
			//[InlineData(1572869)]
			public void AsLZEncodedAndDecoded(int hastablePrime) {
				var i = 1;
				var sourceFile = FileExtensions.PathCombine(sourcePath, $"{i.ToString("00000")}-first-frame-color.bmp");
				var image = ImageFrame.FromFile(sourceFile);
				var encoded = image.AsLZEncoded(hastablePrime);
				var decoded = encoded.AsImageFrame(hastablePrime);
				Assert.True(image.Image.Length == decoded.Image.Length);
			}
		}

	}
}
