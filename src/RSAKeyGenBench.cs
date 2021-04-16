using System.Collections.Generic;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;

namespace NetCryptoBench
{
    public class RSAKeyGenBench
    {
        [Params(1024, 2048, 4096)]
        public int KeySize;

        [Benchmark]
        public void GenerateKey()
        {
            RSA.Create(KeySize).ExportParameters(true);
        }
    }
}