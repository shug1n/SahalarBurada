using System.Security.Cryptography;
using System.Text;

namespace SahalarBurada.Helpers
{
    public static class SifreHelper
    {
        public static string Hash(string sifre)
        {
            using (var sha = SHA256.Create())
            {
                var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(sifre));
                var sb = new StringBuilder();
                foreach (var b in bytes)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        public static bool Dogrula(string sifre, string hash)
        {
            return Hash(sifre) == hash;
        }
    }
}
