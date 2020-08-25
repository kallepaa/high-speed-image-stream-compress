``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17134.1667 (1803/April2018Update/Redstone4)
Intel Core i5-6600K CPU 3.50GHz (Skylake), 1 CPU, 4 logical and 4 physical cores
Frequency=3421871 Hz, Resolution=292.2378 ns, Timer=TSC
.NET Core SDK=3.1.100
  [Host]          : .NET Core 2.1.8 (CoreCLR 4.6.27317.03, CoreFX 4.6.27317.03), X64 RyuJIT
  EncodeAndDecode : .NET Core 2.1.8 (CoreCLR 4.6.27317.03, CoreFX 4.6.27317.03), X64 RyuJIT

Job=EncodeAndDecode  IterationCount=1  LaunchCount=3  
RunStrategy=ColdStart  WarmupCount=1  

```
|                                Method |        Mean |       Error |     StdDev |      Median |       Gen 0 |       Gen 1 |     Gen 2 |  Allocated |
|-------------------------------------- |------------:|------------:|-----------:|------------:|------------:|------------:|----------:|-----------:|
|   &#39;Encode LZ HashTable - Prime 12289&#39; | 7,247.07 ms |   588.70 ms |  32.269 ms | 7,233.61 ms | 103000.0000 |  23000.0000 | 4000.0000 |  561.31 MB |
| &#39;Encode LZ Trie - Initial capacity 1&#39; | 3,510.18 ms |   224.14 ms |  12.286 ms | 3,510.95 ms |  85000.0000 |  20000.0000 | 4000.0000 |  462.53 MB |
|                   &#39;Encode LZ Trie256&#39; | 5,165.94 ms |   364.88 ms |  20.000 ms | 5,158.48 ms | 342000.0000 | 122000.0000 | 6000.0000 |  2001.6 MB |
|                         &#39;Encode GZip&#39; |    82.63 ms |    13.13 ms |   0.720 ms |    82.34 ms |           - |           - |         - |    5.58 MB |
|   &#39;Decode LZ HashTable - Prime 12289&#39; | 5,333.87 ms |   146.10 ms |   8.008 ms | 5,337.76 ms |  51000.0000 |  13000.0000 | 3000.0000 |  301.38 MB |
| &#39;Decode LZ Trie - Initial capacity 1&#39; | 3,765.47 ms |   493.05 ms |  27.026 ms | 3,779.89 ms |  79000.0000 |  27000.0000 | 4000.0000 |  459.71 MB |
|                   &#39;Decode LZ Trie256&#39; | 7,265.92 ms |   783.88 ms |  42.967 ms | 7,289.84 ms | 615000.0000 | 220000.0000 | 7000.0000 | 3657.17 MB |
|                         &#39;Decode GZip&#39; |   191.69 ms | 5,387.08 ms | 295.284 ms |    21.31 ms |           - |           - |         - |   10.51 MB |
