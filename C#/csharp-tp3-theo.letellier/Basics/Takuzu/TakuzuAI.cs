using System;

namespace Takuzu
{

    public class TakuzuAI
    {
        public static int[,] CloneArray(int[,] grid)
        {
            int longueur0 = grid.GetLength(0);
            int longueur1 = grid.GetLength(1);

            int[,] copy = new int[longueur0,longueur1];

            for (int x = 0; x < longueur0; x++)
            {
                for (int y = 0; y < longueur1; y++)
                {
                    copy[x, y] = grid[x, y];
                }
            }

            return copy;
        }
        
        public static void AI(int[,] grid)
        {
            int longueur0 = grid.GetLength(0);
            int longueur1 = grid.GetLength(1);

            int[,] copy = CloneArray(grid);

            Random rnd = new Random();

            for (int x = 0; x < longueur0; x++)
            {
                for (int y = 0; y < longueur1; y++)
                {
                    int value = rnd.Next(2);
                    if (value == 0)
                    {
                        if (Takuzu.PutCell(grid, x, y, value) == false)
                        {
                            if (Takuzu.PutCell(grid, x, y, 1) == false)
                            {AI(copy);}
                            else
                            {Takuzu.PutCell(grid, x, y, 1);}
                        }
                        else
                        {Takuzu.PutCell(grid, x, y, value);}
                    }

                    if (value == 1)
                    {
                        if (Takuzu.PutCell(grid, x, y, value) == false)
                        {
                            if (Takuzu.PutCell(grid, x, y, 0) == false)
                            {AI(copy);}
                            else
                            {Takuzu.PutCell(grid, x, y, 0);}
                        }
                        else
                        {Takuzu.PutCell(grid, x, y, value);}
                    }
                }
            }

            if (Takuzu.IsGridValid(grid))
            {
                Console.Clear();
                Console.WriteLine("\n"+"Completed !" + "\n");
                Takuzu.PrintGrid(grid);
                return;
            }
            if (Takuzu.IsGridValid(grid) == false)
            {
                AI(copy);
            }
        }
    }
}
