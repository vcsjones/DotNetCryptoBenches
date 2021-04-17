using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;

namespace NetCryptoBench
{
    public class ShaBench
    {
        [Params(0, 64)]
        public int DataSize;

        public byte[] Data;

        [ParamsSource(nameof(GetHashAlgorithms))]
        public HashAlgorithm HashAlgorithm;

        public IEnumerable<HashAlgorithm> GetHashAlgorithms()
        {
            yield return SHA256.Create();
            yield return SHA512.Create();
            yield return SHA384.Create();
            yield return SHA1.Create();
            yield return MD5.Create();

            yield return new SHA256CryptoServiceProvider();
            yield return new SHA512CryptoServiceProvider();
            yield return new SHA384CryptoServiceProvider();
            yield return new SHA1CryptoServiceProvider();
            yield return new MD5CryptoServiceProvider();

            yield return new SHA256Managed();
            yield return new SHA512Managed();
            yield return new SHA384Managed();
            yield return new SHA1Managed();
        }

        [GlobalSetup]
        public void Setup()
        {
            Data = new byte[DataSize];
            RandomNumberGenerator.Fill(Data);
        }

        [Benchmark]
        public void ComputeHash()
        {
            HashAlgorithm.ComputeHash(Data);
        }

        [Benchmark]
        public void ComputeHashRedundantInit()
        {
            HashAlgorithm.Initialize();
            HashAlgorithm.ComputeHash(Data);
        }

        [Benchmark]
        public void TransformFinalBlock()
        {
            HashAlgorithm.TransformFinalBlock(Data, 0, Data.Length);
            _ = HashAlgorithm.Hash;
        }
    }
}
