using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Threading;

namespace YouAndCthulhu
{
    public class Function
    {
        // A Function contains an id, composed of a natural and a character,
        // a list of Actions, which are kinds of lambda expressions, and a
        // register.
        private UInt64 idnum;
        private char idchar;
        private List<Action> execution;
        private int accumulator;

        public Function(UInt64 idnum, char idchar, string commands, 
                        FunctionTable ftable)
        {
            this.idnum = idnum;
            this.idchar = idchar;
            this.accumulator = 0;
            this.execution = new List<Action>();
            ParseCommands(commands, ftable);
        }

        // Getters
        public ulong Idnum => idnum;
        public char Idchar => idchar;
        public int Accumulator => accumulator;

        // Methods implements Function Commands as seen on Esolang.
        public void Increment()
        {
            ++accumulator;
        }

        public void Decrement()
        {
            --accumulator;
        }

        public void MoveOut(Function f)
        {
            f.accumulator = accumulator;
        }

        public void MoveIn(Function f)
        {
            accumulator = f.accumulator;
        }

        public void Output()
        {
            Console.WriteLine(Accumulator);
        }

        public void Input()
        {
            Console.WriteLine("Waiting for integer input: ");
            try
            {
                UInt64 input = Convert.ToUInt64(Console.ReadLine());
                Console.WriteLine();
            }
            catch (Exception exception)
            {
               throw new ArgumentException("Invalid input");
            }
        }
        
        public void Execute()
        {
            foreach (var action in execution)
                action();
        }
        
        private void ParseCommands(string commands, FunctionTable ftable)
        // Given the command string and the ftable, parses commands by creating
        // a lambda expression and adding it to the list every time.
        {
            int index = 0;
            
            while (index < commands.Length)
            {
                Action act;
                switch (LexerParser.CommandLexer(commands, index++))
                {
                    case LexerParser.CommandToken.TOKEN_INCREMENT:
                    {
                        act = () => Increment();
                        break;
                    }
                    case LexerParser.CommandToken.TOKEN_DECREMENT:
                    {
                        act = () => Decrement();
                        break;
                    }
                    case LexerParser.CommandToken.TOKEN_OUTPUT:
                    {
                        act = () => Output();
                        break;
                    }
                    case LexerParser.CommandToken.TOKEN_INPUT:
                    {
                        act = () => Input();
                        break;
                    }
                    case LexerParser.CommandToken.TOKEN_MOVE_IN:
                    {
                        ulong x = LexerParser.GetIdNatural(commands, ref index);
                        char y = LexerParser.GetIdLetter(commands, ref index);
                        act = () => MoveIn(ftable.Search(x, y));
                        break;
                    }
                    case LexerParser.CommandToken.TOKEN_MOVE_OUT:
                    {
                        ulong x = LexerParser.GetIdNatural(commands, ref index);
                        char y = LexerParser.GetIdLetter(commands, ref index);
                        act = () => MoveOut(ftable.Search(x, y));
                        break;
                    }
                    case LexerParser.CommandToken.TOKEN_CALL:
                    {
                        // calling a function simply consists in executing it...
                        act = () => Execute();
                        break;
                    }
                    case LexerParser.CommandToken.TOKEN_CALL_ACC:
                    {
                        act = () => Execute();
                        break;
                    }
                    default:
                    {
                        throw new Exception("Unexpected token in parsing");
                    }
                }

                execution.Add(act);
            }
        }
        
    }
}