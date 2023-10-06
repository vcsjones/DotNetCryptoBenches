using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;

namespace NetCryptoBench
{
    [MemoryDiagnoser]
    public class EcbOneShot
    {
        [Params(16)]
        public int DataSize;

        [Params(1, 2, 3)]
        public int NumberOfOperations;

        [Params(PaddingMode.PKCS7)]
        public PaddingMode Mode;

        [ParamsSource(nameof(GetAlgorithms))]
        public AlgFactory Algorithm;

        public byte[] Key;

        public IEnumerable<AlgFactory> GetAlgorithms()
        {
            yield return new AlgFactory (Aes.Create, nameof(Aes));
            yield return new AlgFactory (TripleDES.Create, nameof(TripleDES));
            yield return new AlgFactory (DES.Create, nameof(DES));
            yield return new AlgFactory (RC2.Create, nameof(RC2));
        }

        private byte[] _plaintext, _ciphertext;
        private byte[] _destination;

        [GlobalSetup]
        public void GlobalSetup()
        {
            (var algFactory, _) = Algorithm;
            using SymmetricAlgorithm alg = algFactory();
            _plaintext = RandomNumberGenerator.GetBytes(DataSize);
            _destination = new byte[alg.GetCiphertextLengthEcb(DataSize, Mode)];
            _ciphertext = alg.EncryptEcb(_plaintext, Mode);
            Key = alg.Key;
        }

        [Benchmark]
        public void Encrypt_Ecb_ToSpan()
        {
            (var algFactory, _) = Algorithm;
            using SymmetricAlgorithm alg = algFactory();
            alg.Key = Key;

            for (int i = 0; i < NumberOfOperations; i++)
            {
                alg.EncryptEcb(_plaintext, _destination, Mode);
            }
        }

        [Benchmark]
        public void DecryptEcb_ToSpan()
        {
            (var algFactory, _) = Algorithm;
            using SymmetricAlgorithm alg = algFactory();
            alg.Key = Key;

            for (int i = 0; i < NumberOfOperations; i++)
            {
                alg.DecryptEcb(_ciphertext, _destination, Mode);
            }
        }
    }
}