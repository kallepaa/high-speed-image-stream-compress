# Testausdokumentti

## Mitä on testattu, miten tämä tehtiin

### Yksikkötestaus

Yksikkötestaukseen on käytetty XUnit testauskehikkoa. Yksikkötestauksissa testattu ohjelman toiminnallisuuksia ja joita yksikköjä on testattu erikseen. Käytännössä testit ajettiin Visual Studion yksikkötestaus työkalun kautta. Testikattavuusraportin tiedot ajettiin myös Visual Studion kautta ja tulokset tallennettiin XML-muotoiseen tiedostoon nimeltä latest.coveragexml. Testiraportin ulkoasun generoimiseen käytettiin ReportGenerator ohjelmaan, joka ladattiin Nuget pakettina testiohjelmaan. ReportGenerator ohjelma suorittettiin komentokehotteesta komennolla

>dotnet %UserProfile%\.nuget\packages\reportgenerator\4.6.4\tools\netcoreapp2.1\ReportGenerator.dll "-reports:latest.coveragexml" "-targetdir:coveragereport" -reporttypes:Html  

ReportGenerator tallensin raportin ulkoasun tiedostot hakemistoon *coveragereport*, jonka voi katsella <a href="https://htmlpreview.github.io/?https://github.com/kallepaa/high-speed-image-stream-compress/blob/master/StreamCompressTest/coveragereport/index.html" target="_blank">tästä linkistä</a>

### Suorituskykytestaus


## Minkälaisilla syötteillä testaus tehtiin (vertailupainotteisissa töissä tärkeää)

### Yksikkötestaus
Syötteinä käytettiin oikeita kuvia, sekä jossain testeissä generoitua dataa.

### Suorituskykytestaus


## Miten testit voidaan toistaa

### Yksikkötestaus
Yksikkötestaukset voidaan ajaa Visual Studion kautta.

### Suorituskykytestaus

## Ohjelman toiminnan empiirisen testauksen tulosten esittäminen graafisessa muodossa.


