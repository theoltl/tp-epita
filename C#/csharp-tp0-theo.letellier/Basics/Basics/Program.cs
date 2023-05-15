using System;

namespace Basics
{
    internal class Program
    {
        //Display "Bonjour, le Monde ! "
        public static void HelloWorld()
        {
            Console.WriteLine("Bonjour, le Monde!");
        }

        
        
        //Return the factorial of the number n passed as a parameter.
        public static uint Factorial(uint n)
        {
            if (n == 1)
            {
                return n * 1;
            }
            else
            {
                return n * Factorial((n - 1));
            }
        }




        //Takes a number and returns true or false depending on whether it is a prime or not.
        public static bool IsPrime(uint n, uint d = 2)
        {
            if (d == n)
            {
                    return true;
            }
            else if ((n % d) == 0)
            { 
                return false; 
            }
            else 
            { 
                return IsPrime(n,(d+1));
            }
        }


        public static int faktorial(int n)
        {
            int count = n;
            if (n == 0)
                return 1;
            while (n != 1)
            {
                count *= (n - 1);
                n--;
            }

            return count;
        }
        
        //Computes the nth term of the Fibonacci sequence
        public static uint Fibonacci(uint n)
        {
            if (n == 0)
            {
                return 0;
            }
            else if ((n == 1) || (n == 2))
            {
                return 1;
            }
            else
            {
                return Fibonacci(n - 1) + Fibonacci(n - 2);
            }
        }


        public static int fiboo(int n)
        {
            int a = 0;
            int b = 1;

            while (n > 1)
            {
                a = a + b;
                b = a + b;
                n = n - 2;
            }

            if (n % 2 == 0)
                return a;
            return b;
        }


        //Takes an integer n and returns a string enumerating each step of Fizz Buzz from 1 to n:
        public static string FizzBuzz(uint n, string str = "",uint cpt = 1)
        {
            if (cpt == (n+1))
            {
                return (str);
            }
            else if (cpt % 15 == 0)
            {
                return FizzBuzz((n), (str + ", Fizz Buzz"), (cpt + 1));
            }
            else if (cpt % 5 == 0)
            {
                return FizzBuzz((n), (str+", Buzz"),(cpt+1));
            }
            else if (cpt % 3 == 0)
            { 
                return FizzBuzz((n),(str+", Fizz"),(cpt+1));
            }
            else if (cpt == 1)
            { 
                return FizzBuzz((n),(str + cpt),(cpt+1));
            }
            else 
            { 
                return FizzBuzz((n),(str+", " + cpt),(cpt+1));
            }
        }

        
        //Main
        public static void Main(string[] str)
        {
            Console.WriteLine(fiboo(7));
        }
    }
}