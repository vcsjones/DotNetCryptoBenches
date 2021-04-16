using System.Collections.Generic;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;

namespace NetCryptoBench
{
    public class ECDsaImportExportBench
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
        private ECParameters privateParameters;
        private ECParameters publicParameters;
        private ECCurve _eccurve;


        [GlobalSetup]
        public void Setup()
        {
            _eccurve = ECCurve.CreateFromFriendlyName(curve);
            using var tempEcdsa =  ECDsa.Create(_eccurve);
            privateParameters = tempEcdsa.ExportParameters(true);
            publicParameters = tempEcdsa.ExportParameters(false);
            ecdsa = ECDsa.Create(_eccurve);
        }

        [Benchmark]
        public void ImportPrivateParameters()
        {
            ecdsa.ImportParameters(privateParameters);
        }

        [Benchmark]
        public void ImportPublicParameters()
        {
            ecdsa.ImportParameters(publicParameters);
        }

        [Benchmark]
        public void ExportPrivateParameters()
        {
            ecdsa.ExportParameters(true);
        }

        [Benchmark]
        public void ExportPublicParameters()
        {
            ecdsa.ExportParameters(false);
        }
    }
}