using System.Collections.Generic;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;

namespace NetCryptoBench
{
    public class ECDsaBench
    {
        public class ECDsaConfig
        {
            public ECDsa ECDsa;
            public HashAlgorithmName HashAlgorithm;
            public ECCurve Curve;

            public ECDsaConfig(ECCurve curve, HashAlgorithmName hashAlgorithm)
            {
                this.ECDsa = ECDsa.Create(curve);
                this.HashAlgorithm = hashAlgorithm;
                this.Curve = curve;
            }

            public override string ToString()
            {
                return $"{Curve.Oid.FriendlyName}, {HashAlgorithm.Name}";
            }
        }
        public IEnumerable<ECDsaConfig> GetECDsaConfigs()
        {
            yield return new ECDsaConfig(ECCurve.NamedCurves.nistP256, HashAlgorithmName.SHA256);
            yield return new ECDsaConfig(ECCurve.NamedCurves.nistP384, HashAlgorithmName.SHA384);
            yield return new ECDsaConfig(ECCurve.NamedCurves.nistP521, HashAlgorithmName.SHA512);
        }

        [ParamsSource(nameof(GetECDsaConfigs))]
        public ECDsaConfig Config;

        public byte[] Data;
        public byte[] Signature;
        public byte[] Hash;
        
        [GlobalSetup]
        public void Setup()
        {
            Data = new byte[32];
            RandomNumberGenerator.Fill(Data);
            Signature = Config.ECDsa.SignData(Data, Config.HashAlgorithm);
            using IncrementalHash hasher = IncrementalHash.CreateHash(Config.HashAlgorithm);
            hasher.AppendData(Data);
            Hash = hasher.GetHashAndReset();
        }

        [Benchmark]
        public void SignHash()
        {
            Config.ECDsa.SignHash(Hash);
        }
        
        [Benchmark]
        public void VerifyHash()
        {
            Config.ECDsa.VerifyHash(Hash, Signature);
        }
    }
}