# Käyttöohje

1. [Mene ohjelman julkaisut sivulle](../../releases)
2. Valitse paketeista oman käyttöjärjestelmäsi versio.
3. Lataa viimeisin julkaisun zip -paketti koneellesi. 
4. Lataa paketti ja pura se
5. Siirry hakemistoon
6. Aja ohjelma 

## Install .NET Core on Linux
Ohjeet dotnet asennukseen löytyvät osoitteesta https://docs.microsoft.com/en-us/dotnet/core/install/linux

## Install .NET Core on macOS
Ohjeet dotnet asennukseen löytyvät osoitteesta https://docs.microsoft.com/en-us/dotnet/core/install/macos

## Install .NET Core on Windows
Ohjeet dotnet asennukseen löytyvät osoitteesta https://docs.microsoft.com/en-us/dotnet/core/install/windows?tabs=netcore31


## Miten ohjelma suoritetaan, miten eri toiminnallisuuksia käytetään

Ohjelma suoritetaan komentokehotteesta käynnistämällä ohjelma komennolla *StreamCompress [options]*. Alla listaus ohjelman vastaanottamista syötteistä.

**Usage:**

StreamCompress [options]

**Options:**

--source-path <source-path> Stream images source folder

--source-file-suffix <source-file-suffix> Source filename suffix

--destination-path <destination-path> Destination folder

--destination-file-suffix <destination-file-suffix> Destination filename suffix

--start-index <start-index> Image stream first image index [default: 0]

--count <count> Count of images to handle [default: 1]

--method <AsGrayScale|AsGrayScaleAsHuffmanDecoded|AsGrayScaleAsHuffmanEncoded|AsGrayScaleAsLZ78Decoded|AsGrayScaleAsLZ78Encoded|AsLZ78Decoded|AsLZ78Encoded> Image handling method

--gray-scale-colors <Full|Half|Quarter> Gray scale image color count [default: Full]

--crop-left-px <crop-left-px> Image crop px left [default: 0]

--crop-right-px <crop-right-px> Image crop px right [default: 0]

--crop-top-px <crop-top-px> Image crop px top [default: 0]

--crop-bottom-px <crop-bottom-px> Image crop px bottom [default: 0]

--lz-compression-dictionary <HashTable|Trie|Trie256> LZ compression dictionary type [default: HashTable]

--lz-compression-hash-table-prime <lz-compression-hash-table-prime> LZ compression hash table prime [default: 12289]

--lz-compression-trie-initial-capacity <lz-compression-trie-initial-capacity> LZ compression trie node container initial capacity [default: 1]

--version Show version information

-?, -h, --help Show help and usage information

## Minkä muotoisia syötteitä ohjelma hyväksyy

Ohjelman osaa lukea 24 bittisä bittikartta (.bmp) kuvia, sekä ohjelman pakkaustiedostoja.

### Esimerkkejä

* Kuvan kroppaaminen, muuntaminen harmaasävyiseksi ja pakkaaminen LZ78 algoritmillä käyttäen oletus hakemistoa

>--source-path C:\Temp\Source --source-file-suffix original.bmp --destination-path C:\Temp\Destination --destination-file-suffix as-gray-scale-cropped-as-lz78-encoded --start-index 1 --count 1 --method AsGrayScaleAsLZ78Encoded --crop-left-px 432 --crop-right-px 464 --crop-top-px 16 --crop-bottom-px 96

* LZ78 pakatun harmaasävyisen kuvan dekoodaminen

>--source-path C:\Temp\Destination --source-file-suffix as-gray-scale-cropped-as-lz78-encoded --destination-path C:\Temp\Destination --destination-file-suffix as-gray-scale-cropped-as-lz78-encoded-decoded.bmp --start-index 1 --count 1 --method AsGrayScaleAsLZ78Decoded

* Kuvan kroppaaminen ja muuntaminen harmaasävyiseksi kuvaksi jossa 256 sävyä

>--source-path C:\Temp\Source --source-file-suffix original.bmp --destination-path C:\Temp\Destination --destination-file-suffix as-gray-scale-cropped.bmp --start-index 1 --count 1 --method AsGrayScale --crop-left-px 432 --crop-right-px 464 --crop-top-px 16 --crop-bottom-px 96


* Kuvan kroppaaminen ja pakkaaminen LZ78 algoritmilla

>--source-path C:\Temp\Source --source-file-suffix original.bmp --destination-path C:\Temp\Destination --destination-file-suffix cropped-as-lz78-encoded --start-index 1 --count 1 --method AsLZ78Encoded --crop-left-px 432 --crop-right-px 464 --crop-top-px 16 --crop-bottom-px 96

* LZ78 pakatun kuvan dekoodaminen

>--source-path C:\Temp\Destination --source-file-suffix cropped-as-lz78-encoded --destination-path C:\Temp\Destination --destination-file-suffix cropped-as-lz78-encoded-decoded.bmp --start-index 1 --count 1 --method AsLZ78Decoded

* Kuvan kroppaaminen, muuntaminen harmaasävyiseksi ja pakkaaminen Huffman algoritmillä

