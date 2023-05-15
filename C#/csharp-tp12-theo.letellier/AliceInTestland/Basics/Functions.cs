using System;

namespace Basics
{
    public static class Functions
    {
        // Return the index of the king of the hill
        // If there are several kings (like { 1, 2, 2, 2, 1 }), return the index of the first one
        // The case { 1, 2, 3, 2, 1, 2, 3, 2, 1 } should return -1 because there are several hills
        // If there isn't one, returns -1
        public static int KingOfTheHill(int[] arr)
        {
            var len = arr.Length;
            var i = 0;
            for (; i < len - 1 && arr[i] < arr[i + 1]; ++i) ;
            var king = i;
            for (; i < len - 1 && arr[i] >= arr[i + 1]; ++i) ;

            return i == len - 1 ? king : -1;
        }

        // Sort an array using the trouble sort method
        public static void TroubleSort(int[] array)
        {
            var done = false;
            while (!done)
            {
                done = true;
                for (var i = 0; i < array.Length - 2; ++i)
                {
                    if (array[i] <= array[i + 2]) continue;
                    done = false;
                    (array[i], array[i + 2]) = (array[i + 2], array[i]);
                }
            }
        }

        // Return the Manhattan distance between two points
        // See https://en.wikipedia.org/w/index.php?title=Manhattan_distance
        public static int ManhattanDistance(Tuple<int, int> lhs, Tuple<int, int> rhs)
        {
            return Math.Abs(lhs.Item1 - rhs.Item1) + Math.Abs(lhs.Item2 - rhs.Item2);
        }
    }
}