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

        [ParamsSource(nameof(HashAlgorithmNames))]
        public HashAlgorithmName HashAlgorithmName;

        public RSASignaturePadding[] RSASignaturePaddings { get; } = new []
        {
            //RSASignaturePadding.Pkcs1,
            RSASignaturePadding.Pss
        };

        public HashAlgorithmName[] HashAlgorithmNames { get; } = new[]
        {
            HashAlgorithmName.MD5,
            HashAlgorithmName.SHA256,
        };

        [GlobalSetup]
        public void Setup()
        {
            Rsa = RSA.Create(2048);

            if (HashAlgorithmName == HashAlgorithmName.MD5)
            {
                Hash = new byte[MD5.HashSizeInBytes];
            }
            else if (HashAlgorithmName == HashAlgorithmName.SHA256)
            {
                Hash = new byte[SHA256.HashSizeInBytes];
            }
            else
            {
                throw new InvalidOperationException("Nope");
            }

            Signature = Rsa.SignHash(Hash, HashAlgorithmName, SignaturePadding);
        }

        [Benchmark]
        [SkipLocalsInit]
        public bool SignHash()
        {
            Span<byte> destination = stackalloc byte[4096 / 8];
            return Rsa.TrySignHash(Hash, destination, HashAlgorithmName, SignaturePadding, out _);
        }

        [Benchmark]
        [SkipLocalsInit]
        public bool VerifyHash()
        {
            return Rsa.VerifyHash(Hash, Signature, HashAlgorithmName, SignaturePadding);
        }
    }
}