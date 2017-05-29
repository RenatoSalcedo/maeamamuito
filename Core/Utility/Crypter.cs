using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.DataProtection;

namespace MaeAmaMuito.Core.Utility
{
    public class Crypter
    {
        private static readonly string PubKey = "99MAM99"; 
        static readonly byte[] CryptoCode = new byte[] { 0x50, 0x76, 0x61, 0x6e, 0x23, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x60, 0x76 };

        public static string Encrypt(string encryptString)   
        {  
            byte[] clearBytes = Encoding.Unicode.GetBytes(encryptString);  
            using(Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(GetPubKey(), GetCryptoCode());
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Dispose();
                    }

                    encryptString = Convert.ToBase64String(ms.ToArray());
                }
            }

            return encryptString;  
        }

        private static byte[] GetCryptoCode()
        {
            return CryptoCode;
        }

        private static string GetPubKey()
        {
            return PubKey;
        }

        private void moveBytes(Stream fonte, Stream destino)
        {
            byte[] bytes = new byte[2049];
            var contador = fonte.Read(bytes, 0, bytes.Length - 1);
            while (0 != contador)
            {
                destino.Write(bytes, 0, contador);
                contador = fonte.Read(bytes, 0, bytes.Length - 1);
            }
        }
        public static string Decrypt(string cipherText)   
        {  
            cipherText = cipherText.Replace(" ", "+");  
            byte[] cipherBytes = Convert.FromBase64String(cipherText);  
            using(Aes encryptor = Aes.Create())   
            {  
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(PubKey, CryptoCode);  
                encryptor.Key = pdb.GetBytes(32);  
                encryptor.IV = pdb.GetBytes(16);

                using(MemoryStream ms = new MemoryStream())   
                {  
                    using(CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write)) {  
                        cs.Write(cipherBytes, 0, cipherBytes.Length);  
                        cs.Dispose();  
                    }

                    cipherText = Encoding.Unicode.GetString(ms.ToArray());  
                }  
            } 

            return cipherText;  
        }  
    }
}