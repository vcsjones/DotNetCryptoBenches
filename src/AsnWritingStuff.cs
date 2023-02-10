using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Pkcs;
using BenchmarkDotNet.Attributes;

namespace NetCryptoBench
{
    [MemoryDiagnoser]
    public class AsnWritingStuff
    {
        private Rfc3161TimestampRequest req;

        [GlobalSetup]
        public void GlobalSetup()
        {
            req = Rfc3161TimestampRequest.CreateFromHash(new byte[32], HashAlgorithmName.SHA256);
        }

        [Benchmark]
        public X509BasicConstraintsExtension NewX509BasicConstraints()
        {
            return new X509BasicConstraintsExtension(false, false, 0, true);
        }

        [Benchmark]
        public byte[] CreateTimeStampReq()
        {
            return req.Encode();
        }

    }
}