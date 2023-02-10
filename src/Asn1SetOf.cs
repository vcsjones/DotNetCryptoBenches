using System;
using System.Formats.Asn1;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using BenchmarkDotNet.Attributes;

namespace NetCryptoBench
{
    [MemoryDiagnoser]
    public class Asn1SetOf
    {
        X509Certificate2 _cert;
        CmsSigner _signer;
        SignedCms _cms;

        [GlobalSetup]
        public void Setup()
        {
            RSA rsa = RSA.Create(2048);
            CertificateRequest req = new CertificateRequest("CN=potato", rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            _cert = req.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddYears(1));
            _signer = new CmsSigner(SubjectIdentifierType.SubjectKeyIdentifier, _cert);
            SignedCms cms = new SignedCms(new ContentInfo(new byte[] { 1, 2, 3 }));
            cms.ComputeSignature(_signer);
           _cms = cms;
        }

        [Benchmark]
        public byte[] WriteSignedCms()
        {
           return _cms.Encode();
        }
    }
}