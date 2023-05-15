using System;
using System.Collections.Generic;
using static Basics.Functions;

namespace Basics
{
    public static class Tests
    {
        public static void TestKingOfTheHill(ref uint passed, ref uint failed)
        {
            // FIXME: print the title of the test suite
            Console.WriteLine("=== KingOfTheHill ===");

            // Test name: arrIncreasing
            // GIVEN
            int[] arrIncreasing = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            if (KingOfTheHill(arrIncreasing) == 9)
            {
                passed += 1;
                Console.ForegroundColor  = ConsoleColor.DarkGreen;
                Console.WriteLine("[OK] arrIncreasing");
            }
            else
            {
                failed += 1;
                Console.ForegroundColor  = ConsoleColor.Red;
                Console.Write("[ERROR] arrIncreasing");
            }

            // FIXME
            // THEN
            // FIXME
            
            // Test name: arrDecreasing
            // GIVEN
            int[] arrDecreasing = { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            if (KingOfTheHill(arrDecreasing) == 0)
            {
                passed += 1;
                Console.ForegroundColor  = ConsoleColor.DarkGreen;
                Console.WriteLine("[OK] arrDecreasing");
            }
            else
            {
                failed += 1;
                Console.ForegroundColor  = ConsoleColor.Red;
                Console.WriteLine("[ERROR] arrDecreasing");
            }

            // Test name: arrHill
            // GIVEN
            int[] arrHill = { 0, 1, 2, 3, 4, 5, 4, 3, 2, 1, 0 };
            if (KingOfTheHill(arrHill) == 5)
            {
                passed += 1;
                Console.ForegroundColor  = ConsoleColor.DarkGreen;
                Console.WriteLine("[OK] arrHill");
            }
            else
            {
                failed += 1;
                Console.ForegroundColor  = ConsoleColor.DarkRed;
                Console.WriteLine("[ERROR] arrHill");
            }

            // Test name: arrInvalid
            // GIVEN
            int[] arrInvalid = { 0, 1, 2, 1, 0, 1, 2, 3, 2, 1, 0 };
            if (KingOfTheHill(arrInvalid) == -1)
            {
                passed += 1;
                Console.ForegroundColor  = ConsoleColor.DarkGreen;
                Console.WriteLine("[OK] arrInvalid");
            }
            else
            {
                failed += 1;
                Console.ForegroundColor  = ConsoleColor.DarkRed;
                Console.WriteLine("[ERROR] arrInvalid");
            }

            // Test name: arrFlat
            // GIVEN
            int[] arrFlat = { 42, 42, 42, 42, 42 };
            if (KingOfTheHill(arrFlat) == 0)
            {
                passed += 1;
                Console.ForegroundColor  = ConsoleColor.DarkGreen;
                Console.WriteLine("[OK] arrFlat");
            }
            else
            {
                failed += 1;
                Console.ForegroundColor  = ConsoleColor.DarkRed;
                Console.WriteLine("[ERROR] arrFlat");
            }

            // Test name: arrAlmostThere1
            // GIVEN
            int[] arrAlmostThere1 = { 0, 1, 2, 3, 4, 5, 4, 3, 2, 1, 0, 1 };
            if (KingOfTheHill(arrAlmostThere1) == -1)
            {
                passed += 1;
                Console.ForegroundColor  = ConsoleColor.DarkGreen;
                Console.WriteLine("[OK] arrAlmostThere1");
            }
            else
            {
                failed += 1;
                Console.ForegroundColor  = ConsoleColor.DarkRed;
                Console.WriteLine("[ERROR] arrAlmostThere1");
            }

            // Test name: arrAlmostThere2
            // GIVEN
            int[] arrAlmostThere2 = { 1, 0, 1, 2, 3, 4, 5, 4, 3, 2, 1, 0 };
            if (KingOfTheHill(arrAlmostThere2) == -1)
            {
                passed += 1;
                Console.ForegroundColor  = ConsoleColor.DarkGreen;
                Console.WriteLine("[OK] arrAlmostThere2");
            }
            else
            {
                failed += 1;
                Console.ForegroundColor  = ConsoleColor.DarkRed;
                Console.WriteLine("[ERROR] arrAlmostThere2");
            }
            
            // Test name: arrSeveralSameElements
            // GIVEN
            int[] arrSeveralSameElements = { 1, 2, 3, 3, 4, 5, 5, 2 };
            if (KingOfTheHill(arrSeveralSameElements) == -1)
            {
                passed += 1;
                Console.ForegroundColor  = ConsoleColor.DarkGreen;
                Console.WriteLine("[OK] arrSeveralSameElements");
            }
            else
            {
                failed += 1;
                Console.ForegroundColor  = ConsoleColor.DarkRed;
                Console.WriteLine("[ERROR] arrSeveralSameElements");
            }
            
            Console.WriteLine();
            Console.ForegroundColor  = ConsoleColor.White;
        }
        
        // Return true if the array is sorted in non-decreasing order, else false
        private static bool IsSorted(IReadOnlyList<int> array)
        {
            for (var i = 0; i < array.Count - 1; ++i)
                if (array[i] > array[i + 1])
                    return false;
            return true;
        }

        // Print an formatted array inline
        private static string ArrayToString(IReadOnlyList<int> array)
        {
            var str = "{ ";
            for (var i = 0; i < array.Count; i++)
            {
                str += array[i];
                if (i != array.Count - 1)
                    str += ", ";
            }
            str += " }";
            return str;
        }

        public static void TestTroubleSort(ref uint passed, ref uint failed)
        {
            // FIXME: print the title of the test suite
            Console.WriteLine("=== TroubleSort ===");
            // Test name: arrIncreasing
            // GIVEN
            int[] arrIncreasing = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            TroubleSort(arrIncreasing);
            if (IsSorted(arrIncreasing))
            {
                passed += 1;
                Console.ForegroundColor  = ConsoleColor.DarkGreen;
                Console.WriteLine("[OK] arrIncreasing");
            }
            else
            {
                failed += 1;
                Console.ForegroundColor  = ConsoleColor.DarkRed;
                Console.WriteLine("[ERROR] arrIncreasing");
                string sorted = "{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }";
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Got : {0}, Expected : {1}", ArrayToString(arrIncreasing), sorted);
            }

            // Test name: arrDecreasing
            // GIVEN
            int[] arrDecreasing = { 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            TroubleSort(arrDecreasing);
            if (IsSorted(arrDecreasing))
            {
                passed += 1;
                Console.ForegroundColor  = ConsoleColor.DarkGreen;
                Console.WriteLine("[OK] arrDecreasing");
            }
            else
            {
                failed += 1;
                Console.ForegroundColor  = ConsoleColor.DarkRed;
                Console.WriteLine("[ERROR] arrDecreasing");
                string sorted = "{ 0, 1, 2, 3, 4, 5, 6, 7, 8 }";
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Got : {0}, Expected : {1}", ArrayToString(arrDecreasing), sorted);
            }

            // Test name: arrHill
            // GIVEN
            int[] arrHill = { 1, 2, 3, 4, 4, 3, 2, 1, 0 };
            TroubleSort(arrHill);
            if (IsSorted(arrHill))
            {
                passed += 1;
                Console.ForegroundColor  = ConsoleColor.DarkGreen;
                Console.WriteLine("[OK] arrHill");
            }
            else
            {
                failed += 1;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("[ERROR] arrHill");
                string sorted = "{ 0, 1, 1, 2, 2, 3, 3, 4, 4 }";
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Got : {0}, Expected : {1}", ArrayToString(arrHill), sorted);
            }

            // Test name: arrRandom
            // GIVEN
            int[] arrRandom = { 0, 1, 1, 2, 2, 0, 3 };
            TroubleSort(arrRandom);
            if (IsSorted(arrRandom))
            {
                passed += 1;
                Console.ForegroundColor  = ConsoleColor.DarkGreen;
                Console.WriteLine("[OK] arrRandom");
            }
            else
            {
                failed += 1;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("[ERROR] arrRandom");
                string sorted = "{ 0, 0, 1, 1, 2, 2, 3 }";
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Got : {0}, Expected : {1}", ArrayToString(arrRandom), sorted);
            }

            // Test name: arrFlat
            // GIVEN
            int[] arrFlat = { 42, 42, 42, 42, 42 };
            TroubleSort(arrFlat);
            if (IsSorted(arrFlat))
            {
                passed += 1;
                Console.ForegroundColor  = ConsoleColor.DarkGreen;
                Console.WriteLine("[OK] arrFlat");
            }
            else
            {
                failed += 1;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("[ERROR] arrFlat");
                string sorted = "{ 42, 42, 42, 42, 42 }";
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Got : {0}, Expected : {1}", ArrayToString(arrFlat), sorted);
            }

            // Test name: arrAlmostThere1
            // GIVEN
            int[] arrAlmostThere1 = { 0, 1, 2, 3, 4, 5, 4, 3, 2, 1, 0, 1 };
            TroubleSort(arrAlmostThere1);
            if (IsSorted(arrAlmostThere1))
            {
                passed += 1;
                Console.ForegroundColor  = ConsoleColor.DarkGreen;
                Console.WriteLine("[OK] arrAlmostThere1");
            }
            else
            {
                failed += 1;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("[ERROR] arrAlmostThere1");
                string sorted = "{ 0, 0, 1, 1, 1, 2, 2, 3, 3, 4, 4, 5 }";
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Got : {0}, Expected : {1}", ArrayToString(arrAlmostThere1), sorted);
            }

            // Test name: arrAlmostThere2
            // GIVEN
            int[] arrAlmostThere2 = { 1, 0, 1, 2, 3, 4, 5, 4, 3, 2, 1, 0 };
            TroubleSort(arrAlmostThere2);
            if (IsSorted(arrAlmostThere2))
            {
                passed += 1;
                Console.ForegroundColor  = ConsoleColor.DarkGreen;
                Console.WriteLine("[OK] arrAlmostThere2");
            }
            else
            {
                failed += 1;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("[ERROR] arrAlmostThere2");
                string sorted = "{ 0, 0, 1, 1, 1, 2, 2, 3, 3, 4, 4, 5 }";
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Got : {0}, Expected : {1}", ArrayToString(arrAlmostThere2), sorted);
            }
            Console.WriteLine();
            Console.ForegroundColor  = ConsoleColor.White;
        }
        
        public static void TestManhattanDistance(ref uint passed, ref uint failed)
        {
            // FIXME: print the name of the test suite
            Console.WriteLine("=== ManhattanDistance ===");
            
            Tuple<int, int> p1;
            Tuple<int, int> p2;

            // Test name: zero
            // GIVEN
            p1 = new Tuple<int, int>(0, 0);
            p2 = new Tuple<int, int>(0, 0);
            if (ManhattanDistance(p1, p2) == 0)
            {
                passed += 1;
                Console.ForegroundColor  = ConsoleColor.DarkGreen;
                Console.WriteLine("[OK] zero");
            }
            else
            {
                failed += 1;
                Console.ForegroundColor  = ConsoleColor.DarkRed;
                Console.WriteLine("[ERROR] zero");
            }

            // Test name: simple
            // GIVEN
            p1 = new Tuple<int, int>(1, 2);
            p2 = new Tuple<int, int>(2, 3);
            if (ManhattanDistance(p1, p2) == 2)
            {
                passed += 1;
                Console.ForegroundColor  = ConsoleColor.DarkGreen;
                Console.WriteLine("[OK] simple");
            }
            else
            {
                failed += 1;
                Console.ForegroundColor  = ConsoleColor.DarkRed;
                Console.WriteLine("[ERROR] simple");
            }

            // Test name: medium
            // GIVEN
            p1 = new Tuple<int, int>(1, 2);
            p2 = new Tuple<int, int>(5, 10);
            if (ManhattanDistance(p1, p2) == 12)
            {
                passed += 1;
                Console.ForegroundColor  = ConsoleColor.DarkGreen;
                Console.WriteLine("[OK] medium");
            }
            else
            {
                failed += 1;
                Console.ForegroundColor  = ConsoleColor.DarkRed;
                Console.WriteLine("[ERROR] medium");
            }
            
            // Test name: negative
            // GIVEN
            p1 = new Tuple<int, int>(-1, -2);
            p2 = new Tuple<int, int>(-5, -10);
            if (ManhattanDistance(p1, p2) == 12)
            {
                passed += 1;
                Console.ForegroundColor  = ConsoleColor.DarkGreen;
                Console.WriteLine("[OK] negative");
            }
            else
            {
                failed += 1;
                Console.ForegroundColor  = ConsoleColor.DarkRed;
                Console.WriteLine("[ERROR] negative");
            }
            
            // Test name: positiveAndNegative
            // GIVEN
            p1 = new Tuple<int, int>(-1, -2);
            p2 = new Tuple<int, int>(5, 10);
            if (ManhattanDistance(p1, p2) == 18)
            {
                passed += 1;
                Console.ForegroundColor  = ConsoleColor.DarkGreen;
                Console.WriteLine("[OK] positiveAndNegative");
            }
            else
            {
                failed += 1;
                Console.ForegroundColor  = ConsoleColor.DarkRed;
                Console.WriteLine("[ERROR] positiveAndNegative");
            }

            Console.WriteLine();
            Console.ForegroundColor  = ConsoleColor.White;
        }
    }
}