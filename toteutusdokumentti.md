# Toteutusdokumentti

## Ohjelman yleisrakenne

### Pääohjelma

Pääohjelma on toteutettu luokkaan Program.

### Ohjelman domain luokat ja rajapinnat

* Bittikarttakuva
  * ImageFrame
  * ImageFrameGrayScale
  * CropSetup
* Huffman koodaus
  * HuffmanImageFrame
  * HuffmanTreeNode
  * MinHeap 
* LZ koodaus
  * LZImageFrame
  * ILZ78CodingTable
  * HashTable
  * Tries

### Domain luokkien laajennukset

Domain luokkien laajennukset löytyvät Extensions luokasta.

Domain luokkien laajennukset toteuttavat käytännössä muunnokset eri domainluokkien välillä. 
Esimerkiksi kun luokka ImageFrame on alustettu, laajennuksien avulla se voidaan muuntaa ImageFrameGrayScale luokan instansiksi jne... 

### IO ym. muut tarvittavat laajennukset

* FileExtensions pitää sisällään IO operaatiot
* BitAndByteExtensions pitää sisällään tavujen ja bittien käsittelyyn tarvittavia operaatioita
* ISaveable rajapinnan avulla sen totteuttavat "Frame" luokat voidaan lukea ja tallentaa levylle
* ByteMemoryStream luokka piilottaa MemoryStream toteutuksen muistiin kirjoittamista varten

## Saavutetut aika- ja tilavaativuudet (m.m. O-analyysit pseudokoodista)

## Suorituskyky- ja O-analyysivertailu (mikäli työ vertailupainotteinen)

## Työn mahdolliset puutteet ja parannusehdotukset

## Lähteet