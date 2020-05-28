``` ini

BenchmarkDotNet=v0.12.1, OS=macOS Catalina 10.15.5 (19F96) [Darwin 19.5.0]
Intel Core i7-8700B CPU 3.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=5.0.100-preview.4.20258.7
  [Host]     : .NET Core 5.0.0 (CoreCLR 5.0.20.25106, CoreFX 5.0.20.25106), X64 RyuJIT
  Job-PTGMVF : .NET Core 5.0 (CoreCLR 42.42.42.42424, CoreFX 42.42.42.42424), X64 RyuJIT

Toolchain=CoreRun  

```
|     Method | DataLength |  CurveName | HashAlgorithm |      Mean |     Error |    StdDev |
|----------- |----------- |----------- |-------------- |----------:|----------:|----------:|
|   **SignData** |          **1** | **ECDSA_P256** |          **SHA1** |  **4.991 ms** | **0.0150 ms** | **0.0125 ms** |
| VerifyData |          1 | ECDSA_P256 |          SHA1 |  9.397 ms | 0.1499 ms | 0.1329 ms |
|   SignHash |          1 | ECDSA_P256 |          SHA1 |  5.052 ms | 0.0141 ms | 0.0125 ms |
| VerifyHash |          1 | ECDSA_P256 |          SHA1 |  9.582 ms | 0.1266 ms | 0.1122 ms |
|   **SignData** |          **1** | **ECDSA_P256** |        **SHA256** |  **5.066 ms** | **0.0157 ms** | **0.0139 ms** |
| VerifyData |          1 | ECDSA_P256 |        SHA256 |  9.476 ms | 0.1325 ms | 0.1175 ms |
|   SignHash |          1 | ECDSA_P256 |        SHA256 |  5.077 ms | 0.0133 ms | 0.0118 ms |
| VerifyHash |          1 | ECDSA_P256 |        SHA256 |  9.458 ms | 0.1521 ms | 0.1423 ms |
|   **SignData** |          **1** | **ECDSA_P256** |        **SHA512** |  **5.083 ms** | **0.0113 ms** | **0.0105 ms** |
| VerifyData |          1 | ECDSA_P256 |        SHA512 |  9.338 ms | 0.1867 ms | 0.1833 ms |
|   SignHash |          1 | ECDSA_P256 |        SHA512 |  5.097 ms | 0.0170 ms | 0.0159 ms |
| VerifyHash |          1 | ECDSA_P256 |        SHA512 |  9.432 ms | 0.1029 ms | 0.0963 ms |
|   **SignData** |          **1** | **ECDSA_P384** |          **SHA1** |  **9.500 ms** | **0.0297 ms** | **0.0278 ms** |
| VerifyData |          1 | ECDSA_P384 |          SHA1 | 18.112 ms | 0.2964 ms | 0.2772 ms |
|   SignHash |          1 | ECDSA_P384 |          SHA1 |  9.460 ms | 0.0196 ms | 0.0183 ms |
| VerifyHash |          1 | ECDSA_P384 |          SHA1 | 18.190 ms | 0.2121 ms | 0.1984 ms |
|   **SignData** |          **1** | **ECDSA_P384** |        **SHA256** |  **9.489 ms** | **0.0229 ms** | **0.0203 ms** |
| VerifyData |          1 | ECDSA_P384 |        SHA256 | 17.838 ms | 0.3022 ms | 0.2826 ms |
|   SignHash |          1 | ECDSA_P384 |        SHA256 |  9.439 ms | 0.0241 ms | 0.0214 ms |
| VerifyHash |          1 | ECDSA_P384 |        SHA256 | 18.250 ms | 0.2645 ms | 0.2474 ms |
|   **SignData** |          **1** | **ECDSA_P384** |        **SHA512** |  **9.473 ms** | **0.0236 ms** | **0.0221 ms** |
| VerifyData |          1 | ECDSA_P384 |        SHA512 | 18.145 ms | 0.1908 ms | 0.1691 ms |
|   SignHash |          1 | ECDSA_P384 |        SHA512 |  9.452 ms | 0.0252 ms | 0.0236 ms |
| VerifyHash |          1 | ECDSA_P384 |        SHA512 | 18.036 ms | 0.1834 ms | 0.1715 ms |
|   **SignData** |          **1** | **ECDSA_P521** |          **SHA1** | **17.732 ms** | **0.0517 ms** | **0.0484 ms** |
| VerifyData |          1 | ECDSA_P521 |          SHA1 | 34.301 ms | 0.3534 ms | 0.3305 ms |
|   SignHash |          1 | ECDSA_P521 |          SHA1 | 17.721 ms | 0.0594 ms | 0.0527 ms |
| VerifyHash |          1 | ECDSA_P521 |          SHA1 | 34.574 ms | 0.5077 ms | 0.4501 ms |
|   **SignData** |          **1** | **ECDSA_P521** |        **SHA256** | **17.708 ms** | **0.0475 ms** | **0.0421 ms** |
| VerifyData |          1 | ECDSA_P521 |        SHA256 | 34.423 ms | 0.6816 ms | 0.6376 ms |
|   SignHash |          1 | ECDSA_P521 |        SHA256 | 17.710 ms | 0.0797 ms | 0.0706 ms |
| VerifyHash |          1 | ECDSA_P521 |        SHA256 | 33.845 ms | 0.4593 ms | 0.3836 ms |
|   **SignData** |          **1** | **ECDSA_P521** |        **SHA512** | **17.696 ms** | **0.0732 ms** | **0.0649 ms** |
| VerifyData |          1 | ECDSA_P521 |        SHA512 | 34.149 ms | 0.4192 ms | 0.3921 ms |
|   SignHash |          1 | ECDSA_P521 |        SHA512 | 17.710 ms | 0.0723 ms | 0.0676 ms |
| VerifyHash |          1 | ECDSA_P521 |        SHA512 | 34.229 ms | 0.4459 ms | 0.3952 ms |
|   **SignData** |         **32** | **ECDSA_P256** |          **SHA1** |  **5.080 ms** | **0.0113 ms** | **0.0106 ms** |
| VerifyData |         32 | ECDSA_P256 |          SHA1 |  9.428 ms | 0.1402 ms | 0.1311 ms |
|   SignHash |         32 | ECDSA_P256 |          SHA1 |  5.086 ms | 0.0098 ms | 0.0081 ms |
| VerifyHash |         32 | ECDSA_P256 |          SHA1 |  9.711 ms | 0.1915 ms | 0.1880 ms |
|   **SignData** |         **32** | **ECDSA_P256** |        **SHA256** |  **5.100 ms** | **0.0242 ms** | **0.0226 ms** |
| VerifyData |         32 | ECDSA_P256 |        SHA256 |  9.268 ms | 0.0864 ms | 0.0721 ms |
|   SignHash |         32 | ECDSA_P256 |        SHA256 |  5.104 ms | 0.0146 ms | 0.0136 ms |
| VerifyHash |         32 | ECDSA_P256 |        SHA256 |  9.597 ms | 0.1209 ms | 0.1131 ms |
|   **SignData** |         **32** | **ECDSA_P256** |        **SHA512** |  **5.087 ms** | **0.0115 ms** | **0.0096 ms** |
| VerifyData |         32 | ECDSA_P256 |        SHA512 |  9.448 ms | 0.1868 ms | 0.1918 ms |
|   SignHash |         32 | ECDSA_P256 |        SHA512 |  5.103 ms | 0.0187 ms | 0.0175 ms |
| VerifyHash |         32 | ECDSA_P256 |        SHA512 |  9.609 ms | 0.1164 ms | 0.1089 ms |
|   **SignData** |         **32** | **ECDSA_P384** |          **SHA1** |  **9.455 ms** | **0.0238 ms** | **0.0222 ms** |
| VerifyData |         32 | ECDSA_P384 |          SHA1 | 17.563 ms | 0.2108 ms | 0.1971 ms |
|   SignHash |         32 | ECDSA_P384 |          SHA1 |  9.619 ms | 0.1868 ms | 0.2151 ms |
| VerifyHash |         32 | ECDSA_P384 |          SHA1 | 18.501 ms | 0.3222 ms | 0.3013 ms |
|   **SignData** |         **32** | **ECDSA_P384** |        **SHA256** |  **9.639 ms** | **0.1881 ms** | **0.1668 ms** |
| VerifyData |         32 | ECDSA_P384 |        SHA256 | 18.458 ms | 0.1149 ms | 0.1075 ms |
|   SignHash |         32 | ECDSA_P384 |        SHA256 |  9.508 ms | 0.1081 ms | 0.1011 ms |
| VerifyHash |         32 | ECDSA_P384 |        SHA256 | 18.295 ms | 0.2950 ms | 0.2463 ms |
|   **SignData** |         **32** | **ECDSA_P384** |        **SHA512** |  **9.486 ms** | **0.0848 ms** | **0.0752 ms** |
| VerifyData |         32 | ECDSA_P384 |        SHA512 | 18.427 ms | 0.1612 ms | 0.1429 ms |
|   SignHash |         32 | ECDSA_P384 |        SHA512 |  9.509 ms | 0.0769 ms | 0.0642 ms |
| VerifyHash |         32 | ECDSA_P384 |        SHA512 | 18.113 ms | 0.1665 ms | 0.1557 ms |
|   **SignData** |         **32** | **ECDSA_P521** |          **SHA1** | **17.726 ms** | **0.0626 ms** | **0.0555 ms** |
| VerifyData |         32 | ECDSA_P521 |          SHA1 | 35.056 ms | 0.6231 ms | 0.5828 ms |
|   SignHash |         32 | ECDSA_P521 |          SHA1 | 17.932 ms | 0.2598 ms | 0.2430 ms |
| VerifyHash |         32 | ECDSA_P521 |          SHA1 | 35.151 ms | 0.5821 ms | 0.5160 ms |
|   **SignData** |         **32** | **ECDSA_P521** |        **SHA256** | **17.807 ms** | **0.1275 ms** | **0.1193 ms** |
| VerifyData |         32 | ECDSA_P521 |        SHA256 | 34.402 ms | 0.2104 ms | 0.1968 ms |
|   SignHash |         32 | ECDSA_P521 |        SHA256 | 17.733 ms | 0.0519 ms | 0.0485 ms |
| VerifyHash |         32 | ECDSA_P521 |        SHA256 | 34.751 ms | 0.3141 ms | 0.2938 ms |
|   **SignData** |         **32** | **ECDSA_P521** |        **SHA512** | **17.719 ms** | **0.0446 ms** | **0.0395 ms** |
| VerifyData |         32 | ECDSA_P521 |        SHA512 | 34.340 ms | 0.2097 ms | 0.1961 ms |
|   SignHash |         32 | ECDSA_P521 |        SHA512 | 17.654 ms | 0.0599 ms | 0.0561 ms |
| VerifyHash |         32 | ECDSA_P521 |        SHA512 | 34.347 ms | 0.2248 ms | 0.2103 ms |
|   **SignData** |       **1000** | **ECDSA_P256** |          **SHA1** |  **5.129 ms** | **0.0118 ms** | **0.0110 ms** |
| VerifyData |       1000 | ECDSA_P256 |          SHA1 |  9.499 ms | 0.1634 ms | 0.1529 ms |
|   SignHash |       1000 | ECDSA_P256 |          SHA1 |  5.136 ms | 0.0132 ms | 0.0124 ms |
| VerifyHash |       1000 | ECDSA_P256 |          SHA1 |  9.869 ms | 0.1964 ms | 0.2101 ms |
|   **SignData** |       **1000** | **ECDSA_P256** |        **SHA256** |  **5.146 ms** | **0.0175 ms** | **0.0163 ms** |
| VerifyData |       1000 | ECDSA_P256 |        SHA256 |  9.764 ms | 0.1113 ms | 0.1041 ms |
|   SignHash |       1000 | ECDSA_P256 |        SHA256 |  5.179 ms | 0.0943 ms | 0.0836 ms |
| VerifyHash |       1000 | ECDSA_P256 |        SHA256 |  9.841 ms | 0.1291 ms | 0.1208 ms |
|   **SignData** |       **1000** | **ECDSA_P256** |        **SHA512** |  **5.171 ms** | **0.0190 ms** | **0.0168 ms** |
| VerifyData |       1000 | ECDSA_P256 |        SHA512 |  9.597 ms | 0.0575 ms | 0.0480 ms |
|   SignHash |       1000 | ECDSA_P256 |        SHA512 |  5.180 ms | 0.0251 ms | 0.0234 ms |
| VerifyHash |       1000 | ECDSA_P256 |        SHA512 |  9.858 ms | 0.1799 ms | 0.1847 ms |
|   **SignData** |       **1000** | **ECDSA_P384** |          **SHA1** |  **9.529 ms** | **0.0366 ms** | **0.0343 ms** |
| VerifyData |       1000 | ECDSA_P384 |          SHA1 | 18.173 ms | 0.1334 ms | 0.1248 ms |
|   SignHash |       1000 | ECDSA_P384 |          SHA1 |  9.499 ms | 0.0415 ms | 0.0388 ms |
| VerifyHash |       1000 | ECDSA_P384 |          SHA1 | 18.444 ms | 0.3179 ms | 0.2974 ms |
|   **SignData** |       **1000** | **ECDSA_P384** |        **SHA256** |  **9.471 ms** | **0.0625 ms** | **0.0488 ms** |
| VerifyData |       1000 | ECDSA_P384 |        SHA256 | 18.211 ms | 0.1356 ms | 0.1202 ms |
|   SignHash |       1000 | ECDSA_P384 |        SHA256 |  9.455 ms | 0.0350 ms | 0.0327 ms |
| VerifyHash |       1000 | ECDSA_P384 |        SHA256 | 18.252 ms | 0.2377 ms | 0.2223 ms |
|   **SignData** |       **1000** | **ECDSA_P384** |        **SHA512** |  **9.464 ms** | **0.0367 ms** | **0.0343 ms** |
| VerifyData |       1000 | ECDSA_P384 |        SHA512 | 17.936 ms | 0.2143 ms | 0.2005 ms |
|   SignHash |       1000 | ECDSA_P384 |        SHA512 |  9.459 ms | 0.0314 ms | 0.0278 ms |
| VerifyHash |       1000 | ECDSA_P384 |        SHA512 | 18.319 ms | 0.2823 ms | 0.2641 ms |
|   **SignData** |       **1000** | **ECDSA_P521** |          **SHA1** | **17.671 ms** | **0.0383 ms** | **0.0358 ms** |
| VerifyData |       1000 | ECDSA_P521 |          SHA1 | 34.466 ms | 0.2754 ms | 0.2576 ms |
|   SignHash |       1000 | ECDSA_P521 |          SHA1 | 17.751 ms | 0.0458 ms | 0.0429 ms |
| VerifyHash |       1000 | ECDSA_P521 |          SHA1 | 34.604 ms | 0.2195 ms | 0.2053 ms |
|   **SignData** |       **1000** | **ECDSA_P521** |        **SHA256** | **17.659 ms** | **0.0435 ms** | **0.0407 ms** |
| VerifyData |       1000 | ECDSA_P521 |        SHA256 | 34.408 ms | 0.2473 ms | 0.2314 ms |
|   SignHash |       1000 | ECDSA_P521 |        SHA256 | 17.720 ms | 0.0412 ms | 0.0385 ms |
| VerifyHash |       1000 | ECDSA_P521 |        SHA256 | 34.190 ms | 0.2620 ms | 0.2322 ms |
|   **SignData** |       **1000** | **ECDSA_P521** |        **SHA512** | **17.603 ms** | **0.0360 ms** | **0.0337 ms** |
| VerifyData |       1000 | ECDSA_P521 |        SHA512 | 34.270 ms | 0.1812 ms | 0.1606 ms |
|   SignHash |       1000 | ECDSA_P521 |        SHA512 | 17.660 ms | 0.0393 ms | 0.0367 ms |
| VerifyHash |       1000 | ECDSA_P521 |        SHA512 | 34.622 ms | 0.2419 ms | 0.2263 ms |
