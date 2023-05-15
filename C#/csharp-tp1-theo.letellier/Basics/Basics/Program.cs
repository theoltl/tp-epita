using System;

namespace Basics
{
    class Program
    {
        
        static void Parrot(int count, string str)
        {
            var i = 0;
            do
            {
                Console.WriteLine(str);
                i++;
            } while (i != count);
        }


        static void Introduction(string name, uint age, string city, string work)
        {
            Console.WriteLine("Hello, my name is " + name + ", I am " + age + ", I live in " + city +
                              " and I work in " + work);
        }



        #region Tower

        public static void Ground()
        {
            string ground =
                @"|     _     | 
|    | |    |
|____|_|____|";

            Console.WriteLine(ground);
        }
        
        public static void Roof()
        {
            string top = @" 
 ___________ 
|           |";
            Console.WriteLine(top);
        }

        public static void Floor(int nb)
        {
            string floor =
                @"|  _     _  |
| |o|   |o| |
| |_|   |_| |";

            var i = 0;
            do
            {
                Console.WriteLine(floor);
                i++;
            } while (i != nb);
        }

        public static void Tower(int nb)
        {
            Roof();
            Floor(nb);
            Ground();
        }
        
        #endregion


        public static bool CheckNumber(int input, int number)
        {
            if (input == number)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Congratulation, the number was: " + number + "\n");
                return true;
            }

            if (input < number)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The correct number is superior to " + input + "\n");
                return false;

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The correct number is inferior to " + input + "\n");
                return false;
            }
        }


        
        public static bool Game(int numbers, int tries)
        {
            if (tries > 0)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(tries + " tries left :");
                int value = Convert.ToInt32(Console.ReadLine());

                if (value == numbers)
                {
                    CheckNumber(value, numbers);
                    return true;
                }

                if (value < numbers)
                {
                    CheckNumber(value, numbers);
                    Game(numbers, (tries - 1));
                    return false;
                }

                if (value > numbers)
                {
                    CheckNumber(value, numbers);
                    Game(numbers, (tries - 1));
                    return false;
                }
            }

            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The correct number was " + numbers + "\n");
                return false;
            }
        }

        

        //Bonus

        #region GAME2


        public static void Initialisation()
        {
            #region level

            #region level art

            string easy =
                @"
+-------------------+
|     1 - EASY      |
+-------------------+";
            string medium =
                @"
+-------------------+
|    2 - MEDIUM     |
+-------------------+";
            string hard =
                @"
+-------------------+
|     3 - HARD      |
+-------------------+";

            #endregion

            #region level color

            Console.Clear();
            Console.Write("Niveaux de difficulté ");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(easy);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(medium);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(hard);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n" + "\n" + "Entrez le nombre correspondant à la difficulté choisie : ");

            #endregion

            #region choose level

            int level = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            if (level == 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("La difficulté choisie est : EASY \n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (level == 2)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("La difficulté choisie est : MEDIUM \n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("La difficulté choisie est : HARD \n");
                Console.ForegroundColor = ConsoleColor.White;
            }

            #endregion

            #endregion

            Jeu(level);
            Retry();
        }

        public static void Retry()
        {
            #region thx

            string THANKS =
                @"  
  _______ _    _          _   _ _  __ _____     ______ ____  _____      _____  _           __     _______ _   _  _____ 
 |__   __| |  | |   /\   | \ | | |/ // ____|   |  ____/ __ \|  __ \    |  __ \| |        /\\ \   / /_   _| \ | |/ ____|
    | |  | |__| |  /  \  |  \| | ' /| (___     | |__ | |  | | |__) |   | |__) | |       /  \\ \_/ /  | | |  \| | |  __ 
    | |  |  __  | / /\ \ | . ` |  <  \___ \    |  __|| |  | |  _  /    |  ___/| |      / /\ \\   /   | | | . ` | | |_ |
    | |  | |  | |/ ____ \| |\  | . \ ____) |   | |   | |__| | | \ \    | |    | |____ / ____ \| |   _| |_| |\  | |__| |
    |_|  |_|  |_/_/    \_\_| \_|_|\_\_____/    |_|    \____/|_|  \_\   |_|    |______/_/    \_\_|  |_____|_| \_|\_____|";

            #endregion
           
            
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Do you wanna retry ? (y or n)");
            if (Console.ReadLine() == "y")
            {
                Console.Clear();
                Initialisation();
            }
            else
            {
                Console.Clear();
                Console.WriteLine(THANKS);
            }
        }
        

        public static void Jeu(int level)
        {
            var random = new Random();
            int guesseasy = random.Next(1, 10);
            int guessmedium = random.Next(1, 20);
            int guesshard = random.Next(1, 40);

            if (level == 1)
            {
                Console.WriteLine("Le nombre est compris entre 1 et 10");
                Game(guesseasy, 5);
            }

            if (level == 2)
            {
                Console.WriteLine("Le nombre est compris entre 1 et 20");
                Game(guessmedium, 5);
            }

            if (level == 3)
            {
                Console.WriteLine("Le nombre est compris entre 1 et 40");
                Game(guesshard, 5);
            }
        }



        #endregion
        

        static void Main(string[] args)
        {
            //If you wanna play, please remove the two slashes before Initialisation
            Initialisation();
            
            
        }
    }
}

