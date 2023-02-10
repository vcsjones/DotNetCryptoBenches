using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;

namespace NetCryptoBench
{
    public class RSABench
    {
        public byte[] Signature;
        public byte[] Hash;
        public RSA Rsa;

        [ParamsSource(nameof(RSASignaturePaddings))]
        public RSASignaturePadding SignaturePadding;

        public RSASignaturePadding[] RSASignaturePaddings { get; } = new []
        {
            RSASignaturePadding.Pkcs1,
            RSASignaturePadding.Pss
        };

        [GlobalSetup]
        public void Setup()
        {
            Rsa = RSA.Create(2048);
            Hash = new byte[32];
            Signature = Rsa.SignHash(Hash, HashAlgorithmName.SHA256, SignaturePadding);
        }

        [Benchmark]
        [SkipLocalsInit]
        public bool SignHash()
        {
            Span<byte> destination = stackalloc byte[4096 / 8];
            return Rsa.TrySignHash(Hash, destination, HashAlgorithmName.SHA256, SignaturePadding, out _);
        }

        [Benchmark]
        public void VerifyHash()
        {
            Rsa.VerifyHash(Hash, Signature, HashAlgorithmName.SHA256, SignaturePadding);
        }
    }
}