``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17134.1667 (1803/April2018Update/Redstone4)
Intel Core i5-6600K CPU 3.50GHz (Skylake), 1 CPU, 4 logical and 4 physical cores
Frequency=3421871 Hz, Resolution=292.2378 ns, Timer=TSC
.NET Core SDK=3.1.100
  [Host]    : .NET Core 2.1.8 (CoreCLR 4.6.27317.03, CoreFX 4.6.27317.03), X64 RyuJIT
  EncodeJob : .NET Core 2.1.8 (CoreCLR 4.6.27317.03, CoreFX 4.6.27317.03), X64 RyuJIT

Job=EncodeJob  IterationCount=1  LaunchCount=3  
RunStrategy=ColdStart  WarmupCount=1  

```
|                      Method |    Mean |    Error |   StdDev |       Gen 0 |       Gen 1 |     Gen 2 | Allocated |
|---------------------------- |--------:|---------:|---------:|------------:|------------:|----------:|----------:|
|   &#39;HashTable - Prime 12289&#39; | 5.955 s | 0.1387 s | 0.0076 s |  90000.0000 |  22000.0000 | 4000.0000 | 521.62 MB |
| &#39;Trie - Initial capacity 1&#39; | 2.893 s | 0.3282 s | 0.0180 s |  73000.0000 |  19000.0000 | 4000.0000 | 422.83 MB |
|                     Trie256 | 4.327 s | 1.4956 s | 0.0820 s | 332000.0000 | 121000.0000 | 6000.0000 | 1961.9 MB |
