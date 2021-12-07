using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Handlers
{
	public class Cryption
	{
		private DESCryptoServiceProvider des;
        public string Encrypt(string encText)
        {
            if (string.IsNullOrEmpty(encText))
            {
            }
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                des.CreateEncryptor(des.Key, des.IV), CryptoStreamMode.Write);
            StreamWriter writer = new StreamWriter(cryptoStream);
            writer.Write(encText);
            writer.Flush();
            cryptoStream.FlushFinalBlock();
            writer.Flush();
            return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
        }

        public string Decrypt(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException
                   ("The string which needs to be decrypted can not be null.");
            }
            MemoryStream memoryStream = new MemoryStream
                    (Convert.FromBase64String(text));
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                des.CreateDecryptor(des.Key, des.IV), CryptoStreamMode.Read);
            StreamReader reader = new StreamReader(cryptoStream);
            return reader.ReadToEnd();
        }
    }
}
