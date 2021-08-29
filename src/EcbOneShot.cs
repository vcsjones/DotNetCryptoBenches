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

        [Params(PaddingMode.None, PaddingMode.PKCS7)]
        public PaddingMode Mode;

        [ParamsSource(nameof(GetAlgorithms))]
        public SymmetricAlgorithm Algorithm;

        public IEnumerable<SymmetricAlgorithm> GetAlgorithms()
        {
            yield return Aes.Create();
            yield return TripleDES.Create();
            yield return DES.Create();
            yield return RC2.Create();
        }

        private byte[] _plaintext, _ciphertext;
        private byte[] _destination;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _plaintext = RandomNumberGenerator.GetBytes(DataSize);
            _destination = new byte[Algorithm.GetCiphertextLengthEcb(DataSize, Mode)];
            _ciphertext = Algorithm.EncryptEcb(_plaintext, Mode);
        }

        [Benchmark]
        public void Encrypt_Ecb_ToSpan()
        {
            Algorithm.EncryptEcb(_plaintext, _destination, Mode);
        }

        [Benchmark]
        public void DecryptEcb_ToSpan()
        {
            Algorithm.DecryptEcb(_ciphertext, _destination, Mode);
        }
    }
}