using System.Collections.Generic;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace NetCryptoBench
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromTypes(new[] { typeof(ECDsaBench) }).Run(args);
        }
    }

    public class ECDsaBench
    {
        public IEnumerable<string> CurveNames => new [] {
            "ECDSA_P256",
            "ECDSA_P384",
            "ECDSA_P521"
        };

        public IEnumerable<HashAlgorithmName> HashAlgorithms => new [] {
            HashAlgorithmName.SHA1,
            HashAlgorithmName.SHA256,
            HashAlgorithmName.SHA512,
        };

        [ParamsSource(nameof(CurveNames))]
        public string CurveName;

        public ECCurve Curve;

        [ParamsSource(nameof(HashAlgorithms))]
        public HashAlgorithmName HashAlgorithm;

        [Params(1, 32, 1000)]
        public int DataLength;

        public ECDsa ecdsa;
        public byte[] Data;
        public byte[] Signature;
        public byte[] Hash;
        
        [GlobalSetup]
        public void Setup()
        {
            Curve = ECCurve.CreateFromFriendlyName(CurveName);
            ecdsa = ECDsa.Create(Curve);
            Data = new byte[DataLength];
            RandomNumberGenerator.Fill(Data);
            Signature = ecdsa.SignData(Data, HashAlgorithm);
            using IncrementalHash hasher = IncrementalHash.CreateHash(HashAlgorithm);
            hasher.AppendData(Data);
            Hash = hasher.GetHashAndReset();
        }

        [Benchmark]
        public void SignData()
        {
            ecdsa.SignData(Data, HashAlgorithm);
        }
        
        [Benchmark]
        public void VerifyData()
        {
            ecdsa.VerifyData(Data, Signature, HashAlgorithm);
        }

        [Benchmark]
        public void SignHash()
        {
            ecdsa.SignHash(Data);
        }
        
        [Benchmark]
        public void VerifyHash()
        {
            ecdsa.VerifyHash(Data, Signature);
        }
    }
}
