<a name='assembly'></a>
# StreamCompress

## Contents

- [BitAndByteExtensions](#T-StreamCompress-Utils-BitAndByteExtensions 'StreamCompress.Utils.BitAndByteExtensions')
  - [AsBytes(val)](#M-StreamCompress-Utils-BitAndByteExtensions-AsBytes-System-Int32- 'StreamCompress.Utils.BitAndByteExtensions.AsBytes(System.Int32)')
  - [AsBytes(val)](#M-StreamCompress-Utils-BitAndByteExtensions-AsBytes-System-UInt32- 'StreamCompress.Utils.BitAndByteExtensions.AsBytes(System.UInt32)')
  - [AsBytes(val)](#M-StreamCompress-Utils-BitAndByteExtensions-AsBytes-System-UInt16- 'StreamCompress.Utils.BitAndByteExtensions.AsBytes(System.UInt16)')
  - [AsCompressed(val,maxValue,valueCount)](#M-StreamCompress-Utils-BitAndByteExtensions-AsCompressed-System-Byte[],System-Int32,System-Int32- 'StreamCompress.Utils.BitAndByteExtensions.AsCompressed(System.Byte[],System.Int32,System.Int32)')
  - [AsDecompressed(val)](#M-StreamCompress-Utils-BitAndByteExtensions-AsDecompressed-System-Byte[]- 'StreamCompress.Utils.BitAndByteExtensions.AsDecompressed(System.Byte[])')
  - [AsInt(bytes,offset,count)](#M-StreamCompress-Utils-BitAndByteExtensions-AsInt-System-Byte[],System-Int32,System-Int32- 'StreamCompress.Utils.BitAndByteExtensions.AsInt(System.Byte[],System.Int32,System.Int32)')
  - [AsUInt16(bytes,offset)](#M-StreamCompress-Utils-BitAndByteExtensions-AsUInt16-System-Byte[],System-Int32- 'StreamCompress.Utils.BitAndByteExtensions.AsUInt16(System.Byte[],System.Int32)')
  - [Compare(b1,b2)](#M-StreamCompress-Utils-BitAndByteExtensions-Compare-System-Byte[],System-Byte[]- 'StreamCompress.Utils.BitAndByteExtensions.Compare(System.Byte[],System.Byte[])')
  - [Concatenate(bytes1,bytes2)](#M-StreamCompress-Utils-BitAndByteExtensions-Concatenate-System-Byte[],System-Byte[]- 'StreamCompress.Utils.BitAndByteExtensions.Concatenate(System.Byte[],System.Byte[])')
  - [CopyBytesTo(val,srcOffSet,dest)](#M-StreamCompress-Utils-BitAndByteExtensions-CopyBytesTo-System-Byte[],System-Int32,System-Byte[]- 'StreamCompress.Utils.BitAndByteExtensions.CopyBytesTo(System.Byte[],System.Int32,System.Byte[])')
  - [CopyBytesTo(val,srcOffSet,dest,destOffSet,count)](#M-StreamCompress-Utils-BitAndByteExtensions-CopyBytesTo-System-Byte[],System-Int32,System-Byte[],System-Int32,System-Int32- 'StreamCompress.Utils.BitAndByteExtensions.CopyBytesTo(System.Byte[],System.Int32,System.Byte[],System.Int32,System.Int32)')
  - [CopyBytesTo(val,dest,destOffSet)](#M-StreamCompress-Utils-BitAndByteExtensions-CopyBytesTo-System-Byte[],System-Byte[],System-Int32- 'StreamCompress.Utils.BitAndByteExtensions.CopyBytesTo(System.Byte[],System.Byte[],System.Int32)')
  - [GetBitFromByte(b,bitIndex)](#M-StreamCompress-Utils-BitAndByteExtensions-GetBitFromByte-System-Byte,System-Int32- 'StreamCompress.Utils.BitAndByteExtensions.GetBitFromByte(System.Byte,System.Int32)')
  - [GetBitTable(val,bits)](#M-StreamCompress-Utils-BitAndByteExtensions-GetBitTable-System-Int32,System-Int32- 'StreamCompress.Utils.BitAndByteExtensions.GetBitTable(System.Int32,System.Int32)')
  - [SetBitToByte(b,bitIndex)](#M-StreamCompress-Utils-BitAndByteExtensions-SetBitToByte-System-Byte,System-Int32- 'StreamCompress.Utils.BitAndByteExtensions.SetBitToByte(System.Byte,System.Int32)')
- [ByteMemoryStream](#T-StreamCompress-Utils-ByteMemoryStream 'StreamCompress.Utils.ByteMemoryStream')
  - [#ctor(initialSize)](#M-StreamCompress-Utils-ByteMemoryStream-#ctor-System-Int32- 'StreamCompress.Utils.ByteMemoryStream.#ctor(System.Int32)')
  - [#ctor(buffer)](#M-StreamCompress-Utils-ByteMemoryStream-#ctor-System-Byte[]- 'StreamCompress.Utils.ByteMemoryStream.#ctor(System.Byte[])')
  - [AddBytes(bytes)](#M-StreamCompress-Utils-ByteMemoryStream-AddBytes-System-Byte[]- 'StreamCompress.Utils.ByteMemoryStream.AddBytes(System.Byte[])')
  - [Dispose()](#M-StreamCompress-Utils-ByteMemoryStream-Dispose 'StreamCompress.Utils.ByteMemoryStream.Dispose')
  - [ReadBytes()](#M-StreamCompress-Utils-ByteMemoryStream-ReadBytes 'StreamCompress.Utils.ByteMemoryStream.ReadBytes')
- [CommandLineArgs](#T-StreamCompress-Program-CommandLineArgs 'StreamCompress.Program.CommandLineArgs')
  - [Count](#P-StreamCompress-Program-CommandLineArgs-Count 'StreamCompress.Program.CommandLineArgs.Count')
  - [CropBottomPx](#P-StreamCompress-Program-CommandLineArgs-CropBottomPx 'StreamCompress.Program.CommandLineArgs.CropBottomPx')
  - [CropLeftPx](#P-StreamCompress-Program-CommandLineArgs-CropLeftPx 'StreamCompress.Program.CommandLineArgs.CropLeftPx')
  - [CropRightPx](#P-StreamCompress-Program-CommandLineArgs-CropRightPx 'StreamCompress.Program.CommandLineArgs.CropRightPx')
  - [CropTopPx](#P-StreamCompress-Program-CommandLineArgs-CropTopPx 'StreamCompress.Program.CommandLineArgs.CropTopPx')
  - [DestinationFileSuffix](#P-StreamCompress-Program-CommandLineArgs-DestinationFileSuffix 'StreamCompress.Program.CommandLineArgs.DestinationFileSuffix')
  - [DestinationPath](#P-StreamCompress-Program-CommandLineArgs-DestinationPath 'StreamCompress.Program.CommandLineArgs.DestinationPath')
  - [GrayScaleColors](#P-StreamCompress-Program-CommandLineArgs-GrayScaleColors 'StreamCompress.Program.CommandLineArgs.GrayScaleColors')
  - [LZCompressionDictionary](#P-StreamCompress-Program-CommandLineArgs-LZCompressionDictionary 'StreamCompress.Program.CommandLineArgs.LZCompressionDictionary')
  - [LZCompressionHashTablePrime](#P-StreamCompress-Program-CommandLineArgs-LZCompressionHashTablePrime 'StreamCompress.Program.CommandLineArgs.LZCompressionHashTablePrime')
  - [LZCompressionTrieInitialCapacity](#P-StreamCompress-Program-CommandLineArgs-LZCompressionTrieInitialCapacity 'StreamCompress.Program.CommandLineArgs.LZCompressionTrieInitialCapacity')
  - [Method](#P-StreamCompress-Program-CommandLineArgs-Method 'StreamCompress.Program.CommandLineArgs.Method')
  - [SourceFileSuffix](#P-StreamCompress-Program-CommandLineArgs-SourceFileSuffix 'StreamCompress.Program.CommandLineArgs.SourceFileSuffix')
  - [SourcePath](#P-StreamCompress-Program-CommandLineArgs-SourcePath 'StreamCompress.Program.CommandLineArgs.SourcePath')
  - [StartIndex](#P-StreamCompress-Program-CommandLineArgs-StartIndex 'StreamCompress.Program.CommandLineArgs.StartIndex')
- [CropSetup](#T-StreamCompress-Domain-Image-CropSetup 'StreamCompress.Domain.Image.CropSetup')
  - [BottomPx](#P-StreamCompress-Domain-Image-CropSetup-BottomPx 'StreamCompress.Domain.Image.CropSetup.BottomPx')
  - [LeftPx](#P-StreamCompress-Domain-Image-CropSetup-LeftPx 'StreamCompress.Domain.Image.CropSetup.LeftPx')
  - [RightPx](#P-StreamCompress-Domain-Image-CropSetup-RightPx 'StreamCompress.Domain.Image.CropSetup.RightPx')
  - [TopPx](#P-StreamCompress-Domain-Image-CropSetup-TopPx 'StreamCompress.Domain.Image.CropSetup.TopPx')
- [Extensions](#T-StreamCompress-DomainExtensions-GZip-Extensions 'StreamCompress.DomainExtensions.GZip.Extensions')
- [Extensions](#T-StreamCompress-DomainExtensions-Huffman-Extensions 'StreamCompress.DomainExtensions.Huffman.Extensions')
- [Extensions](#T-StreamCompress-DomainExtensions-Image-Extensions 'StreamCompress.DomainExtensions.Image.Extensions')
- [Extensions](#T-StreamCompress-DomainExtensions-LZ-Extensions 'StreamCompress.DomainExtensions.LZ.Extensions')
  - [AsImageFrame\`\`1(encodedImage)](#M-StreamCompress-DomainExtensions-GZip-Extensions-AsImageFrame``1-StreamCompress-Domain-GZip-GZipImageFrame- 'StreamCompress.DomainExtensions.GZip.Extensions.AsImageFrame``1(StreamCompress.Domain.GZip.GZipImageFrame)')
  - [AsImageGrayScaleFrame(encodedImage)](#M-StreamCompress-DomainExtensions-Huffman-Extensions-AsImageGrayScaleFrame-StreamCompress-Domain-Huffman-HuffmanImageFrame- 'StreamCompress.DomainExtensions.Huffman.Extensions.AsImageGrayScaleFrame(StreamCompress.Domain.Huffman.HuffmanImageFrame)')
  - [AsCropSetup(a)](#M-StreamCompress-DomainExtensions-Image-Extensions-AsCropSetup-StreamCompress-Program-CommandLineArgs- 'StreamCompress.DomainExtensions.Image.Extensions.AsCropSetup(StreamCompress.Program.CommandLineArgs)')
  - [AsCroppedImage(image,cropSetup)](#M-StreamCompress-DomainExtensions-Image-Extensions-AsCroppedImage-StreamCompress-Domain-Image-ImageFrame,StreamCompress-Domain-Image-CropSetup- 'StreamCompress.DomainExtensions.Image.Extensions.AsCroppedImage(StreamCompress.Domain.Image.ImageFrame,StreamCompress.Domain.Image.CropSetup)')
  - [AsGZipEncoded\`\`1(image)](#M-StreamCompress-DomainExtensions-Image-Extensions-AsGZipEncoded``1-``0- 'StreamCompress.DomainExtensions.Image.Extensions.AsGZipEncoded``1(``0)')
  - [AsGrayScale(image,colors)](#M-StreamCompress-DomainExtensions-Image-Extensions-AsGrayScale-StreamCompress-Domain-Image-ImageFrame,System-Int32- 'StreamCompress.DomainExtensions.Image.Extensions.AsGrayScale(StreamCompress.Domain.Image.ImageFrame,System.Int32)')
  - [AsHuffmanEncoded(image)](#M-StreamCompress-DomainExtensions-Image-Extensions-AsHuffmanEncoded-StreamCompress-Domain-Image-ImageFrameGrayScale- 'StreamCompress.DomainExtensions.Image.Extensions.AsHuffmanEncoded(StreamCompress.Domain.Image.ImageFrameGrayScale)')
  - [AsLZEncodedUsingHashTable\`\`1(image,hashPrime)](#M-StreamCompress-DomainExtensions-Image-Extensions-AsLZEncodedUsingHashTable``1-``0,System-Int32- 'StreamCompress.DomainExtensions.Image.Extensions.AsLZEncodedUsingHashTable``1(``0,System.Int32)')
  - [AsLZEncodedUsingTrie256\`\`1(image)](#M-StreamCompress-DomainExtensions-Image-Extensions-AsLZEncodedUsingTrie256``1-``0- 'StreamCompress.DomainExtensions.Image.Extensions.AsLZEncodedUsingTrie256``1(``0)')
  - [AsLZEncodedUsingTrie\`\`1(image,nodeInitialCapacity)](#M-StreamCompress-DomainExtensions-Image-Extensions-AsLZEncodedUsingTrie``1-``0,System-Int32- 'StreamCompress.DomainExtensions.Image.Extensions.AsLZEncodedUsingTrie``1(``0,System.Int32)')
  - [AsPlanted(image,plantWidthPx,plantHeightPx)](#M-StreamCompress-DomainExtensions-Image-Extensions-AsPlanted-StreamCompress-Domain-Image-ImageFrameGrayScale,System-Int32,System-Int32- 'StreamCompress.DomainExtensions.Image.Extensions.AsPlanted(StreamCompress.Domain.Image.ImageFrameGrayScale,System.Int32,System.Int32)')
  - [BytesAsLZEncodedUsingHashTable(input,hashPrime)](#M-StreamCompress-DomainExtensions-Image-Extensions-BytesAsLZEncodedUsingHashTable-System-Byte[],System-Int32- 'StreamCompress.DomainExtensions.Image.Extensions.BytesAsLZEncodedUsingHashTable(System.Byte[],System.Int32)')
  - [BytesAsLZEncodedUsingTrie(input,nodeInitialCapacity)](#M-StreamCompress-DomainExtensions-Image-Extensions-BytesAsLZEncodedUsingTrie-System-Byte[],System-Int32- 'StreamCompress.DomainExtensions.Image.Extensions.BytesAsLZEncodedUsingTrie(System.Byte[],System.Int32)')
  - [BytesAsLZEncodedUsingTrie256(input)](#M-StreamCompress-DomainExtensions-Image-Extensions-BytesAsLZEncodedUsingTrie256-System-Byte[]- 'StreamCompress.DomainExtensions.Image.Extensions.BytesAsLZEncodedUsingTrie256(System.Byte[])')
  - [_asLZEncoded(input,encoderDic)](#M-StreamCompress-DomainExtensions-Image-Extensions-_asLZEncoded-System-Byte[],StreamCompress-Domain-LZ-ILZ78CodingTable{System-Int32}- 'StreamCompress.DomainExtensions.Image.Extensions._asLZEncoded(System.Byte[],StreamCompress.Domain.LZ.ILZ78CodingTable{System.Int32})')
  - [AsImageFrameUsingHashTable\`\`1(encodedImage,hashPrime)](#M-StreamCompress-DomainExtensions-LZ-Extensions-AsImageFrameUsingHashTable``1-StreamCompress-Domain-LZ-LZImageFrame,System-Int32- 'StreamCompress.DomainExtensions.LZ.Extensions.AsImageFrameUsingHashTable``1(StreamCompress.Domain.LZ.LZImageFrame,System.Int32)')
  - [AsImageFrameUsingTrie256\`\`1(encodedImage)](#M-StreamCompress-DomainExtensions-LZ-Extensions-AsImageFrameUsingTrie256``1-StreamCompress-Domain-LZ-LZImageFrame- 'StreamCompress.DomainExtensions.LZ.Extensions.AsImageFrameUsingTrie256``1(StreamCompress.Domain.LZ.LZImageFrame)')
  - [AsImageFrameUsingTrie\`\`1(encodedImage,nodeInitialCapacity)](#M-StreamCompress-DomainExtensions-LZ-Extensions-AsImageFrameUsingTrie``1-StreamCompress-Domain-LZ-LZImageFrame,System-Int32- 'StreamCompress.DomainExtensions.LZ.Extensions.AsImageFrameUsingTrie``1(StreamCompress.Domain.LZ.LZImageFrame,System.Int32)')
  - [AsLZDecodedUsingHashTable(codes,hashPrime)](#M-StreamCompress-DomainExtensions-LZ-Extensions-AsLZDecodedUsingHashTable-System-Byte[],System-Int32- 'StreamCompress.DomainExtensions.LZ.Extensions.AsLZDecodedUsingHashTable(System.Byte[],System.Int32)')
  - [AsLZDecodedUsingTrie(codes,nodeInitialCapacity)](#M-StreamCompress-DomainExtensions-LZ-Extensions-AsLZDecodedUsingTrie-System-Byte[],System-Int32- 'StreamCompress.DomainExtensions.LZ.Extensions.AsLZDecodedUsingTrie(System.Byte[],System.Int32)')
  - [AsLZDecodedUsingTrie256(codes)](#M-StreamCompress-DomainExtensions-LZ-Extensions-AsLZDecodedUsingTrie256-System-Byte[]- 'StreamCompress.DomainExtensions.LZ.Extensions.AsLZDecodedUsingTrie256(System.Byte[])')
  - [_asLZDecoded(codes,decoderDic)](#M-StreamCompress-DomainExtensions-LZ-Extensions-_asLZDecoded-System-Byte[],StreamCompress-Domain-LZ-ILZ78CodingTable{System-Byte[]}- 'StreamCompress.DomainExtensions.LZ.Extensions._asLZDecoded(System.Byte[],StreamCompress.Domain.LZ.ILZ78CodingTable{System.Byte[]})')
- [FileExtensions](#T-StreamCompress-Utils-FileExtensions 'StreamCompress.Utils.FileExtensions')
  - [PathCombine(paths)](#M-StreamCompress-Utils-FileExtensions-PathCombine-System-String[]- 'StreamCompress.Utils.FileExtensions.PathCombine(System.String[])')
  - [ReadAllBytes(filename)](#M-StreamCompress-Utils-FileExtensions-ReadAllBytes-System-String- 'StreamCompress.Utils.FileExtensions.ReadAllBytes(System.String)')
  - [SaveToFile(bytes,filename)](#M-StreamCompress-Utils-FileExtensions-SaveToFile-System-Byte[],System-String- 'StreamCompress.Utils.FileExtensions.SaveToFile(System.Byte[],System.String)')
- [GZipImageFrame](#T-StreamCompress-Domain-GZip-GZipImageFrame 'StreamCompress.Domain.GZip.GZipImageFrame')
  - [#ctor(data)](#M-StreamCompress-Domain-GZip-GZipImageFrame-#ctor-System-Byte[]- 'StreamCompress.Domain.GZip.GZipImageFrame.#ctor(System.Byte[])')
  - [#ctor()](#M-StreamCompress-Domain-GZip-GZipImageFrame-#ctor 'StreamCompress.Domain.GZip.GZipImageFrame.#ctor')
  - [Data](#P-StreamCompress-Domain-GZip-GZipImageFrame-Data 'StreamCompress.Domain.GZip.GZipImageFrame.Data')
  - [Open(path)](#M-StreamCompress-Domain-GZip-GZipImageFrame-Open-System-String- 'StreamCompress.Domain.GZip.GZipImageFrame.Open(System.String)')
  - [Save(path)](#M-StreamCompress-Domain-GZip-GZipImageFrame-Save-System-String- 'StreamCompress.Domain.GZip.GZipImageFrame.Save(System.String)')
- [GrayScaleColors](#T-StreamCompress-Program-GrayScaleColors 'StreamCompress.Program.GrayScaleColors')
  - [Full](#F-StreamCompress-Program-GrayScaleColors-Full 'StreamCompress.Program.GrayScaleColors.Full')
  - [Half](#F-StreamCompress-Program-GrayScaleColors-Half 'StreamCompress.Program.GrayScaleColors.Half')
  - [Quarter](#F-StreamCompress-Program-GrayScaleColors-Quarter 'StreamCompress.Program.GrayScaleColors.Quarter')
- [HashTableItem\`1](#T-StreamCompress-Domain-LZ-HashTable`1-HashTableItem`1 'StreamCompress.Domain.LZ.HashTable`1.HashTableItem`1')
  - [#ctor(searchKey,codeWord,m)](#M-StreamCompress-Domain-LZ-HashTable`1-HashTableItem`1-#ctor-System-Byte[],`1,System-Int32- 'StreamCompress.Domain.LZ.HashTable`1.HashTableItem`1.#ctor(System.Byte[],`1,System.Int32)')
  - [CodeWord](#F-StreamCompress-Domain-LZ-HashTable`1-HashTableItem`1-CodeWord 'StreamCompress.Domain.LZ.HashTable`1.HashTableItem`1.CodeWord')
  - [Hash](#F-StreamCompress-Domain-LZ-HashTable`1-HashTableItem`1-Hash 'StreamCompress.Domain.LZ.HashTable`1.HashTableItem`1.Hash')
  - [SearchKey](#F-StreamCompress-Domain-LZ-HashTable`1-HashTableItem`1-SearchKey 'StreamCompress.Domain.LZ.HashTable`1.HashTableItem`1.SearchKey')
  - [LinkedItem](#P-StreamCompress-Domain-LZ-HashTable`1-HashTableItem`1-LinkedItem 'StreamCompress.Domain.LZ.HashTable`1.HashTableItem`1.LinkedItem')
  - [CompareTo(other)](#M-StreamCompress-Domain-LZ-HashTable`1-HashTableItem`1-CompareTo-StreamCompress-Domain-LZ-HashTable{`0}-HashTableItem{`1}- 'StreamCompress.Domain.LZ.HashTable`1.HashTableItem`1.CompareTo(StreamCompress.Domain.LZ.HashTable{`0}.HashTableItem{`1})')
  - [SetLinkedItem(item)](#M-StreamCompress-Domain-LZ-HashTable`1-HashTableItem`1-SetLinkedItem-StreamCompress-Domain-LZ-HashTable{`0}-HashTableItem{`1}- 'StreamCompress.Domain.LZ.HashTable`1.HashTableItem`1.SetLinkedItem(StreamCompress.Domain.LZ.HashTable{`0}.HashTableItem{`1})')
- [HashTable\`1](#T-StreamCompress-Domain-LZ-HashTable`1 'StreamCompress.Domain.LZ.HashTable`1')
  - [#ctor(m)](#M-StreamCompress-Domain-LZ-HashTable`1-#ctor-System-Int32- 'StreamCompress.Domain.LZ.HashTable`1.#ctor(System.Int32)')
  - [Count](#P-StreamCompress-Domain-LZ-HashTable`1-Count 'StreamCompress.Domain.LZ.HashTable`1.Count')
  - [HashTableItems](#P-StreamCompress-Domain-LZ-HashTable`1-HashTableItems 'StreamCompress.Domain.LZ.HashTable`1.HashTableItems')
  - [Insert(searchKey,codeWord)](#M-StreamCompress-Domain-LZ-HashTable`1-Insert-System-Byte[],`0- 'StreamCompress.Domain.LZ.HashTable`1.Insert(System.Byte[],`0)')
  - [Search(searchKey)](#M-StreamCompress-Domain-LZ-HashTable`1-Search-System-Byte[]- 'StreamCompress.Domain.LZ.HashTable`1.Search(System.Byte[])')
- [HeaderColorItem](#T-StreamCompress-Domain-Huffman-HuffmanImageFrame-HeaderColorItem 'StreamCompress.Domain.Huffman.HuffmanImageFrame.HeaderColorItem')
  - [#ctor(bytes,startIndex)](#M-StreamCompress-Domain-Huffman-HuffmanImageFrame-HeaderColorItem-#ctor-System-Byte[],System-Int32- 'StreamCompress.Domain.Huffman.HuffmanImageFrame.HeaderColorItem.#ctor(System.Byte[],System.Int32)')
  - [#ctor(symbol,codeBitsCount,code)](#M-StreamCompress-Domain-Huffman-HuffmanImageFrame-HeaderColorItem-#ctor-System-Int32,System-Int32,System-Int32- 'StreamCompress.Domain.Huffman.HuffmanImageFrame.HeaderColorItem.#ctor(System.Int32,System.Int32,System.Int32)')
  - [HEADER_COLOR_CODE_BIT_CODE_BYTES](#F-StreamCompress-Domain-Huffman-HuffmanImageFrame-HeaderColorItem-HEADER_COLOR_CODE_BIT_CODE_BYTES 'StreamCompress.Domain.Huffman.HuffmanImageFrame.HeaderColorItem.HEADER_COLOR_CODE_BIT_CODE_BYTES')
  - [HEADER_COLOR_CODE_BIT_COUNT_BYTES](#F-StreamCompress-Domain-Huffman-HuffmanImageFrame-HeaderColorItem-HEADER_COLOR_CODE_BIT_COUNT_BYTES 'StreamCompress.Domain.Huffman.HuffmanImageFrame.HeaderColorItem.HEADER_COLOR_CODE_BIT_COUNT_BYTES')
  - [HEADER_COLOR_SYMBOL_BYTES](#F-StreamCompress-Domain-Huffman-HuffmanImageFrame-HeaderColorItem-HEADER_COLOR_SYMBOL_BYTES 'StreamCompress.Domain.Huffman.HuffmanImageFrame.HeaderColorItem.HEADER_COLOR_SYMBOL_BYTES')
  - [Code](#P-StreamCompress-Domain-Huffman-HuffmanImageFrame-HeaderColorItem-Code 'StreamCompress.Domain.Huffman.HuffmanImageFrame.HeaderColorItem.Code')
  - [CodeBitsCount](#P-StreamCompress-Domain-Huffman-HuffmanImageFrame-HeaderColorItem-CodeBitsCount 'StreamCompress.Domain.Huffman.HuffmanImageFrame.HeaderColorItem.CodeBitsCount')
  - [Symbol](#P-StreamCompress-Domain-Huffman-HuffmanImageFrame-HeaderColorItem-Symbol 'StreamCompress.Domain.Huffman.HuffmanImageFrame.HeaderColorItem.Symbol')
  - [GetBytesLength()](#M-StreamCompress-Domain-Huffman-HuffmanImageFrame-HeaderColorItem-GetBytesLength 'StreamCompress.Domain.Huffman.HuffmanImageFrame.HeaderColorItem.GetBytesLength')
- [HuffmanImageFrame](#T-StreamCompress-Domain-Huffman-HuffmanImageFrame 'StreamCompress.Domain.Huffman.HuffmanImageFrame')
  - [#ctor(compressedBits,colorCodes,maxCodeBitsLength,originalImageDataLength,originalImageHeader)](#M-StreamCompress-Domain-Huffman-HuffmanImageFrame-#ctor-System-Int32,StreamCompress-Domain-Huffman-HuffmanImageFrame-HeaderColorItem[],System-Int32,System-Int32,System-Byte[]- 'StreamCompress.Domain.Huffman.HuffmanImageFrame.#ctor(System.Int32,StreamCompress.Domain.Huffman.HuffmanImageFrame.HeaderColorItem[],System.Int32,System.Int32,System.Byte[])')
  - [#ctor(data)](#M-StreamCompress-Domain-Huffman-HuffmanImageFrame-#ctor-System-Byte[]- 'StreamCompress.Domain.Huffman.HuffmanImageFrame.#ctor(System.Byte[])')
  - [#ctor()](#M-StreamCompress-Domain-Huffman-HuffmanImageFrame-#ctor 'StreamCompress.Domain.Huffman.HuffmanImageFrame.#ctor')
  - [HEADER_COLOR_CODE_COUNT_BYTES](#F-StreamCompress-Domain-Huffman-HuffmanImageFrame-HEADER_COLOR_CODE_COUNT_BYTES 'StreamCompress.Domain.Huffman.HuffmanImageFrame.HEADER_COLOR_CODE_COUNT_BYTES')
  - [HEADER_COLOR_CODE_COUNT_BYTES_POS](#F-StreamCompress-Domain-Huffman-HuffmanImageFrame-HEADER_COLOR_CODE_COUNT_BYTES_POS 'StreamCompress.Domain.Huffman.HuffmanImageFrame.HEADER_COLOR_CODE_COUNT_BYTES_POS')
  - [HEADER_COMPRESSED_BITS_BYTES](#F-StreamCompress-Domain-Huffman-HuffmanImageFrame-HEADER_COMPRESSED_BITS_BYTES 'StreamCompress.Domain.Huffman.HuffmanImageFrame.HEADER_COMPRESSED_BITS_BYTES')
  - [HEADER_COMPRESSED_BITS_BYTES_POS](#F-StreamCompress-Domain-Huffman-HuffmanImageFrame-HEADER_COMPRESSED_BITS_BYTES_POS 'StreamCompress.Domain.Huffman.HuffmanImageFrame.HEADER_COMPRESSED_BITS_BYTES_POS')
  - [HEADER_MAX_CODE_BITS_BYTES](#F-StreamCompress-Domain-Huffman-HuffmanImageFrame-HEADER_MAX_CODE_BITS_BYTES 'StreamCompress.Domain.Huffman.HuffmanImageFrame.HEADER_MAX_CODE_BITS_BYTES')
  - [HEADER_MAX_CODE_BITS_BYTES_POS](#F-StreamCompress-Domain-Huffman-HuffmanImageFrame-HEADER_MAX_CODE_BITS_BYTES_POS 'StreamCompress.Domain.Huffman.HuffmanImageFrame.HEADER_MAX_CODE_BITS_BYTES_POS')
  - [HEADER_ORIGINAL_IMAGE_DATA_BYTES](#F-StreamCompress-Domain-Huffman-HuffmanImageFrame-HEADER_ORIGINAL_IMAGE_DATA_BYTES 'StreamCompress.Domain.Huffman.HuffmanImageFrame.HEADER_ORIGINAL_IMAGE_DATA_BYTES')
  - [HEADER_ORIGINAL_IMAGE_DATA_BYTES_POS](#F-StreamCompress-Domain-Huffman-HuffmanImageFrame-HEADER_ORIGINAL_IMAGE_DATA_BYTES_POS 'StreamCompress.Domain.Huffman.HuffmanImageFrame.HEADER_ORIGINAL_IMAGE_DATA_BYTES_POS')
  - [HEADER_ORIGINAL_IMAGE_HEADER_BYTES](#F-StreamCompress-Domain-Huffman-HuffmanImageFrame-HEADER_ORIGINAL_IMAGE_HEADER_BYTES 'StreamCompress.Domain.Huffman.HuffmanImageFrame.HEADER_ORIGINAL_IMAGE_HEADER_BYTES')
  - [HEADER_ORIGINAL_IMAGE_HEADER_BYTES_POS](#F-StreamCompress-Domain-Huffman-HuffmanImageFrame-HEADER_ORIGINAL_IMAGE_HEADER_BYTES_POS 'StreamCompress.Domain.Huffman.HuffmanImageFrame.HEADER_ORIGINAL_IMAGE_HEADER_BYTES_POS')
  - [ColorCodeCount](#P-StreamCompress-Domain-Huffman-HuffmanImageFrame-ColorCodeCount 'StreamCompress.Domain.Huffman.HuffmanImageFrame.ColorCodeCount')
  - [ColorCodeHeaderLength](#P-StreamCompress-Domain-Huffman-HuffmanImageFrame-ColorCodeHeaderLength 'StreamCompress.Domain.Huffman.HuffmanImageFrame.ColorCodeHeaderLength')
  - [CompressedBits](#P-StreamCompress-Domain-Huffman-HuffmanImageFrame-CompressedBits 'StreamCompress.Domain.Huffman.HuffmanImageFrame.CompressedBits')
  - [Data](#P-StreamCompress-Domain-Huffman-HuffmanImageFrame-Data 'StreamCompress.Domain.Huffman.HuffmanImageFrame.Data')
  - [FixedHeaderLength](#P-StreamCompress-Domain-Huffman-HuffmanImageFrame-FixedHeaderLength 'StreamCompress.Domain.Huffman.HuffmanImageFrame.FixedHeaderLength')
  - [ImageDataOffSet](#P-StreamCompress-Domain-Huffman-HuffmanImageFrame-ImageDataOffSet 'StreamCompress.Domain.Huffman.HuffmanImageFrame.ImageDataOffSet')
  - [MaxCodeBitsLength](#P-StreamCompress-Domain-Huffman-HuffmanImageFrame-MaxCodeBitsLength 'StreamCompress.Domain.Huffman.HuffmanImageFrame.MaxCodeBitsLength')
  - [OriginalImageDataLength](#P-StreamCompress-Domain-Huffman-HuffmanImageFrame-OriginalImageDataLength 'StreamCompress.Domain.Huffman.HuffmanImageFrame.OriginalImageDataLength')
  - [OriginalImageHeaderLength](#P-StreamCompress-Domain-Huffman-HuffmanImageFrame-OriginalImageHeaderLength 'StreamCompress.Domain.Huffman.HuffmanImageFrame.OriginalImageHeaderLength')
  - [GetBit(index)](#M-StreamCompress-Domain-Huffman-HuffmanImageFrame-GetBit-System-Int32- 'StreamCompress.Domain.Huffman.HuffmanImageFrame.GetBit(System.Int32)')
  - [GetColorCodeItemFromHeader(index)](#M-StreamCompress-Domain-Huffman-HuffmanImageFrame-GetColorCodeItemFromHeader-System-Int32- 'StreamCompress.Domain.Huffman.HuffmanImageFrame.GetColorCodeItemFromHeader(System.Int32)')
  - [Open(path)](#M-StreamCompress-Domain-Huffman-HuffmanImageFrame-Open-System-String- 'StreamCompress.Domain.Huffman.HuffmanImageFrame.Open(System.String)')
  - [Save(path)](#M-StreamCompress-Domain-Huffman-HuffmanImageFrame-Save-System-String- 'StreamCompress.Domain.Huffman.HuffmanImageFrame.Save(System.String)')
- [HuffmanTreeNode\`1](#T-StreamCompress-Domain-Huffman-HuffmanTreeNode`1 'StreamCompress.Domain.Huffman.HuffmanTreeNode`1')
  - [#ctor(symbol)](#M-StreamCompress-Domain-Huffman-HuffmanTreeNode`1-#ctor-`0- 'StreamCompress.Domain.Huffman.HuffmanTreeNode`1.#ctor(`0)')
  - [#ctor(symbol,code,codeBits)](#M-StreamCompress-Domain-Huffman-HuffmanTreeNode`1-#ctor-`0,System-Int32,System-Int32- 'StreamCompress.Domain.Huffman.HuffmanTreeNode`1.#ctor(`0,System.Int32,System.Int32)')
  - [#ctor()](#M-StreamCompress-Domain-Huffman-HuffmanTreeNode`1-#ctor 'StreamCompress.Domain.Huffman.HuffmanTreeNode`1.#ctor')
  - [#ctor(frequency,leftChild,rightChild)](#M-StreamCompress-Domain-Huffman-HuffmanTreeNode`1-#ctor-System-Int32,StreamCompress-Domain-Huffman-HuffmanTreeNode{`0},StreamCompress-Domain-Huffman-HuffmanTreeNode{`0}- 'StreamCompress.Domain.Huffman.HuffmanTreeNode`1.#ctor(System.Int32,StreamCompress.Domain.Huffman.HuffmanTreeNode{`0},StreamCompress.Domain.Huffman.HuffmanTreeNode{`0})')
  - [_codeBitPos](#F-StreamCompress-Domain-Huffman-HuffmanTreeNode`1-_codeBitPos 'StreamCompress.Domain.Huffman.HuffmanTreeNode`1._codeBitPos')
  - [Code](#P-StreamCompress-Domain-Huffman-HuffmanTreeNode`1-Code 'StreamCompress.Domain.Huffman.HuffmanTreeNode`1.Code')
  - [CodeBitTable](#P-StreamCompress-Domain-Huffman-HuffmanTreeNode`1-CodeBitTable 'StreamCompress.Domain.Huffman.HuffmanTreeNode`1.CodeBitTable')
  - [CodeBits](#P-StreamCompress-Domain-Huffman-HuffmanTreeNode`1-CodeBits 'StreamCompress.Domain.Huffman.HuffmanTreeNode`1.CodeBits')
  - [Frequency](#P-StreamCompress-Domain-Huffman-HuffmanTreeNode`1-Frequency 'StreamCompress.Domain.Huffman.HuffmanTreeNode`1.Frequency')
  - [IsRightChild](#P-StreamCompress-Domain-Huffman-HuffmanTreeNode`1-IsRightChild 'StreamCompress.Domain.Huffman.HuffmanTreeNode`1.IsRightChild')
  - [Leaf](#P-StreamCompress-Domain-Huffman-HuffmanTreeNode`1-Leaf 'StreamCompress.Domain.Huffman.HuffmanTreeNode`1.Leaf')
  - [LeftChild](#P-StreamCompress-Domain-Huffman-HuffmanTreeNode`1-LeftChild 'StreamCompress.Domain.Huffman.HuffmanTreeNode`1.LeftChild')
  - [Parent](#P-StreamCompress-Domain-Huffman-HuffmanTreeNode`1-Parent 'StreamCompress.Domain.Huffman.HuffmanTreeNode`1.Parent')
  - [RightChild](#P-StreamCompress-Domain-Huffman-HuffmanTreeNode`1-RightChild 'StreamCompress.Domain.Huffman.HuffmanTreeNode`1.RightChild')
  - [Symbol](#P-StreamCompress-Domain-Huffman-HuffmanTreeNode`1-Symbol 'StreamCompress.Domain.Huffman.HuffmanTreeNode`1.Symbol')
  - [TotalBits](#P-StreamCompress-Domain-Huffman-HuffmanTreeNode`1-TotalBits 'StreamCompress.Domain.Huffman.HuffmanTreeNode`1.TotalBits')
  - [IncreaseFrequency()](#M-StreamCompress-Domain-Huffman-HuffmanTreeNode`1-IncreaseFrequency 'StreamCompress.Domain.Huffman.HuffmanTreeNode`1.IncreaseFrequency')
  - [InternalNodeCreate(leftNode,rightNode)](#M-StreamCompress-Domain-Huffman-HuffmanTreeNode`1-InternalNodeCreate-StreamCompress-Domain-Huffman-HuffmanTreeNode{`0},StreamCompress-Domain-Huffman-HuffmanTreeNode{`0}- 'StreamCompress.Domain.Huffman.HuffmanTreeNode`1.InternalNodeCreate(StreamCompress.Domain.Huffman.HuffmanTreeNode{`0},StreamCompress.Domain.Huffman.HuffmanTreeNode{`0})')
  - [PopulateBitTable()](#M-StreamCompress-Domain-Huffman-HuffmanTreeNode`1-PopulateBitTable 'StreamCompress.Domain.Huffman.HuffmanTreeNode`1.PopulateBitTable')
  - [ResetCode()](#M-StreamCompress-Domain-Huffman-HuffmanTreeNode`1-ResetCode 'StreamCompress.Domain.Huffman.HuffmanTreeNode`1.ResetCode')
  - [SetChild(childNode)](#M-StreamCompress-Domain-Huffman-HuffmanTreeNode`1-SetChild-StreamCompress-Domain-Huffman-HuffmanTreeNode{`0}- 'StreamCompress.Domain.Huffman.HuffmanTreeNode`1.SetChild(StreamCompress.Domain.Huffman.HuffmanTreeNode{`0})')
  - [SetCodeNextBit()](#M-StreamCompress-Domain-Huffman-HuffmanTreeNode`1-SetCodeNextBit-System-Int32- 'StreamCompress.Domain.Huffman.HuffmanTreeNode`1.SetCodeNextBit(System.Int32)')
  - [SetParent(parent,isRightChild)](#M-StreamCompress-Domain-Huffman-HuffmanTreeNode`1-SetParent-StreamCompress-Domain-Huffman-HuffmanTreeNode{`0},System-Boolean- 'StreamCompress.Domain.Huffman.HuffmanTreeNode`1.SetParent(StreamCompress.Domain.Huffman.HuffmanTreeNode{`0},System.Boolean)')
- [ILZ78CodingTableItem\`1](#T-StreamCompress-Domain-LZ-ILZ78CodingTableItem`1 'StreamCompress.Domain.LZ.ILZ78CodingTableItem`1')
  - [#ctor(codeWord)](#M-StreamCompress-Domain-LZ-ILZ78CodingTableItem`1-#ctor-`0- 'StreamCompress.Domain.LZ.ILZ78CodingTableItem`1.#ctor(`0)')
  - [CodeWord](#P-StreamCompress-Domain-LZ-ILZ78CodingTableItem`1-CodeWord 'StreamCompress.Domain.LZ.ILZ78CodingTableItem`1.CodeWord')
- [ILZ78CodingTable\`1](#T-StreamCompress-Domain-LZ-ILZ78CodingTable`1 'StreamCompress.Domain.LZ.ILZ78CodingTable`1')
  - [Count](#P-StreamCompress-Domain-LZ-ILZ78CodingTable`1-Count 'StreamCompress.Domain.LZ.ILZ78CodingTable`1.Count')
  - [Insert(searchKey,codeWord)](#M-StreamCompress-Domain-LZ-ILZ78CodingTable`1-Insert-System-Byte[],`0- 'StreamCompress.Domain.LZ.ILZ78CodingTable`1.Insert(System.Byte[],`0)')
  - [Search(searchKey)](#M-StreamCompress-Domain-LZ-ILZ78CodingTable`1-Search-System-Byte[]- 'StreamCompress.Domain.LZ.ILZ78CodingTable`1.Search(System.Byte[])')
- [ISaveable\`1](#T-StreamCompress-Utils-ISaveable`1 'StreamCompress.Utils.ISaveable`1')
  - [Open(path)](#M-StreamCompress-Utils-ISaveable`1-Open-System-String- 'StreamCompress.Utils.ISaveable`1.Open(System.String)')
  - [Save(path)](#M-StreamCompress-Utils-ISaveable`1-Save-System-String- 'StreamCompress.Utils.ISaveable`1.Save(System.String)')
- [ImageFrame](#T-StreamCompress-Domain-Image-ImageFrame 'StreamCompress.Domain.Image.ImageFrame')
  - [#ctor()](#M-StreamCompress-Domain-Image-ImageFrame-#ctor 'StreamCompress.Domain.Image.ImageFrame.#ctor')
  - [#ctor(image)](#M-StreamCompress-Domain-Image-ImageFrame-#ctor-System-Byte[]- 'StreamCompress.Domain.Image.ImageFrame.#ctor(System.Byte[])')
  - [HEADER_256_COLOR_TABLE_SIZE](#F-StreamCompress-Domain-Image-ImageFrame-HEADER_256_COLOR_TABLE_SIZE 'StreamCompress.Domain.Image.ImageFrame.HEADER_256_COLOR_TABLE_SIZE')
  - [HEADER_BYTES](#F-StreamCompress-Domain-Image-ImageFrame-HEADER_BYTES 'StreamCompress.Domain.Image.ImageFrame.HEADER_BYTES')
  - [BitsPerPixel](#P-StreamCompress-Domain-Image-ImageFrame-BitsPerPixel 'StreamCompress.Domain.Image.ImageFrame.BitsPerPixel')
  - [HeaderBytesLength](#P-StreamCompress-Domain-Image-ImageFrame-HeaderBytesLength 'StreamCompress.Domain.Image.ImageFrame.HeaderBytesLength')
  - [Image](#P-StreamCompress-Domain-Image-ImageFrame-Image 'StreamCompress.Domain.Image.ImageFrame.Image')
  - [ImageHeightPx](#P-StreamCompress-Domain-Image-ImageFrame-ImageHeightPx 'StreamCompress.Domain.Image.ImageFrame.ImageHeightPx')
  - [ImageWidthPx](#P-StreamCompress-Domain-Image-ImageFrame-ImageWidthPx 'StreamCompress.Domain.Image.ImageFrame.ImageWidthPx')
  - [FromBytes(image)](#M-StreamCompress-Domain-Image-ImageFrame-FromBytes-System-Byte[]- 'StreamCompress.Domain.Image.ImageFrame.FromBytes(System.Byte[])')
  - [FromFile(path)](#M-StreamCompress-Domain-Image-ImageFrame-FromFile-System-String- 'StreamCompress.Domain.Image.ImageFrame.FromFile(System.String)')
  - [Open(path)](#M-StreamCompress-Domain-Image-ImageFrame-Open-System-String- 'StreamCompress.Domain.Image.ImageFrame.Open(System.String)')
  - [Save(path)](#M-StreamCompress-Domain-Image-ImageFrame-Save-System-String- 'StreamCompress.Domain.Image.ImageFrame.Save(System.String)')
  - [SetSizeInfo(length,widthPx,heightPx)](#M-StreamCompress-Domain-Image-ImageFrame-SetSizeInfo-System-UInt32,System-Int32,System-Int32- 'StreamCompress.Domain.Image.ImageFrame.SetSizeInfo(System.UInt32,System.Int32,System.Int32)')
- [ImageFrameGrayScale](#T-StreamCompress-Domain-Image-ImageFrameGrayScale 'StreamCompress.Domain.Image.ImageFrameGrayScale')
  - [#ctor()](#M-StreamCompress-Domain-Image-ImageFrameGrayScale-#ctor 'StreamCompress.Domain.Image.ImageFrameGrayScale.#ctor')
  - [#ctor(image)](#M-StreamCompress-Domain-Image-ImageFrameGrayScale-#ctor-System-Byte[]- 'StreamCompress.Domain.Image.ImageFrameGrayScale.#ctor(System.Byte[])')
  - [SetColorTable()](#M-StreamCompress-Domain-Image-ImageFrameGrayScale-SetColorTable 'StreamCompress.Domain.Image.ImageFrameGrayScale.SetColorTable')
  - [StreamCompress#Utils#ISaveable{StreamCompress#Domain#Image#ImageFrameGrayScale}#Open(path)](#M-StreamCompress-Domain-Image-ImageFrameGrayScale-StreamCompress#Utils#ISaveable{StreamCompress#Domain#Image#ImageFrameGrayScale}#Open-System-String- 'StreamCompress.Domain.Image.ImageFrameGrayScale.StreamCompress#Utils#ISaveable{StreamCompress#Domain#Image#ImageFrameGrayScale}#Open(System.String)')
  - [StreamCompress#Utils#ISaveable{StreamCompress#Domain#Image#ImageFrameGrayScale}#Save(path)](#M-StreamCompress-Domain-Image-ImageFrameGrayScale-StreamCompress#Utils#ISaveable{StreamCompress#Domain#Image#ImageFrameGrayScale}#Save-System-String- 'StreamCompress.Domain.Image.ImageFrameGrayScale.StreamCompress#Utils#ISaveable{StreamCompress#Domain#Image#ImageFrameGrayScale}#Save(System.String)')
- [LZCompressionDictionary](#T-StreamCompress-Program-LZCompressionDictionary 'StreamCompress.Program.LZCompressionDictionary')
  - [HashTable](#F-StreamCompress-Program-LZCompressionDictionary-HashTable 'StreamCompress.Program.LZCompressionDictionary.HashTable')
  - [Trie](#F-StreamCompress-Program-LZCompressionDictionary-Trie 'StreamCompress.Program.LZCompressionDictionary.Trie')
  - [Trie256](#F-StreamCompress-Program-LZCompressionDictionary-Trie256 'StreamCompress.Program.LZCompressionDictionary.Trie256')
- [LZImageFrame](#T-StreamCompress-Domain-LZ-LZImageFrame 'StreamCompress.Domain.LZ.LZImageFrame')
  - [#ctor()](#M-StreamCompress-Domain-LZ-LZImageFrame-#ctor 'StreamCompress.Domain.LZ.LZImageFrame.#ctor')
  - [#ctor(codes)](#M-StreamCompress-Domain-LZ-LZImageFrame-#ctor-System-Byte[]- 'StreamCompress.Domain.LZ.LZImageFrame.#ctor(System.Byte[])')
  - [Codes](#P-StreamCompress-Domain-LZ-LZImageFrame-Codes 'StreamCompress.Domain.LZ.LZImageFrame.Codes')
  - [Open(path)](#M-StreamCompress-Domain-LZ-LZImageFrame-Open-System-String- 'StreamCompress.Domain.LZ.LZImageFrame.Open(System.String)')
  - [Save(path)](#M-StreamCompress-Domain-LZ-LZImageFrame-Save-System-String- 'StreamCompress.Domain.LZ.LZImageFrame.Save(System.String)')
- [Method](#T-StreamCompress-Program-Method 'StreamCompress.Program.Method')
  - [AsGZipDecoded](#F-StreamCompress-Program-Method-AsGZipDecoded 'StreamCompress.Program.Method.AsGZipDecoded')
  - [AsGZipEncoded](#F-StreamCompress-Program-Method-AsGZipEncoded 'StreamCompress.Program.Method.AsGZipEncoded')
  - [AsGrayScale](#F-StreamCompress-Program-Method-AsGrayScale 'StreamCompress.Program.Method.AsGrayScale')
  - [AsGrayScaleAsGZipDecoded](#F-StreamCompress-Program-Method-AsGrayScaleAsGZipDecoded 'StreamCompress.Program.Method.AsGrayScaleAsGZipDecoded')
  - [AsGrayScaleAsGZipEncoded](#F-StreamCompress-Program-Method-AsGrayScaleAsGZipEncoded 'StreamCompress.Program.Method.AsGrayScaleAsGZipEncoded')
  - [AsGrayScaleAsHuffmanDecoded](#F-StreamCompress-Program-Method-AsGrayScaleAsHuffmanDecoded 'StreamCompress.Program.Method.AsGrayScaleAsHuffmanDecoded')
  - [AsGrayScaleAsHuffmanEncoded](#F-StreamCompress-Program-Method-AsGrayScaleAsHuffmanEncoded 'StreamCompress.Program.Method.AsGrayScaleAsHuffmanEncoded')
  - [AsGrayScaleAsLZ78Decoded](#F-StreamCompress-Program-Method-AsGrayScaleAsLZ78Decoded 'StreamCompress.Program.Method.AsGrayScaleAsLZ78Decoded')
  - [AsGrayScaleAsLZ78Encoded](#F-StreamCompress-Program-Method-AsGrayScaleAsLZ78Encoded 'StreamCompress.Program.Method.AsGrayScaleAsLZ78Encoded')
  - [AsLZ78Decoded](#F-StreamCompress-Program-Method-AsLZ78Decoded 'StreamCompress.Program.Method.AsLZ78Decoded')
  - [AsLZ78Encoded](#F-StreamCompress-Program-Method-AsLZ78Encoded 'StreamCompress.Program.Method.AsLZ78Encoded')
- [MinHeap\`1](#T-StreamCompress-Domain-Huffman-MinHeap`1 'StreamCompress.Domain.Huffman.MinHeap`1')
  - [#ctor(n)](#M-StreamCompress-Domain-Huffman-MinHeap`1-#ctor-System-Int32- 'StreamCompress.Domain.Huffman.MinHeap`1.#ctor(System.Int32)')
  - [_heap](#F-StreamCompress-Domain-Huffman-MinHeap`1-_heap 'StreamCompress.Domain.Huffman.MinHeap`1._heap')
  - [_heapData](#F-StreamCompress-Domain-Huffman-MinHeap`1-_heapData 'StreamCompress.Domain.Huffman.MinHeap`1._heapData')
  - [HeapSize](#P-StreamCompress-Domain-Huffman-MinHeap`1-HeapSize 'StreamCompress.Domain.Huffman.MinHeap`1.HeapSize')
  - [DelMin()](#M-StreamCompress-Domain-Huffman-MinHeap`1-DelMin 'StreamCompress.Domain.Huffman.MinHeap`1.DelMin')
  - [Insert(nodeKey,nodeData)](#M-StreamCompress-Domain-Huffman-MinHeap`1-Insert-System-Int32,`0- 'StreamCompress.Domain.Huffman.MinHeap`1.Insert(System.Int32,`0)')
  - [_getParentIndex(i)](#M-StreamCompress-Domain-Huffman-MinHeap`1-_getParentIndex-System-Int32- 'StreamCompress.Domain.Huffman.MinHeap`1._getParentIndex(System.Int32)')
  - [_heapify(i)](#M-StreamCompress-Domain-Huffman-MinHeap`1-_heapify-System-Int32- 'StreamCompress.Domain.Huffman.MinHeap`1._heapify(System.Int32)')
  - [_leftChildNodeIndex(i)](#M-StreamCompress-Domain-Huffman-MinHeap`1-_leftChildNodeIndex-System-Int32- 'StreamCompress.Domain.Huffman.MinHeap`1._leftChildNodeIndex(System.Int32)')
  - [_rightChildNodeIndex(i)](#M-StreamCompress-Domain-Huffman-MinHeap`1-_rightChildNodeIndex-System-Int32- 'StreamCompress.Domain.Huffman.MinHeap`1._rightChildNodeIndex(System.Int32)')
  - [_swapNodeLocations(i,j)](#M-StreamCompress-Domain-Huffman-MinHeap`1-_swapNodeLocations-System-Int32,System-Int32- 'StreamCompress.Domain.Huffman.MinHeap`1._swapNodeLocations(System.Int32,System.Int32)')
- [Program](#T-StreamCompress-Program 'StreamCompress.Program')
  - [Main(args)](#M-StreamCompress-Program-Main-System-String[]- 'StreamCompress.Program.Main(System.String[])')
  - [SourceLooper\`\`2(cmdArgs,func)](#M-StreamCompress-Program-SourceLooper``2-StreamCompress-Program-CommandLineArgs,System-Func{System-Int32,StreamCompress-Program-CommandLineArgs,``0,StreamCompress-Utils-ISaveable{``1}}- 'StreamCompress.Program.SourceLooper``2(StreamCompress.Program.CommandLineArgs,System.Func{System.Int32,StreamCompress.Program.CommandLineArgs,``0,StreamCompress.Utils.ISaveable{``1}})')
  - [_filePath(i,path,suffix)](#M-StreamCompress-Program-_filePath-System-Int32,System-String,System-String- 'StreamCompress.Program._filePath(System.Int32,System.String,System.String)')
- [Tries256\`1](#T-StreamCompress-Domain-LZ-Tries256`1 'StreamCompress.Domain.LZ.Tries256`1')
  - [#ctor()](#M-StreamCompress-Domain-LZ-Tries256`1-#ctor 'StreamCompress.Domain.LZ.Tries256`1.#ctor')
  - [Count](#P-StreamCompress-Domain-LZ-Tries256`1-Count 'StreamCompress.Domain.LZ.Tries256`1.Count')
  - [Insert(searchKey,codeWord)](#M-StreamCompress-Domain-LZ-Tries256`1-Insert-System-Byte[],`0- 'StreamCompress.Domain.LZ.Tries256`1.Insert(System.Byte[],`0)')
  - [Search(searchKey)](#M-StreamCompress-Domain-LZ-Tries256`1-Search-System-Byte[]- 'StreamCompress.Domain.LZ.Tries256`1.Search(System.Byte[])')
- [TriesContainer256\`1](#T-StreamCompress-Domain-LZ-Tries256`1-TriesContainer256`1 'StreamCompress.Domain.LZ.Tries256`1.TriesContainer256`1')
  - [CodeWord](#P-StreamCompress-Domain-LZ-Tries256`1-TriesContainer256`1-CodeWord 'StreamCompress.Domain.LZ.Tries256`1.TriesContainer256`1.CodeWord')
  - [IsSet](#P-StreamCompress-Domain-LZ-Tries256`1-TriesContainer256`1-IsSet 'StreamCompress.Domain.LZ.Tries256`1.TriesContainer256`1.IsSet')
  - [Nodes](#P-StreamCompress-Domain-LZ-Tries256`1-TriesContainer256`1-Nodes 'StreamCompress.Domain.LZ.Tries256`1.TriesContainer256`1.Nodes')
  - [Add(b)](#M-StreamCompress-Domain-LZ-Tries256`1-TriesContainer256`1-Add-System-Byte- 'StreamCompress.Domain.LZ.Tries256`1.TriesContainer256`1.Add(System.Byte)')
  - [Get(b)](#M-StreamCompress-Domain-LZ-Tries256`1-TriesContainer256`1-Get-System-Byte- 'StreamCompress.Domain.LZ.Tries256`1.TriesContainer256`1.Get(System.Byte)')
  - [SetCodeWord(codeWord)](#M-StreamCompress-Domain-LZ-Tries256`1-TriesContainer256`1-SetCodeWord-`1- 'StreamCompress.Domain.LZ.Tries256`1.TriesContainer256`1.SetCodeWord(`1)')
- [TriesContainer\`1](#T-StreamCompress-Domain-LZ-Tries`1-TriesContainer`1 'StreamCompress.Domain.LZ.Tries`1.TriesContainer`1')
  - [#ctor(capacity)](#M-StreamCompress-Domain-LZ-Tries`1-TriesContainer`1-#ctor-System-Int32- 'StreamCompress.Domain.LZ.Tries`1.TriesContainer`1.#ctor(System.Int32)')
  - [CodeWord](#P-StreamCompress-Domain-LZ-Tries`1-TriesContainer`1-CodeWord 'StreamCompress.Domain.LZ.Tries`1.TriesContainer`1.CodeWord')
  - [IsSet](#P-StreamCompress-Domain-LZ-Tries`1-TriesContainer`1-IsSet 'StreamCompress.Domain.LZ.Tries`1.TriesContainer`1.IsSet')
  - [Nodes](#P-StreamCompress-Domain-LZ-Tries`1-TriesContainer`1-Nodes 'StreamCompress.Domain.LZ.Tries`1.TriesContainer`1.Nodes')
  - [NodesCount](#P-StreamCompress-Domain-LZ-Tries`1-TriesContainer`1-NodesCount 'StreamCompress.Domain.LZ.Tries`1.TriesContainer`1.NodesCount')
  - [Add(b)](#M-StreamCompress-Domain-LZ-Tries`1-TriesContainer`1-Add-System-Byte- 'StreamCompress.Domain.LZ.Tries`1.TriesContainer`1.Add(System.Byte)')
  - [Get(b)](#M-StreamCompress-Domain-LZ-Tries`1-TriesContainer`1-Get-System-Byte- 'StreamCompress.Domain.LZ.Tries`1.TriesContainer`1.Get(System.Byte)')
- [TriesNode256\`1](#T-StreamCompress-Domain-LZ-Tries256`1-TriesNode256`1 'StreamCompress.Domain.LZ.Tries256`1.TriesNode256`1')
  - [#ctor(b)](#M-StreamCompress-Domain-LZ-Tries256`1-TriesNode256`1-#ctor-System-Byte- 'StreamCompress.Domain.LZ.Tries256`1.TriesNode256`1.#ctor(System.Byte)')
  - [Byte](#P-StreamCompress-Domain-LZ-Tries256`1-TriesNode256`1-Byte 'StreamCompress.Domain.LZ.Tries256`1.TriesNode256`1.Byte')
  - [ChildContainer](#P-StreamCompress-Domain-LZ-Tries256`1-TriesNode256`1-ChildContainer 'StreamCompress.Domain.LZ.Tries256`1.TriesNode256`1.ChildContainer')
- [TriesNode\`1](#T-StreamCompress-Domain-LZ-Tries`1-TriesNode`1 'StreamCompress.Domain.LZ.Tries`1.TriesNode`1')
  - [#ctor(b,capacity)](#M-StreamCompress-Domain-LZ-Tries`1-TriesNode`1-#ctor-System-Byte,System-Int32- 'StreamCompress.Domain.LZ.Tries`1.TriesNode`1.#ctor(System.Byte,System.Int32)')
  - [Byte](#P-StreamCompress-Domain-LZ-Tries`1-TriesNode`1-Byte 'StreamCompress.Domain.LZ.Tries`1.TriesNode`1.Byte')
  - [ChildContainer](#P-StreamCompress-Domain-LZ-Tries`1-TriesNode`1-ChildContainer 'StreamCompress.Domain.LZ.Tries`1.TriesNode`1.ChildContainer')
- [Tries\`1](#T-StreamCompress-Domain-LZ-Tries`1 'StreamCompress.Domain.LZ.Tries`1')
  - [#ctor(containerCapacity)](#M-StreamCompress-Domain-LZ-Tries`1-#ctor-System-Int32- 'StreamCompress.Domain.LZ.Tries`1.#ctor(System.Int32)')
  - [Count](#P-StreamCompress-Domain-LZ-Tries`1-Count 'StreamCompress.Domain.LZ.Tries`1.Count')
  - [Insert(searchKey,codeWord)](#M-StreamCompress-Domain-LZ-Tries`1-Insert-System-Byte[],`0- 'StreamCompress.Domain.LZ.Tries`1.Insert(System.Byte[],`0)')
  - [Search(searchKey)](#M-StreamCompress-Domain-LZ-Tries`1-Search-System-Byte[]- 'StreamCompress.Domain.LZ.Tries`1.Search(System.Byte[])')

<a name='T-StreamCompress-Utils-BitAndByteExtensions'></a>
## BitAndByteExtensions `type`

##### Namespace

StreamCompress.Utils

##### Summary

Extensions for byte and bit manipulation

<a name='M-StreamCompress-Utils-BitAndByteExtensions-AsBytes-System-Int32-'></a>
### AsBytes(val) `method`

##### Summary

Converts 32 bit integer to byte array

##### Returns

Value as byte array

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| val | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Value |

<a name='M-StreamCompress-Utils-BitAndByteExtensions-AsBytes-System-UInt32-'></a>
### AsBytes(val) `method`

##### Summary

Converts 32 bit unsigned integer to byte array

##### Returns

Value as byte array

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| val | [System.UInt32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.UInt32 'System.UInt32') | Value |

<a name='M-StreamCompress-Utils-BitAndByteExtensions-AsBytes-System-UInt16-'></a>
### AsBytes(val) `method`

##### Summary

Converts 16 bit unsigned integer to byte array

##### Returns

Value as byte array

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| val | [System.UInt16](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.UInt16 'System.UInt16') | Value |

<a name='M-StreamCompress-Utils-BitAndByteExtensions-AsCompressed-System-Byte[],System-Int32,System-Int32-'></a>
### AsCompressed(val,maxValue,valueCount) `method`

##### Summary

Compress byte array of int values to byte array, which use minimum amount space based max int value

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| val | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | Byte array of 32 bit integers |
| maxValue | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') |  |
| valueCount | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') |  |

<a name='M-StreamCompress-Utils-BitAndByteExtensions-AsDecompressed-System-Byte[]-'></a>
### AsDecompressed(val) `method`

##### Summary

Decompress bytes compressed by AsCompressed method

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| val | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') |  |

<a name='M-StreamCompress-Utils-BitAndByteExtensions-AsInt-System-Byte[],System-Int32,System-Int32-'></a>
### AsInt(bytes,offset,count) `method`

##### Summary

Converts 1 - 4 bytes as 32 bit integer

##### Returns

4 bytes as 32 bit integer

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| bytes | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | Source bytes |
| offset | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Source offset |
| count | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Source bytes count |

<a name='M-StreamCompress-Utils-BitAndByteExtensions-AsUInt16-System-Byte[],System-Int32-'></a>
### AsUInt16(bytes,offset) `method`

##### Summary

Converts 2 bytes as 16 bit integer

##### Returns

4 bytes as 16 bit integer

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| bytes | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | Source bytes |
| offset | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Source offset |

<a name='M-StreamCompress-Utils-BitAndByteExtensions-Compare-System-Byte[],System-Byte[]-'></a>
### Compare(b1,b2) `method`

##### Summary

Compares to byte arrays

##### Returns

true when arrays are equal otherwise false

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| b1 | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | this |
| b2 | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | other |

<a name='M-StreamCompress-Utils-BitAndByteExtensions-Concatenate-System-Byte[],System-Byte[]-'></a>
### Concatenate(bytes1,bytes2) `method`

##### Summary

Concatenates this byte array with given one

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| bytes1 | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | This |
| bytes2 | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | Bytes to add |

<a name='M-StreamCompress-Utils-BitAndByteExtensions-CopyBytesTo-System-Byte[],System-Int32,System-Byte[]-'></a>
### CopyBytesTo(val,srcOffSet,dest) `method`

##### Summary

Copies bytes from source to destionation array

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| val | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | Source array |
| srcOffSet | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Source offset |
| dest | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | Destination array |

<a name='M-StreamCompress-Utils-BitAndByteExtensions-CopyBytesTo-System-Byte[],System-Int32,System-Byte[],System-Int32,System-Int32-'></a>
### CopyBytesTo(val,srcOffSet,dest,destOffSet,count) `method`

##### Summary

Copies bytes from source to destionation array

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| val | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | Source array |
| srcOffSet | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Source offset |
| dest | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | Destination array |
| destOffSet | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Destination offset |
| count | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Copied bytes count |

<a name='M-StreamCompress-Utils-BitAndByteExtensions-CopyBytesTo-System-Byte[],System-Byte[],System-Int32-'></a>
### CopyBytesTo(val,dest,destOffSet) `method`

##### Summary

Copies bytes from source to destionation array

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| val | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | Source array |
| dest | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | Destination array |
| destOffSet | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Destination offset |

<a name='M-StreamCompress-Utils-BitAndByteExtensions-GetBitFromByte-System-Byte,System-Int32-'></a>
### GetBitFromByte(b,bitIndex) `method`

##### Summary

Reads bit from byte using given index

##### Returns

True when bit is set to 1, otherwise false

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| b | [System.Byte](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte 'System.Byte') | Byte |
| bitIndex | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Bit index |

<a name='M-StreamCompress-Utils-BitAndByteExtensions-GetBitTable-System-Int32,System-Int32-'></a>
### GetBitTable(val,bits) `method`

##### Summary

Populates bits code in array using order so that last index has most significant bit

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| val | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Input value |
| bits | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | How many bits |

<a name='M-StreamCompress-Utils-BitAndByteExtensions-SetBitToByte-System-Byte,System-Int32-'></a>
### SetBitToByte(b,bitIndex) `method`

##### Summary

Set bit value to 1 in byte using given index

##### Returns

Modified byte

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| b | [System.Byte](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte 'System.Byte') | Byte |
| bitIndex | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Bit index |

<a name='T-StreamCompress-Utils-ByteMemoryStream'></a>
## ByteMemoryStream `type`

##### Namespace

StreamCompress.Utils

##### Summary

Wraps MemoryStream

<a name='M-StreamCompress-Utils-ByteMemoryStream-#ctor-System-Int32-'></a>
### #ctor(initialSize) `constructor`

##### Summary

Constructor for new memory stream

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| initialSize | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Initial buffer size |

<a name='M-StreamCompress-Utils-ByteMemoryStream-#ctor-System-Byte[]-'></a>
### #ctor(buffer) `constructor`

##### Summary

Constructor for new memory stream

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| buffer | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | Initial data |

<a name='M-StreamCompress-Utils-ByteMemoryStream-AddBytes-System-Byte[]-'></a>
### AddBytes(bytes) `method`

##### Summary

Adds bytes to memory stream

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| bytes | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | Bytes to add |

<a name='M-StreamCompress-Utils-ByteMemoryStream-Dispose'></a>
### Dispose() `method`

##### Summary

Finalize intance and release resources

##### Parameters

This method has no parameters.

<a name='M-StreamCompress-Utils-ByteMemoryStream-ReadBytes'></a>
### ReadBytes() `method`

##### Summary

Reads written bytes from memory stream

##### Returns



##### Parameters

This method has no parameters.

<a name='T-StreamCompress-Program-CommandLineArgs'></a>
## CommandLineArgs `type`

##### Namespace

StreamCompress.Program

##### Summary

Command line arguments

<a name='P-StreamCompress-Program-CommandLineArgs-Count'></a>
### Count `property`

##### Summary

How many source files are proceed

<a name='P-StreamCompress-Program-CommandLineArgs-CropBottomPx'></a>
### CropBottomPx `property`

##### Summary

Image crop bottom

<a name='P-StreamCompress-Program-CommandLineArgs-CropLeftPx'></a>
### CropLeftPx `property`

##### Summary

Image crop left

<a name='P-StreamCompress-Program-CommandLineArgs-CropRightPx'></a>
### CropRightPx `property`

##### Summary

Image crop right

<a name='P-StreamCompress-Program-CommandLineArgs-CropTopPx'></a>
### CropTopPx `property`

##### Summary

Image crop top

<a name='P-StreamCompress-Program-CommandLineArgs-DestinationFileSuffix'></a>
### DestinationFileSuffix `property`

##### Summary

Output file suffix

<a name='P-StreamCompress-Program-CommandLineArgs-DestinationPath'></a>
### DestinationPath `property`

##### Summary

Output folder

<a name='P-StreamCompress-Program-CommandLineArgs-GrayScaleColors'></a>
### GrayScaleColors `property`

##### Summary

How many colors are used in gray scale image

<a name='P-StreamCompress-Program-CommandLineArgs-LZCompressionDictionary'></a>
### LZCompressionDictionary `property`

##### Summary

Dictionary implementation used in LZ78 compression

<a name='P-StreamCompress-Program-CommandLineArgs-LZCompressionHashTablePrime'></a>
### LZCompressionHashTablePrime `property`

##### Summary

Hash table dictionary prime number

<a name='P-StreamCompress-Program-CommandLineArgs-LZCompressionTrieInitialCapacity'></a>
### LZCompressionTrieInitialCapacity `property`

##### Summary

Dynamic trie implementation node tables initial size

<a name='P-StreamCompress-Program-CommandLineArgs-Method'></a>
### Method `property`

##### Summary

Compression method

<a name='P-StreamCompress-Program-CommandLineArgs-SourceFileSuffix'></a>
### SourceFileSuffix `property`

##### Summary

Sourcefiles filename suffix with extension

<a name='P-StreamCompress-Program-CommandLineArgs-SourcePath'></a>
### SourcePath `property`

##### Summary

Source data path

<a name='P-StreamCompress-Program-CommandLineArgs-StartIndex'></a>
### StartIndex `property`

##### Summary

Source files start index

<a name='T-StreamCompress-Domain-Image-CropSetup'></a>
## CropSetup `type`

##### Namespace

StreamCompress.Domain.Image

##### Summary

Presents image crop information

<a name='P-StreamCompress-Domain-Image-CropSetup-BottomPx'></a>
### BottomPx `property`

##### Summary

Pixels to crop from bottom

<a name='P-StreamCompress-Domain-Image-CropSetup-LeftPx'></a>
### LeftPx `property`

##### Summary

Pixels to crop from left

<a name='P-StreamCompress-Domain-Image-CropSetup-RightPx'></a>
### RightPx `property`

##### Summary

Pixels to crop from right

<a name='P-StreamCompress-Domain-Image-CropSetup-TopPx'></a>
### TopPx `property`

##### Summary

Pixels to crop from top

<a name='T-StreamCompress-DomainExtensions-GZip-Extensions'></a>
## Extensions `type`

##### Namespace

StreamCompress.DomainExtensions.GZip

##### Summary

GZip extensions

<a name='T-StreamCompress-DomainExtensions-Huffman-Extensions'></a>
## Extensions `type`

##### Namespace

StreamCompress.DomainExtensions.Huffman

##### Summary

Domain extensions for domain objects manipulation

<a name='T-StreamCompress-DomainExtensions-Image-Extensions'></a>
## Extensions `type`

##### Namespace

StreamCompress.DomainExtensions.Image

##### Summary

Domain extensions for domain objects manipulation

<a name='T-StreamCompress-DomainExtensions-LZ-Extensions'></a>
## Extensions `type`

##### Namespace

StreamCompress.DomainExtensions.LZ

##### Summary

Domain extensions for domain objects manipulation

<a name='M-StreamCompress-DomainExtensions-GZip-Extensions-AsImageFrame``1-StreamCompress-Domain-GZip-GZipImageFrame-'></a>
### AsImageFrame\`\`1(encodedImage) `method`

##### Summary

Decodes compressed image

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| encodedImage | [StreamCompress.Domain.GZip.GZipImageFrame](#T-StreamCompress-Domain-GZip-GZipImageFrame 'StreamCompress.Domain.GZip.GZipImageFrame') | Image encoded bytes |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of image |

<a name='M-StreamCompress-DomainExtensions-Huffman-Extensions-AsImageGrayScaleFrame-StreamCompress-Domain-Huffman-HuffmanImageFrame-'></a>
### AsImageGrayScaleFrame(encodedImage) `method`

##### Summary

Decodes Huffman encoded image back to gray scale image

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| encodedImage | [StreamCompress.Domain.Huffman.HuffmanImageFrame](#T-StreamCompress-Domain-Huffman-HuffmanImageFrame 'StreamCompress.Domain.Huffman.HuffmanImageFrame') |  |

<a name='M-StreamCompress-DomainExtensions-Image-Extensions-AsCropSetup-StreamCompress-Program-CommandLineArgs-'></a>
### AsCropSetup(a) `method`

##### Summary

Create crop setup from command line arguments

##### Returns

Crop setup

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| a | [StreamCompress.Program.CommandLineArgs](#T-StreamCompress-Program-CommandLineArgs 'StreamCompress.Program.CommandLineArgs') | Command line arguments |

<a name='M-StreamCompress-DomainExtensions-Image-Extensions-AsCroppedImage-StreamCompress-Domain-Image-ImageFrame,StreamCompress-Domain-Image-CropSetup-'></a>
### AsCroppedImage(image,cropSetup) `method`

##### Summary

Crops given image

##### Returns

Cropped image

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| image | [StreamCompress.Domain.Image.ImageFrame](#T-StreamCompress-Domain-Image-ImageFrame 'StreamCompress.Domain.Image.ImageFrame') | Image to crop |
| cropSetup | [StreamCompress.Domain.Image.CropSetup](#T-StreamCompress-Domain-Image-CropSetup 'StreamCompress.Domain.Image.CropSetup') | Crop setup |

<a name='M-StreamCompress-DomainExtensions-Image-Extensions-AsGZipEncoded``1-``0-'></a>
### AsGZipEncoded\`\`1(image) `method`

##### Summary

Compress bytes using .Net Core impl. of GZip 
Just for benchmark reason

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| image | [\`\`0](#T-``0 '``0') |  |

<a name='M-StreamCompress-DomainExtensions-Image-Extensions-AsGrayScale-StreamCompress-Domain-Image-ImageFrame,System-Int32-'></a>
### AsGrayScale(image,colors) `method`

##### Summary

Converts 24 bit color image to gray scale image

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| image | [StreamCompress.Domain.Image.ImageFrame](#T-StreamCompress-Domain-Image-ImageFrame 'StreamCompress.Domain.Image.ImageFrame') | Color image |
| colors | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | How many gray colors are used in gray image |

<a name='M-StreamCompress-DomainExtensions-Image-Extensions-AsHuffmanEncoded-StreamCompress-Domain-Image-ImageFrameGrayScale-'></a>
### AsHuffmanEncoded(image) `method`

##### Summary

Encodes gray scale image using huffman coding

##### Returns

Huffman image frame

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| image | [StreamCompress.Domain.Image.ImageFrameGrayScale](#T-StreamCompress-Domain-Image-ImageFrameGrayScale 'StreamCompress.Domain.Image.ImageFrameGrayScale') | Image to encode |

<a name='M-StreamCompress-DomainExtensions-Image-Extensions-AsLZEncodedUsingHashTable``1-``0,System-Int32-'></a>
### AsLZEncodedUsingHashTable\`\`1(image,hashPrime) `method`

##### Summary

Encodes image using LZ and hash table as dictionary

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| image | [\`\`0](#T-``0 '``0') | Image to encode |
| hashPrime | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | m value in hash table |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of image |

<a name='M-StreamCompress-DomainExtensions-Image-Extensions-AsLZEncodedUsingTrie256``1-``0-'></a>
### AsLZEncodedUsingTrie256\`\`1(image) `method`

##### Summary

Encodes image using LZ and fixed length trie as dictionary

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| image | [\`\`0](#T-``0 '``0') | Image to encode |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of image |

<a name='M-StreamCompress-DomainExtensions-Image-Extensions-AsLZEncodedUsingTrie``1-``0,System-Int32-'></a>
### AsLZEncodedUsingTrie\`\`1(image,nodeInitialCapacity) `method`

##### Summary

Encodes image using LZ and trie as dictionary

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| image | [\`\`0](#T-``0 '``0') | Image to encode |
| nodeInitialCapacity | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Node table initial size |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of image |

<a name='M-StreamCompress-DomainExtensions-Image-Extensions-AsPlanted-StreamCompress-Domain-Image-ImageFrameGrayScale,System-Int32,System-Int32-'></a>
### AsPlanted(image,plantWidthPx,plantHeightPx) `method`

##### Summary

Adds given image in the center of the given plant area and return new image instance

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| image | [StreamCompress.Domain.Image.ImageFrameGrayScale](#T-StreamCompress-Domain-Image-ImageFrameGrayScale 'StreamCompress.Domain.Image.ImageFrameGrayScale') | Image to plant inside new image |
| plantWidthPx | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | New image width |
| plantHeightPx | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | New image height |

<a name='M-StreamCompress-DomainExtensions-Image-Extensions-BytesAsLZEncodedUsingHashTable-System-Byte[],System-Int32-'></a>
### BytesAsLZEncodedUsingHashTable(input,hashPrime) `method`

##### Summary

Encodes bytes using LZ and hash table as dictionary

##### Returns

Encoded byte array

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| input | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | Byte array |
| hashPrime | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | m value in hash table |

<a name='M-StreamCompress-DomainExtensions-Image-Extensions-BytesAsLZEncodedUsingTrie-System-Byte[],System-Int32-'></a>
### BytesAsLZEncodedUsingTrie(input,nodeInitialCapacity) `method`

##### Summary

Encodes bytes using LZ and trie as dictionary

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| input | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | Byte array |
| nodeInitialCapacity | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Node table initial size |

<a name='M-StreamCompress-DomainExtensions-Image-Extensions-BytesAsLZEncodedUsingTrie256-System-Byte[]-'></a>
### BytesAsLZEncodedUsingTrie256(input) `method`

##### Summary

Encodes bytes using LZ and fixed length trie as dictionary

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| input | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | Byte array |

<a name='M-StreamCompress-DomainExtensions-Image-Extensions-_asLZEncoded-System-Byte[],StreamCompress-Domain-LZ-ILZ78CodingTable{System-Int32}-'></a>
### _asLZEncoded(input,encoderDic) `method`

##### Summary

Encode given data using LZ coding and given dictionary

##### Returns

Encoded byte array

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| input | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | Byte array to encode |
| encoderDic | [StreamCompress.Domain.LZ.ILZ78CodingTable{System.Int32}](#T-StreamCompress-Domain-LZ-ILZ78CodingTable{System-Int32} 'StreamCompress.Domain.LZ.ILZ78CodingTable{System.Int32}') | Dictionary implementation |

<a name='M-StreamCompress-DomainExtensions-LZ-Extensions-AsImageFrameUsingHashTable``1-StreamCompress-Domain-LZ-LZImageFrame,System-Int32-'></a>
### AsImageFrameUsingHashTable\`\`1(encodedImage,hashPrime) `method`

##### Summary

Decodes LZ compressed data

##### Returns

Decompressed data

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| encodedImage | [StreamCompress.Domain.LZ.LZImageFrame](#T-StreamCompress-Domain-LZ-LZImageFrame 'StreamCompress.Domain.LZ.LZImageFrame') | LZ encoded image frame |
| hashPrime | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | m value used in hash table |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of image |

<a name='M-StreamCompress-DomainExtensions-LZ-Extensions-AsImageFrameUsingTrie256``1-StreamCompress-Domain-LZ-LZImageFrame-'></a>
### AsImageFrameUsingTrie256\`\`1(encodedImage) `method`

##### Summary

Decodes LZ compressed data

##### Returns

Return image frame of type T

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| encodedImage | [StreamCompress.Domain.LZ.LZImageFrame](#T-StreamCompress-Domain-LZ-LZImageFrame 'StreamCompress.Domain.LZ.LZImageFrame') | LZ encoded image frame |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of image |

<a name='M-StreamCompress-DomainExtensions-LZ-Extensions-AsImageFrameUsingTrie``1-StreamCompress-Domain-LZ-LZImageFrame,System-Int32-'></a>
### AsImageFrameUsingTrie\`\`1(encodedImage,nodeInitialCapacity) `method`

##### Summary

Decodes LZ compressed data

##### Returns

Return image frame of type T

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| encodedImage | [StreamCompress.Domain.LZ.LZImageFrame](#T-StreamCompress-Domain-LZ-LZImageFrame 'StreamCompress.Domain.LZ.LZImageFrame') | LZ encoded image frame |
| nodeInitialCapacity | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Node table initial size |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of image |

<a name='M-StreamCompress-DomainExtensions-LZ-Extensions-AsLZDecodedUsingHashTable-System-Byte[],System-Int32-'></a>
### AsLZDecodedUsingHashTable(codes,hashPrime) `method`

##### Summary

Decodes compressed bytes

##### Returns

Decompressed data

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| codes | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | Compressed bytes |
| hashPrime | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | m value used in hash table |

<a name='M-StreamCompress-DomainExtensions-LZ-Extensions-AsLZDecodedUsingTrie-System-Byte[],System-Int32-'></a>
### AsLZDecodedUsingTrie(codes,nodeInitialCapacity) `method`

##### Summary

Decodes compressed bytes

##### Returns

Decompressed data

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| codes | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | Compressed bytes |
| nodeInitialCapacity | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Node table initial size |

<a name='M-StreamCompress-DomainExtensions-LZ-Extensions-AsLZDecodedUsingTrie256-System-Byte[]-'></a>
### AsLZDecodedUsingTrie256(codes) `method`

##### Summary

Decodes compressed bytes

##### Returns

Decompressed data

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| codes | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | Compressed bytes |

<a name='M-StreamCompress-DomainExtensions-LZ-Extensions-_asLZDecoded-System-Byte[],StreamCompress-Domain-LZ-ILZ78CodingTable{System-Byte[]}-'></a>
### _asLZDecoded(codes,decoderDic) `method`

##### Summary

Decodes LZ compressed bytes

##### Returns

Decompressed data

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| codes | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | Compressed bytes |
| decoderDic | [StreamCompress.Domain.LZ.ILZ78CodingTable{System.Byte[]}](#T-StreamCompress-Domain-LZ-ILZ78CodingTable{System-Byte[]} 'StreamCompress.Domain.LZ.ILZ78CodingTable{System.Byte[]}') | Dictionary to use in decoding |

<a name='T-StreamCompress-Utils-FileExtensions'></a>
## FileExtensions `type`

##### Namespace

StreamCompress.Utils

##### Summary

Operations for file manipulations

<a name='M-StreamCompress-Utils-FileExtensions-PathCombine-System-String[]-'></a>
### PathCombine(paths) `method`

##### Summary

Combines single path from given parameter values

##### Returns

Valid path

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| paths | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') | Paths |

<a name='M-StreamCompress-Utils-FileExtensions-ReadAllBytes-System-String-'></a>
### ReadAllBytes(filename) `method`

##### Summary

Reads all bytes from file

##### Returns

Byte array of file content

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| filename | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Filename |

<a name='M-StreamCompress-Utils-FileExtensions-SaveToFile-System-Byte[],System-String-'></a>
### SaveToFile(bytes,filename) `method`

##### Summary

Save byte array to file

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| bytes | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | Byte array |
| filename | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Filename |

<a name='T-StreamCompress-Domain-GZip-GZipImageFrame'></a>
## GZipImageFrame `type`

##### Namespace

StreamCompress.Domain.GZip

##### Summary

Presents single image frame in GZip compressed form

<a name='M-StreamCompress-Domain-GZip-GZipImageFrame-#ctor-System-Byte[]-'></a>
### #ctor(data) `constructor`

##### Summary

Constructor to create frame from byte array

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| data | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') |  |

<a name='M-StreamCompress-Domain-GZip-GZipImageFrame-#ctor'></a>
### #ctor() `constructor`

##### Summary

Parametless constructor

##### Parameters

This constructor has no parameters.

<a name='P-StreamCompress-Domain-GZip-GZipImageFrame-Data'></a>
### Data `property`

##### Summary

Byte array which contains compressed image

<a name='M-StreamCompress-Domain-GZip-GZipImageFrame-Open-System-String-'></a>
### Open(path) `method`

##### Summary

Reads comressed image frame from file

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| path | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-StreamCompress-Domain-GZip-GZipImageFrame-Save-System-String-'></a>
### Save(path) `method`

##### Summary

Saves compressed image frame to file

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| path | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='T-StreamCompress-Program-GrayScaleColors'></a>
## GrayScaleColors `type`

##### Namespace

StreamCompress.Program

##### Summary

Gray scale image color counts

<a name='F-StreamCompress-Program-GrayScaleColors-Full'></a>
### Full `constants`

##### Summary

256 colors

<a name='F-StreamCompress-Program-GrayScaleColors-Half'></a>
### Half `constants`

##### Summary

128 colors

<a name='F-StreamCompress-Program-GrayScaleColors-Quarter'></a>
### Quarter `constants`

##### Summary

64 colors

<a name='T-StreamCompress-Domain-LZ-HashTable`1-HashTableItem`1'></a>
## HashTableItem\`1 `type`

##### Namespace

StreamCompress.Domain.LZ.HashTable`1

##### Summary

Hash table item

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TT | CodeWord type |

<a name='M-StreamCompress-Domain-LZ-HashTable`1-HashTableItem`1-#ctor-System-Byte[],`1,System-Int32-'></a>
### #ctor(searchKey,codeWord,m) `constructor`

##### Summary

Constructor to create new item. Method will also calculate key and hash

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| searchKey | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') |  |
| codeWord | [\`1](#T-`1 '`1') |  |
| m | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') |  |

<a name='F-StreamCompress-Domain-LZ-HashTable`1-HashTableItem`1-CodeWord'></a>
### CodeWord `constants`

##### Summary

Value saved to item

<a name='F-StreamCompress-Domain-LZ-HashTable`1-HashTableItem`1-Hash'></a>
### Hash `constants`

##### Summary

Hash value

<a name='F-StreamCompress-Domain-LZ-HashTable`1-HashTableItem`1-SearchKey'></a>
### SearchKey `constants`

##### Summary

Key

<a name='P-StreamCompress-Domain-LZ-HashTable`1-HashTableItem`1-LinkedItem'></a>
### LinkedItem `property`

##### Summary

Linked list

<a name='M-StreamCompress-Domain-LZ-HashTable`1-HashTableItem`1-CompareTo-StreamCompress-Domain-LZ-HashTable{`0}-HashTableItem{`1}-'></a>
### CompareTo(other) `method`

##### Summary

Compares this item to given one

##### Returns

zero when items are equal, otherwise -1

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| other | [StreamCompress.Domain.LZ.HashTable{\`0}.HashTableItem{\`1}](#T-StreamCompress-Domain-LZ-HashTable{`0}-HashTableItem{`1} 'StreamCompress.Domain.LZ.HashTable{`0}.HashTableItem{`1}') | Other item |

<a name='M-StreamCompress-Domain-LZ-HashTable`1-HashTableItem`1-SetLinkedItem-StreamCompress-Domain-LZ-HashTable{`0}-HashTableItem{`1}-'></a>
### SetLinkedItem(item) `method`

##### Summary

Ser given item as linked item to this item

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| item | [StreamCompress.Domain.LZ.HashTable{\`0}.HashTableItem{\`1}](#T-StreamCompress-Domain-LZ-HashTable{`0}-HashTableItem{`1} 'StreamCompress.Domain.LZ.HashTable{`0}.HashTableItem{`1}') |  |

<a name='T-StreamCompress-Domain-LZ-HashTable`1'></a>
## HashTable\`1 `type`

##### Namespace

StreamCompress.Domain.LZ

##### Summary

Hash table impl

<a name='M-StreamCompress-Domain-LZ-HashTable`1-#ctor-System-Int32-'></a>
### #ctor(m) `constructor`

##### Summary

Constructor for new HashTable

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| m | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Hash table size |

<a name='P-StreamCompress-Domain-LZ-HashTable`1-Count'></a>
### Count `property`

##### Summary

Items count

<a name='P-StreamCompress-Domain-LZ-HashTable`1-HashTableItems'></a>
### HashTableItems `property`

##### Summary

Hash table items

<a name='M-StreamCompress-Domain-LZ-HashTable`1-Insert-System-Byte[],`0-'></a>
### Insert(searchKey,codeWord) `method`

##### Summary

Inserts new item to HashTable if it does not already exists

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| searchKey | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | Key |
| codeWord | [\`0](#T-`0 '`0') | Value |

<a name='M-StreamCompress-Domain-LZ-HashTable`1-Search-System-Byte[]-'></a>
### Search(searchKey) `method`

##### Summary

Serach method for hash table items

##### Returns

Item if it does exists, otherwise null

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| searchKey | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | Key |

<a name='T-StreamCompress-Domain-Huffman-HuffmanImageFrame-HeaderColorItem'></a>
## HeaderColorItem `type`

##### Namespace

StreamCompress.Domain.Huffman.HuffmanImageFrame

##### Summary

Header color item

<a name='M-StreamCompress-Domain-Huffman-HuffmanImageFrame-HeaderColorItem-#ctor-System-Byte[],System-Int32-'></a>
### #ctor(bytes,startIndex) `constructor`

##### Summary

Init color item using given byte array and reading data from it from given index

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| bytes | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | Byte array, which contains header item |
| startIndex | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Item start index in byte array |

<a name='M-StreamCompress-Domain-Huffman-HuffmanImageFrame-HeaderColorItem-#ctor-System-Int32,System-Int32,System-Int32-'></a>
### #ctor(symbol,codeBitsCount,code) `constructor`

##### Summary

Init new item using given values

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| symbol | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') |  |
| codeBitsCount | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') |  |
| code | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') |  |

<a name='F-StreamCompress-Domain-Huffman-HuffmanImageFrame-HeaderColorItem-HEADER_COLOR_CODE_BIT_CODE_BYTES'></a>
### HEADER_COLOR_CODE_BIT_CODE_BYTES `constants`

##### Summary

Bytes used for color code

<a name='F-StreamCompress-Domain-Huffman-HuffmanImageFrame-HeaderColorItem-HEADER_COLOR_CODE_BIT_COUNT_BYTES'></a>
### HEADER_COLOR_CODE_BIT_COUNT_BYTES `constants`

##### Summary

Bytes used for color code bit count

<a name='F-StreamCompress-Domain-Huffman-HuffmanImageFrame-HeaderColorItem-HEADER_COLOR_SYMBOL_BYTES'></a>
### HEADER_COLOR_SYMBOL_BYTES `constants`

##### Summary

Bytes used for color symbol

<a name='P-StreamCompress-Domain-Huffman-HuffmanImageFrame-HeaderColorItem-Code'></a>
### Code `property`

##### Summary

Code

<a name='P-StreamCompress-Domain-Huffman-HuffmanImageFrame-HeaderColorItem-CodeBitsCount'></a>
### CodeBitsCount `property`

##### Summary

Bits

<a name='P-StreamCompress-Domain-Huffman-HuffmanImageFrame-HeaderColorItem-Symbol'></a>
### Symbol `property`

##### Summary

Symbole

<a name='M-StreamCompress-Domain-Huffman-HuffmanImageFrame-HeaderColorItem-GetBytesLength'></a>
### GetBytesLength() `method`

##### Summary

Header item length in header

##### Returns



##### Parameters

This method has no parameters.

<a name='T-StreamCompress-Domain-Huffman-HuffmanImageFrame'></a>
## HuffmanImageFrame `type`

##### Namespace

StreamCompress.Domain.Huffman

##### Summary

Presents single image frame as Huffman encoded

<a name='M-StreamCompress-Domain-Huffman-HuffmanImageFrame-#ctor-System-Int32,StreamCompress-Domain-Huffman-HuffmanImageFrame-HeaderColorItem[],System-Int32,System-Int32,System-Byte[]-'></a>
### #ctor(compressedBits,colorCodes,maxCodeBitsLength,originalImageDataLength,originalImageHeader) `constructor`

##### Summary

Constructor for huffamn encoded image frame

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| compressedBits | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Compressed bits count |
| colorCodes | [StreamCompress.Domain.Huffman.HuffmanImageFrame.HeaderColorItem[]](#T-StreamCompress-Domain-Huffman-HuffmanImageFrame-HeaderColorItem[] 'StreamCompress.Domain.Huffman.HuffmanImageFrame.HeaderColorItem[]') | Color code count |
| maxCodeBitsLength | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Longest bit length |
| originalImageDataLength | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Original image header length |
| originalImageHeader | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | Original image header |

<a name='M-StreamCompress-Domain-Huffman-HuffmanImageFrame-#ctor-System-Byte[]-'></a>
### #ctor(data) `constructor`

##### Summary

New huffman image frame from given data

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| data | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') |  |

<a name='M-StreamCompress-Domain-Huffman-HuffmanImageFrame-#ctor'></a>
### #ctor() `constructor`

##### Summary

Parametless constructor

##### Parameters

This constructor has no parameters.

<a name='F-StreamCompress-Domain-Huffman-HuffmanImageFrame-HEADER_COLOR_CODE_COUNT_BYTES'></a>
### HEADER_COLOR_CODE_COUNT_BYTES `constants`

##### Summary

Color code count header field length in bytes

<a name='F-StreamCompress-Domain-Huffman-HuffmanImageFrame-HEADER_COLOR_CODE_COUNT_BYTES_POS'></a>
### HEADER_COLOR_CODE_COUNT_BYTES_POS `constants`

##### Summary

Color code count  header field position

<a name='F-StreamCompress-Domain-Huffman-HuffmanImageFrame-HEADER_COMPRESSED_BITS_BYTES'></a>
### HEADER_COMPRESSED_BITS_BYTES `constants`

##### Summary

Compressed bits header field length in bytes

<a name='F-StreamCompress-Domain-Huffman-HuffmanImageFrame-HEADER_COMPRESSED_BITS_BYTES_POS'></a>
### HEADER_COMPRESSED_BITS_BYTES_POS `constants`

##### Summary

Compressed bits header field position

<a name='F-StreamCompress-Domain-Huffman-HuffmanImageFrame-HEADER_MAX_CODE_BITS_BYTES'></a>
### HEADER_MAX_CODE_BITS_BYTES `constants`

##### Summary

Max code length header field length in bytes

<a name='F-StreamCompress-Domain-Huffman-HuffmanImageFrame-HEADER_MAX_CODE_BITS_BYTES_POS'></a>
### HEADER_MAX_CODE_BITS_BYTES_POS `constants`

##### Summary

Max code length  header field position

<a name='F-StreamCompress-Domain-Huffman-HuffmanImageFrame-HEADER_ORIGINAL_IMAGE_DATA_BYTES'></a>
### HEADER_ORIGINAL_IMAGE_DATA_BYTES `constants`

##### Summary

Original image data header field length in bytes

<a name='F-StreamCompress-Domain-Huffman-HuffmanImageFrame-HEADER_ORIGINAL_IMAGE_DATA_BYTES_POS'></a>
### HEADER_ORIGINAL_IMAGE_DATA_BYTES_POS `constants`

##### Summary

Original image data header field position

<a name='F-StreamCompress-Domain-Huffman-HuffmanImageFrame-HEADER_ORIGINAL_IMAGE_HEADER_BYTES'></a>
### HEADER_ORIGINAL_IMAGE_HEADER_BYTES `constants`

##### Summary

Original image header header field length in bytes

<a name='F-StreamCompress-Domain-Huffman-HuffmanImageFrame-HEADER_ORIGINAL_IMAGE_HEADER_BYTES_POS'></a>
### HEADER_ORIGINAL_IMAGE_HEADER_BYTES_POS `constants`

##### Summary

Original image header  header field position

<a name='P-StreamCompress-Domain-Huffman-HuffmanImageFrame-ColorCodeCount'></a>
### ColorCodeCount `property`

##### Summary

Count of color codes

<a name='P-StreamCompress-Domain-Huffman-HuffmanImageFrame-ColorCodeHeaderLength'></a>
### ColorCodeHeaderLength `property`

##### Summary

Total size of color header

<a name='P-StreamCompress-Domain-Huffman-HuffmanImageFrame-CompressedBits'></a>
### CompressedBits `property`

##### Summary

Compressed bits count

<a name='P-StreamCompress-Domain-Huffman-HuffmanImageFrame-Data'></a>
### Data `property`

##### Summary

Frame data header + image

<a name='P-StreamCompress-Domain-Huffman-HuffmanImageFrame-FixedHeaderLength'></a>
### FixedHeaderLength `property`

##### Summary

Total size of header

<a name='P-StreamCompress-Domain-Huffman-HuffmanImageFrame-ImageDataOffSet'></a>
### ImageDataOffSet `property`

##### Summary

Image off set

<a name='P-StreamCompress-Domain-Huffman-HuffmanImageFrame-MaxCodeBitsLength'></a>
### MaxCodeBitsLength `property`

##### Summary

Longest bit length

<a name='P-StreamCompress-Domain-Huffman-HuffmanImageFrame-OriginalImageDataLength'></a>
### OriginalImageDataLength `property`

##### Summary

Original image data length

<a name='P-StreamCompress-Domain-Huffman-HuffmanImageFrame-OriginalImageHeaderLength'></a>
### OriginalImageHeaderLength `property`

##### Summary

Original image header length

<a name='M-StreamCompress-Domain-Huffman-HuffmanImageFrame-GetBit-System-Int32-'></a>
### GetBit(index) `method`

##### Summary

Check if bit is set in byte in given index. Read direction is from left to right.

##### Returns

If bit is set then true otherwise false

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| index | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Bit position in byte |

<a name='M-StreamCompress-Domain-Huffman-HuffmanImageFrame-GetColorCodeItemFromHeader-System-Int32-'></a>
### GetColorCodeItemFromHeader(index) `method`

##### Summary

Reads color code item from header from given index

##### Returns

Color code from given index

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| index | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Color code index |

<a name='M-StreamCompress-Domain-Huffman-HuffmanImageFrame-Open-System-String-'></a>
### Open(path) `method`

##### Summary

Open huffman image frmae from file

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| path | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Path |

<a name='M-StreamCompress-Domain-Huffman-HuffmanImageFrame-Save-System-String-'></a>
### Save(path) `method`

##### Summary

Saves data to given file

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| path | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Path |

<a name='T-StreamCompress-Domain-Huffman-HuffmanTreeNode`1'></a>
## HuffmanTreeNode\`1 `type`

##### Namespace

StreamCompress.Domain.Huffman

##### Summary

Presents one node in huffman tree

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-StreamCompress-Domain-Huffman-HuffmanTreeNode`1-#ctor-`0-'></a>
### #ctor(symbol) `constructor`

##### Summary

To create leaf

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| symbol | [\`0](#T-`0 '`0') |  |

<a name='M-StreamCompress-Domain-Huffman-HuffmanTreeNode`1-#ctor-`0,System-Int32,System-Int32-'></a>
### #ctor(symbol,code,codeBits) `constructor`

##### Summary

To create leaf when decoding

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| symbol | [\`0](#T-`0 '`0') | Symbol |
| code | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Code |
| codeBits | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Bits |

<a name='M-StreamCompress-Domain-Huffman-HuffmanTreeNode`1-#ctor'></a>
### #ctor() `constructor`

##### Summary

To create internal node when decoding

##### Parameters

This constructor has no parameters.

<a name='M-StreamCompress-Domain-Huffman-HuffmanTreeNode`1-#ctor-System-Int32,StreamCompress-Domain-Huffman-HuffmanTreeNode{`0},StreamCompress-Domain-Huffman-HuffmanTreeNode{`0}-'></a>
### #ctor(frequency,leftChild,rightChild) `constructor`

##### Summary

Constructor to create internal node

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| frequency | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Frequency |
| leftChild | [StreamCompress.Domain.Huffman.HuffmanTreeNode{\`0}](#T-StreamCompress-Domain-Huffman-HuffmanTreeNode{`0} 'StreamCompress.Domain.Huffman.HuffmanTreeNode{`0}') | Left child |
| rightChild | [StreamCompress.Domain.Huffman.HuffmanTreeNode{\`0}](#T-StreamCompress-Domain-Huffman-HuffmanTreeNode{`0} 'StreamCompress.Domain.Huffman.HuffmanTreeNode{`0}') | Right child |

<a name='F-StreamCompress-Domain-Huffman-HuffmanTreeNode`1-_codeBitPos'></a>
### _codeBitPos `constants`

##### Summary

internal cursor to keep track which bit in code value has not been set yet

<a name='P-StreamCompress-Domain-Huffman-HuffmanTreeNode`1-Code'></a>
### Code `property`

##### Summary

Code numeric value

<a name='P-StreamCompress-Domain-Huffman-HuffmanTreeNode`1-CodeBitTable'></a>
### CodeBitTable `property`

##### Summary

Contains code bits in array and most significant bit is last one

<a name='P-StreamCompress-Domain-Huffman-HuffmanTreeNode`1-CodeBits'></a>
### CodeBits `property`

##### Summary

Bits used for code

<a name='P-StreamCompress-Domain-Huffman-HuffmanTreeNode`1-Frequency'></a>
### Frequency `property`

##### Summary

Node frequency / priority

<a name='P-StreamCompress-Domain-Huffman-HuffmanTreeNode`1-IsRightChild'></a>
### IsRightChild `property`

##### Summary

Is right child of this node parent

<a name='P-StreamCompress-Domain-Huffman-HuffmanTreeNode`1-Leaf'></a>
### Leaf `property`

##### Summary

Is node or internal node

<a name='P-StreamCompress-Domain-Huffman-HuffmanTreeNode`1-LeftChild'></a>
### LeftChild `property`

##### Summary

Node left child

<a name='P-StreamCompress-Domain-Huffman-HuffmanTreeNode`1-Parent'></a>
### Parent `property`

##### Summary

Node parent

<a name='P-StreamCompress-Domain-Huffman-HuffmanTreeNode`1-RightChild'></a>
### RightChild `property`

##### Summary

Node right child

<a name='P-StreamCompress-Domain-Huffman-HuffmanTreeNode`1-Symbol'></a>
### Symbol `property`

##### Summary

Symbol

<a name='P-StreamCompress-Domain-Huffman-HuffmanTreeNode`1-TotalBits'></a>
### TotalBits `property`

##### Summary

Total bits used for symbol

<a name='M-StreamCompress-Domain-Huffman-HuffmanTreeNode`1-IncreaseFrequency'></a>
### IncreaseFrequency() `method`

##### Summary

Increase node symbol frequency

##### Parameters

This method has no parameters.

<a name='M-StreamCompress-Domain-Huffman-HuffmanTreeNode`1-InternalNodeCreate-StreamCompress-Domain-Huffman-HuffmanTreeNode{`0},StreamCompress-Domain-Huffman-HuffmanTreeNode{`0}-'></a>
### InternalNodeCreate(leftNode,rightNode) `method`

##### Summary

Combines left node and right node as new internal node and sets new node as parent node to both nodes.

##### Returns

new internal node

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| leftNode | [StreamCompress.Domain.Huffman.HuffmanTreeNode{\`0}](#T-StreamCompress-Domain-Huffman-HuffmanTreeNode{`0} 'StreamCompress.Domain.Huffman.HuffmanTreeNode{`0}') | left node |
| rightNode | [StreamCompress.Domain.Huffman.HuffmanTreeNode{\`0}](#T-StreamCompress-Domain-Huffman-HuffmanTreeNode{`0} 'StreamCompress.Domain.Huffman.HuffmanTreeNode{`0}') | right node |

<a name='M-StreamCompress-Domain-Huffman-HuffmanTreeNode`1-PopulateBitTable'></a>
### PopulateBitTable() `method`

##### Summary

Populates bits code in array using order so that last index has most significant bit

##### Parameters

This method has no parameters.

<a name='M-StreamCompress-Domain-Huffman-HuffmanTreeNode`1-ResetCode'></a>
### ResetCode() `method`

##### Summary

Resets code value and code bit position

##### Parameters

This method has no parameters.

<a name='M-StreamCompress-Domain-Huffman-HuffmanTreeNode`1-SetChild-StreamCompress-Domain-Huffman-HuffmanTreeNode{`0}-'></a>
### SetChild(childNode) `method`

##### Summary

Sets child as child node to this node

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| childNode | [StreamCompress.Domain.Huffman.HuffmanTreeNode{\`0}](#T-StreamCompress-Domain-Huffman-HuffmanTreeNode{`0} 'StreamCompress.Domain.Huffman.HuffmanTreeNode{`0}') |  |

<a name='M-StreamCompress-Domain-Huffman-HuffmanTreeNode`1-SetCodeNextBit-System-Int32-'></a>
### SetCodeNextBit() `method`

##### Summary

Sets code value bit value in current bit position to zero when node is left and 1 when node is right child

##### Parameters

This method has no parameters.

<a name='M-StreamCompress-Domain-Huffman-HuffmanTreeNode`1-SetParent-StreamCompress-Domain-Huffman-HuffmanTreeNode{`0},System-Boolean-'></a>
### SetParent(parent,isRightChild) `method`

##### Summary

Sets given node as parent to this node and defines if this node is left or right of parent

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| parent | [StreamCompress.Domain.Huffman.HuffmanTreeNode{\`0}](#T-StreamCompress-Domain-Huffman-HuffmanTreeNode{`0} 'StreamCompress.Domain.Huffman.HuffmanTreeNode{`0}') | Parent node |
| isRightChild | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Is right child |

<a name='T-StreamCompress-Domain-LZ-ILZ78CodingTableItem`1'></a>
## ILZ78CodingTableItem\`1 `type`

##### Namespace

StreamCompress.Domain.LZ

##### Summary

Presents item in dictionary

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-StreamCompress-Domain-LZ-ILZ78CodingTableItem`1-#ctor-`0-'></a>
### #ctor(codeWord) `constructor`

##### Summary

Item constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| codeWord | [\`0](#T-`0 '`0') | Item code word |

<a name='P-StreamCompress-Domain-LZ-ILZ78CodingTableItem`1-CodeWord'></a>
### CodeWord `property`

##### Summary

Item code word

<a name='T-StreamCompress-Domain-LZ-ILZ78CodingTable`1'></a>
## ILZ78CodingTable\`1 `type`

##### Namespace

StreamCompress.Domain.LZ

##### Summary

Interface for dictionary implementatio used in LZ compression

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='P-StreamCompress-Domain-LZ-ILZ78CodingTable`1-Count'></a>
### Count `property`

##### Summary

Items count in dictionary

<a name='M-StreamCompress-Domain-LZ-ILZ78CodingTable`1-Insert-System-Byte[],`0-'></a>
### Insert(searchKey,codeWord) `method`

##### Summary

Insert new item to dictionary

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| searchKey | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | Item key |
| codeWord | [\`0](#T-`0 '`0') | Item value |

<a name='M-StreamCompress-Domain-LZ-ILZ78CodingTable`1-Search-System-Byte[]-'></a>
### Search(searchKey) `method`

##### Summary

Search item from disctionary

##### Returns

Existing item or null

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| searchKey | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | Search key |

<a name='T-StreamCompress-Utils-ISaveable`1'></a>
## ISaveable\`1 `type`

##### Namespace

StreamCompress.Utils

##### Summary

Interface for saving and opening saveable domain objects in project

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of domain object |

<a name='M-StreamCompress-Utils-ISaveable`1-Open-System-String-'></a>
### Open(path) `method`

##### Summary

Reads object from given file

##### Returns

Object

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| path | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | File name |

<a name='M-StreamCompress-Utils-ISaveable`1-Save-System-String-'></a>
### Save(path) `method`

##### Summary

Saves object to given file

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| path | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | File path |

<a name='T-StreamCompress-Domain-Image-ImageFrame'></a>
## ImageFrame `type`

##### Namespace

StreamCompress.Domain.Image

##### Summary

Presents single image frame

<a name='M-StreamCompress-Domain-Image-ImageFrame-#ctor'></a>
### #ctor() `constructor`

##### Summary

Parametless constructor

##### Parameters

This constructor has no parameters.

<a name='M-StreamCompress-Domain-Image-ImageFrame-#ctor-System-Byte[]-'></a>
### #ctor(image) `constructor`

##### Summary

Constructor to create image frame from byte array

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| image | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | Bitmap image byte array |

<a name='F-StreamCompress-Domain-Image-ImageFrame-HEADER_256_COLOR_TABLE_SIZE'></a>
### HEADER_256_COLOR_TABLE_SIZE `constants`

##### Summary

Color table size when it contains 256 colors

<a name='F-StreamCompress-Domain-Image-ImageFrame-HEADER_BYTES'></a>
### HEADER_BYTES `constants`

##### Summary

Bitmap image fixed header size

<a name='P-StreamCompress-Domain-Image-ImageFrame-BitsPerPixel'></a>
### BitsPerPixel `property`

##### Summary

How many bits is used to prsent single pixel

<a name='P-StreamCompress-Domain-Image-ImageFrame-HeaderBytesLength'></a>
### HeaderBytesLength `property`

##### Summary

Header total bytes

<a name='P-StreamCompress-Domain-Image-ImageFrame-Image'></a>
### Image `property`

##### Summary

Image data with header

<a name='P-StreamCompress-Domain-Image-ImageFrame-ImageHeightPx'></a>
### ImageHeightPx `property`

##### Summary

Image height in pixels

<a name='P-StreamCompress-Domain-Image-ImageFrame-ImageWidthPx'></a>
### ImageWidthPx `property`

##### Summary

Image width in pixels

<a name='M-StreamCompress-Domain-Image-ImageFrame-FromBytes-System-Byte[]-'></a>
### FromBytes(image) `method`

##### Summary

Initialize frame from given bytes

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| image | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | Image |

<a name='M-StreamCompress-Domain-Image-ImageFrame-FromFile-System-String-'></a>
### FromFile(path) `method`

##### Summary

Reads image frame from file

##### Returns

Image frame with image data

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| path | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Filename |

<a name='M-StreamCompress-Domain-Image-ImageFrame-Open-System-String-'></a>
### Open(path) `method`

##### Summary

Reads image frame from file

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| path | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-StreamCompress-Domain-Image-ImageFrame-Save-System-String-'></a>
### Save(path) `method`

##### Summary

Saves image frame to file

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| path | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-StreamCompress-Domain-Image-ImageFrame-SetSizeInfo-System-UInt32,System-Int32,System-Int32-'></a>
### SetSizeInfo(length,widthPx,heightPx) `method`

##### Summary

Sets size information to header

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| length | [System.UInt32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.UInt32 'System.UInt32') | Image total length |
| widthPx | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Image width in pixels |
| heightPx | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Image height in pixels |

<a name='T-StreamCompress-Domain-Image-ImageFrameGrayScale'></a>
## ImageFrameGrayScale `type`

##### Namespace

StreamCompress.Domain.Image

##### Summary

Present image frame which image is gray scale image

<a name='M-StreamCompress-Domain-Image-ImageFrameGrayScale-#ctor'></a>
### #ctor() `constructor`

##### Summary

Parametless constructor

##### Parameters

This constructor has no parameters.

<a name='M-StreamCompress-Domain-Image-ImageFrameGrayScale-#ctor-System-Byte[]-'></a>
### #ctor(image) `constructor`

##### Summary

Constructor to create image frame from byte array

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| image | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | Bitmap image byte array |

<a name='M-StreamCompress-Domain-Image-ImageFrameGrayScale-SetColorTable'></a>
### SetColorTable() `method`

##### Summary

Generates color table to image header

##### Parameters

This method has no parameters.

<a name='M-StreamCompress-Domain-Image-ImageFrameGrayScale-StreamCompress#Utils#ISaveable{StreamCompress#Domain#Image#ImageFrameGrayScale}#Open-System-String-'></a>
### StreamCompress#Utils#ISaveable{StreamCompress#Domain#Image#ImageFrameGrayScale}#Open(path) `method`

##### Summary

Saves image frame to file

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| path | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-StreamCompress-Domain-Image-ImageFrameGrayScale-StreamCompress#Utils#ISaveable{StreamCompress#Domain#Image#ImageFrameGrayScale}#Save-System-String-'></a>
### StreamCompress#Utils#ISaveable{StreamCompress#Domain#Image#ImageFrameGrayScale}#Save(path) `method`

##### Summary

Reads image frame from file

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| path | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='T-StreamCompress-Program-LZCompressionDictionary'></a>
## LZCompressionDictionary `type`

##### Namespace

StreamCompress.Program

##### Summary

LZ compression dictionary types

<a name='F-StreamCompress-Program-LZCompressionDictionary-HashTable'></a>
### HashTable `constants`

##### Summary

Hash table implementation

<a name='F-StreamCompress-Program-LZCompressionDictionary-Trie'></a>
### Trie `constants`

##### Summary

Trie dynamic size node table implementation

<a name='F-StreamCompress-Program-LZCompressionDictionary-Trie256'></a>
### Trie256 `constants`

##### Summary

Trie fixed size node table implementation

<a name='T-StreamCompress-Domain-LZ-LZImageFrame'></a>
## LZImageFrame `type`

##### Namespace

StreamCompress.Domain.LZ

##### Summary

Presents single image frame in LZ compressed form

<a name='M-StreamCompress-Domain-LZ-LZImageFrame-#ctor'></a>
### #ctor() `constructor`

##### Summary

Parametless constructor

##### Parameters

This constructor has no parameters.

<a name='M-StreamCompress-Domain-LZ-LZImageFrame-#ctor-System-Byte[]-'></a>
### #ctor(codes) `constructor`

##### Summary

Constructor to create frame from byte array

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| codes | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') |  |

<a name='P-StreamCompress-Domain-LZ-LZImageFrame-Codes'></a>
### Codes `property`

##### Summary

Byte array which contains compressed image

<a name='M-StreamCompress-Domain-LZ-LZImageFrame-Open-System-String-'></a>
### Open(path) `method`

##### Summary

Reads comressed image frame from file

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| path | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-StreamCompress-Domain-LZ-LZImageFrame-Save-System-String-'></a>
### Save(path) `method`

##### Summary

Saves compressed image frame to file

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| path | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='T-StreamCompress-Program-Method'></a>
## Method `type`

##### Namespace

StreamCompress.Program

##### Summary

Supported methods

<a name='F-StreamCompress-Program-Method-AsGZipDecoded'></a>
### AsGZipDecoded `constants`

##### Summary

Decodes image using GZip compression

<a name='F-StreamCompress-Program-Method-AsGZipEncoded'></a>
### AsGZipEncoded `constants`

##### Summary

Encodes image using GZip compression

<a name='F-StreamCompress-Program-Method-AsGrayScale'></a>
### AsGrayScale `constants`

##### Summary

Converts image as gray scale

<a name='F-StreamCompress-Program-Method-AsGrayScaleAsGZipDecoded'></a>
### AsGrayScaleAsGZipDecoded `constants`

##### Summary

Decodes gray scale image using GZip compression

<a name='F-StreamCompress-Program-Method-AsGrayScaleAsGZipEncoded'></a>
### AsGrayScaleAsGZipEncoded `constants`

##### Summary

Converts image as gray scale and encodes image using GZip compression

<a name='F-StreamCompress-Program-Method-AsGrayScaleAsHuffmanDecoded'></a>
### AsGrayScaleAsHuffmanDecoded `constants`

##### Summary

Decodes huffman encoded gray scale image

<a name='F-StreamCompress-Program-Method-AsGrayScaleAsHuffmanEncoded'></a>
### AsGrayScaleAsHuffmanEncoded `constants`

##### Summary

Converts image as gray scale and encode it using Huffman coding

<a name='F-StreamCompress-Program-Method-AsGrayScaleAsLZ78Decoded'></a>
### AsGrayScaleAsLZ78Decoded `constants`

##### Summary

Decodes gray scale image using LZ78 compression

<a name='F-StreamCompress-Program-Method-AsGrayScaleAsLZ78Encoded'></a>
### AsGrayScaleAsLZ78Encoded `constants`

##### Summary

Converts image as gray scale and encodes image using LZ78 compression

<a name='F-StreamCompress-Program-Method-AsLZ78Decoded'></a>
### AsLZ78Decoded `constants`

##### Summary

Decodes image using LZ78 compression

<a name='F-StreamCompress-Program-Method-AsLZ78Encoded'></a>
### AsLZ78Encoded `constants`

##### Summary

Encodes image using LZ78 compression

<a name='T-StreamCompress-Domain-Huffman-MinHeap`1'></a>
## MinHeap\`1 `type`

##### Namespace

StreamCompress.Domain.Huffman

##### Summary

Min heap implementation

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Data to store into node |

<a name='M-StreamCompress-Domain-Huffman-MinHeap`1-#ctor-System-Int32-'></a>
### #ctor(n) `constructor`

##### Summary

Constructor for new heap

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| n | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Maximum size of nodes in tree |

<a name='F-StreamCompress-Domain-Huffman-MinHeap`1-_heap'></a>
### _heap `constants`

##### Summary

heap table

<a name='F-StreamCompress-Domain-Huffman-MinHeap`1-_heapData'></a>
### _heapData `constants`

##### Summary

nodes data

<a name='P-StreamCompress-Domain-Huffman-MinHeap`1-HeapSize'></a>
### HeapSize `property`

##### Summary

Heap size

<a name='M-StreamCompress-Domain-Huffman-MinHeap`1-DelMin'></a>
### DelMin() `method`

##### Summary

Removes smallest key from heap and returns node data

##### Returns

Smallest key and node data

##### Parameters

This method has no parameters.

<a name='M-StreamCompress-Domain-Huffman-MinHeap`1-Insert-System-Int32,`0-'></a>
### Insert(nodeKey,nodeData) `method`

##### Summary

Inserts new node to heap

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| nodeKey | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') |  |
| nodeData | [\`0](#T-`0 '`0') |  |

<a name='M-StreamCompress-Domain-Huffman-MinHeap`1-_getParentIndex-System-Int32-'></a>
### _getParentIndex(i) `method`

##### Summary

Resolves given index parent node index

##### Returns

Parent index

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| i | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') |  |

<a name='M-StreamCompress-Domain-Huffman-MinHeap`1-_heapify-System-Int32-'></a>
### _heapify(i) `method`

##### Summary

Heapify routine

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| i | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Start index |

<a name='M-StreamCompress-Domain-Huffman-MinHeap`1-_leftChildNodeIndex-System-Int32-'></a>
### _leftChildNodeIndex(i) `method`

##### Summary

Resolves given index left child node index

##### Returns

Left child index

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| i | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Node index |

<a name='M-StreamCompress-Domain-Huffman-MinHeap`1-_rightChildNodeIndex-System-Int32-'></a>
### _rightChildNodeIndex(i) `method`

##### Summary

Resolves given index right child node index

##### Returns

Right child index

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| i | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Node index |

<a name='M-StreamCompress-Domain-Huffman-MinHeap`1-_swapNodeLocations-System-Int32,System-Int32-'></a>
### _swapNodeLocations(i,j) `method`

##### Summary

Switch two node index locations in table

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| i | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Index 1 |
| j | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Index 2 |

<a name='T-StreamCompress-Program'></a>
## Program `type`

##### Namespace

StreamCompress

##### Summary

Main program

<a name='M-StreamCompress-Program-Main-System-String[]-'></a>
### Main(args) `method`

##### Summary

Program start method

##### Returns

0 when OK

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| args | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') | Command line arguments |

<a name='M-StreamCompress-Program-SourceLooper``2-StreamCompress-Program-CommandLineArgs,System-Func{System-Int32,StreamCompress-Program-CommandLineArgs,``0,StreamCompress-Utils-ISaveable{``1}}-'></a>
### SourceLooper\`\`2(cmdArgs,func) `method`

##### Summary

Iterates over source folder and reads file using index. 
Executes given function and then saves return value to file.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| cmdArgs | [StreamCompress.Program.CommandLineArgs](#T-StreamCompress-Program-CommandLineArgs 'StreamCompress.Program.CommandLineArgs') | Command line arguments |
| func | [System.Func{System.Int32,StreamCompress.Program.CommandLineArgs,\`\`0,StreamCompress.Utils.ISaveable{\`\`1}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Int32,StreamCompress.Program.CommandLineArgs,``0,StreamCompress.Utils.ISaveable{``1}}') | Executing function |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of domain object |
| R | Type of domain object |

<a name='M-StreamCompress-Program-_filePath-System-Int32,System-String,System-String-'></a>
### _filePath(i,path,suffix) `method`

##### Summary

Builds full path to file

##### Returns

Full path

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| i | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | File index |
| path | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | File path |
| suffix | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | File suffix |

<a name='T-StreamCompress-Domain-LZ-Tries256`1'></a>
## Tries256\`1 `type`

##### Namespace

StreamCompress.Domain.LZ

##### Summary

Implements trie algoritm using fixed length node table

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-StreamCompress-Domain-LZ-Tries256`1-#ctor'></a>
### #ctor() `constructor`

##### Summary

Constructor

##### Parameters

This constructor has no parameters.

<a name='P-StreamCompress-Domain-LZ-Tries256`1-Count'></a>
### Count `property`

##### Summary

Nodes count

<a name='M-StreamCompress-Domain-LZ-Tries256`1-Insert-System-Byte[],`0-'></a>
### Insert(searchKey,codeWord) `method`

##### Summary

Adds new item to dictionary

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| searchKey | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | Key |
| codeWord | [\`0](#T-`0 '`0') | Value |

<a name='M-StreamCompress-Domain-LZ-Tries256`1-Search-System-Byte[]-'></a>
### Search(searchKey) `method`

##### Summary

Search item from dictionary

##### Returns

Item if it exists

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| searchKey | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | Key |

<a name='T-StreamCompress-Domain-LZ-Tries256`1-TriesContainer256`1'></a>
## TriesContainer256\`1 `type`

##### Namespace

StreamCompress.Domain.LZ.Tries256`1

##### Summary

Container node, which contains nodes

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TT | Type of code word |

<a name='P-StreamCompress-Domain-LZ-Tries256`1-TriesContainer256`1-CodeWord'></a>
### CodeWord `property`

##### Summary

Word saved to this container

<a name='P-StreamCompress-Domain-LZ-Tries256`1-TriesContainer256`1-IsSet'></a>
### IsSet `property`

##### Summary

Is container node that contains full word

<a name='P-StreamCompress-Domain-LZ-Tries256`1-TriesContainer256`1-Nodes'></a>
### Nodes `property`

##### Summary

Nodes saved to this container

<a name='M-StreamCompress-Domain-LZ-Tries256`1-TriesContainer256`1-Add-System-Byte-'></a>
### Add(b) `method`

##### Summary

Adds byte to container

##### Returns

Added node

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| b | [System.Byte](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte 'System.Byte') | byte |

<a name='M-StreamCompress-Domain-LZ-Tries256`1-TriesContainer256`1-Get-System-Byte-'></a>
### Get(b) `method`

##### Summary

Return byte from container if it is set

##### Returns

Node if it's set else null

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| b | [System.Byte](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte 'System.Byte') | Byte to look up |

<a name='M-StreamCompress-Domain-LZ-Tries256`1-TriesContainer256`1-SetCodeWord-`1-'></a>
### SetCodeWord(codeWord) `method`

##### Summary

Sets code word to container

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| codeWord | [\`1](#T-`1 '`1') |  |

<a name='T-StreamCompress-Domain-LZ-Tries`1-TriesContainer`1'></a>
## TriesContainer\`1 `type`

##### Namespace

StreamCompress.Domain.LZ.Tries`1

##### Summary

Container node, which contains nodes

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TT | Type of code word |

<a name='M-StreamCompress-Domain-LZ-Tries`1-TriesContainer`1-#ctor-System-Int32-'></a>
### #ctor(capacity) `constructor`

##### Summary

Container constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| capacity | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Nodes tabel intiial capacity |

<a name='P-StreamCompress-Domain-LZ-Tries`1-TriesContainer`1-CodeWord'></a>
### CodeWord `property`

##### Summary

Word saved to this container

<a name='P-StreamCompress-Domain-LZ-Tries`1-TriesContainer`1-IsSet'></a>
### IsSet `property`

##### Summary

Is container node that contains full word

<a name='P-StreamCompress-Domain-LZ-Tries`1-TriesContainer`1-Nodes'></a>
### Nodes `property`

##### Summary

Nodes saved to this container

<a name='P-StreamCompress-Domain-LZ-Tries`1-TriesContainer`1-NodesCount'></a>
### NodesCount `property`

##### Summary

Count of nodes

<a name='M-StreamCompress-Domain-LZ-Tries`1-TriesContainer`1-Add-System-Byte-'></a>
### Add(b) `method`

##### Summary

Adds byte to container

##### Returns

Added node

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| b | [System.Byte](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte 'System.Byte') | byte |

<a name='M-StreamCompress-Domain-LZ-Tries`1-TriesContainer`1-Get-System-Byte-'></a>
### Get(b) `method`

##### Summary

Return byte from container if it is set

##### Returns

Node if it's set else null

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| b | [System.Byte](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte 'System.Byte') | Byte to look up |

<a name='T-StreamCompress-Domain-LZ-Tries256`1-TriesNode256`1'></a>
## TriesNode256\`1 `type`

##### Namespace

StreamCompress.Domain.LZ.Tries256`1

##### Summary

Node that contains byte value and links to child containers

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TTT |  |

<a name='M-StreamCompress-Domain-LZ-Tries256`1-TriesNode256`1-#ctor-System-Byte-'></a>
### #ctor(b) `constructor`

##### Summary

Node constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| b | [System.Byte](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte 'System.Byte') | Byte value |

<a name='P-StreamCompress-Domain-LZ-Tries256`1-TriesNode256`1-Byte'></a>
### Byte `property`

##### Summary

Byte

<a name='P-StreamCompress-Domain-LZ-Tries256`1-TriesNode256`1-ChildContainer'></a>
### ChildContainer `property`

##### Summary

Child container

<a name='T-StreamCompress-Domain-LZ-Tries`1-TriesNode`1'></a>
## TriesNode\`1 `type`

##### Namespace

StreamCompress.Domain.LZ.Tries`1

##### Summary

Node that contains byte value and links to child containers

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TTT |  |

<a name='M-StreamCompress-Domain-LZ-Tries`1-TriesNode`1-#ctor-System-Byte,System-Int32-'></a>
### #ctor(b,capacity) `constructor`

##### Summary

Node constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| b | [System.Byte](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte 'System.Byte') | Byte value |
| capacity | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Child container initial capacity |

<a name='P-StreamCompress-Domain-LZ-Tries`1-TriesNode`1-Byte'></a>
### Byte `property`

##### Summary

Byte

<a name='P-StreamCompress-Domain-LZ-Tries`1-TriesNode`1-ChildContainer'></a>
### ChildContainer `property`

##### Summary

Child container

<a name='T-StreamCompress-Domain-LZ-Tries`1'></a>
## Tries\`1 `type`

##### Namespace

StreamCompress.Domain.LZ

##### Summary

Implements trie algoritmin using dynamic size node table

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-StreamCompress-Domain-LZ-Tries`1-#ctor-System-Int32-'></a>
### #ctor(containerCapacity) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| containerCapacity | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') |  |

<a name='P-StreamCompress-Domain-LZ-Tries`1-Count'></a>
### Count `property`

##### Summary

Items count

<a name='M-StreamCompress-Domain-LZ-Tries`1-Insert-System-Byte[],`0-'></a>
### Insert(searchKey,codeWord) `method`

##### Summary

Adds new item to dictionary

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| searchKey | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | Key |
| codeWord | [\`0](#T-`0 '`0') | Value |

<a name='M-StreamCompress-Domain-LZ-Tries`1-Search-System-Byte[]-'></a>
### Search(searchKey) `method`

##### Summary

Search item from dictionary

##### Returns

Existing key value or null

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| searchKey | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | Key |
