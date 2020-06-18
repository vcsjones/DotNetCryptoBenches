using System.Collections.Generic;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;

namespace NetCryptoBench
{
    public class ECDsaKeyGenBench
    {
        public IEnumerable<string> GetECCurve()
        {
            yield return ECCurve.NamedCurves.nistP256.Oid.FriendlyName;
            yield return ECCurve.NamedCurves.nistP384.Oid.FriendlyName;
            yield return ECCurve.NamedCurves.nistP521.Oid.FriendlyName;
        }

        [ParamsSource(nameof(GetECCurve))]
        public string curve;

        private ECDsa ecdsa;
        private ECCurve _eccurve;

        [GlobalSetup]
        public void Setup()
        {
            _eccurve = ECCurve.CreateFromFriendlyName(curve);
            ecdsa = ECDsa.Create();
        }

        [Benchmark]
        public void KeyGen()
        {
            ecdsa.GenerateKey(_eccurve);
        }
    }
}