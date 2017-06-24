using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStote.Helpers
{
    public static class FileHelpers
    {
        public static bool TryCopyFile(string sourceFilePath, string destinationDirectory, out string outPath)
        {
            outPath = string.Empty;
            try
            {
                var rootPath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
                outPath = String.Format(@"{0}\{1}{2}", destinationDirectory, Guid.NewGuid(), Path.GetExtension(sourceFilePath));
                File.Copy(sourceFilePath, rootPath + outPath);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
