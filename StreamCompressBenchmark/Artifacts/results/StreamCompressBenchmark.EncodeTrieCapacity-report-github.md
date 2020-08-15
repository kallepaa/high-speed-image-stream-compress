``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17134.1667 (1803/April2018Update/Redstone4)
Intel Core i5-6600K CPU 3.50GHz (Skylake), 1 CPU, 4 logical and 4 physical cores
Frequency=3421871 Hz, Resolution=292.2378 ns, Timer=TSC
.NET Core SDK=3.1.100
  [Host]                : .NET Core 2.1.8 (CoreCLR 4.6.27317.03, CoreFX 4.6.27317.03), X64 RyuJIT
  EncodeTrieCapacityJob : .NET Core 2.1.8 (CoreCLR 4.6.27317.03, CoreFX 4.6.27317.03), X64 RyuJIT

Job=EncodeTrieCapacityJob  IterationCount=1  LaunchCount=3  
RunStrategy=ColdStart  WarmupCount=1  

```
| Method | Capacity |     Mean |    Error |   StdDev |        Gen 0 |       Gen 1 |     Gen 2 |  Allocated |
|------- |--------- |---------:|---------:|---------:|-------------:|------------:|----------:|-----------:|
|   **Trie** |        **1** |  **3.066 s** | **1.8469 s** | **0.1012 s** |   **73000.0000** |  **19000.0000** | **4000.0000** |  **422.83 MB** |
|   **Trie** |       **10** |  **2.780 s** | **0.1687 s** | **0.0092 s** |   **74000.0000** |  **23000.0000** | **4000.0000** |  **426.57 MB** |
|   **Trie** |      **100** |  **4.104 s** | **0.6265 s** | **0.0343 s** |  **168000.0000** |  **61000.0000** | **5000.0000** |  **987.19 MB** |
|   **Trie** |     **1000** | **11.174 s** | **4.0823 s** | **0.2238 s** | **1116000.0000** | **398000.0000** | **9000.0000** | **6648.42 MB** |
