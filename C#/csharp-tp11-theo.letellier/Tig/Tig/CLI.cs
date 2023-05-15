using System;

namespace Tig
{
    public class CLI
    {
        // Threshold 0
        public static void ExecCommand(string[] input)
        {
            string command = input[0];
            string[] args = new string[input.Length - 1];
            for (int i = 1; i <= input.Length; i++)
            {
                args[i - 1] = input[i];
            }
            
            switch (command.ToLower())
            {
                case "init":
                    Command.Init();
                    break;
                case "add":
                    Command.Add(args);
                    break;
                    
                case "commit":
                    Command.Commit(input[1]);
                    break;
                
                case "log":
                    Command.Log();
                    break;
                
                case "status":
                    Command.Status();
                    break;
                
                default:
                    Console.WriteLine("Unknown command {0}", command);
                    break;
            }
        }
    }
}
