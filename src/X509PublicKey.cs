using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using BenchmarkDotNet.Attributes;

namespace NetCryptoBench
{
    [MemoryDiagnoser]
    public class X509PublicKey
    {
        X509Certificate2 cert;

        [IterationSetup]
        public void Setup()
        {
            cert = X509Certificate2.CreateFromPem("""
            -----BEGIN CERTIFICATE-----
MIIDezCCAwGgAwIBAgISAy0yxh5eZpqRDopZTmcERSd7MAoGCCqGSM49BAMDMDIx
CzAJBgNVBAYTAlVTMRYwFAYDVQQKEw1MZXQncyBFbmNyeXB0MQswCQYDVQQDEwJF
MTAeFw0yNDAxMTIwOTM4NDdaFw0yNDA0MTEwOTM4NDZaMBcxFTATBgNVBAMTDHZj
c2pvbmVzLmRldjBZMBMGByqGSM49AgEGCCqGSM49AwEHA0IABEqzPBW0/93Uv2Nn
E/V/GEAZrW3AYm+O8WEiUk9DgNVSi0WJ/psE/vKTnRZJLfW2w/5f1tuNp8NlJHJO
gHSDPfqjggIQMIICDDAOBgNVHQ8BAf8EBAMCB4AwHQYDVR0lBBYwFAYIKwYBBQUH
AwEGCCsGAQUFBwMCMAwGA1UdEwEB/wQCMAAwHQYDVR0OBBYEFEFL3zN4bXTkKpHR
Y39t+EJlc4owMB8GA1UdIwQYMBaAFFrz7Sv8NsI3eblSMOpUb89Vyy6sMFUGCCsG
AQUFBwEBBEkwRzAhBggrBgEFBQcwAYYVaHR0cDovL2UxLm8ubGVuY3Iub3JnMCIG
CCsGAQUFBzAChhZodHRwOi8vZTEuaS5sZW5jci5vcmcvMBcGA1UdEQQQMA6CDHZj
c2pvbmVzLmRldjATBgNVHSAEDDAKMAgGBmeBDAECATCCAQYGCisGAQQB1nkCBAIE
gfcEgfQA8gB3AEiw42vapkc0D+VqAvqdMOscUgHLVt0sgdm7v6s52IRzAAABjP1A
vQwAAAQDAEgwRgIhANxfkSfMMZT+zv9+tGYWxS4E+EGeQMo8P0ClwypkTDQuAiEA
rmmKnPzFT+tH5d0fSemzd4GBkZi/Q0dkhxXBib/VIIsAdwA7U3d1Pi25gE6LMFsG
/kA7Z9hPw/THvQANLXJv4frUFwAAAYz9QL0UAAAEAwBIMEYCIQCRJDynap+WbRzY
Vf8hlDhs5KMXmgFEGhTv9BcxrS/TpwIhALoExITonoKNpwHE75VZEHCZwseMfhQX
ItfP7ARBXLV8MAoGCCqGSM49BAMDA2gAMGUCMHD/QvETrCgPalCkVBg4RrzL25VP
3ePz35kztUunSICEybda/0q1c/CKU9dQTeW5oQIxAN73qjXH5eHbYDCosn4iM2Yu
ziss+Vw/szMsxTXcRKtpjSgdqQ+lQe9SAam3QiW/YQ==
-----END CERTIFICATE-----
""");
            _ = cert.GetKeyAlgorithm();
            _ = cert.GetPublicKey();
            _ = cert.GetKeyAlgorithmParameters();
        }

        [Benchmark]
        public PublicKey GetPublicKey()
        {
            return cert.PublicKey;
        }
    }
}