using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Tree
{
    public class Tree
    {
        /* Please write your code for the Tree section in this file */
        public static int ListMyFiles(string path,int file_count)
        {
            foreach (var x in Directory.EnumerateFiles(path))
            {
                {
                    string filess = x.Replace(path, "");
                    StringBuilder fil = new StringBuilder(filess);
                    fil.Remove(0, 1);
                    Console.WriteLine("|-- {0}", fil);
                    file_count += 1;
                }
            }
            return file_count;
        }
        
        
        public static int ListMyfilesInFolder(string path,int file_count, string str)
        {
            foreach (var x in Directory.EnumerateFiles(path))
            {
               string last = Directory.EnumerateFiles(path).Last();

                if (x == last)
                {
                    string filess = x.Replace(path, "");
                    StringBuilder filee = new StringBuilder(filess);
                    filee.Remove(0, 1);
                    Console.WriteLine(str + "+-- {0}", filee);
                    file_count += 1;
                }
                else
                {
                    string filess = x.Replace(path, "");
                    StringBuilder fil = new StringBuilder(filess);
                    fil.Remove(0, 1);
                    Console.WriteLine(str + "|-- {0}", fil);
                    file_count += 1;
                }
            }
            return file_count;
        }
        
        /*
         * Don't forget to respect exactly the output that we provide !
         * We deduce point if the output doesn't respect every space, comma, letter, ... exactly !
         */
        public static void DrawMyTree(string path)
        {
            string filestr = " files"; 
            string dirstr = "";
            int file_count = 0;
            int dir_count = 0;
            string str = "|   ";
            
            
            file_count += ListMyFiles(path, 0);
            
            
            foreach (var x in Directory.EnumerateDirectories(path))
            {
                var last = Directory.EnumerateDirectories(path).Last();
                string dirname = x;
                string directory = x.Replace(path, "");
                StringBuilder dir = new StringBuilder(directory);
                dir.Remove(0, 1);
                dir_count += 1;
                if (x == last)
                {
                    Console.WriteLine("+-- {0}", dir);
                    str = "|   ";
                    file_count += ListMyfilesInFolder(x, 0, str);
                }
                else
                {
                    Console.WriteLine("|-- {0}", dir);
                    str = "|   ";
                    file_count += ListMyfilesInFolder(x, 0, str);
                }
                    

                foreach (var z in Directory.EnumerateDirectories(dirname))
                {
                    string dir1= z.Replace(dirname + @"\", "");
                    Console.WriteLine("|   |--" + dir1);
                    foreach (var y in Directory.EnumerateDirectories(z))
                    {
                        string dir2= y.Replace(z +  @"\", "");
                        Console.WriteLine("|   |   |--" + dir2);
                        dir_count++;
                        str = "|   |   |   ";
                        file_count += ListMyfilesInFolder(y, 0, str);
                    }

                    str = "|   |   ";
                    dir_count++;
                    file_count += ListMyfilesInFolder(z, 0, str);
                    
                }
            }
            
            
            #region conditions
            if (dir_count == 0 && file_count == 0)
                return;
            if (file_count == 0)
                filestr = "";
            if (dir_count == 0)
                dirstr = "";
            if (file_count == 1)
                filestr = "1 file";
            if (dir_count == 1 && file_count > 0)
                dirstr = "1 directory, ";
            if (dir_count > 1 && file_count > 1)
            {
                filestr = file_count + " files";
                dirstr = dir_count + " directories, ";
            }
            #endregion
            
            Console.Write(dirstr + filestr);
        }

        
    }
}