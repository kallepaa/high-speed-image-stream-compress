del -r .\Publish\win-x64
del -r .\Publish\osx-x64
del -r .\Publish\linux-x64

dotnet publish .\StreamCompress\StreamCompress.csproj -r win-x64 --output Publish\win-x64  
dotnet publish .\StreamCompress\StreamCompress.csproj -r osx-x64 --output Publish\osx-x64  
dotnet publish .\StreamCompress\StreamCompress.csproj -r linux-x64 --output Publish\linux-x64 
