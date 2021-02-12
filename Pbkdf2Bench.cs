using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;

namespace NetCryptoBench
{
    [MemoryDiagnoser]
    public class Pbkdf2Bench
    {
        [Params(1024, 32)]
        public int ExtractSize;

        [Params(1000, 10000, 100000)]
        public int Iterations;

        [Params("SHA256", "SHA512", "SHA1")]
        public string HashAlgorithm;

        public Rfc2898DeriveBytes _instance;
        public HashAlgorithmName _hash;
        public byte[] _password;
        public byte[] _salt;

        [GlobalSetup]
        public void Setup()
        {
            _password = new byte[32];
            RandomNumberGenerator.Fill(_password);
            _salt = new byte[32];
            RandomNumberGenerator.Fill(_salt);

            _hash = new HashAlgorithmName(HashAlgorithm);
            _instance = new Rfc2898DeriveBytes(_password, _salt, Iterations);
        }


        [Benchmark(Baseline = true)]
        public void GetBytes()
        {
            _instance.GetBytes(ExtractSize);
        }

        [Benchmark]
        public void OneShot()
        {
            Span<byte> dest = stackalloc byte[ExtractSize];
            Rfc2898DeriveBytes.Pbkdf2DeriveBytes(_password, _salt, Iterations, _hash, dest);
        }
    }
}