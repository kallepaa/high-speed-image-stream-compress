# Viikko 5

_Mitä olen tehnyt tällä viikolla?_

* Trie algoritmin totetus vakiokokoisilla 256 paikkaisilla tauluilla
* Käyttöohjeet
* Ensimmäinen julkaisu ohjelmasta
* Suoritukyky / vertailu testauksia
* Päivittänyt koodin dokumentointia

_Miten ohjelma on edistynyt?_

* Trie algoritmin toteutus ja lisääminen yhdeksi vaihtoehdoksi LZ78 pakkaukseen

_Mitä opin tällä viikolla / tänään?_

* Julkaisun tekeminen GitHubiin
* Suorituskyky testauksessa käyttämäni BenchmarkDotNet kehikon käyttämistä

_Mikä jäi epäselväksi tai tuottanut vaikeuksia? Vastaa tähän kohtaan rehellisesti, koska saat tarvittaessa apua tämän kohdan perusteella._

_Mitä teen seuraavaksi?_

* Viimeistelen suorituskykytestaukset ja testausdokumentin
* Viimeistelen toteutusdokumentin

# Viikko 4

_Mitä olen tehnyt tällä viikolla?_

* Valitettavasti en kerennyt edistämään työtä tällä viikolla

_Miten ohjelma on edistynyt?_

* Tällä viikolla ei edistystä 

_Mitä opin tällä viikolla / tänään?_

_Mikä jäi epäselväksi tai tuottanut vaikeuksia? Vastaa tähän kohtaan rehellisesti, koska saat tarvittaessa apua tämän kohdan perusteella._


_Mitä teen seuraavaksi?_

* Muutan palautteen perusteella Trie toteutusta niin, että jokaisessa solmussa on 256 kokoinen taulu
* Viimeistelen toteutusdokumentin
* Teen käyttöohjeet
* Teen ohjelmasta julkaisun GitHubiin
* Aloitan testausdokumentin tekemisen

# Viikko 3

_Mitä olen tehnyt tällä viikolla?_

* Selvitellyt LZ77 koodausken periaatteita. MS:ltä löytyi yksinkertainen kuvaus periaatteista. [LZ77 Compression Algorithm
](https://docs.microsoft.com/en-us/openspecs/windows_protocols/ms-wusp/fb98aa28-5cd7-407f-8869-a6cef1ff1ccb)
* Toteuttanut Trie algoritmin vaihtoehtona hajautustaululle nykyisessä LZ koodauksessa
* Aloittanut toteutusdokumentin tekemistä
* Viimeistellyt CLI toteutuksen
* Täydentänyt yksikkö testauksia
* Lisännyt yksikkötestauksiin testikattavuus raportin
* Täydentänyt koodin dokumentointia
* Uudelleen järjestellyt lähdekoodin hakemisto ja nimiavaruuksien rakennetta

_Miten ohjelma on edistynyt?_

* Trie algoritmi on vaihtoehto hajautustaululle
* Ohjelmaa voidaan ajaa komentokehotteesta 

_Mitä opin tällä viikolla / tänään?_

* Tire algoritmin periaatteet
* LZ77 algoritmin yksinkertaiset periaatteet 
* Tehokkaan koodin toteuttaminen isoilla syötteillä ei ole helppoa

_Mikä jäi epäselväksi tai tuottanut vaikeuksia? Vastaa tähän kohtaan rehellisesti, koska saat tarvittaessa apua tämän kohdan perusteella._

* Trie algoritmi ei parantanut suoritus kykyä. Pisimmät hakuavaimet ovat 512 tavua. Tuskin pystyn tämän työn aikana pääsemään määrittelyssä määrittämiini nopeus tavoitteisiin. Jos on vielä aikaa niin teen totetuksen LZ77 lla.

_Mitä teen seuraavaksi?_

* Viimeistelen toteutusdokumentin
* Teen käyttöohjeet
* Teen ohjelmasta julkaisun GitHubiin
* Aloitan testausdokumentin tekemisen

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