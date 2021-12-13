using Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Data.Implements
{
	public class SaveData
	{
        private static DESCryptoServiceProvider des;
        public string Encrypt(string encText)
        {
            if (string.IsNullOrEmpty(encText))
            {
                return "";
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

        public string Decrypt(string cryptedString)
        {
            if (string.IsNullOrEmpty(cryptedString))
            {
                throw new ArgumentNullException
                   ("The string which needs to be decrypted can not be null.");
            }
            MemoryStream memoryStream = new MemoryStream
                    (Convert.FromBase64String(cryptedString));
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                des.CreateDecryptor(des.Key, des.IV), CryptoStreamMode.Read);
            StreamReader reader = new StreamReader(cryptoStream);
            return reader.ReadToEnd();
        }

        public static void Save(List<User> users)
		{
            var strJson = JsonConvert.SerializeObject(users);
            using (var context = new Database())
            {
                DataDB elem = context.Datas.FirstOrDefault();
                if (string.IsNullOrEmpty(strJson))
                {
                    throw new Exception("Нет данных");
                }
                else
                {
                    elem = new DataDB();
                    context.Datas.Add(elem);
                }
                elem.text = strJson;
                context.SaveChanges();
            }
        }

        public string GetHash(string input)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    // can be "x2" if you want lowercase
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString();
            }
        }

        public List<User> Read(string passPhrase)
        {
            if (des == null)
            {
                try
                {
                    des = new DESCryptoServiceProvider
                    {
                        Mode = CipherMode.ECB
                    };
                    // Генерируем ключ
                    byte[] arr = Encoding.UTF8.GetBytes(passPhrase).ToList().Take(8).ToArray();
                    byte[] arr1 = Encoding.UTF8.GetBytes(passPhrase).ToList().Take(8).ToArray();
                    des.Key = arr;
                    //Случайное значение
                    des.IV = arr1;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            using (var context = new Database())
            {
                var jsonStr = context.Datas.FirstOrDefault();
                if(jsonStr != null)
                    return JsonConvert.DeserializeObject<List<User>>(Decrypt(jsonStr.text));
                return null;
            }
        }
    }
}
