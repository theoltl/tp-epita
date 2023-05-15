using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace Basics
{
    public class Basics
    {
        /* Please write your code for the Basics section in this file */

        public static void ListThemAll(string path)
        {
            if (Directory.Exists(path) == false)
            {
                Console.Write("Error: {0} is not a directory !", path);
                return;
            }

            Console.WriteLine("Content of {0} : ", path);
            
            foreach (var x in Directory.EnumerateFiles(path))
            {
                Console.WriteLine(x.Replace(path, ""));
            }
        }

        

        public static void ListMyDirectory(string path)
        {
            if (Directory.Exists(path) == false)
                Console.Write("Error: {0} is not a directory !", path);
            
            Console.WriteLine("List of the directory in {0} :", path);
            
            foreach (var x in Directory.EnumerateDirectories(path))
            {
                Console.WriteLine(x.Replace(path, ""));
            }
        }
        
        public static int Levenshtein(string str1, string str2)
        {
            int max, min;
            if (str1.Length == 0 || str2.Length == 0)
                return str1.Length + str2.Length;
            
            if (str1.Length < str2.Length)
            {
                min = str1.Length; 
                max = str2.Length;
            }
            else
            {
                min = str2.Length;
                max = str1.Length;
            }
            
            int count = max - min;
            
            for (int i = 0; i < min; i++)
            {
                if (str1[i] == str2[i])
                    i += 0;
                else
                    count += 1;
            }
            return count;
        }

        public static void ListMyLevenshtein(string path, string reference, int distance)
        {
            Console.WriteLine("Directory in {0} that have a distance <= {1} from {2} : ", path, distance, reference );
        
            foreach (var x in Directory.EnumerateDirectories(path))
            {
                if (Levenshtein(x.Replace(path, ""), reference) <= distance)
                    Console.WriteLine(x.Replace(path, ""));
            }
        }

        public static void CopyThisFilePlease(string path, string dest)
        {
            if (File.Exists(path) == false)
            {
                Console.Write("Error: {0} is not a file !", path);
                return;
            }
            if (File.Exists(dest))
            {
                Console.Write("Error: {0} already exist ! abort mission :(", dest);
                return;
            }
            
            File.Copy(path,dest);
            Console.Write("{0} has been copied to {1} with love <3", path, dest);
        }
    }
}
