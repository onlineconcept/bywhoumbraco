using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Helpers
{
    public class MD5Helper
    {
        public static string CalculateMd5Hash(string[] paramsList, string secret)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(string.Join("", paramsList) + secret);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        public static string ValidateMD5(string[] paramsList, string secret)
        {
            byte[] bytes = Encoding.Default.GetBytes(string.Join("", paramsList) + secret);
            try
            {
                byte[] hash = new MD5CryptoServiceProvider().ComputeHash(bytes);
                string str = "";
                foreach (byte num in hash)
                    str = num >= (byte)16 ? str + num.ToString("x") : str + "0" + num.ToString("x");
                return str;
            }
            catch
            {
                throw;
            }
        }


    }
}
