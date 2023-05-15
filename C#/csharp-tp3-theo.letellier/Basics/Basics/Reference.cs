using System;

namespace Basics
{
    public static class Reference
    {
        public static void Swap(ref int lhs, ref int rhs)
        {
            (lhs, rhs) = (rhs, lhs);
            return;
        }
        
        public static int Trunc(ref float f)
        {
            int a = Convert.ToInt32(Math.Truncate(f));
            f = f % a;
            return a;
        }
        
        public static void RotChar(ref char c, int n)
        {
            if (c < 48 || c > 122)
            {
                throw new System.ArgumentException("La valeur doit être de type entier ou être une lettre.");
            }
            else
            {
                if (c < 58 && c > 47)
                {
                    if (c + n > 57)
                    {
                        c = (char) (c + (n % 10) - 10);
                        Console.Write(c);
                        return;
                    }
                    if (c + n < 47)
                    {
                        c = (char) (c + 10 + (n % 10));
                        Console.Write(c);
                        return;
                    }
                    else
                    {
                        c = (char) (c + n);
                        Console.Write(c);
                        return;
                    }
                }
                if (c < 91 && c > 64)
                {
                    if (c + n > 90)
                    {
                        c = (char) (c + (n % 10) - 26);
                        Console.Write(c);
                        return;
                    }
                    if (c + n < 65)
                    {
                        c = (char) (c + 26 + (n % 10));
                        Console.Write(c);
                        return;
                    }
                    else
                    {
                        c = (char) (c + n);
                        Console.Write(c);
                        return;
                    }
                }
                else
                {
                    if (c + n > 122)
                    {
                        c = (char) (c + (n % 10) - 26);
                        Console.Write(c);
                        return;
                    }
                    if (c + n < 91)
                    {
                        c = (char) (c + 26 + (n % 10));
                        Console.Write(c);
                        return;
                    }
                    else
                    {
                        c = (char) (c + n);
                        Console.Write(c);
                        return;
                    }
                }
            }
        }
    }
}