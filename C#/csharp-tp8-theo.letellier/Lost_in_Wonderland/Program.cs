using System;

namespace Lost_in_Wonderland
{
    class Program
    {
        static void Main(string[] args)
        {
            Maze Test = new Maze(5);
            Test.CarvePath(1, 2, Maze.Direction.NORTH);
            Console.Write(Test.MazeToString());
        }
    }
}