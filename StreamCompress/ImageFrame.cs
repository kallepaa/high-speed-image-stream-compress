using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StreamCompress {
	public class ImageFrame {

		public byte[] Image { get; }
		public int HeaderBytesLength { get; set; }
		public int ImageWidthPx { get; }
		public int ImageHeightPx { get; }
		public int BitsPerPixel { get; }


		public ImageFrame(byte[] image) {
			Image = image;
			HeaderBytesLength = (int)BitConverter.ToUInt32(image, 10);
			ImageWidthPx = (int)BitConverter.ToUInt32(image, 18);
			ImageHeightPx = (int)BitConverter.ToUInt32(image, 22);
			BitsPerPixel = (int)BitConverter.ToUInt16(image, 28);
		}

		public static ImageFrame FromFile(string path) {
			return new ImageFrame(File.ReadAllBytes(path));
		}

		public void Save(string path) {
			File.WriteAllBytes(path, Image);
		}

		public string HeaderInfo() {

			var ret = new StringBuilder();

			ret.AppendLine($"Filetype: {BitConverter.ToUInt16(Image, 0)}");
			ret.AppendLine($"Filesize : {BitConverter.ToUInt32(Image, 2)}");
			ret.AppendLine($"Reserved : {BitConverter.ToUInt16(Image, 6)}");
			ret.AppendLine($"Reserved : {BitConverter.ToUInt16(Image, 8)}");
			ret.AppendLine($"PixelDataOffSet : {BitConverter.ToUInt32(Image, 10)}");
			ret.AppendLine($"HeaderSize : {BitConverter.ToUInt32(Image, 14)}");
			ret.AppendLine($"ImageWidth : {BitConverter.ToUInt32(Image, 18)}");
			ret.AppendLine($"ImageHeight : {BitConverter.ToUInt32(Image, 22)}");
			ret.AppendLine($"Planes : {BitConverter.ToUInt16(Image, 26)}");
			ret.AppendLine($"BitsPerPixel : {BitConverter.ToUInt16(Image, 28)}");
			ret.AppendLine($"Compression : {BitConverter.ToUInt32(Image, 30)}");
			ret.AppendLine($"ImageSize : {BitConverter.ToUInt32(Image, 34)}");
			ret.AppendLine($"XpixelsPerMeter : {BitConverter.ToUInt32(Image, 38)}");
			ret.AppendLine($"YpixelsPerMeter : {BitConverter.ToUInt32(Image, 42)}");
			ret.AppendLine($"TotalColors : {BitConverter.ToUInt32(Image, 46)}");
			ret.AppendLine($"ImportantColors : {BitConverter.ToUInt32(Image, 50)}");

			//				var colorBytes = (int)pixelDataOffSet - header.Length;

			//				if (colorBytes > 0 && true) {

			//					var colors = new byte[colorBytes];
			//					file.Read(colors, 0, colors.Length);
			//					var colorIndexes = colorBytes / 4;

			//					Console.WriteLine($"COLOR TABLE Colors {colorIndexes}");

			//					for (int colorIndex = 0; colorIndex < colorIndexes; colorIndex++) {
			//						var colorIndexStartPos = 4 * colorIndex;
			//						Console.WriteLine($"rgb({((int)colors[colorIndexStartPos])}, {((int)colors[colorIndexStartPos + 1])}, {((int)colors[colorIndexStartPos + 2])})");

			////						Console.WriteLine($"#{((int)colors[colorIndexStartPos]).ToString("X2")}{((int)colors[colorIndexStartPos+1]).ToString("X2")}{((int)colors[colorIndexStartPos+2]).ToString("X2")}");
			//					}
			//				}


			return ret.ToString();
		}



	}
}
