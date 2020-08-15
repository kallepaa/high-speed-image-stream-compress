SET results=%cd%\Artifacts
dotnet build --configuration release
cd bin\release\netcoreapp2.1
echo %results%
dotnet StreamCompressBenchmark.dll -f * -a %results%
cd ..\..\..