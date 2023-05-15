using System;

namespace Takuzu
{
    public static class Takuzu
    { 
        public static void PrintGrid(int[,] grid)
        {
            int i = 0;
            Console.Write("   ");
            for (; i < grid.GetLength(0); i++)
            {
                Console.Write(i + " ");
            }
            
            Console.WriteLine();

            for (i = 0; i < grid.GetLength(1); i++)
            {
                Console.Write(i + " |");
                for(int count = 0; count < grid.GetLength(1); count++)
                {
                    if (grid[i,count] == -1)
                        Console.Write(" |");
                    if (grid[i,count] == 1)
                        Console.Write("1|");
                    if (grid[i,count] == 0)
                        Console.Write("0|");
                }
                Console.WriteLine();
            }
        }
        
        public static bool IsRowValid(int[,] grid, int row)
        {
            int count0 = 0, count1 = 0, close0 = 0, close1 = 0;
         
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                if (grid[row, i] == 0)
                {
                    count0++;
                    close0++;
                    close1 = 0;
                }
                
                if (grid[row, i] == 1)
                {
                    count1++;
                    close1++;
                    close0 = 0;
                }
                
                if (close0 > 2 || close1 > 2)
                    return false;
                
                if ((count0 > (grid.GetLength(0) / 2)) || count1 > (grid.GetLength(0) / 2))
                    return false;
            }
            return true;
        }
        
        public static bool IsColumnValid(int[,] grid, int col)
        {
            int count0 = 0, count1 = 0, close0 = 0, close1 = 0;
         
            for (int i = 0; i < grid.GetLength(1); i++)
            {
                if (grid[i, col] == 0)
                {
                    count0++;
                    close0++;
                    close1 = 0;
                }
                if (grid[i, col] == 1)
                {
                    count1++;
                    close1++;
                    close0 = 0;
                }
              
                
                if (close0 > 2 || close1 > 2)
                    return false;
                
                if (count0 > grid.GetLength(1) / 2  || count1 > grid.GetLength(1) / 2)
                    return false;
            }
            return true;
        }
        
        public static bool IsGridValid(int[,] grid)
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                if (IsRowValid(grid, i))
                {
                    for (int z = i+1; z < grid.GetLength(0); z++)
                    {
                        int count = 0;
                        for (int c = 0; c < grid.GetLength(0); c++)
                        {
                            if (grid[i, c] == -1)
                                return false;
                            if (grid[z, c] == -1)
                                return false;
                            if (grid[i, c] == grid[z, c])
                                count++;
                            if (count == grid.GetLength(0))
                                return false;
                        }
                    }
                }
                
                if (IsColumnValid(grid, i))
                {
                    for (int z = i+1; z < grid.GetLength(0); z++)
                    {
                        int count = 0;
                        for (int c = 0; c < grid.GetLength(0); c++)
                        {
                            if (grid[c, i] == -1)
                                return false;
                            if (grid[c, z] == -1)
                                return false;
                            if (grid[c, i] == grid[c, z])
                                count++;
                            if (count == grid.GetLength(0))
                                return false;
                        }
                    }
                }
                else
                    return false;
            }
            return true;
        }

        public static bool PutCell(int[,] grid, int x, int y, int val)
        {
            if (x >= grid.GetLength(0) || y >= grid.GetLength(1))
                return false;
            {
                if (grid[x, y] == -1)
                {
                    if (val == 1 || val == 0)
                    {
                        grid[x, y] = val;
                        if (IsRowValid(grid, x) == false)
                        {
                            grid[x, y] = -1;
                            return false;
                        }
                        if (IsColumnValid(grid, y) == false)
                        {
                            grid[x, y] = -1;
                            return false;
                        }
                    }
                }
                return true;
            }
        }
        
        public static void Game(int[,] start)
        {
            
            while (IsGridValid(start) == false)
            {
                PrintGrid(start);
                
                Console.Write("x : ");
                int x = Convert.ToInt32(Console.ReadLine());                    
                Console.Write("y : ");       
                int y = Convert.ToInt32(Console.ReadLine());
                Console.Write("value : ");       
                int value = Convert.ToInt32(Console.ReadLine());

                PutCell(start, x, y, value);
            }
            
            PrintGrid(start);
            
            Console.WriteLine("\n");
            
            Console.WriteLine("Bravo vous avez gagné !");
        }
        
    }
}