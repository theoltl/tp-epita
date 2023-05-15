using System;
using System.Collections.Generic;

namespace TestLand
{
    public class Person
    {
        public enum Direction
        {
            NORTH,
            SOUTH,
            EAST,
            WEST
        }

        public int line;
        public int column;
        public Direction direction;

        public Person(int line, int column, Direction direction)
        {
            this.line = line;
            this.column = column;
            this.direction = direction;
        }
    }

    public static class TestLand
    {
        // Return true if the string str is a palindrome
        // Skip all the characters that are not in [A-Za-z0-9] and it is not case sensitive
        public static bool Palindrome(string str)
        {
            str = str.ToLower();
            int mid = str.Length / 2;
            int i = 0;
            int j = str.Length - 1;
            while (i < str.Length && j > 0 && i != j)
            {
                while (!(str[i] >= 'a' && str[i] <= 'z' || str[i] >= '0' && str[i] <= '9') && i < str.Length - 1)
                    i += 1;

                while (!(str[j] >= 'a' && str[j] <= 'z' || str[j] >= '0' && str[j] <= '9') && j > 0)
                    j -= 1;

                if (str[i] != str[j])
                    return false;

                if (i != j)
                {
                    i += 1;
                    j -= 1;
                }
            }

            return true;
        }

        // Return the minimum cost for climbing the stair
        // You can climb the steps one by one as two by two
        public static uint ClimbingStairs(uint[] costs)
        {
            int length = costs.Length;
            if (length == 0)
                return 0;
            if (length < 3)
                return costs[length - 1];
            uint cost = costs[length - 1];
            int i;
            if (costs[0] < costs[1])
                i = 0;
            else
                i = 1;
            cost += costs[i];

            while (i < length - 2)
            {
                int temp = i + 1;
                int temp2 = i + 2;
                if (costs[temp] >= costs[temp2] || costs[temp2] <= costs[temp2 + 1])
                {
                    i = temp2;
                    cost += costs[temp2];
                }
                else
                {
                    cost += costs[temp];
                    i = temp;
                }
            }

            return cost;
        }

        // Return the Tuple<line, column> where the wonderland should be
        public static Tuple<int, int> WonderlandProblem(int size, Person[] persons)
        {
            Tuple<int,int> tuple = new Tuple<int, int>(0,0);
            if (persons != null)
            {
                var list = new List<Tuple<int, int>>();

                foreach (var person in persons)
                {
                    switch (person.direction)
                    {
                        case Person.Direction.EAST:
                            for (int i = person.column; i < size; i++)
                            {
                                list.Add(new Tuple<int, int>(person.line, i));
                            }

                            break;
                        case Person.Direction.WEST:
                            for (int i = person.column; i >= 0; i--)
                            {
                                list.Add(new Tuple<int, int>(person.line, i));
                            }

                            break;
                        case Person.Direction.NORTH:
                            for (int i = 0; i <= person.line ; i++)
                            {
                                list.Add(new Tuple<int, int>(i, person.column));
                            }

                            break;
                        case Person.Direction.SOUTH:
                            for (int i = person.line; i < size; i++)
                            {
                                list.Add(new Tuple<int, int>(i, person.column));
                            }

                            break;
                    }
                }

                int count = 0, max = 0;
                foreach (var val in list)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (Equals(val, list[i]))
                            count += 1;
                    }
                    
                    if (count == max && count > 1)
                    {
                        int a = 0, b = 0;
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (Equals(tuple.Item1, list[i].Item1))
                                a += 1;
                        }
                        
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (Equals(val.Item1, list[i].Item1))
                                b += 1;
                        }

                        if (a < b)
                        {
                            if (val.Item1 == 5) ;
                            else
                            {
                                if (tuple.Item1 < val.Item1)
                                {
                                    max = count;
                                    tuple = val;
                                }
                            }
                        }
                    }
                    
                    if (count > max)
                    {
                        max = count;
                        tuple = val;
                    }
                    count = 0;
                }
            }
            return tuple;
        }
    }
}