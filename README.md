# Search Fight
Rank and compare keywords by results on search engines

Using Newtonsoft JSon libraries
```
dotnet add package Newtonsoft.Json
```

Using Google and Bing APIs

Built in .NET Core

```
dotnet build
dotnet publish -r win10-x64
bin/Debug/netcoreapp2.2/win10-x64/publish/searchfight.exe java "mastering .net" python

java: SearchFight.GoogleSearch: 419000000 SearchFight.BingSearch: 23500000
python: SearchFight.GoogleSearch: 271000000 SearchFight.BingSearch: 17300000
SearchFight.GoogleSearch Winner: java (419000000)
SearchFight.BingSearch Winner: java (23500000)
Total Winner: java (442500000)
```
