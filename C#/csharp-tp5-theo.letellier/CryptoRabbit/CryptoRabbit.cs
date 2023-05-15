using System.IO;
using System.Text;

namespace CryptoRabbit
{
    public class CryptoRabbit
    {
        /* Write your code for the CryptoRabbit section in this file */
        
        
        public static char BitwiseRot(char c, int n)
        {
            if (c+n > 127)
            {
                int d = c + n;
                for (; d > 127;  d -= 127)
                    continue;
                c = (char) (d);
                return c;
            }
            if (c+n < 0)
            {
                int d = c + n;
                for (; d < 0;  d += 127)
                    continue;
                c = (char) (d);
                return c;
            }
            {
                c = (char) (c + n);
                return c;
            }
        }

        public static string ReadFileContent(string filename)
        {
            string txt;
            txt = File.ReadAllText(filename);
            return txt;
        }
        

        public static void WriteFileContent(string filename, string content)
        {
            File.WriteAllText(filename, content);
        }

        /* If you want to add some mode you can start by adding them to this enum */
        /* Don't forget to introduce them #README */
        public enum ExecutionMode
        {
            EncryptBitwise,
            DecryptBitwise
        }

        public static void CryptoRabbitRun(string inputFile, string outputFile, ExecutionMode mode, int n)
        {
            string inputString = ReadFileContent(inputFile);
            StringBuilder sb = new StringBuilder();

            foreach (char c in inputString)
            {
                switch (mode)
                {
                    case ExecutionMode.EncryptBitwise:
                        sb.Append(BitwiseRot(c, n)); /* This is how we applied the function for every character */
                        break;
                    case ExecutionMode.DecryptBitwise:
                        sb.Append(BitwiseRot(c, -n));
                        break;
                    /* Add here the link for the function applied according to the mode */
                    default:
                        sb.Append(BitwiseRot(c, n));
                        break;
                }
            }

            WriteFileContent(outputFile, sb.ToString());
        }
    }
}