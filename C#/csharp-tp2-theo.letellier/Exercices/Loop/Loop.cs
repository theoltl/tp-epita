using System;

namespace Exercice
{
    public class Exercice
    {
        public static void PrintNaturals(int n)
        {
            int count = 1;
            while (count < n+1)
            {
                if (count == n)
                {
                    Console.Write(n + "\n");
                    return;
                }
                
                {
                    Console.Write(count + " ");
                    count++;
                }
            }
        }

        
        public static void PrintPrimes(int n)
        {
            for (int num = 1; num <= n; num++)
            {
                int count = 0;

                for (int div = 2; div <= num / 2; div++)
                {
                    if (num % div == 0)
                    {
                        count++;
                        break;
                    }
                }

                if (count == 0 && num != 0) 
                {
                    Console.Write(num + " ");
                }
            }
        }

        public static void PrintPrimz(int n)
        {
            for (int num = 1; num <= n; num++)
            {
                bool count = true;
                for (int div = 2; div <= num / 2; div++)
                {
                    if (num % div == 0)
                    {
                        count = false;
                    }
                }
                if (count && num != 1)
                    Console.Write(num + " ");
            }
        }


        public static long Fibonacci(int n)
        {
            long a = 0;
            long b = 1;

            while (n > 1)
            {
                a = a + b;
                b = a + b;
                n = n - 2;
            }

            if (n % 2 == 0)
            {
                Console.Write(a);
                return a;
            }
            else
            {
                Console.Write(b);
                return b;
            }
        }

            
        
        public static int fibooo(int n)
        {
            (int a, int b) = (0,1);

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
        #region PrintStrong
        
        public static long Factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            if (n == 1)
            {
                return n;
            }
            else
            {
                return n * Factorial((n - 1));
            }
        }
        
        
        public static bool IsStrong(int n)
        {
            int count = n;
            long acc = 0;

            while (count > 0)
            {
                acc += Factorial((count % 10));
                count = count / 10;
                
            }

            if (acc == n)
            {
                return true;
            }
            return false;
        }
        
        
        public static void PrintStrong(int n)
        {
            Console.Write(1);
            for (int i = 2; i <= n; i++)
            {
                if (IsStrong(i))
                { 
                    Console.Write(" " + i);
                }
            }
        }
        
        #endregion
        
        
        public static float Abs(float n)
        {
            if (n < 0)
                return -n;
            return n;
        }

        
        public static float Sqrt(float n)
        {
            float half = .5f;
            float x = half * n;
            float x1 = half * (x + (n / x));
            
            while(Abs(x - x1) >= 0.001)
            {
                x = x1;
                x1 = half * (x + n / x);
            }

            x1 = Convert.ToSingle(Math.Round(x1, 3));
            return x1;
        }

        public static long Power(long a, long b)
        {
            long c = a;
            if (b == 0)
                return 1;
            else
            {
                for (;  b > 1 ; b--)
                    a *= c ;
                return a;
            }
        }

        
        #region PrintTree
        public static void Tree(int n)
        {
            for (int count = 1; count <= n; count++)
            {
                for (int space = count; space <= n; space++)
                {
                    Console.Write(" ");
                }
                for (int leaf = 1; leaf < count * 2; leaf++)
                {
                    if(leaf % 2 != 0)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write("*");
                    }
                }
                Console.WriteLine("");
            }
        }
        
        public static void Base(int n)
        {
            int count = 1;
            if (n > 3)
            {
                while (count >= 0)
                {
                    for (int space = 1; space <= n; space++)
                    {
                        Console.Write(" ");
                    }
                    Console.WriteLine("*");
                    count--;
                }
            }
            else
            {
                for (int j = 1; j <= n; j++)
                {
                    Console.Write(" ");
                }

                Console.Write("*"); 
            }
        }
        
        public static void PrintTree(int n)
        {
            Tree(n);
            Base(n);
        }
        
        #endregion


        public static bool Izprim(int n)
        {
            if (n < 2)
                return false;
            for (int d = 2; d != n; d++)
            {
                if (n % d == 0)
                    return false;
                
            }

            return true;
        }
        
        public static int Syracuse(int n)
        {
            int count;
            for (count = 1; n > 1; count++ )
            {
                if (n % 2 == 0)
                {
                    n /= 2;
                }
                else
                {
                    n = 3 * n + 1;
                }
            }
            return count;
        }

        //Bonus de Noël :
        
        #region ChristmasTree
        
        public static void C_Tree(int n)
        {
            Random color = new Random();
            for (int count = 1; count <= n; count++)
            {
                for (int space = count; space <= n; space++)
                {
                    Console.Write(" ");
                }
                for (int leaf = 1; leaf < count * 2; leaf++)
                {
                    if(leaf % 2 != 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("*");
                    }
                    else
                    {
                        Console.ForegroundColor = (ConsoleColor)color.Next(0,16);
                        Console.Write("*");
                    }
                }
                Console.WriteLine("");
            }
        }
        
        
        public static void C_Base(int n)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            int count = 1;
            if (n > 3)
            {
                while (count >= 0)
                {
                    for (int space = 1; space <= n; space++)
                    {
                        Console.Write(" ");
                    }
                    Console.WriteLine("*");
                    count--;
                }
            }
            else
            {
                for (int j = 1; j <= n; j++)
                {
                    Console.Write(" ");
                }

                Console.Write("*"); 
            }
        }
        
        
        public static void ChristmasTree(int n)
        {
            C_Tree(n);
            C_Base(n);
        }
        
        #endregion
    }
}
