using System;
using System.Collections.Generic;

namespace Lost_in_Wonderland
{
    public class Maze
    {
        public enum Direction
        {
            NORTH,
            SOUTH,
            EAST,
            WEST,
            NULL
        }
        private Cell[,] maze;
        private int size;

        public Maze(int size)
        {
            this.size = size;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    maze[i,j] = new Cell(false,true);
                    
                }
            }
        }
        
        #region PrettyPrint
        
        public void CarvePath(int i, int j, Direction dir)
        {
            switch (dir)
            {
                case Direction.EAST:
                    maze[i, j].Right = false;
                    break;
                case Direction.SOUTH:
                    maze[i, j].Down = false;
                    break;
                case Direction.WEST:
                    maze[i, j].Left = false;
                    break;
                case Direction.NORTH:
                    maze[i, j].Up = false;
                    break;
            }
        }
        
        #endregion
        
        #region PrettyPrint
        
        public string MazeToString()
        {
            string aaaa = "";
            string Wall = "||";
            string Wall2 = "=";
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    if (maze[i,j].Left)
                    {
                        Console.Write(Wall);
                    }
                    if (maze[i,j].Right)
                    {
                        Console.Write(Wall);
                    }
                    
                    if (maze[i,j].Down)
                    {
                        Console.Write(Wall2);
                    }
                    if (maze[i,j].Up)
                    {
                        Console.Write(Wall2);
                    }
                    
                }
            }

            return aaaa;
        }
        
        #endregion
        
        #region Backtracking 

        public bool IsExit(int i, int j)
        {
            return maze[i, j].End;
        }
        
        public void MarkPath(int i, int j)
        {
            maze[i, j].IsPath = !maze[i, j].IsPath;
        }

        public bool IsPath(int i, int j)
        {
            return maze[i, j].IsPath;
        }

        public bool IsValidCell(int i, int j)
        {
            return (i >= 0 && i < size && j >= 0 && j < size);
        }

        public bool IsValidDirection(int i, int j, Direction direction)
        {
            switch (direction)
            {
                case Direction.EAST:
                    return maze[i, j].Right;
                case Direction.SOUTH:
                    return maze[i, j].Down;
                case Direction.WEST:
                    return maze[i, j].Left;
                case Direction.NORTH:
                    return maze[i, j].Up;
            }

            return false;
        }
        
        #endregion
    }
}