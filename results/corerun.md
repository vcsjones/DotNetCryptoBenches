``` ini

BenchmarkDotNet=v0.12.1, OS=macOS Catalina 10.15.5 (19F96) [Darwin 19.5.0]
Intel Core i7-8700B CPU 3.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=5.0.100-preview.4.20258.7
  [Host]     : .NET Core 5.0.0 (CoreCLR 5.0.20.25106, CoreFX 5.0.20.25106), X64 RyuJIT
  Job-IHGVMS : .NET Core 5.0 (CoreCLR 42.42.42.42424, CoreFX 42.42.42.42424), X64 RyuJIT

Toolchain=CoreRun  

```
|     Method | DataLength |  CurveName | HashAlgorithm |       Mean |    Error |   StdDev |     Median |
|----------- |----------- |----------- |-------------- |-----------:|---------:|---------:|-----------:|
|   **SignData** |          **1** | **ECDSA_P256** |          **SHA1** |   **282.3 μs** |  **2.25 μs** |  **1.88 μs** |   **281.9 μs** |
| VerifyData |          1 | ECDSA_P256 |          SHA1 |   231.2 μs |  2.20 μs |  2.06 μs |   230.8 μs |
|   SignHash |          1 | ECDSA_P256 |          SHA1 |   281.4 μs |  1.33 μs |  1.11 μs |   281.2 μs |
| VerifyHash |          1 | ECDSA_P256 |          SHA1 |   228.7 μs |  1.13 μs |  0.94 μs |   228.5 μs |
|   **SignData** |          **1** | **ECDSA_P256** |        **SHA256** |   **283.7 μs** |  **3.17 μs** |  **2.96 μs** |   **282.2 μs** |
| VerifyData |          1 | ECDSA_P256 |        SHA256 |   234.8 μs |  2.74 μs |  2.43 μs |   235.1 μs |
|   SignHash |          1 | ECDSA_P256 |        SHA256 |   281.3 μs |  2.09 μs |  1.86 μs |   281.0 μs |
| VerifyHash |          1 | ECDSA_P256 |        SHA256 |   230.8 μs |  2.38 μs |  2.23 μs |   230.2 μs |
|   **SignData** |          **1** | **ECDSA_P256** |        **SHA512** |   **282.9 μs** |  **3.00 μs** |  **2.81 μs** |   **282.0 μs** |
| VerifyData |          1 | ECDSA_P256 |        SHA512 |   228.9 μs |  1.75 μs |  1.55 μs |   228.9 μs |
|   SignHash |          1 | ECDSA_P256 |        SHA512 |   282.3 μs |  2.52 μs |  2.36 μs |   282.0 μs |
| VerifyHash |          1 | ECDSA_P256 |        SHA512 |   226.6 μs |  1.98 μs |  1.75 μs |   226.6 μs |
|   **SignData** |          **1** | **ECDSA_P384** |          **SHA1** |   **787.8 μs** |  **3.82 μs** |  **2.98 μs** |   **788.9 μs** |
| VerifyData |          1 | ECDSA_P384 |          SHA1 |   655.5 μs | 12.27 μs | 10.88 μs |   657.0 μs |
|   SignHash |          1 | ECDSA_P384 |          SHA1 |   814.4 μs | 15.54 μs | 15.26 μs |   815.6 μs |
| VerifyHash |          1 | ECDSA_P384 |          SHA1 |   631.1 μs |  4.37 μs |  4.09 μs |   630.4 μs |
|   **SignData** |          **1** | **ECDSA_P384** |        **SHA256** |   **788.3 μs** |  **6.75 μs** |  **5.98 μs** |   **786.7 μs** |
| VerifyData |          1 | ECDSA_P384 |        SHA256 |   636.4 μs |  4.52 μs |  3.77 μs |   637.5 μs |
|   SignHash |          1 | ECDSA_P384 |        SHA256 |   818.0 μs | 15.24 μs | 25.04 μs |   819.0 μs |
| VerifyHash |          1 | ECDSA_P384 |        SHA256 |   637.4 μs | 11.44 μs | 10.70 μs |   637.4 μs |
|   **SignData** |          **1** | **ECDSA_P384** |        **SHA512** |   **810.1 μs** | **15.80 μs** | **26.40 μs** |   **797.9 μs** |
| VerifyData |          1 | ECDSA_P384 |        SHA512 |   637.3 μs |  6.54 μs |  6.12 μs |   635.9 μs |
|   SignHash |          1 | ECDSA_P384 |        SHA512 |   781.9 μs |  7.52 μs |  6.67 μs |   778.6 μs |
| VerifyHash |          1 | ECDSA_P384 |        SHA512 |   634.9 μs |  5.95 μs |  5.28 μs |   634.0 μs |
|   **SignData** |          **1** | **ECDSA_P521** |          **SHA1** | **1,105.9 μs** | **10.10 μs** |  **9.45 μs** | **1,102.3 μs** |
| VerifyData |          1 | ECDSA_P521 |          SHA1 |   853.8 μs |  6.95 μs |  6.16 μs |   851.7 μs |
|   SignHash |          1 | ECDSA_P521 |          SHA1 | 1,102.3 μs |  5.38 μs |  4.77 μs | 1,102.0 μs |
| VerifyHash |          1 | ECDSA_P521 |          SHA1 |   830.8 μs |  5.05 μs |  4.72 μs |   829.3 μs |
|   **SignData** |          **1** | **ECDSA_P521** |        **SHA256** | **1,106.1 μs** | **10.37 μs** |  **9.70 μs** | **1,104.1 μs** |
| VerifyData |          1 | ECDSA_P521 |        SHA256 |   838.0 μs |  3.41 μs |  2.66 μs |   837.6 μs |
|   SignHash |          1 | ECDSA_P521 |        SHA256 | 1,101.4 μs |  8.32 μs |  7.79 μs | 1,100.0 μs |
| VerifyHash |          1 | ECDSA_P521 |        SHA256 |   841.7 μs |  6.99 μs |  6.54 μs |   838.4 μs |
|   **SignData** |          **1** | **ECDSA_P521** |        **SHA512** | **1,101.6 μs** |  **7.88 μs** |  **6.99 μs** | **1,100.6 μs** |
| VerifyData |          1 | ECDSA_P521 |        SHA512 |   839.3 μs |  5.88 μs |  5.22 μs |   839.1 μs |
|   SignHash |          1 | ECDSA_P521 |        SHA512 | 1,101.0 μs |  6.91 μs |  5.77 μs | 1,099.5 μs |
| VerifyHash |          1 | ECDSA_P521 |        SHA512 |   852.0 μs |  5.24 μs |  4.90 μs |   851.3 μs |
|   **SignData** |         **32** | **ECDSA_P256** |          **SHA1** |   **278.3 μs** |  **1.85 μs** |  **1.64 μs** |   **277.8 μs** |
| VerifyData |         32 | ECDSA_P256 |          SHA1 |   230.4 μs |  1.25 μs |  1.11 μs |   229.9 μs |
|   SignHash |         32 | ECDSA_P256 |          SHA1 |   277.6 μs |  1.78 μs |  1.66 μs |   277.5 μs |
| VerifyHash |         32 | ECDSA_P256 |          SHA1 |   227.2 μs |  1.97 μs |  1.85 μs |   226.7 μs |
|   **SignData** |         **32** | **ECDSA_P256** |        **SHA256** |   **277.1 μs** |  **0.68 μs** |  **0.57 μs** |   **277.2 μs** |
| VerifyData |         32 | ECDSA_P256 |        SHA256 |   230.4 μs |  4.54 μs |  6.21 μs |   227.7 μs |
|   SignHash |         32 | ECDSA_P256 |        SHA256 |   279.0 μs |  2.57 μs |  2.28 μs |   278.2 μs |
| VerifyHash |         32 | ECDSA_P256 |        SHA256 |   231.2 μs |  1.65 μs |  1.38 μs |   231.3 μs |
|   **SignData** |         **32** | **ECDSA_P256** |        **SHA512** |   **278.2 μs** |  **1.29 μs** |  **1.14 μs** |   **278.0 μs** |
| VerifyData |         32 | ECDSA_P256 |        SHA512 |   225.1 μs |  2.36 μs |  2.20 μs |   224.5 μs |
|   SignHash |         32 | ECDSA_P256 |        SHA512 |   277.1 μs |  1.60 μs |  1.42 μs |   276.8 μs |
| VerifyHash |         32 | ECDSA_P256 |        SHA512 |   229.6 μs |  1.88 μs |  1.76 μs |   228.8 μs |
|   **SignData** |         **32** | **ECDSA_P384** |          **SHA1** |   **782.4 μs** |  **6.68 μs** |  **6.25 μs** |   **780.8 μs** |
| VerifyData |         32 | ECDSA_P384 |          SHA1 |   635.3 μs |  3.76 μs |  3.33 μs |   634.6 μs |
|   SignHash |         32 | ECDSA_P384 |          SHA1 |   781.8 μs |  5.88 μs |  5.50 μs |   779.9 μs |
| VerifyHash |         32 | ECDSA_P384 |          SHA1 |   638.8 μs |  3.46 μs |  2.89 μs |   638.0 μs |
|   **SignData** |         **32** | **ECDSA_P384** |        **SHA256** |   **778.4 μs** |  **3.57 μs** |  **3.34 μs** |   **778.6 μs** |
| VerifyData |         32 | ECDSA_P384 |        SHA256 |   624.9 μs |  3.76 μs |  3.14 μs |   624.4 μs |
|   SignHash |         32 | ECDSA_P384 |        SHA256 |   776.4 μs |  2.41 μs |  2.13 μs |   776.7 μs |
| VerifyHash |         32 | ECDSA_P384 |        SHA256 |   623.1 μs |  4.49 μs |  4.20 μs |   621.0 μs |
|   **SignData** |         **32** | **ECDSA_P384** |        **SHA512** |   **778.7 μs** |  **1.72 μs** |  **1.34 μs** |   **778.6 μs** |
| VerifyData |         32 | ECDSA_P384 |        SHA512 |   634.7 μs |  7.15 μs |  6.69 μs |   634.1 μs |
|   SignHash |         32 | ECDSA_P384 |        SHA512 |   780.7 μs |  6.10 μs |  5.70 μs |   777.6 μs |
| VerifyHash |         32 | ECDSA_P384 |        SHA512 |   634.7 μs |  6.95 μs |  6.50 μs |   632.7 μs |
|   **SignData** |         **32** | **ECDSA_P521** |          **SHA1** | **1,098.5 μs** |  **3.80 μs** |  **3.37 μs** | **1,098.7 μs** |
| VerifyData |         32 | ECDSA_P521 |          SHA1 |   834.6 μs |  4.42 μs |  3.91 μs |   834.9 μs |
|   SignHash |         32 | ECDSA_P521 |          SHA1 | 1,095.1 μs |  4.02 μs |  3.35 μs | 1,095.9 μs |
| VerifyHash |         32 | ECDSA_P521 |          SHA1 |   832.9 μs |  8.02 μs |  7.50 μs |   832.7 μs |
|   **SignData** |         **32** | **ECDSA_P521** |        **SHA256** | **1,102.8 μs** |  **7.66 μs** |  **7.17 μs** | **1,101.2 μs** |
| VerifyData |         32 | ECDSA_P521 |        SHA256 |   834.4 μs |  1.56 μs |  1.30 μs |   834.4 μs |
|   SignHash |         32 | ECDSA_P521 |        SHA256 | 1,108.7 μs | 14.66 μs | 13.71 μs | 1,107.0 μs |
| VerifyHash |         32 | ECDSA_P521 |        SHA256 |   851.5 μs |  8.75 μs |  8.18 μs |   848.3 μs |
|   **SignData** |         **32** | **ECDSA_P521** |        **SHA512** | **1,100.1 μs** |  **7.06 μs** |  **6.26 μs** | **1,098.0 μs** |
| VerifyData |         32 | ECDSA_P521 |        SHA512 |   841.6 μs |  6.17 μs |  5.77 μs |   840.2 μs |
|   SignHash |         32 | ECDSA_P521 |        SHA512 | 1,108.3 μs | 15.10 μs | 14.13 μs | 1,102.6 μs |
| VerifyHash |         32 | ECDSA_P521 |        SHA512 |   848.5 μs | 14.84 μs | 15.24 μs |   841.3 μs |
|   **SignData** |       **1000** | **ECDSA_P256** |          **SHA1** |   **294.6 μs** |  **4.67 μs** |  **4.14 μs** |   **293.3 μs** |
| VerifyData |       1000 | ECDSA_P256 |          SHA1 |   246.7 μs |  4.91 μs |  4.60 μs |   246.6 μs |
|   SignHash |       1000 | ECDSA_P256 |          SHA1 |   285.1 μs |  5.56 μs |  6.62 μs |   284.4 μs |
| VerifyHash |       1000 | ECDSA_P256 |          SHA1 |   232.6 μs |  4.54 μs |  5.23 μs |   231.4 μs |
|   **SignData** |       **1000** | **ECDSA_P256** |        **SHA256** |   **280.2 μs** |  **1.96 μs** |  **1.63 μs** |   **280.3 μs** |
| VerifyData |       1000 | ECDSA_P256 |        SHA256 |   223.7 μs |  2.03 μs |  1.90 μs |   223.9 μs |
|   SignHash |       1000 | ECDSA_P256 |        SHA256 |   277.5 μs |  1.32 μs |  1.10 μs |   277.3 μs |
| VerifyHash |       1000 | ECDSA_P256 |        SHA256 |   231.1 μs |  1.97 μs |  1.75 μs |   231.2 μs |
|   **SignData** |       **1000** | **ECDSA_P256** |        **SHA512** |   **279.2 μs** |  **1.49 μs** |  **1.32 μs** |   **278.8 μs** |
| VerifyData |       1000 | ECDSA_P256 |        SHA512 |   230.5 μs |  2.42 μs |  2.26 μs |   230.8 μs |
|   SignHash |       1000 | ECDSA_P256 |        SHA512 |   277.8 μs |  2.86 μs |  2.53 μs |   277.2 μs |
| VerifyHash |       1000 | ECDSA_P256 |        SHA512 |   227.8 μs |  1.54 μs |  1.36 μs |   227.6 μs |
|   **SignData** |       **1000** | **ECDSA_P384** |          **SHA1** |   **790.9 μs** | **11.15 μs** | **10.43 μs** |   **787.0 μs** |
| VerifyData |       1000 | ECDSA_P384 |          SHA1 |   630.0 μs |  6.69 μs |  6.26 μs |   628.0 μs |
|   SignHash |       1000 | ECDSA_P384 |          SHA1 |   777.9 μs |  3.11 μs |  2.75 μs |   777.7 μs |
| VerifyHash |       1000 | ECDSA_P384 |          SHA1 |   628.8 μs |  2.06 μs |  1.61 μs |   629.2 μs |
|   **SignData** |       **1000** | **ECDSA_P384** |        **SHA256** |   **782.1 μs** |  **2.54 μs** |  **2.12 μs** |   **782.3 μs** |
| VerifyData |       1000 | ECDSA_P384 |        SHA256 |   640.7 μs |  5.31 μs |  4.96 μs |   639.9 μs |
|   SignHash |       1000 | ECDSA_P384 |        SHA256 |   779.9 μs |  4.75 μs |  3.97 μs |   778.9 μs |
| VerifyHash |       1000 | ECDSA_P384 |        SHA256 |   637.6 μs |  6.31 μs |  5.60 μs |   636.6 μs |
|   **SignData** |       **1000** | **ECDSA_P384** |        **SHA512** |   **787.9 μs** |  **6.59 μs** |  **6.16 μs** |   **788.3 μs** |
| VerifyData |       1000 | ECDSA_P384 |        SHA512 |   631.4 μs |  5.82 μs |  5.16 μs |   629.6 μs |
|   SignHash |       1000 | ECDSA_P384 |        SHA512 |   785.3 μs |  8.77 μs |  8.20 μs |   782.8 μs |
| VerifyHash |       1000 | ECDSA_P384 |        SHA512 |   624.0 μs |  2.56 μs |  2.14 μs |   622.9 μs |
|   **SignData** |       **1000** | **ECDSA_P521** |          **SHA1** | **1,100.0 μs** |  **6.23 μs** |  **5.20 μs** | **1,099.8 μs** |
| VerifyData |       1000 | ECDSA_P521 |          SHA1 |   841.5 μs |  9.10 μs |  8.51 μs |   838.6 μs |
|   SignHash |       1000 | ECDSA_P521 |          SHA1 | 1,117.5 μs | 20.93 μs | 20.55 μs | 1,107.7 μs |
| VerifyHash |       1000 | ECDSA_P521 |          SHA1 |   844.5 μs | 16.39 μs | 15.33 μs |   843.1 μs |
|   **SignData** |       **1000** | **ECDSA_P521** |        **SHA256** | **1,133.7 μs** | **22.20 μs** | **31.12 μs** | **1,124.9 μs** |
| VerifyData |       1000 | ECDSA_P521 |        SHA256 |   844.6 μs |  4.55 μs |  3.80 μs |   844.9 μs |
|   SignHash |       1000 | ECDSA_P521 |        SHA256 | 1,102.1 μs |  7.98 μs |  7.46 μs | 1,100.5 μs |
| VerifyHash |       1000 | ECDSA_P521 |        SHA256 |   856.6 μs | 16.31 μs | 15.26 μs |   851.2 μs |
|   **SignData** |       **1000** | **ECDSA_P521** |        **SHA512** | **1,105.9 μs** | **10.05 μs** |  **9.40 μs** | **1,103.1 μs** |
| VerifyData |       1000 | ECDSA_P521 |        SHA512 |   853.9 μs | 10.02 μs |  9.37 μs |   849.9 μs |
|   SignHash |       1000 | ECDSA_P521 |        SHA512 | 1,100.6 μs |  7.28 μs |  6.81 μs | 1,098.1 μs |
| VerifyHash |       1000 | ECDSA_P521 |        SHA512 |   837.1 μs |  7.55 μs |  7.06 μs |   834.8 μs |
