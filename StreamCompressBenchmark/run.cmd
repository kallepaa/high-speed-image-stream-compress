SET results=%cd%
dotnet build --configuration release
cd bin\release\netcoreapp2.1
echo %results%
dotnet StreamCompressBenchmark.dll -f * -a %results% --disableLogFile
cd ..\..\..
cd results

copy *.md StreamCompressBenchmark.report-github.md
del *.csv
del *.html
cd ..