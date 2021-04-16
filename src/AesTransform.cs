using System.Collections.Generic;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;

namespace NetCryptoBench
{
    [MemoryDiagnoser]
    public class AesTransformBench
    {
        [Params(16, 1024 * 1024)]
        public int DataSize;

        [Params(PaddingMode.None, PaddingMode.PKCS7)]
        public PaddingMode Mode;
        private Aes aes;
        private ICryptoTransform encrypt, decrypt;
        private byte[] encryptData, decryptDataPadded, decryptData;
        private byte[] outputScratch;

        [GlobalSetup]
        public void GlobalSetup()
        {
            aes = Aes.Create();
            aes.Padding = Mode;
            encrypt = aes.CreateEncryptor();
            decrypt = aes.CreateDecryptor();
            encryptData = new byte[DataSize];
            decryptData = new byte[DataSize];
            RandomNumberGenerator.Fill(encryptData);
            decryptDataPadded = encrypt.TransformFinalBlock(encryptData, 0, encryptData.Length);
            encrypt.TransformBlock(encryptData, 0, encryptData.Length, decryptData, 0);
            outputScratch = new byte[DataSize + aes.BlockSize];
        }

        [Benchmark]
        public void Encrypt_TransformBlock()
        {
            encrypt.TransformBlock(encryptData, 0, encryptData.Length, outputScratch, 0);
        }

        [Benchmark]
        public void Decrypt_TransformBlock()
        {
            decrypt.TransformBlock(decryptData, 0, decryptData.Length, outputScratch, 0);
        }

        [Benchmark]
        public void Encrypt_TransformFinalBlock()
        {
            encrypt.TransformFinalBlock(encryptData, 0, encryptData.Length);
        }

        [Benchmark]
        public void Decrypt_TransformFinalBlock()
        {
            decrypt.TransformFinalBlock(decryptDataPadded, 0, decryptDataPadded.Length);
        }
    }
}