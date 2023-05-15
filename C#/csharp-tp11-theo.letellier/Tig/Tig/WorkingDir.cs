using System.Collections.Generic;
using System.IO;

namespace Tig
{
    // Do not modify!
    public class WorkingDir
    {
        // GetAllFiles is used in the "tig status" command (threshold 6)
        public static List<string> GetAllFiles()
        {
            List<string> res = new List<string>();
            string[] all = Directory.GetFiles(".", "*.*", SearchOption.AllDirectories);

            foreach (string path in all)
            {
                if (path.StartsWith("./.tig"))
                    continue;
                // Remove "./" prefix
                res.Add(path.Substring(2));
            }

            return res;
        }
    }
}
