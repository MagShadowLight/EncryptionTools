using System.Security.Cryptography;

namespace EncryptorTools
{
    public class Encrypter
    {
        private static readonly byte[] _key = new byte[16]
                {
                    0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
                    0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16
                };
        private static byte[] _IV;
        public static void Encrypt(string text, string path)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            using (Aes aes = Aes.Create())
            {
                aes.Key = _key;
                byte[] IV = aes.IV;
                fileStream.Write(IV, 0, IV.Length);
                using (CryptoStream crypto = new(
                    fileStream,
                    aes.CreateEncryptor(),
                    CryptoStreamMode.Write))
                {
                    using (StreamWriter writer = new(crypto))
                        writer.WriteLine(text);
                }
            }
        }
        public static string Decrypt(string path)
        {
            string decryptedText;
            using (FileStream fileStream = new(path, FileMode.Open))
            using (Aes aes = Aes.Create())
            {
                _IV = new byte[aes.IV.Length];
                ReadByte(fileStream, aes);
                using (CryptoStream crypto = new(
                    fileStream,
                    aes.CreateDecryptor(_key, _IV),
                    CryptoStreamMode.Read))
                {
                    using (StreamReader reader = new(crypto))
                    {
                        decryptedText = reader.ReadToEnd();
                    }

                }
            }
            return decryptedText;
        }

        private static void ReadByte(FileStream fileStream, Aes aes)
        {
            int numBytesReader = aes.IV.Length;
            int numread = 0;
            while (numBytesReader > 0)
            {
                int num = fileStream.Read(_IV, numread, numBytesReader);
                if (num == 0)
                    break;

                numBytesReader -= num;
                numread += num;
            }
        }
    }
}
