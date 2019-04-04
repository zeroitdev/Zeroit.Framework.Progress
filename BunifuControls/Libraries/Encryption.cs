using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Zeroit.Framework.Progress.CustomControls
{
    [DebuggerStepThrough]
    internal static class Encryption
    {
        private const int int_0 = 256;

        public static string Decrypt(string cipherText, string passPhrase, string salt = "tu89geji340t89u2")
        {
            string str;
            try
            {
                byte[] bytes = Encoding.ASCII.GetBytes(salt);
                byte[] numArray = Convert.FromBase64String(cipherText);
                byte[] bytes1 = (new PasswordDeriveBytes(passPhrase, null)).GetBytes(32);
                ICryptoTransform cryptoTransform = (new RijndaelManaged()
                {
                    Mode = CipherMode.CBC
                }).CreateDecryptor(bytes1, bytes);
                MemoryStream memoryStream = new MemoryStream(numArray);
                CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Read);
                byte[] numArray1 = new byte[(int)numArray.Length];
                int num = cryptoStream.Read(numArray1, 0, (int)numArray1.Length);
                memoryStream.Close();
                cryptoStream.Close();
                str = Encoding.UTF8.GetString(numArray1, 0, num);
            }
            catch (Exception exception)
            {
                str = null;
            }
            return str;
        }

        public static string Encrypt(string plainText, string passPhrase, string salt = "tu89geji340t89u2")
        {
            byte[] bytes = Encoding.UTF8.GetBytes(salt);
            byte[] numArray = Encoding.UTF8.GetBytes(plainText);
            byte[] bytes1 = (new PasswordDeriveBytes(passPhrase, null)).GetBytes(32);
            ICryptoTransform cryptoTransform = (new RijndaelManaged()
            {
                Mode = CipherMode.CBC
            }).CreateEncryptor(bytes1, bytes);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write);
            cryptoStream.Write(numArray, 0, (int)numArray.Length);
            cryptoStream.FlushFinalBlock();
            byte[] array = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            return Convert.ToBase64String(array);
        }
    }
}
