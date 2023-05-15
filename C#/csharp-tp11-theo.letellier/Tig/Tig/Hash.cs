using System.Security.Cryptography;
using System.Text;

namespace Tig
{
    // Do not modify!
    public class Hash
    {
        public static string SHA1(string input)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder(hash.Length * 2);

                // Convert hash to hexadecimal string of size 8
                foreach (byte b in hash)
                    sb.Append(b.ToString("x2"));
                return sb.ToString().Substring(0, 8);
            }
        }
    }
}