>--source-path C:\Temp\Source --source-file-suffix original.bmp --destination-path C:\Temp\Destination --destination-file-suffix as-gray-scale-cropped-as-huffman-encoded --start-index 1 --count 1 --method AsGrayScaleAsHuffmanEncoded --crop-left-px 432 --crop-right-px 464 --crop-top-px 16 --crop-bottom-px 96

* Huffman pakatun harmaasävyisen kuvan dekoodaaminen

>--source-path C:\Temp\Destination --source-file-suffix as-gray-scale-cropped-as-huffman-encoded --destination-path C:\Temp\Destination --destination-file-suffix as-gray-scale-cropped-as-huffman-encoded-decoded.bmp --start-index 1 --count 1 --method AsGrayScaleAsHuffmanDecoded

* Kuvan muuntaminen harmaasävyiseksi kuvaksi jossa 256 sävyä

>--source-path C:\Temp\Source --source-file-suffix original.bmp --destination-path C:\Temp\Destination --destination-file-suffix as-gray-scale.bmp --start-index 1 --count 1 --method AsGrayScale

* Kuvan muuntaminen harmaasävyiseksi ja pakkaaminen Huffman algoritmillä

>--source-path C:\Temp\Source --source-file-suffix original.bmp --destination-path C:\Temp\Destination --destination-file-suffix as-gray-scale-as-huffman-encoded --start-index 1 --count 1 --method AsGrayScaleAsHuffmanEncoded

* Kuvan pakkaaminen LZ78 algoritmillä käyttäen oletus hakemistoa

>--source-path C:\Temp\Source --source-file-suffix original.bmp --destination-path C:\Temp\Destination --destination-file-suffix as-lz78-encoded --start-index 1 --count 1 --method AsLZ78Encoded

* Kuvan kroppaaminen ja pakkaaminen LZ78 algoritmillä käyttäen Trie256 hakemistoa

>--source-path C:\Temp\Source --source-file-suffix original.bmp --destination-path C:\Temp\Destination --destination-file-suffix cropped-as-lz78-dic-trie-256-encoded --start-index 1 --count 1 --method AsLZ78Encoded --lz-compression-dictionary Trie256 --crop-left-px 432 --crop-right-px 464 --crop-top-px 16 --crop-bottom-px 96

* Kuvan pakkaaminen LZ78 algoritmillä käyttäen Trie256 hakemistoa

>--source-path C:\Temp\Source --source-file-suffix original.bmp --destination-path C:\Temp\Destination --destination-file-suffix as-lz78-dic-trie-256-encoded --start-index 1 --count 1 --method AsLZ78Encoded --lz-compression-dictionary Trie256

* LZ78 pakatun kuvan dekoodaminen käyttäen Trie256 hakemistoa

>--source-path C:\Temp\Destination --source-file-suffix cropped-as-lz78-dic-trie-256-encoded --destination-path C:\Temp\Destination --destination-file-suffix cropped-as-lz78-dic-trie-256-encoded-decoded.bmp --start-index 1 --count 1 --method AsLZ78Decoded --lz-compression-dictionary Trie256

* Kuvan muuntaminen harmaasävyiseksi ja pakkaaminen LZ78 algoritmiä

>--source-path C:\Temp\Source --source-file-suffix original.bmp --destination-path C:\Temp\Destination --destination-file-suffix as-gray-scale-as-lz78-encoded --start-index 1 --count 1 --method AsGrayScaleAsLZ78Encoded

* LZ78 pakatun harmaasävyisen kuvan dekoodaminen käyttäen oletus hakemistoa

>--source-path C:\Temp\Destination --source-file-suffix as-gray-scale-as-lz78-encoded --destination-path C:\Temp\Destination --destination-file-suffix as-gray-scale-as-lz78-encoded-decoded.bmp --start-index 1 --count 1 --method AsGrayScaleAsLZ78Decoded

* Kuvan kroppaaminen ja pakkaaminen LZ78 algoritmillä käyttäen Trie hakemistoa

>--source-path C:\Temp\Source --source-file-suffix original.bmp --destination-path C:\Temp\Destination --destination-file-suffix cropped-as-lz78-dic-trie-encoded --start-index 1 --count 1 --method AsLZ78Encoded --lz-compression-dictionary Trie --lz-compression-trie-initial-capacity 1 --crop-left-px 432 --crop-right-px 464 --crop-top-px 16 --crop-bottom-px 96

* Kuvan pakkaaminen LZ78 algoritmillä käyttäen Trie hakemistoa

>--source-path C:\Temp\Source --source-file-suffix original.bmp --destination-path C:\Temp\Destination --destination-file-suffix as-lz78-dic-trie-encoded --start-index 1 --count 1 --method AsLZ78Encoded --lz-compression-dictionary Trie --lz-compression-trie-initial-capacity 1


## Missä hakemistossa on jar ja ajamiseen tarvittavat testitiedostot.

Testitiedostot voi ladata GitHubista hakemistosta [StreamCompressTest/TestData/Source](https://github.com/kallepaa/high-speed-image-stream-compress/tree/master/StreamCompressTest/TestData/Source)

Koneella tulee olla kaksi hakemistoa esimerkiksi C:\Temp\Source johon testitiedostot tallennetaan ja C:\Temp\Destination, johon ohjelma tallentaa tulokset

Ohjelma puretaan yksinkertaisesti johonkin hakemistoon ja ajetaan komentokehotteesta.