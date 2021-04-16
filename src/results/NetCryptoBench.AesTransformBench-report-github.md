``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.329 (2004/?/20H1)
AMD Ryzen Threadripper 1950X, 1 CPU, 32 logical and 16 physical cores
.NET Core SDK=5.0.100-preview.8.20327.6
  [Host]     : .NET Core 5.0.0 (CoreCLR 5.0.20.32609, CoreFX 5.0.20.32609), X64 RyuJIT
  Job-KIEEMV : .NET Core 5.0 (CoreCLR 42.42.42.42424, CoreFX 42.42.42.42424), X64 RyuJIT
  Job-NGJVVM : .NET Core 5.0 (CoreCLR 42.42.42.42424, CoreFX 42.42.42.42424), X64 RyuJIT


```
|                      Method |        Job |   Toolchain | DataSize |  Mode |            Mean |         Error |        StdDev | Ratio | RatioSD |    Gen 0 |    Gen 1 |    Gen 2 | Allocated |
|---------------------------- |----------- |------------ |--------- |------ |----------------:|--------------:|--------------:|------:|--------:|---------:|---------:|---------:|----------:|
|      **Encrypt_TransformBlock** | **Job-KIEEMV** | **crypto-span** |       **16** |  **None** |        **84.22 ns** |      **1.215 ns** |      **1.136 ns** |  **1.10** |    **0.02** |        **-** |        **-** |        **-** |         **-** |
|      Encrypt_TransformBlock | Job-NGJVVM |      master |       16 |  None |        76.83 ns |      1.313 ns |      1.164 ns |  1.00 |    0.00 |        - |        - |        - |         - |
|                             |            |             |          |       |                 |               |               |       |         |          |          |          |           |
|      Decrypt_TransformBlock | Job-KIEEMV | crypto-span |       16 |  None |        92.94 ns |      1.003 ns |      0.838 ns |  1.09 |    0.01 |        - |        - |        - |         - |
|      Decrypt_TransformBlock | Job-NGJVVM |      master |       16 |  None |        85.39 ns |      0.376 ns |      0.334 ns |  1.00 |    0.00 |        - |        - |        - |         - |
|                             |            |             |          |       |                 |               |               |       |         |          |          |          |           |
| Encrypt_TransformFinalBlock | Job-KIEEMV | crypto-span |       16 |  None |       120.77 ns |      2.426 ns |      2.383 ns |  0.92 |    0.01 |   0.0095 |        - |        - |      40 B |
| Encrypt_TransformFinalBlock | Job-NGJVVM |      master |       16 |  None |       131.35 ns |      2.601 ns |      2.783 ns |  1.00 |    0.00 |   0.0191 |        - |        - |      80 B |
|                             |            |             |          |       |                 |               |               |       |         |          |          |          |           |
| Decrypt_TransformFinalBlock | Job-KIEEMV | crypto-span |       16 |  None |       339.21 ns |      4.908 ns |      4.351 ns |  2.20 |    0.04 |   0.0124 |   0.0124 |   0.0124 |      80 B |
| Decrypt_TransformFinalBlock | Job-NGJVVM |      master |       16 |  None |       154.00 ns |      2.873 ns |      2.547 ns |  1.00 |    0.00 |   0.0286 |        - |        - |     120 B |
|                             |            |             |          |       |                 |               |               |       |         |          |          |          |           |
|      **Encrypt_TransformBlock** | **Job-KIEEMV** | **crypto-span** |       **16** | **PKCS7** |        **82.48 ns** |      **0.813 ns** |      **0.761 ns** |  **1.06** |    **0.03** |        **-** |        **-** |        **-** |         **-** |
|      Encrypt_TransformBlock | Job-NGJVVM |      master |       16 | PKCS7 |        78.32 ns |      1.598 ns |      2.187 ns |  1.00 |    0.00 |        - |        - |        - |         - |
|                             |            |             |          |       |                 |               |               |       |         |          |          |          |           |
|      Decrypt_TransformBlock | Job-KIEEMV | crypto-span |       16 | PKCS7 |       106.73 ns |      0.241 ns |      0.202 ns |  1.13 |    0.02 |        - |        - |        - |         - |
|      Decrypt_TransformBlock | Job-NGJVVM |      master |       16 | PKCS7 |        94.23 ns |      1.484 ns |      1.388 ns |  1.00 |    0.00 |        - |        - |        - |         - |
|                             |            |             |          |       |                 |               |               |       |         |          |          |          |           |
| Encrypt_TransformFinalBlock | Job-KIEEMV | crypto-span |       16 | PKCS7 |       132.34 ns |      2.493 ns |      2.210 ns |  0.86 |    0.02 |   0.0134 |        - |        - |      56 B |
| Encrypt_TransformFinalBlock | Job-NGJVVM |      master |       16 | PKCS7 |       154.47 ns |      2.397 ns |      2.242 ns |  1.00 |    0.00 |   0.0267 |        - |        - |     112 B |
|                             |            |             |          |       |                 |               |               |       |         |          |          |          |           |
| Decrypt_TransformFinalBlock | Job-KIEEMV | crypto-span |       16 | PKCS7 |       455.78 ns |      8.863 ns |      8.705 ns |  2.56 |    0.06 |   0.0176 |   0.0176 |   0.0176 |      96 B |
| Decrypt_TransformFinalBlock | Job-NGJVVM |      master |       16 | PKCS7 |       178.09 ns |      1.533 ns |      1.434 ns |  1.00 |    0.00 |   0.0362 |        - |        - |     152 B |
|                             |            |             |          |       |                 |               |               |       |         |          |          |          |           |
|      **Encrypt_TransformBlock** | **Job-KIEEMV** | **crypto-span** |  **1048576** |  **None** | **1,023,915.08 ns** | **15,698.799 ns** | **13,916.576 ns** |  **1.01** |    **0.02** |        **-** |        **-** |        **-** |         **-** |
|      Encrypt_TransformBlock | Job-NGJVVM |      master |  1048576 |  None | 1,015,709.63 ns |  8,083.787 ns |  7,166.066 ns |  1.00 |    0.00 |        - |        - |        - |         - |
|                             |            |             |          |       |                 |               |               |       |         |          |          |          |           |
|      Decrypt_TransformBlock | Job-KIEEMV | crypto-span |  1048576 |  None |   152,448.25 ns |  1,471.525 ns |  1,304.468 ns |  1.00 |    0.01 |        - |        - |        - |         - |
|      Decrypt_TransformBlock | Job-NGJVVM |      master |  1048576 |  None |   153,017.68 ns |  1,500.208 ns |  1,403.295 ns |  1.00 |    0.00 |        - |        - |        - |         - |
|                             |            |             |          |       |                 |               |               |       |         |          |          |          |           |
| Encrypt_TransformFinalBlock | Job-KIEEMV | crypto-span |  1048576 |  None | 1,212,545.25 ns |  4,686.582 ns |  3,913.508 ns |  0.82 |    0.01 | 195.3125 | 195.3125 | 195.3125 | 1048595 B |
| Encrypt_TransformFinalBlock | Job-NGJVVM |      master |  1048576 |  None | 1,471,075.17 ns | 20,637.055 ns | 17,232.876 ns |  1.00 |    0.00 | 330.0781 | 330.0781 | 330.0781 | 2097192 B |
|                             |            |             |          |       |                 |               |               |       |         |          |          |          |           |
| Decrypt_TransformFinalBlock | Job-KIEEMV | crypto-span |  1048576 |  None |   460,371.80 ns |  6,776.091 ns |  6,338.360 ns |  0.25 |    0.00 | 249.5117 | 249.5117 | 249.5117 | 2097194 B |
| Decrypt_TransformFinalBlock | Job-NGJVVM |      master |  1048576 |  None | 1,845,271.35 ns | 15,860.071 ns | 13,243.877 ns |  1.00 |    0.00 | 398.4375 | 398.4375 | 398.4375 | 3145790 B |
|                             |            |             |          |       |                 |               |               |       |         |          |          |          |           |
|      **Encrypt_TransformBlock** | **Job-KIEEMV** | **crypto-span** |  **1048576** | **PKCS7** | **1,000,132.84 ns** |  **5,567.049 ns** |  **4,935.044 ns** |  **0.99** |    **0.02** |        **-** |        **-** |        **-** |         **-** |
|      Encrypt_TransformBlock | Job-NGJVVM |      master |  1048576 | PKCS7 | 1,012,608.16 ns | 20,018.006 ns | 21,419.042 ns |  1.00 |    0.00 |        - |        - |        - |         - |
|                             |            |             |          |       |                 |               |               |       |         |          |          |          |           |
|      Decrypt_TransformBlock | Job-KIEEMV | crypto-span |  1048576 | PKCS7 |   153,782.05 ns |    283.368 ns |    251.198 ns |  1.00 |    0.00 |        - |        - |        - |         - |
|      Decrypt_TransformBlock | Job-NGJVVM |      master |  1048576 | PKCS7 |   153,690.69 ns |    530.196 ns |    495.946 ns |  1.00 |    0.00 |        - |        - |        - |         - |
|                             |            |             |          |       |                 |               |               |       |         |          |          |          |           |
| Encrypt_TransformFinalBlock | Job-KIEEMV | crypto-span |  1048576 | PKCS7 | 1,215,485.64 ns | 10,929.405 ns |  9,688.633 ns |  0.82 |    0.02 | 195.3125 | 195.3125 | 195.3125 | 1048611 B |
| Encrypt_TransformFinalBlock | Job-NGJVVM |      master |  1048576 | PKCS7 | 1,487,894.11 ns | 29,256.477 ns | 32,518.496 ns |  1.00 |    0.00 | 324.2188 | 324.2188 | 324.2188 | 2097224 B |
|                             |            |             |          |       |                 |               |               |       |         |          |          |          |           |
| Decrypt_TransformFinalBlock | Job-KIEEMV | crypto-span |  1048576 | PKCS7 | 1,246,567.08 ns | 12,922.905 ns | 12,088.093 ns |  0.68 |    0.01 | 361.3281 | 361.3281 | 361.3281 | 3145835 B |
| Decrypt_TransformFinalBlock | Job-NGJVVM |      master |  1048576 | PKCS7 | 1,844,825.73 ns | 23,217.198 ns | 21,717.382 ns |  1.00 |    0.00 | 398.4375 | 398.4375 | 398.4375 | 3145822 B |
