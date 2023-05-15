using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mime;

namespace YouAndCthulhu
{
    public class Program
    {
        public static void CthulhuSlaver(string path)
        // Read a file, fills a function table and execute it, thus running a Cthulhu program.
        {
            FunctionTable ftable = new FunctionTable();
            var texte = File.ReadAllLines(path);
            foreach (var ligne in texte)
            {
                if (ligne != "" && ligne != "\n")
                {
                    ftable.Add(LexerParser.LineToFunction(ligne, ftable));
                }
            }
            
            ftable.Execute();
        }

        static void Main()
        {
            CthulhuSlaver(@"test.txt");
        }
    }
}
