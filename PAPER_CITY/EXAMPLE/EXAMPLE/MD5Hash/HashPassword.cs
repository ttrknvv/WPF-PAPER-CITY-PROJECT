using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PaperCity.MD5Hash
{
    public class HashPassword
    {
        public static string GetHashPassword(string password)
        {
            try
            {
                MD5 md5 = MD5.Create();

                byte[] b = Encoding.ASCII.GetBytes(password);
                byte[] hash = md5.ComputeHash(b);

                StringBuilder sb = new StringBuilder();
                foreach (var a in hash)
                {
                    sb.Append(a.ToString("X2"));
                }

                return Convert.ToString(sb);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ErrorHashPassword", MessageBoxButton.OK, MessageBoxImage.Error);
                return "";
            }
            
        }

    }
}
