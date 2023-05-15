using System;
using System.Collections.Generic;
using System.IO;

namespace AliSHe
{
    public class Builtins
    {

        public static void Pwd(List<string> args)
        {
            if (args.Count == 0)
                Console.WriteLine(Directory.GetCurrentDirectory());

            else
                throw new ArgumentException(
                    "pwd: too many arguments");
        }

        public static void Cd(List<string> args)
        {
            if (args.Count == 0)
            {
                var dir = Directory.GetDirectoryRoot(
                    Directory.GetCurrentDirectory());

                Directory.SetCurrentDirectory(dir);
            }

            else
            {
                if (args.Count > 1)
                    throw new ArgumentException(
                        "cd: too many arguments");

                else if (Directory.Exists(args[0]))
                    Directory.SetCurrentDirectory(args[0]);

                else if (!Directory.Exists(args[0]) || !File.Exists(args[0]))
                    throw new ArgumentException(
                        "cd: {0} : No such file or directory", args[0]);

                else if (!Directory.Exists(args[0]))
                    throw new ArgumentException(
                        "cd: {0} : Not a directory", args[0]);
            }
        }


        public static void Echo(List<string> args)
        {
            if (args.Count == 0)
                Console.WriteLine();

            else
            {
                for (int i = 0; i < args.Count; i++)
                    Console.Write("{0} ", args[i]);
                Console.WriteLine();
            }
        }
        
        public static void Ls(List<string> args)
        {
            if (args.Count == 0)
            {
                DirectoryInfo directory = new DirectoryInfo(
                    Directory.GetCurrentDirectory());

                Pwd(args);
                foreach (DirectoryInfo element in directory.GetDirectories())
                {
                    Console.Write("{0} ", element.Name);
                }

                foreach (FileInfo element in directory.GetFiles())
                {
                    Console.Write("{0} ", element.Name);
                }

                Console.WriteLine();
            }
            else
            {
                foreach (var element in args)
                {
                    if (Directory.Exists(element))
                    {
                        Console.WriteLine("{0} :", element);

                        foreach (var fichier in Directory.EnumerateFiles(element))
                        {
                            Console.Write(fichier + " ");
                        }
                        Console.WriteLine();
                    }

                    if (File.Exists(element))
                        Console.Write(element + " ");

                    else
                    {
                        throw new ArgumentException(
                            "ls: cannot access {0} : No such file or directory", element);
                    }
                }
		Console.WriteLine();
            }
        }


        public static void Cat(List<string> args)
        {
            if (args.Count == 0)
                throw new ArgumentException("cat: no arguments given");

            foreach (var element in args)
            {
                var path = Directory.GetCurrentDirectory(); 

                if (Directory.Exists(element))
                    throw new ArgumentException("cat : " + element.Replace(path,"") + " : Is a directory");


                if (File.Exists(element) == false)
                    throw new ArgumentException("cat: " + element.Replace(path,"") + " No such file or directory");


                Console.WriteLine(File.ReadAllText(element));
            }
        }
    }
}
