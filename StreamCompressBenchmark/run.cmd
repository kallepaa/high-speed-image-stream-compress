SET results=%cd%
dotnet build --configuration release
cd bin\release\netcoreapp2.1
echo %results%
dotnet StreamCompressBenchmark.dll -f StreamCompressBenchmark.Encode.* -a %results% -e GitHub
cd ..\..\..