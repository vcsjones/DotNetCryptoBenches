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

        public SHA256 SHA256 = SHA256.Create();

        [GlobalSetup]
        public void Setup()
        {
            Data = new byte[DataSize];
            RandomNumberGenerator.Fill(Data);
        }

        [Benchmark]
        public void Sha256ComputeHash()
        {
            SHA256.ComputeHash(Data);
        }

        [Benchmark]
        public void Sha256TransformFinalBlock()
        {
            SHA256.TransformFinalBlock(Data, 0, Data.Length);
            _ = SHA256.Hash;
        }
    }
}