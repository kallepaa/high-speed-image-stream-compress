``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17134.1667 (1803/April2018Update/Redstone4)
Intel Core i5-6600K CPU 3.50GHz (Skylake), 1 CPU, 4 logical and 4 physical cores
Frequency=3421871 Hz, Resolution=292.2378 ns, Timer=TSC
.NET Core SDK=3.1.100
  [Host]                      : .NET Core 2.1.8 (CoreCLR 4.6.27317.03, CoreFX 4.6.27317.03), X64 RyuJIT
  EncodeAndDecodeTrieCapacity : .NET Core 2.1.8 (CoreCLR 4.6.27317.03, CoreFX 4.6.27317.03), X64 RyuJIT

Job=EncodeAndDecodeTrieCapacity  IterationCount=1  LaunchCount=3  
RunStrategy=ColdStart  WarmupCount=1  

```
|     Method | Capacity |    Mean |    Error |   StdDev |       Gen 0 |       Gen 1 |     Gen 2 |  Allocated |
|----------- |--------- |--------:|---------:|---------:|------------:|------------:|----------:|-----------:|
| **EncodeTrie** |        **1** | **3.201 s** | **0.4903 s** | **0.0269 s** |  **85000.0000** |  **20000.0000** | **4000.0000** |  **462.53 MB** |
| DecodeTrie |        1 | 3.298 s | 0.6425 s | 0.0352 s |  79000.0000 |  27000.0000 | 4000.0000 |  459.71 MB |
| **EncodeTrie** |       **32** | **3.742 s** | **0.4215 s** | **0.0231 s** | **107000.0000** |  **34000.0000** | **4000.0000** |  **599.86 MB** |
| DecodeTrie |       32 | 4.190 s | 0.7074 s | 0.0388 s | 127000.0000 |  46000.0000 | 5000.0000 |  741.87 MB |
| **EncodeTrie** |       **64** | **4.221 s** | **0.6440 s** | **0.0353 s** | **142000.0000** |  **48000.0000** | **5000.0000** |  **800.58 MB** |
| DecodeTrie |       64 | 5.553 s | 0.8012 s | 0.0439 s | 198000.0000 |  72000.0000 | 6000.0000 | 1159.44 MB |
| **EncodeTrie** |      **128** | **4.889 s** | **1.4388 s** | **0.0789 s** | **210000.0000** |  **75000.0000** | **6000.0000** | **1202.99 MB** |
| DecodeTrie |      128 | 7.129 s | 0.9301 s | 0.0510 s | 337000.0000 | 119000.0000 | 6000.0000 | 1996.13 MB |
