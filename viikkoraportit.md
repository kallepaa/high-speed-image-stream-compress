# Viikko 2

_Mitä olen tehnyt tällä viikolla?_

* Viimeistellyt Huffman koodauksen
* Selvittänyt LZ pakkausta
* Toteuttanut ensimmäisen version LZ pakkauksesta
* Testannut alustavasti pakkausten nopeutta ja kompressiosuhdetta
* Lisännyt ensimmäiset yksikkötestit

_Miten ohjelma on edistynyt?_

*  Huffman koodauksen ja LZ koodauksen toteutukset tehty 

_Mitä opin tällä viikolla / tänään?_

* LZ pakkauksen enkoodauksen ja dekoodauksen periaatteet
* LZ pakkauksesta on kaksi eri haaraa, jotka poikkeavat toisistaa.
* LZ77 haarasta löytämäni [LZ4](https://github.com/lz4/lz4) toteutus pystyisi suorituskykystestausten perusteella pakkamaan riittävän nopeasti kuvavirtaa kahdesta 120FPS x 1280px x 720px kamerasta

_Mikä jäi epäselväksi tai tuottanut vaikeuksia? Vastaa tähän kohtaan rehellisesti, koska saat tarvittaessa apua tämän kohdan perusteella._

* Suurin ongelma tällä hetkellä on toteuttaa LZ pakkauksessa tarvittava nopea haku. 
Siinä ongelmana on tarkemmin sanottuna löytää "variable-length" avaimelle (K) riittävän hyvä hajautus, jotta
haku tapahtuisi vakioajassa. Tällä hetkellä olen käyttänyt "Stack ower flowsta" löytämääni esimerkkiä FNV laskennasta. Tarvitsin vinkkiä tehokkaamalle lisäys / haku algoritmin toteutukselle.

_Mitä teen seuraavaksi?_

* Lisään enemmän yksikkö testauksia
* Lisään testauskattavuudet yksikkötestauksille
* Pyrin selvittämään LZ77 pakkauksen toteutuksen

# Viikko 1

_Mitä olen tehnyt tällä viikolla?_

* Tehnyt määrittely dokumentin
* Perustanut Githubiin projektin
* Perehtynyt bitmap kuvien koodaukseen
* Toteuttanut alustavat bitmap kuvien croppauksen ja muunnon harmaasävyisiksi 8 bit per pikseli
* Perehtynyt Huffman pakkaus algoritmiin
* Aloittanut algoritmin toteuttamisen

_Miten ohjelma on edistynyt?_

*  Bitmap kuvien esikäsittely huffman enkoodausta varten tehty
*  Bitmap kuvan kuvasisällön enkoodaus muistiin toteutettu 

_Mitä opin tällä viikolla / tänään?_

* Bitmap kuvien koodauksen
* Huffman algoritmin enkoodauksen ja dekoodauksen periaatteet

_Mikä jäi epäselväksi tai tuottanut vaikeuksia? Vastaa tähän kohtaan rehellisesti, koska saat tarvittaessa apua tämän kohdan perusteella._

* Tällä hetkellä ei epäselviä asioita

_Mitä teen seuraavaksi?_

* Viimeistelen Huffman enkoodauksen otsakkeen Huffman puun tietojen tallentamista varten ja siirryn sitten enkoodaukseen
* Perehdyn LZ pakkaukseen