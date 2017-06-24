using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BookStote.Helpers
{
    public static class StringHelpers
    {
        public static string EncryptLoginPassword(string clearText, string passwordFormat)
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
                    throw new ArgumentException(string.Format("{0} is not a valid format option", passwordFormat));
                }

                algorithm = MD5.Create();
            }

            byte[] hashedPasswd = algorithm.ComputeHash(Encoding.UTF8.GetBytes(clearText));
            var encryptedPasswd = BitConverter.ToString(hashedPasswd).Replace("-", string.Empty);

            return encryptedPasswd;
        }
    }
}
