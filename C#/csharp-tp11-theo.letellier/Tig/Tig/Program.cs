using System;

namespace Tig
{
    class Program
    {
        // Threshold 0
        static void Main(string[] args)
        {
            if (args == null)
            {
                Console.WriteLine("This is how tig works : tig [COMMAND] [ARGUMENTS])");
            }
            else
            {
                CLI.ExecCommand(args);
            }
        }
    }
}
