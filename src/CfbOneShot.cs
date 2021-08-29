using System.Collections.Generic;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;

namespace NetCryptoBench
{
    [MemoryDiagnoser]
    public class CfbOneShot
    {
        [Params(16)]
        public int DataSize;

        [Params(8)]
        public int FeebackSize;

        [Params(PaddingMode.None, PaddingMode.PKCS7)]
        public PaddingMode Mode;

        [ParamsSource(nameof(GetAlgorithms))]
        public SymmetricAlgorithm Algorithm;

        public IEnumerable<SymmetricAlgorithm> GetAlgorithms()
        {
            yield return Aes.Create();
            yield return TripleDES.Create();
            yield return DES.Create();
        }

        private byte[] _plaintext, _ciphertext;
        private byte[] _iv;
        private byte[] _destination;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _plaintext = RandomNumberGenerator.GetBytes(DataSize);
            _destination = new byte[Algorithm.GetCiphertextLengthCfb(DataSize, Mode, FeebackSize)];
            _iv = RandomNumberGenerator.GetBytes(Algorithm.BlockSize >> 3);
            _ciphertext = Algorithm.EncryptCfb(_plaintext, _iv, Mode, FeebackSize);
        }

        [Benchmark]
        public void Encrypt_Cfb_ToSpan()
        {
            Algorithm.EncryptCfb(_plaintext, _iv, _destination, Mode, FeebackSize);
        }

        [Benchmark]
        public void Decrypt_Cfb_ToSpan()
        {
            Algorithm.DecryptCfb(_ciphertext, _iv, _destination, Mode, FeebackSize);
        }
    }
}