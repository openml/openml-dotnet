using System;
using System.IO;
using System.Security.Cryptography;

namespace OpenML.Utilities
{
    public class Md5Utils
    {
        public static bool HasFileCorrectHash(string filePath, string expectedHash)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filePath))
                {
                    var actualHash = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLower();
                    return actualHash == expectedHash;
                }
            }
        }
    }
}
