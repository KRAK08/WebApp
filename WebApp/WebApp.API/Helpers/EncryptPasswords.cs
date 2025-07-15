using System.Security.Cryptography;
using System.Text;

namespace WebApp.API.Helpers
{
    public static class EncryptPasswords
    {
        public static string EncryptPassword(string password)
        {
            //Llave
            byte[] Key = Encoding.UTF8.GetBytes("lasjfgaflsagfaefofv9f a;");
            //Vector inicializacion
            byte[] IV = Encoding.UTF8.GetBytes("lasjfgaflsagfaef");
            using Aes aes = Aes.Create();
            aes.Key = Key;
            aes.IV = IV;
            ICryptoTransform crypto = aes.CreateEncryptor();
            using MemoryStream memoryStream = new MemoryStream();
            using CryptoStream cryptoStream = new CryptoStream(memoryStream, crypto, CryptoStreamMode.Write);
            using (StreamWriter swEncrypt = new StreamWriter(cryptoStream))
            {
                swEncrypt.Write(password);
            }

            return Convert.ToBase64String(memoryStream.ToArray());
        }

        public static string DecryptPassword(string password)
        {
            //Llave
            byte[] Key = Encoding.UTF8.GetBytes("lasjfgaflsagfaefofv9f a;");
            //Vector inicializacion
            byte[] IV = Encoding.UTF8.GetBytes("lasjfgaflsagfaef");
            using Aes aes = Aes.Create();
            aes.Key = Key;
            aes.IV = IV;
            ICryptoTransform decryptor = aes.CreateEncryptor();

            byte[] cipheredBytes = Convert.FromBase64String(password);
            using MemoryStream memoryStream = new MemoryStream(cipheredBytes);
            using CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Write);
            using StreamReader srDecrypt = new StreamReader(cryptoStream);
            return srDecrypt.ReadToEnd();
        }
    }
}