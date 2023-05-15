using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace YouAndCthulhu
{
    public class FunctionTable
    {
        // List of Function objects
        // A FunctionTable is always sorted. It has elements, each corresponding
        // to a List<Function> containing Function of IdLetter A, B, C or D,
        // respectively contained as elements 0, 1, 2, 3 of the table. These
        // lists are sorted in increasing order of the IdNatural.
        protected List<Function>[] ftable;

        // Constructor
        public FunctionTable()
        {
            this.ftable = new List<Function>[4];
            for (int i = 0; i < 4; i++)
            {
                ftable[i] = new List<Function>();
            }
        }

        // Used in order to keep the table sorted at all time
        // Search idnum in l. If found, return its index, else, returns the index
        // it should be inserted at.
        public int BinarySearch(List<Function> l, ulong idnum)
        {
            int posmin = 0;
            int posmax = l.Count - 1;
            int dichopos = (posmax + posmin) / 2;


            while (posmin <= posmax)
            {
                if (l[dichopos].Idnum < idnum)
                {
                    posmin = dichopos + 1;
                }

                if (l[dichopos].Idnum > idnum)
                {
                    posmax = dichopos - 1;
                }
                else
                {
                    return dichopos;
                }
            }
            
            return dichopos;              
        }


        // Adds a function at the right place in the table
        public void Add(Function f)
        {
            foreach (var fonctionList in ftable)
            {
                foreach (var Fonction in fonctionList)
                {
                    if (Fonction == f)
                        throw new Exception("f is already in ftable");
                }
            }
            ftable[f.Idchar % 65].Add(f);
        }

        // Search method, returns the right function.
        public Function Search(ulong idnum, char idchar)
        {
            foreach (var fonctionList in ftable)
            {
                foreach (var Fonction in fonctionList)
                {
                    if (Fonction.Idchar == idchar && Fonction.Idnum == idnum)
                        return Fonction;
                }
            }
            
            throw new Exception("Function not found");
        }

        // Same but with a register which could be negative
        public Function SearchRegister(int register, char idchar)
        {
            foreach (var fonctionList in ftable)
            {
                foreach (var Fonction in fonctionList)
                {
                    if (Fonction.Idchar == idchar && Fonction.Accumulator == register)
                        return Fonction;
                }
            }
            
            throw new Exception("Function not found");
        }

        // Executes the ftable (by executing 0A)
        public void Execute()
        {
            ftable[0][0].Execute();
            
            throw new Exception("Function not found");
        }
    }
}