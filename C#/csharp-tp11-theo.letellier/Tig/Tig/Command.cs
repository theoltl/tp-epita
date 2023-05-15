using System.Collections.Generic;
using System.IO;
using System;

namespace Tig
{
    public class Command
    {
        // Do not modify!
        private const string Username = "Joseph Marchand";
        private const string Usermail = "joseph.marchand@epita.fr";

        // Threshold 2
        public static void Init()
        {
            string path = Directory.GetCurrentDirectory() + @"\.tig";;
            Directory.CreateDirectory(path);
            path += @"\";
            Directory.CreateDirectory(path + "objects");
            File.Create(path + "index");

            Console.WriteLine("Initialized empty Tig repository.");
        }

        // Threshold 3-1
        public static string HashObject(string data, string type, bool write = false)
        {
            // Hints:
            //   1. Create the object as a string containing the type, data length and data
            //   2. Compute object's hash using SHA1
            //   3. If write is true, then store the object in .tig/objects
            //   4. Return the hash
            string obj = type + " " + data.Length + "\n" + data;
            string hash = Hash.SHA1(obj);
            
            if (write)
                File.WriteAllText(Directory.GetCurrentDirectory() + @"\.tig\objects\hash", hash);

            return hash;
        }

        // Threshold 3-2
        public static void Add(string[] paths)
        {
            // Hints:
            //   1. Read the index
            //   2. For each path
            //       2.1 Check if path exists
            //       2.2 Create a new Tig object (and store it)
            //       2.3 Add object as entry in the index
            //   3. Do not forget to write the updated index!
            var index = new Index();
            foreach (string path in paths)
            {
                if (File.Exists(path))
                {
                    File.Copy(@".\" + path, @".\.tig\objects\" + path, true);
                    index.AddEntry(@".\.tig\objects\" + path, HashObject(File.ReadAllText(path) , "blob", true), path.Length);
                }
            }
            index.WriteIndex();
        }

        // Threshold 4-1
        public static string WriteTree()
        {
            string path = @".tig\objects\tree";
            File.Delete(path);
            var fichier = File.Create(path);
            TextWriter txt = new StreamWriter(path, true);
            
            var index = new Index();
            for (int i = 0; i < index.Entries.Count; i++)
            {
                txt.WriteLine("{0} {1} {2}", "blob", index.Entries[0], index.Entries[1]);
            }
            fichier.Close();
            return HashObject(File.ReadAllText(path), "tree", true);
        }

        // Threshold 4-2
        public static void Commit(string message)
        {
            string path = @".tig\objects\commit";
            File.Delete(path);
            var fichier = File.Create(path);
            TextWriter txt = new StreamWriter(path, true);
            
            txt.WriteLine("{0} {1}", "tree", WriteTree());
            txt.WriteLine("{0} {1} {2}", "author", Username, Usermail);
            txt.WriteLine(message);
            fichier.Close();
            
            Console.WriteLine("[{0}] {1}", HashObject(File.ReadAllText(path), "commit", true), message);
        }

        // Threshold 5
        public static void Log()
        {
            string path = @".tig\objects\commit";
            string path_h = @".tig\HEAD";
            string commit_content = File.ReadAllText(path);
            File.Delete(path);
            var fichier = File.Create(path);
            TextWriter txt = new StreamWriter(path, true);
            if (File.Exists(@".tig\HEAD"))
            {
                txt.WriteLine("{0} {1}", "parent", HashObject(File.ReadAllText(path_h), "commit", true));
                txt.WriteLine(commit_content);
                fichier.Close();
                File.Delete(path_h);
                var HEAD = File.Create(path);
                TextWriter texte = new StreamWriter(path_h, true);
                texte.WriteLine("{0}", HashObject(File.ReadAllText(path), "commit", true));
                HEAD.Close();
            }
            else
            {
                txt.WriteLine("{0}", "parent");
                txt.WriteLine(commit_content);
                fichier.Close();
                var HEAD = File.Create(path);
                TextWriter texte = new StreamWriter(path_h, true);
                texte.WriteLine("{0}", HashObject(File.ReadAllText(path), "commit", true));
                HEAD.Close();
            }
        }

        // Threshold 6
        public static void Status()
        {
            throw new NotImplementedException();
        }
    }
}
