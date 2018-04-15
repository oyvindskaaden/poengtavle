# poengtavle

Dette programmet er skrevet i C# og er en poengtavle

Programmet er fremdeles under utvikling, men er mulig å teste selv. For å gjøre dette, følg installasjonsinstruks under

## Instalasjonsinstrukser

* Last ned eller clone denne giten
  - Git Clone: https://github.com/oyvindskaaden/poengtavle.git
  - Zip-fil: https://github.com/oyvindskaaden/poengtavle/archive/master.zip
    * Unzip mappen
* Flytt "Kurs"-mappen til Mine Dokumenter mappen på maskinen din.
  - Typisk `C:\Users\DITTNAVN\My Documets\`
* Åpne `poengtavle.sln` i Visual Studio 2017
* For at programmet skal fungere **må** du installere [Json.NET](https://www.newtonsoft.com/json)
  - Trykk last ned og følg instrukser
    - Trykk `Tools > NuGet Package Manager > Package Manager Console`
    - Lim inn denne teksten i konsollen: `Install-Package Newtonsoft.Json`
    - [Json.NET](https://www.newtonsoft.com/json) skal nå være installert
    - [Denne](https://docs.microsoft.com/en-us/nuget/quickstart/install-and-use-a-package-in-visual-studio) artikkelen av microsoft er også ganske bra, bruker også [Json.NET](https://www.newtonsoft.com/json) som et eksempel.
* Programmet skal fungere som normalt nå

## Lage egne poengtavler

Du kan lagre egne poengtavler ved å trykke på ny poengtavle eller åpne vedlagt `Maler/Fotball.ptc`.

Når du trykker `Ny poengtavle` vil du få muligheten til å lage din egen poengtavle. For å legge til objekter, klikker du på knappene på siden. For å flytte på objektene, bare "drag and drop".
