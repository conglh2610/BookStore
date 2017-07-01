using System;
using System.IO;

namespace BookStote.Helpers
{
    public static class FileHelpers
    {
        public static bool TryCopyFile(string sourcePath, string destinationPath)
        {
            try
            {
                File.Copy(sourcePath, destinationPath);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
