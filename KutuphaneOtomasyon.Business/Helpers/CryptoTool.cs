using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace KutuphaneOtomasyon.Business.Helpers
{
    public static class CryptoTool
    {

        public static String strPermutation = "AlperBasda_26*92";
        public static byte bytePermutation1 = 0x23;
        public static byte bytePermutation2 = 0x11;
        public static byte bytePermutation3 = 0x27;
        public static byte bytePermutation4 = 0x31;

        //For Password
        public static string EnCryptoPass(string value)
        {
            return Convert.ToBase64String(Encrypt(Encoding.UTF8.GetBytes(value)));
        }

        //For Password
        public static string DeCryptoPass(string value)
        {
            return Encoding.UTF8.GetString(Decrypt(Convert.FromBase64String(value)));
        }

        //For Ids
        public static string EnCryptoId(int value)
        {
            return value.ToString();
        }

        //For Ids
        public static int DeCryptoId(string value)
        {
            return Convert.ToInt32(value);
        }


        // encrypt
        public static byte[] Encrypt(byte[] strData)
        {
            PasswordDeriveBytes passbytes =
                new PasswordDeriveBytes(strPermutation,
                    new byte[] { bytePermutation1,
                        bytePermutation2,
                        bytePermutation3,
                        bytePermutation4
                    });

            MemoryStream memstream = new MemoryStream();
            Aes aes = new AesManaged();
            aes.Key = passbytes.GetBytes(aes.KeySize / 8);
            aes.IV = passbytes.GetBytes(aes.BlockSize / 8);

            CryptoStream cryptostream = new CryptoStream(memstream,
                aes.CreateEncryptor(), CryptoStreamMode.Write);
            cryptostream.Write(strData, 0, strData.Length);
            cryptostream.Close();
            return memstream.ToArray();
        }

        // decrypt
        public static byte[] Decrypt(byte[] strData)
        {
            PasswordDeriveBytes passbytes =
                new PasswordDeriveBytes(strPermutation,
                    new byte[] { bytePermutation1,
                        bytePermutation2,
                        bytePermutation3,
                        bytePermutation4
                    });

            MemoryStream memstream = new MemoryStream();
            Aes aes = new AesManaged();
            aes.Key = passbytes.GetBytes(aes.KeySize / 8);
            aes.IV = passbytes.GetBytes(aes.BlockSize / 8);

            CryptoStream cryptostream = new CryptoStream(memstream,
                aes.CreateDecryptor(), CryptoStreamMode.Write);
            cryptostream.Write(strData, 0, strData.Length);
            cryptostream.Close();
            return memstream.ToArray();
        }
    }
}