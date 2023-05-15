using System;

namespace Basics
{
    public static class Arrays
    {
        public static int Search(int[] arr, int e)
        {
            for (int i = 0 ; i < (arr.Length) ; i++)
            {
                if (arr[i] == e)
                    return i;
            }
            return -1;
        }

        
        public static int KingOfTheHill(int[] arr)
        {
            int i = 0;
            while (arr[i] <= arr[i+1])
                i++;
            int max = arr[i];
            for (i = i+1; i < arr.Length-1; i++)
            {
                if (max > arr[i] && max <= arr[i + 1])
                    return -1;
            }
            return max;
        }    

        
        public static int[] CloneArray(int[] arr)
        {
            int longueur = arr.Length;
            int[] copy = new int[longueur];
            for (int x = 0; x <  longueur; x++)
            {
                copy[x] = arr[x];
            }
            
            return copy;
        }

        
        public static void BubbleSort(int[] arr)
        {
            int i = 0;
            while (i < arr.Length - 1)
            {
                if (arr[i] <= arr[i+1])
                {
                    i++;
                }
                else
                {
                    int temp = arr[i];
                    arr[i] = arr[i + 1];
                    arr[i + 1] = temp;
                    i = 0;
                }
            }
        }

        
        public static void AnotherSort(int[] arr)
        {
            throw new NotImplementedException();
        }

        
        public static void RotN(char[] arr, int n)
        {
            for(int i = 0; i < arr.Length-1; i++)
            {
                Reference.RotChar(ref arr[i], n);
                Console.Write(" ");
            }
            
        }
    }
}
