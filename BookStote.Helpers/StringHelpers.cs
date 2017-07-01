using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStote.Helpers
{
    public static class StringHelpers
    {
        public static string EncryptLoginPassword(this string clearText, string passwordFormat)
        {
            HashAlgorithm algorithm;
            if (clearText == null)
            {
                throw new ArgumentNullException("clearText");
            }
            if (passwordFormat == null)
            {
                throw new ArgumentNullException("passwordFormat");
            }
            if (String.Compare(passwordFormat, "sha1", StringComparison.OrdinalIgnoreCase) == 0)
            {
                algorithm = SHA1.Create();
            }
            else
            {
                if (String.Compare(passwordFormat, "md5", StringComparison.OrdinalIgnoreCase) != 0)
                {
                    throw new ArgumentException($"{passwordFormat} is not a valid format option");
                }

                algorithm = MD5.Create();
            }

            byte[] hashedPasswd = algorithm.ComputeHash(Encoding.UTF8.GetBytes(clearText));
            var encryptedPasswd = BitConverter.ToString(hashedPasswd).Replace("-", string.Empty);

            return encryptedPasswd;
        }

        public static string GetFullPath(this string cover, string subDir)
        {
#if DEBUG
            return $@"{Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()))}{subDir}\{cover}";
#else
            MessageBox.Show($"{Directory.GetCurrentDirectory()}{subDir}{cover}");
            return $"{Directory.GetCurrentDirectory()}{subDir}{cover}"; 
#endif
        }
    }
}
