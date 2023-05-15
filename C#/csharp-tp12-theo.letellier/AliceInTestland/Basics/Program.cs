using System;
using static Basics.Tests;

namespace Basics
{
    public static class Program
    {
        public static void Main()
        {
            uint passed = 0;
            uint failed = 0;

            TestKingOfTheHill(ref passed, ref failed);
            
            TestTroubleSort(ref passed, ref failed);
            
            TestManhattanDistance(ref passed, ref failed);

            Console.WriteLine("=== RESULTS ===");
            Console.WriteLine($"Passed: {passed}, Failed: {failed}");
        }
    }
}
