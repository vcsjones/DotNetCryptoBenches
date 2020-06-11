using System.Collections.Generic;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;

namespace NetCryptoBench
{
    public class RSABench
    {
        public class RSAConfig
        {
            public RSA RSA;
            public HashAlgorithmName HashAlgorithm;
            public int KeySize;

            public RSAConfig(int keySize, HashAlgorithmName hashAlgorithm)
            {
                this.RSA = RSA.Create(keySize);
                this.HashAlgorithm = hashAlgorithm;
                this.KeySize = keySize;
            }

            public override string ToString()
            {
                return $"RSA{KeySize}, {HashAlgorithm.Name}";
            }
        }
        public IEnumerable<RSAConfig> GetRSAConfigs()
        {
            yield return new RSAConfig(2048, HashAlgorithmName.SHA256);
            yield return new RSAConfig(1024, HashAlgorithmName.SHA1);
            yield return new RSAConfig(4096, HashAlgorithmName.SHA512);
        }

        [Params(1, 32, 1000)]
        public int DataLength;

        [ParamsSource(nameof(GetRSAConfigs))]
        public RSAConfig Config;

        public byte[] Data;
        public byte[] Signature;
        public byte[] Hash;
        
        [GlobalSetup]
        public void Setup()
        {
            Data = new byte[DataLength];
            RandomNumberGenerator.Fill(Data);
            Signature = Config.RSA.SignData(Data, Config.HashAlgorithm, RSASignaturePadding.Pkcs1);
            using IncrementalHash hasher = IncrementalHash.CreateHash(Config.HashAlgorithm);
            hasher.AppendData(Data);
            Hash = hasher.GetHashAndReset();
        }

        [Benchmark]
        public void SignData()
        {
            Config.RSA.SignData(Data, Config.HashAlgorithm, RSASignaturePadding.Pkcs1);
        }
        
        [Benchmark]
        public void VerifyData()
        {
            Config.RSA.VerifyData(Data, Signature, Config.HashAlgorithm, RSASignaturePadding.Pkcs1);
        }

        [Benchmark]
        public void SignHash()
        {
            Config.RSA.SignHash(Hash, Config.HashAlgorithm, RSASignaturePadding.Pkcs1);
        }
        
        [Benchmark]
        public void VerifyHash()
        {
            Config.RSA.VerifyHash(Hash, Signature, Config.HashAlgorithm, RSASignaturePadding.Pkcs1);
        }

        [Benchmark]
        public void KeyGen()
        {
            var rsa = RSA.Create(Config.KeySize);
            _ = rsa.ExportParameters(true); //Force keygen
        }
    }
}