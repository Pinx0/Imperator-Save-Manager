using System.Security.Cryptography;
using System.Text;

namespace ImperatorStats.Extensions
{
    public static class Criptograhpy
    {
        public static string GetSha1(this string text)
        {
            var sha1 = SHA1.Create();
            var textOriginal = Encoding.Default.GetBytes(text);
            var hash = sha1.ComputeHash(textOriginal);
            var builder = new StringBuilder();
            foreach (byte i in hash)
            {
                builder.AppendFormat("{0:x2}", i);
            }
            return builder.ToString();
        }
    }
}
