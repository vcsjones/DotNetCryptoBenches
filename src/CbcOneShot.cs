using System.Collections.Generic;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;

namespace NetCryptoBench
{
    [MemoryDiagnoser]
    public class CbcOneShot
    {
        [Params(16)]
        public int DataSize;

        [Params(PaddingMode.None, PaddingMode.PKCS7)]
        public PaddingMode Mode;

        [ParamsSource(nameof(GetAlgorithms))]
        public SymmetricAlgorithm Algorithm;

        public IEnumerable<SymmetricAlgorithm> GetAlgorithms()
        {
            yield return Aes.Create();
            //yield return TripleDES.Create();
            //yield return DES.Create();
            //yield return RC2.Create();
        }

        private byte[] _plaintext, _ciphertext;
        private byte[] _iv;
        private byte[] _destination;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _plaintext = RandomNumberGenerator.GetBytes(DataSize);
            _destination = new byte[Algorithm.GetCiphertextLengthCbc(DataSize, Mode)];
            _iv = RandomNumberGenerator.GetBytes(Algorithm.BlockSize >> 3);
            _ciphertext = Algorithm.EncryptCbc(_plaintext, _iv, Mode);
        }

        [Benchmark]
        public void Encrypt_Cbc_ToSpan()
        {
            Algorithm.EncryptCbc(_plaintext, _iv, _destination, Mode);
        }

        [Benchmark]
        public void Decrypt_Cbc_ToSpan()
        {
            Algorithm.DecryptCbc(_ciphertext, _iv, _destination, Mode);
        }
    }
}