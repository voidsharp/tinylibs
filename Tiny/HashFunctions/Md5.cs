using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Tiny
{
    public static class Md5
    {
        public static IEnumerable<byte> GetHash(byte[] objectToHash)
        {
            var md5 = MD5.Create();
            var inputBytes = objectToHash;
            var hash = md5.ComputeHash(inputBytes);
            return hash;
        }

        public static string GetHash(string stringToHash)
        {
            if (string.IsNullOrEmpty(stringToHash))
                return "";
            var hashAsBytes = GetHash(Encoding.UTF8.GetBytes(stringToHash));
            var sb = new StringBuilder();
            foreach (var t in hashAsBytes)
                sb.Append(t.ToString("x2"));
            return sb.ToString();
        }
    }
}
