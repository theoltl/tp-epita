using System; 
using System.Collections.Generic; 
using System.IO;   
using System.Diagnostics;


namespace AliSHe
{
    public class AliSHe
    {
/*        public static void Main(string[] argv)
        {
        }
*/
        public static List<string> GetCommand()
        {
            string str = Console.ReadLine();
            List<string> liste = new List<string>();

            if (str == null)
            {
            }
            
            else
            {
                string[] temp = str.Split(' ');
                foreach (string element in temp)
                {
                    liste.Add(element);
                }
            }
            return liste;
        }

        public static List<string> GetArgs(List<string> command)
        {
	    command.RemoveAt(0);
	    List<string> liste = new List<string>();
	    
	    foreach (var element in command)
	    {
		    foreach(var val in Globbing.Expand(element))
			    liste.Add(val);
	    }
            return liste;
        }

        public static void Exec(string program, List<string> args)
        {
            if (args.Count == 0)
                Process.Start(program).WaitForExit();

            else
            {
                foreach (string str in args)
                {
                    Process.Start(program, str).WaitForExit();
                }
            }
        }

        public static void Run()
        {
            Console.Write("aliSHe ~ ");
            List<string> liste = GetCommand();
            string program = liste[0];
            List<string> args = GetArgs(liste);

            switch (program.ToLower())
                {
                    case "pwd":
                        Builtins.Pwd(args);
                        Run();
                        break;

                    case "cd":
                        Builtins.Cd(args);
                        Run();
                        break;

                    case "echo":
                        Builtins.Echo(args);
                        Run();
                        break;
                    case "ls":
                        Builtins.Ls(args);
                        Run();
                        break;

                    case "cat":
                        Builtins.Cat(args);
                        Run();
                        break;

                    case "exit":
                        break;

		    case "":
			Run();
			break;	    
		    
		    
		    default:
                        Exec(program,args);
                        Run();
                        break;
            }
        }
    }
}
