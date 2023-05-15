using System;

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
        public int[][] vertical;
        public int[][] horizontal;

        public Maze(int size)
        {
            this.size = size;
            this.maze = new Cell[size,size];
        }
        
        #region PrettyPrint
        
        public void CarvePath(int i, int j, Direction dir)
        {
            switch (dir)
            {
                case Direction.EAST:
                    maze[i, j].Right = false;
                    break;
                case Direction.WEST:
                    maze[i, j].Left = false;
                    break;
                case Direction.NORTH:
                    maze[i, j].Up = false;
                    break;
                case Direction.SOUTH:
                    maze[i, j].Down = false;
                    break;
            }
        }
        
        #endregion
        
        #region PrettyPrint
        
        public string MazeToString()
        {
            //TODO
            // Transforms the maze into a string (follow EXACTLY the output of the subject)
            throw new NotImplementedException();
        }
        
        #endregion
        
        #region Backtracking 

        public bool IsExit(int i, int j)
        {
            //TODO
            throw new NotImplementedException();
        }
        
        public void MarkPath(int i, int j)
        {
            maze[i, j].IsPath = !maze[i, j].IsPath;
        }

        public bool IsPath(int i, int j)
        {
            //TODO
            throw new NotImplementedException();
        }

        public bool IsValidCell(int i, int j)
        {
            //TODO
            throw new NotImplementedException();return (i >= 0 && i < size && j >= 0 && j < size);
        }

        public bool IsValidDirection(int i, int j, Direction direction)
        {
            //TODO
            throw new NotImplementedException();
        }
        
        #endregion
    }
}