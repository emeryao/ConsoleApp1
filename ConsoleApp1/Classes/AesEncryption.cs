using System;
using ConsoleApp1.Interfaces;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace ConsoleApp1.Classes
{
    public class AesEncryption : IEntrance
    {
        /// <summary>
        /// AES Encrypt
        /// </summary>
        /// <param name="message">message to encrypt</param>
        /// <param name="encryptKey">encription key min length:16</param>
        /// <returns>encrypted string</returns>
        public static string Encrypt(string message, string encryptKey)
        {
            try
            {
                using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
                {
                    if (!aesAlg.ValidKeySize(Encoding.Default.GetByteCount(encryptKey) * 8))
                        throw new ArgumentOutOfRangeException("encryptKey", "key bit length invalid:128~256");

                    aesAlg.Key = Encoding.Default.GetBytes(encryptKey);
                    aesAlg.IV = Encoding.Default.GetBytes(encryptKey);
                    ICryptoTransform encryptor = aesAlg.CreateEncryptor();
                    using (MemoryStream msEncrypt = new MemoryStream())
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(message);
                        }
                        return Convert.ToBase64String(msEncrypt.ToArray());
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        /// <summary>
        /// AES Decrypt
        /// </summary>
        /// <param name="encryptString">encrypted string</param>
        /// <param name="encryptKey">encription key</param>
        /// <returns>decrypted message</returns>
        public static string Decrypt(string encryptString, string encryptKey)
        {
            try
            {
                using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
                {
                    if (!aesAlg.ValidKeySize(Encoding.Default.GetByteCount(encryptKey) * 8))
                        throw new ArgumentOutOfRangeException("encryptKey", "key bit length invalid:128~256");

                    aesAlg.Key = Encoding.Default.GetBytes(encryptKey);
                    aesAlg.IV = Encoding.Default.GetBytes(encryptKey);
                    ICryptoTransform decryptor = aesAlg.CreateDecryptor();
                    using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(encryptString)))
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        return srDecrypt.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public void Run()
        {
            string message = "HelloWrold";
            string key = "abcdefghijklmnop";
            Console.WriteLine($"AES encrypt message:{message} with key: {key}");
            Console.WriteLine(Encrypt(message, key));
        }
    }
}
