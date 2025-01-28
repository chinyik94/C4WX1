using System.Security.Cryptography;
using System.Text;

namespace C4WX1.API.Features.Security
{
    public class SecurityService : ISecurityService
    {
        private const string InitVector = "@1B2c3D4e5F6g7H8";
        private const string SaltValue = "$1M4L3W0RX";
        private const string Passphrase = "$1M4L3W0RX";
        private const int PasswordIterations = 2;
        private const int KeySize = 256;

        public string Decrypt(string cipherText)
        {
            if (string.IsNullOrWhiteSpace(cipherText))
            {
                throw new ArgumentException("Must supply a text to be decrypted.", nameof(cipherText));
            }

            byte[] initVectorBytes = Encoding.ASCII.GetBytes(InitVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(SaltValue);
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

            using var deriveBytes = new Rfc2898DeriveBytes(
                Passphrase,
                saltValueBytes,
                PasswordIterations,
                HashAlgorithmName.SHA1);

            byte[] keyBytes = deriveBytes.GetBytes(KeySize / 8);

            using var symmetricKey = Aes.Create();
            symmetricKey.Mode = CipherMode.CBC;

            using var decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
            using var memoryStream = new MemoryStream(cipherTextBytes);
            using var cryptoStream = new CryptoStream(
                memoryStream,
                decryptor,
                CryptoStreamMode.Read);

            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);

            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
        }

        public string Encrypt(string plainText)
        {
            if (string.IsNullOrWhiteSpace(plainText))
            {
                throw new ArgumentException("Must supply a text to be encrypted.", nameof(plainText));
            }

            byte[] initVectorBytes = Encoding.ASCII.GetBytes(InitVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(SaltValue);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            using var deriveBytes = new Rfc2898DeriveBytes(
                Passphrase,
                saltValueBytes,
                PasswordIterations,
            HashAlgorithmName.SHA1);

            byte[] keyBytes = deriveBytes.GetBytes(KeySize / 8);

            using var symmetricKey = Aes.Create();
            symmetricKey.Mode = CipherMode.CBC;

            using var encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            using var memoryStream = new MemoryStream();
            using var cryptoStream = new CryptoStream(
                memoryStream,
                encryptor,
                CryptoStreamMode.Write);

            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();

            byte[] cipherTextBytes = memoryStream.ToArray();

            return Convert.ToBase64String(cipherTextBytes);
        }

        public string GeneratePassword()
        {
            throw new NotImplementedException();
        }
    }
}
