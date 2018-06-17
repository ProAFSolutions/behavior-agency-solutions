using NETCore.Encrypt;
using System;
using System.Collections.Generic;
using System.Text;

namespace BehaviorAgency.Infrastructure
{
    public static class CryptoManager
    {

        public static string Encrypt(string text)
        {
            return EncryptProvider.DESEncrypt(text, "Pr0@FS0luti0ns4Ever");
        }

        public static string Decrypt(string encryptedText)
        {
            return EncryptProvider.RSADecrypt(encryptedText, "Pr0@FS0luti0ns4Ever");
        }

        public static string Encrypt(string plainText, string key)
        {
            return EncryptProvider.DESEncrypt(plainText, key);
        }

        public static string Decrypt(string encryptedText, string key)
        {
            return EncryptProvider.DESDecrypt(encryptedText, key);
        }

        public static string EncryptSHA1(string plainText)
        {
            return EncryptProvider.Sha1(plainText);
        }

        public static string EncryptSHA256(string plainText)
        {
            return EncryptProvider.Sha256(plainText);
        }
    }
}
