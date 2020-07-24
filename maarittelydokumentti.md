# Määrittelydokumentti

## Mitä algoritmeja ja tietorakenteita toteutat työssäsi

* 24 bit map kuva kroppaaminen
* 24 bittisen bitmap kuvan muunnos 8 bitin indeksoiduksi harmaasävyiseksi kuvaksi käyttäen lineaarista konversiota
* Minheap
* Huffman koodaus
* LZ* koodaus

## Mitä ongelmaa ratkaiset ja miksi valitsit kyseiset algoritmit/tietorakenteet

Ratkaista ongelma koskee 120 FPS 1280 x 720 px kameroiden kuvavirran pakkaamista ajantasaisesti ja häviämättömästi niin että oleellinen tieto säilyy.

Kuvan kroppaaminen esikäsittelynä on valittu sen takia, että oleellinen tieto kuvasta löytyy kuvan keskeltä. Varsinkin jos kuvaaminen tapahtuu normaalisti vaakatasossa, reunoille jää paljon turhaa informaatiota.

Valitsin kuvien muunnos algoritmin 24 bit -> 8 bit harmaansävuiseksi sen takia, että se pienentää kropatun kuvan kokoa kolmasosaan ilman pakkausta. Lisäksi 8 bitin pikseli tieto on suoraviivaisempaa koodata Huffman algoritmilla. Lisäksi 24 bit -> koodauksesa voidaan tiputtaa värien määrä portaittain 256, 128, 64 jne.. joka näyttäisi parantavan Huffman koodauksen pakkaustehoa.

Huffman koodaus oli mainittu esimerkkinä ja se on häviötön ja nopea. Sama asia LZ koodauksessa.

## Mitä syötteitä ohjelma saa ja miten näitä käytetään

### Enkoodaus

Ohjelma saa esikäsitellyn kuvavirran, jossa kuvat on koodattu 24 bit 1280 x 720 px bitmap kuvina. Alkuperäinen kuvavirta on YUV muodossa, mutta tätä työtä varten kuvavirta muunnetaan esikäsittelyssä YUV muodosta bittikartta muotoisiksi kuviksi.

Kuva kropataan ensin annettujen arvojen perusteella. Arvot annetaan ylä-, ala-, vasen-, ja oikea suunnista. 

Kroppauksen jälkeen kropattu kuva enkoodataan harmaasävyiseksi annettujen parametrin perusteella. Arvona voi antaa kuinka monta harmaasävyä käytetään kuvassa.

Harmaa sävyinen kuva enkoodataan Huffman algoritmillä tai / ja LZ* algoritmillä.

Pakattu kuva ja sen otsaketiedot palautetaan syötteen antajalle kuvavirtatiedostoon tallentamista varten.

### Dekoodaus

Pakattu kuva ja sen pakkauksen otsaketiedot annetaaan ohjelmalle. Ohjelma palauttaa pakatun kuvan harmaasävyisenä kuvana.

## Tavoitteena olevat aika- ja tilavaativuudet (m.m. O-analyysit)

Tavoitteena oleva käytännöllinen aikavaatimus yhden kuvan enkoodaukselle  on, että se ei saa kestää pidempään kuin 1 / 120 s. Käytännössä sen pitää olla nopeampi. Lisäksi tavoitteena on että useamman kameran liittäminen on mahdollista. Dekoodauksen ei tarvitse olla yhtä nopea, koska kuvat pitää pystyä dekoodaamaan 1 / 30 s.

Tilan vaatimus tulee suoraan käytetyistä algoritmeistä. Käytännössä tilaa vaaditaan koodauksen ajan syötteen verran, jokaisen muunnoksen aikana. 

## Lähteet

* [Bits to Bitmaps: A simple walkthrough of BMP Image Format](https://itnext.io/bits-to-bitmaps-a-simple-walkthrough-of-bmp-image-format-765dc6857393)
* [Grayscale](https://en.wikipedia.org/wiki/Grayscale)
* [Huffman coding](https://en.wikipedia.org/wiki/Huffman_coding)
* [LZ77 and LZ78](https://en.wikipedia.org/wiki/LZ77_and_LZ78)