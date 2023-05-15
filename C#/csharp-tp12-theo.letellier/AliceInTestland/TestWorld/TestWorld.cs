using System;

namespace TestWorld
{
    public static class TestWorld
    {
        // FIXME !
        public static void TroubleSort(int[] array)
        {
            var done = false;
            while (!done)
            {
                done = true;
                for (var i = 0; i < array.Length - 1; ++i)
                {
                    if (array[i] <= array[i + 1]) continue;
                    done = false;
                    (array[i], array[i + 1]) = (array[i + 1], array[i]);
                }
            }
        }

        // Return the index where element is in the array.
        // If the element is not in the array, return where it should be.
        public static int BinarySearch(int[] array, int element)
        {
            int b = 0;
                int e = array.Length;
                while (b < e)
                {
                    int m = b + (e - b) / 2;
                    if (element == array[m])
                        return m;
                    if (element < array[m])
                        e = m;
                    else
                        b = m + 1;
                }
                return b;
        }

        // Print all the number from 1 to n but replace all multiple of 3 by "Fizz", all multiple of 5 by "Buzz",
        // all multiple of 15 by "Fizz Buzz"
        // Example : 1, 2, Fizz, 4, Buzz, 6, 7, 8, 9, 10, 11, 12, 13, 14, Fizz Buzz, 16\n
        
        public static string PrintFizz(int i)
        {
            string str = "";
            if (i == 0)
                str = "";
          
            
            else if (i % 3 == 0)
            {
                str = "Fizz";

                if (i % 5 == 0)
                    str += " Buzz";
            }
            else if (i % 5 == 0)
                str = "Buzz";

            else
            {
                str = i.ToString();
            }

            return str;
        }
        
        public static void FizzBuzz(uint n)
        {
            int i;
            for (i = 0; i < n; i++)
            {
                if (i == 0)
                    Console.Write(PrintFizz(i));
                else
                    Console.Write("{0}, ", PrintFizz(i));
            }

            Console.WriteLine(PrintFizz(i));
        }


        // Return the last tidy number before n
        // Tidy numbers have their digits sorted in non-decreasing order, like 12345
        public static uint TidyNumber(uint n)
        {
            string str = n.ToString();
            int longueur = str.Length;
            char[] list = new char[longueur];
            for (int i = 0; i < longueur; i++)
            {
                list[i] = str[i];
            }

            for (int i = longueur - 2; i >= 0; i--) 
            {
                if (list[i] > list[i + 1]) 
                {
                    for (int j = i + 1; j < longueur; j++) 
                        list[j] = '9'; 
                    list[i]--; 
                } 
            }
            return uint.Parse(new string(list)); 
        }
    }
}