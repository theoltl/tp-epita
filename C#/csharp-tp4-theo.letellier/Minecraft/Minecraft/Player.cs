using System;
using System.Collections.Generic;
using System.Threading;

namespace Minecraft
{
    public class Player : Entity
    {
        # region Constructor

        private string username;

        private int weaponStrength;

        private List<Blocks> inventory = new List<Blocks>();



        public Player(string username, int weaponStrength)
            : base(MobType.PLAYER, 20, "Hi Guys", new Blocks(Blocks.BlockType.NONE, 0))
        {
            this.username = username;
            this.weaponStrength = weaponStrength;
        }

        #endregion

        #region Methods

        public override void WhoAmI()
        {
            Console.WriteLine("I am {0} ! Hi Guys", username);
        }

        public void Attack(Entity entity)
        {
            entity.GetHurt(weaponStrength + 1 );
            if (entity.Hp < 1)
                inventory.Add(entity.GetHurt(weaponStrength));
        }

        public void AddInInventory(Blocks blocks)
        {
            int length = inventory.Count;
            bool ishere = false;

            for (int i = 0; i < length; i++)
            {
                if (inventory[i].count == 64)
                    i += 0;

                else if (blocks.type == inventory[i].type)
                {
                    if (blocks.count + inventory[i].count > 64)
                    {
                        int count = blocks.count + inventory[i].count - 64;
                        inventory[i].count = 64;
                        for (; (count > 64); count -= 64)
                        {
                            inventory.Add(new Blocks(blocks.type, 64));
                        }

                        inventory.Add(new Blocks(blocks.type, count));
                        ishere = true;
                    }
                    else
                    {
                        inventory[i].count += blocks.count;
                        ishere = true;
                    }
                }
            }

            if (ishere == false)
                if (blocks.count > 0)
                {
                    int count = blocks.count;
                    for (; (count > 64); count -= 64)
                    {
                        inventory.Add(new Blocks(blocks.type, 64));
                    }

                    inventory.Add(new Blocks(blocks.type, count));
                }
        }


        public void RemoveInInventory(Blocks blocks)
        {
            int length = inventory.Count;
            for (int i = length - 1; i >= 0; i--)
            {
                if (blocks.type == inventory[i].type)
                {
                    if (inventory[i].count - blocks.count <= 0)
                    {
                        blocks.count -= inventory[i].count;
                        inventory.Remove(inventory[i]);
                    }
                    else
                    {
                        inventory[i].count -= blocks.count;
                    }
                }
            }
        }

        public void Heal(int life)
        {
            if (IsKO)
                return;

            if (hp + life >= 20)
                hp = 20;
            else
                hp += life;
        }

        public void DisplayInventory()
        {
            Console.WriteLine("I have so many blocks. These are :");
            foreach (var i in inventory)
            {
                Console.WriteLine("- " + i.type + " " + i.count);
            }
        }

        public int CountInInventory(Blocks.BlockType type)
        {
            int count = 0;
            foreach (Blocks i in inventory)
            {
                if (i.type == type)
                {
                    count += i.count;
                }
            }

            return count;
        }

        #endregion

        //Bonus

        #region Bonus

        public void Game()
        {
            #region ascii

            string Minecraft = @"
 __          ________ _      _____ ____  __  __ ______        _____ _   _ _______ ____         __  __ _____ _   _ ______ _____ _____            ______ _______ 
 \ \        / /  ____| |    / ____/ __ \|  \/  |  ____|      |_   _| \ | |__   __/ __ \       |  \/  |_   _| \ | |  ____/ ____|  __ \     /\   |  ____|__   __|
  \ \  /\  / /| |__  | |   | |   | |  | | \  / | |__           | | |  \| |  | | | |  | |      | \  / | | | |  \| | |__ | |    | |__) |   /  \  | |__     | |   
   \ \/  \/ / |  __| | |   | |   | |  | | |\/| |  __|          | | | . ` |  | | | |  | |      | |\/| | | | | . ` |  __|| |    |  _  /   / /\ \ |  __|    | |   
    \  /\  /  | |____| |___| |___| |__| | |  | | |____        _| |_| |\  |  | | | |__| |      | |  | |_| |_| |\  | |___| |____| | \ \  / ____ \| |       | |   
     \/  \/   |______|______\_____\____/|_|  |_|______|      |_____|_| \_|  |_|  \____/       |_|  |_|_____|_| \_|______\_____|_|  \_\/_/    \_\_|       |_| ";

            string died = @" 
 __     ______  _    _         _____ _____ ______ _____  
 \ \   / / __ \| |  | |       |  __ \_   _|  ____|  __ \ 
  \ \_/ / |  | | |  | |       | |  | || | | |__  | |  | |
   \   /| |  | | |  | |       | |  | || | |  __| | |  | |
    | | | |__| | |__| |       | |__| || |_| |____| |__| |
    |_|  \____/ \____/        |_____/_____|______|_____/ ";

            string Creeper = @"
█████████████████
█░░░░░░░░░░░░░░░█
█░░████░░░████░░█
█░░████░░░████░░█
█░░░░░░███░░░░░░█
█░░░░███████░░░░█
█░░░░███████░░░░█
█░░░░██░░░██░░░░█
█░░░░░░░░░░░░░░░█
█████████████████";


            string Zombie = @"
█████████████████
█░░░░░░░░░░░░░░░█
█░░░░░░░░░░░░░░░█
█░░████░░░████░░█
█░░████░░░████░░█
█░░░░░░░░░░░░░░░█
█░░░░░░███░░░░░░█
█░░░░░░░░░░░░░░░█
█░░░░███████░░░░█
█░░░░░░░░░░░░░░░█
█████████████████";

            string pig = @"
     __,---.__________
        __,-'         `-.
       /_ /_,'           \&
       _,''               \
      ("")            .    |
         ``--|__|--..-'`.__|";

            string deadpig = @"
     __,---.__________
        __,-'         `-.
       /_ /_,'           \&
       _,x x              \
      ("")            .    |
         ``--|__|--..-'`.__|";


            string ocelot = @"
(""`-''-/"").___..--''""`-._ 
 `O_ O  )   `-.  (     ).`-.__.`) 
 (_Y_.)'  ._   )  `._ `. ``-..-' 
   _..`--'_..-_/  /--'_.'
  ((((.-''  ((((.'  (((.-' ";

            string cow = @" 
 _(__)_        V
'-o o -'__,--.__)
(o_o)        ) 
  \. /___.  |
  ||| _)/_)/
 //_(/_(/_(";
            
            string deadocelot = @"
(""`-''-/"").___..--''""`-._ 
 `X_ X  )   `-.  (     ).`-.__.`) 
 (_Y_.)'  ._   )  `._ `. ``-..-' 
   _..`--'_..-_/  /--'_.'
  ((((.-''  ((((.'  (((.-' ";

            string deadcow = @" 
 _(__)_        V
'-x x -'__,--.__)
(o_o)        ) 
  \. /___.  |
  ||| _)/_)/
 //_(/_(/_(";

            string attack =
                @"
+-------------------+
|     1 - ATTACK    |
+-------------------+";
            string heal = @" 
+-------------------+
|      2 - HEAL     |
+-------------------+";
            
            string RunAway = @" 
+-------------------+
|    3 - RUN AWAY   |
+-------------------+";
            string Continue =
                @"
+-------------------+
|   1 - CONTINUE    |
+-------------------+";
            string REPLAY =
                @"
+-------------------+
|    1 - REPLAY     |
+-------------------+";
            string QUIT = @" 
+-------------------+
|      2 - QUIT     |
+-------------------+";

            string thx = @" 
  _______ _    _          _   _ _  __ _____         ______ ____  _____          _____  _           __     _______ _   _  _____ 
 |__   __| |  | |   /\   | \ | | |/ // ____|       |  ____/ __ \|  __ \        |  __ \| |        /\\ \   / /_   _| \ | |/ ____|
    | |  | |__| |  /  \  |  \| | ' /| (___         | |__ | |  | | |__) |       | |__) | |       /  \\ \_/ /  | | |  \| | |  __ 
    | |  |  __  | / /\ \ | . ` |  <  \___ \        |  __|| |  | |  _  /        |  ___/| |      / /\ \\   /   | | | . ` | | |_ |
    | |  | |  | |/ ____ \| |\  | . \ ____) |       | |   | |__| | | \ \        | |    | |____ / ____ \| |   _| |_| |\  | |__| |
    |_|  |_|  |_/_/    \_\_| \_|_|\_\_____/        |_|    \____/|_|  \_\       |_|    |______/_/    \_\_|  |_____|_| \_|\_____|";

            #endregion

            Console.WriteLine(Minecraft + "\n"+ "\n");
            int q;
            Console.Write("Enter a nickname : ");
            string username = Convert.ToString(Console.ReadLine());
            Player player = new Player(username, 10);
            Thread.Sleep(100);
            int leave = 0;
            int potion = 5;
            
            
            do
            {
                Random rnd = new Random();
                int r = rnd.Next(1, 5);
                int mobLife = rnd.Next(15, weaponStrength*5);
                int i;
                Entity x;
                Aggressive y;

                switch (r)
                {
                    #region Pig
                    case 1:
                        Console.Clear();
                        Console.WriteLine("You have encountered a pig !");
                        x = new Entity(MobType.PIG, 6, "GROINK", new Blocks(Blocks.BlockType.MEAT, 2));
                        for (i = 1; i < 100; i++)
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write(pig + "\n" + "\n");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("{0} has {1} hp", x.Type, x.Hp);
                            Console.WriteLine("You have {0} hp and {1} potion", player.Hp, potion);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(attack);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write(heal);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(RunAway + "\n");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("What do you wanna do ? : ");
                            q = Convert.ToInt32(Console.ReadLine());
                            Console.Clear();
                            if (q == 1)
                            {
                                Attack(x);
                                if (x.IsKO)
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine(deadpig + "\n");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("Pig has been killed in {0} hits", i);
                                    Thread.Sleep(200);
                                    i = 100;
                                }
                            }
                            if (q == 2)
                            {
                                if (potion < 1)
                                    Console.WriteLine("No potion left");
                                else
                                {
                                    player.Heal(20);
                                    potion -= 1;
                                }
                            }
                            else
                            {
                                if (leave > 3)
                                    Console.Write("You can't leave !");
                                else
                                {
                                    leave += 1;
                                    break;  
                                }
                            }
                        }
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(Continue);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(QUIT + "\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("What do you wanna do ? : ");
                        q = Convert.ToInt32(Console.ReadLine());
                        if (q == 1)
                            break;
                        {
                            Console.Write(thx);
                            Thread.Sleep(100);
                            return;
                        }
                    #endregion

                    #region Cow
                    
                    case 2:
                        Console.Clear();
                        Console.WriteLine("You have encountered a cow !");
                        x = new Entity(MobType.COW, 7, "Moo", new Blocks(Blocks.BlockType.MEAT, 4));
                        for (i = 1; i < 100; i++)
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write(cow + "\n" + "\n");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("{0} has {1} hp", x.Type, x.Hp);
                            Console.WriteLine("You have {0} hp and {1} potion", player.Hp, potion);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(attack);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write(heal);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(RunAway + "\n");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("What do you wanna do ? : ");
                            q = Convert.ToInt32(Console.ReadLine());
                            Console.Clear();
                            if (q == 1)
                            {
                                Attack(x);
                                if (x.IsKO)
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine(deadcow + "\n");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("Cow has been killed in {0} hits", i);
                                    Thread.Sleep(200);
                                    i = 100;
                                }
                            }
                            if (q == 2)
                            {
                                if (potion < 1)
                                    Console.WriteLine("No potion left");
                                else
                                {
                                    player.Heal(20);
                                    potion -= 1;
                                }
                            }
                            else
                            {
                                if (leave > 3)
                                    Console.Write("You can't leave !");
                                else
                                {
                                    leave += 1;
                                    break;  
                                }
                            }
                        }
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(Continue);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(QUIT + "\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("What do you wanna do ? : ");
                        q = Convert.ToInt32(Console.ReadLine());
                        if (q == 1)
                            break;
                        {
                            Console.Write(thx);
                            Thread.Sleep(100);
                            return;
                        }

                    #endregion
                    
                    #region Ocelot
                    
                    case 3:
                        Console.Clear();
                        Console.WriteLine("You have encountered an ocelot !");
                        x = new Entity(MobType.OCELOT, 4, "Miaow !", new Blocks(Blocks.BlockType.MEAT, 1));
                        for (i = 1; i < 100; i++)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(ocelot + "\n" + "\n");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("{0} has {1} hp", x.Type, x.Hp);
                            Console.WriteLine("You have {0} hp and {1} potion", player.Hp, potion);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(attack);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write(heal);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(RunAway + "\n");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("What do you wanna do ? : ");
                            q = Convert.ToInt32(Console.ReadLine());
                            Console.Clear();
                            if (q == 1)
                            {
                                Attack(x);
                                if (x.IsKO)
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine(deadocelot + "\n");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("Ocelot has been killed in {0} hits", i);
                                    Thread.Sleep(200);
                                    i = 100;
                                }
                            }
                            if (q == 2)
                            {
                                if (potion < 1)
                                    Console.WriteLine("No potion left");
                                else
                                {
                                    player.Heal(20);
                                    potion -= 1;
                                }
                            }
                            else
                            {
                                if (leave > 3)
                                    Console.Write("You can't leave !");
                                else
                                {
                                    leave += 1;
                                    break;  
                                }
                            }
                        }
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(Continue);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(QUIT + "\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("What do you wanna do ? : ");
                        q = Convert.ToInt32(Console.ReadLine());
                        if (q == 1)
                            break;
                        {
                            Console.Write(thx);
                            Thread.Sleep(100);
                            return;
                        }

                    #endregion
                    
                    #region Zombie
                    
                    case 4:
                        Console.Clear();
                        Console.WriteLine("You have encountered a zombie !");
                        y = new Aggressive(MobType.ZOMBIE, mobLife, "GRAOUUUUU", new Blocks(Blocks.BlockType.ROTTEN_FLESH, 3), 7);
                        for (i = 1; i < 100; i++)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(Zombie + "\n" + "\n");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("{0} has {1} hp", y.Type, y.Hp);
                            Console.WriteLine("You have {0} hp and {1} potion", player.Hp, potion);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(attack);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write(heal);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(RunAway + "\n");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("What do you wanna do ? : ");
                            q = Convert.ToInt32(Console.ReadLine());
                            Console.Clear();
                            if (q == 1)
                            {
                                Attack(y);
                                if (i > 1)
                                {
                                    y.Attack(player);
                                    if (player.isKo)
                                        break;
                                }
                                if (y.IsKO)
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine(Zombie + "\n");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("Zombie has been killed in {0} hits", i);
                                    Thread.Sleep(200);
                                    i = 100;
                                }
                            }
                            
                            else if (q == 2)
                            {
                                if (potion < 1)
                                    Console.WriteLine("No potion left");
                                else
                                {
                                    player.Heal(20);
                                    potion -= 1;
                                }
                            }
                            else
                            {
                                if (leave > 3)
                                    Console.Write("You can't leave !");
                                else
                                {
                                    leave += 1;
                                    break;
                                }
                            }
                        }

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(Continue);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(QUIT + "\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("What do you wanna do ? : ");
                        q = Convert.ToInt32(Console.ReadLine());
                        if (q == 1)
                            break;
                        {
                            Console.Write(thx);
                            Thread.Sleep(100);
                            return;
                        }
                    
                    #endregion
                    
                    #region CREEPER
                    
                    case 5:
                        Console.Clear();
                        Console.WriteLine("You have encountered a creeper !");
                        y = new Aggressive(MobType.CREEPER, mobLife, "pssschhhh", new Blocks(Blocks.BlockType.GUN_POWDER, 3), 19);
                        for (i = 1; i < 100; i++)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write(Creeper + "\n" + "\n");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("{0} has {1} hp", y.Type, y.Hp);
                            Console.WriteLine("You have {0} hp and {1} potion", player.Hp, potion);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(attack);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write(heal);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(RunAway + "\n");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("What do you wanna do ? : ");
                            q = Convert.ToInt32(Console.ReadLine());
                            Console.Clear();
                            if (q == 1)
                            {
                                Attack(y);
                                if (i > 4)
                                {
                                    y.Attack(player);
                                    if (player.isKo)
                                        break;
                                }
                                if (y.IsKO)
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine(Creeper + "\n");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("Creeper has been killed in {0} hits", i);
                                    Thread.Sleep(200);
                                    i = 100;
                                }
                            }
                            if (q == 2)
                            {
                                if (potion < 1)
                                    Console.WriteLine("No potion left");
                                else
                                {
                                    player.Heal(20);
                                    potion -= 1;
                                }
                            }
                            else
                            {
                                if (leave > 3)
                                    Console.Write("You can't leave !");
                                else
                                {
                                    leave += 1;
                                    break;  
                                }
                            }
                        }
                        
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(Continue);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(QUIT + "\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("What do you wanna do ? : ");
                        q = Convert.ToInt32(Console.ReadLine());
                        if (q == 1)
                            break;
                        {
                            Console.Write(thx);
                            Thread.Sleep(100);
                            return;
                        }
                    
                    #endregion
                    
                }
            } while (player.isKo == false);
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(died);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(REPLAY);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(QUIT + "\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("What do you wanna do ? : ");
            q = Convert.ToInt32(Console.ReadLine());
            if (q == 1)
            {}
            else
            {
                Console.Clear();
                Console.Write(thx);
                Thread.Sleep(100);
            }
        }
        
        
        public void Crafting()
        {
            int question, question2;

            Console.WriteLine("Hi, welcome into the crafting menu ! How can I help you ?");
            Console.WriteLine("1 - CRAFT       2 - EXIT");
            question = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            if (question == 1)
            {
                if (CountInInventory(Blocks.BlockType.CRAFTING_TABLE) < 1)
                {
                    Console.WriteLine("You cannot craft without a crafting table. Do you wanna craft one ?");
                    Console.WriteLine("1 - YES \n2 - NO");
                    question = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    if (question == 1)
                    {
                        if (CountInInventory(Blocks.BlockType.PLANKS) > 3)
                        {
                            AddInInventory(new Blocks(Blocks.BlockType.CRAFTING_TABLE, 1));
                            RemoveInInventory(new Blocks(Blocks.BlockType.PLANKS, 4));
                            Console.WriteLine(
                                "Crafting table has been crafted with success ! What do you wanna do now ?");
                            Console.WriteLine("1 - CRAFT       2 - EXIT");
                            question = Convert.ToInt32(Console.ReadLine());
                            Console.Clear();
                            if (question == 1)
                                Crafting();
                        }
                        else
                        {
                            if (4 - CountInInventory(Blocks.BlockType.PLANKS) == 1)
                                Console.WriteLine("You need 1 more plank");
                            else
                                Console.WriteLine("You need {0} more planks",
                                    6 - CountInInventory(Blocks.BlockType.PLANKS));
                        }
                    }
                }
                else
                {
                    Console.WriteLine("What do you need to craft ?");
                    Console.WriteLine("\n1 - STONE_BUTTON \n2 - DOOR \n3 - WOODEN_STAIR \n4 - COBBLESTONE_STAIR");
                    question = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    switch (question)
                    {
                        case 1:
                            if (CountInInventory(Blocks.BlockType.COBBLESTONE) > 0)
                            {
                                AddInInventory(new Blocks(Blocks.BlockType.STONE_BUTTON, 1));
                                RemoveInInventory(new Blocks(Blocks.BlockType.COBBLESTONE, 1));
                                Console.WriteLine(
                                    "Stone Button has been crafted with success ! What do you wanna do now ?");
                                Console.WriteLine("1 - CRAFT       2 - EXIT");
                                question = Convert.ToInt32(Console.ReadLine());
                                Console.Clear();
                                if (question == 1)
                                    Crafting();
                            }
                            else
                                Console.WriteLine("You need 1 more cobblestone");

                            break;

                        case 2:
                            if (CountInInventory(Blocks.BlockType.PLANKS) > 5)
                            {
                                AddInInventory(new Blocks(Blocks.BlockType.DOOR, 3));
                                RemoveInInventory(new Blocks(Blocks.BlockType.PLANKS, 6));
                                Console.WriteLine("Doors has been crafted with success ! What do you wanna do now ?");
                                Console.WriteLine("1 - CRAFT       2 - EXIT");
                                question = Convert.ToInt32(Console.ReadLine());
                                Console.Clear();
                                if (question == 1)
                                    Crafting();
                            }
                            else
                            {
                                if (6 - CountInInventory(Blocks.BlockType.PLANKS) == 1)
                                    Console.WriteLine("You need 1 more plank");
                                else
                                    Console.WriteLine("You need {0} more planks",
                                        6 - CountInInventory(Blocks.BlockType.PLANKS));
                            }

                            break;

                        case 3:
                            if (CountInInventory(Blocks.BlockType.PLANKS) > 5)
                            {
                                AddInInventory(new Blocks(Blocks.BlockType.WOODEN_STAIR, 4));
                                RemoveInInventory(new Blocks(Blocks.BlockType.PLANKS, 6));
                                Console.WriteLine(
                                    "Wooden stairs has been crafted with success ! What do you wanna do now ?");
                                Console.WriteLine("1 - CRAFT       2 - EXIT");
                                question = Convert.ToInt32(Console.ReadLine());
                                Console.Clear();
                                if (question == 1)
                                    Crafting();
                            }
                            else
                            {
                                if (6 - CountInInventory(Blocks.BlockType.PLANKS) == 1)
                                    Console.WriteLine("You need 1 more plank");
                                else
                                    Console.WriteLine("You need {0} more planks",
                                        6 - CountInInventory(Blocks.BlockType.PLANKS));
                            }

                            break;

                        case 4:
                            if (CountInInventory(Blocks.BlockType.COBBLESTONE) > 5)
                            {
                                AddInInventory(new Blocks(Blocks.BlockType.COBBLESTONE_STAIR, 4));
                                RemoveInInventory(new Blocks(Blocks.BlockType.COBBLESTONE, 6));
                                Console.WriteLine(
                                    "Cobblestone stairs has been crafted with success ! What do you wanna do now ?");
                                Console.WriteLine("1 - CRAFT       2 - EXIT");
                                question = Convert.ToInt32(Console.ReadLine());
                                Console.Clear();
                                if (question == 1)
                                    Crafting();
                            }
                            else
                            {
                                if (6 - CountInInventory(Blocks.BlockType.COBBLESTONE) == 1)
                                    Console.WriteLine("You need 1 more cobblestone");
                                else
                                    Console.WriteLine("You need {0} more cobblestones",
                                        6 - CountInInventory(Blocks.BlockType.COBBLESTONE));
                            }

                            break;

                    }

                    Console.WriteLine("Do you wanna craft again ??");
                    Console.WriteLine("1 - YES \n2 - NO");
                    question = Convert.ToInt32(Console.ReadLine());

                    if (question == 1)
                    {
                        Crafting();
                    }
                    else
                    {
                        Console.WriteLine("Do you wanna display your inventory ?");
                        Console.WriteLine("1 - YES \n2 - NO");
                        question2 = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        if (question2 == 1)
                        {
                            DisplayInventory();
                        }
                    }
                }
            }
        }

        public void BuildAnHouse()
        {
            Console.Clear();
            List<string> text = new List<string>();
            int count;
            int craft;
            bool temp = true;
            string house = @"                         
                                 
                            ________[_]________     
                           /\        ______    \  
                          //_\       \    /\    \  
                         //___\       \__/  \    \
                        //_____\       \ |[]|     \
                       //_______\       \|__|      \          This is your new house !
                      /XXXXXXXXXX\                  \
                     /_I_II  I__I_\__________________\
                       I_I|  I__I_____[]_|_[]_____I
                       I_II  I__I_____[]_|_[]_____I
                       I II__I  I     XXXXXXX     I
                    ~~~~~""   ""~~~~~~~~~~~~~~~~~~~~~~~~""";

            if (CountInInventory(Blocks.BlockType.DOOR) < 2)
            {
                if (2 - CountInInventory(Blocks.BlockType.DOOR) == 1)
                    text.Add("1 more door");
                else
                    text.Add("2 more doors");
                temp = false;
            }

            if (CountInInventory(Blocks.BlockType.STONE_BUTTON) < 2)
            {
                if (2 - CountInInventory(Blocks.BlockType.STONE_BUTTON) == 1)
                    text.Add("1 more stone button");
                else
                    text.Add("2 more stone buttons");
                temp = false;
            }

            if (CountInInventory(Blocks.BlockType.COBBLESTONE) < 16)
            {
                if (16 - CountInInventory(Blocks.BlockType.COBBLESTONE) == 1)
                    text.Add("1 more cobblestone");
                else
                {
                    count = 16 - CountInInventory(Blocks.BlockType.COBBLESTONE);
                    text.Add(count + " more planks");
                }

                temp = false;
            }

            if (CountInInventory(Blocks.BlockType.PLANKS) < 16)
            {
                if (16 - CountInInventory(Blocks.BlockType.PLANKS) == 1)
                    text.Add(" 1 more plank");
                else
                {
                    count = 16 - CountInInventory(Blocks.BlockType.PLANKS);
                    text.Add(count + " more planks");
                }

                temp = false;
            }

            if (CountInInventory(Blocks.BlockType.WOODEN_STAIR) < 6)
            {
                if (6 - CountInInventory(Blocks.BlockType.WOODEN_STAIR) == 1)
                    text.Add("1 more wooden stair");
                else
                {
                    count = 6 - CountInInventory(Blocks.BlockType.WOODEN_STAIR);
                    text.Add(count + " more wooden stairs");
                }

                temp = false;
            }

            if (CountInInventory(Blocks.BlockType.COBBLESTONE_STAIR) < 6)
            {
                if (6 - CountInInventory(Blocks.BlockType.COBBLESTONE_STAIR) == 1)
                    text.Add("1 more cobblestone stair");
                else
                {
                    count = 6 - CountInInventory(Blocks.BlockType.COBBLESTONE_STAIR);
                    text.Add(count + " more cobblestone stairs");
                }

                temp = false;
            }

            if (temp)
                Console.Write(house);
            else
            {
                Console.WriteLine(" \n \nTo build your house, you need : \n");
                foreach (var i in text)
                {
                    Console.WriteLine(i);
                }

                Console.WriteLine("Do you wanna craft something ?");
                Console.WriteLine("1 - YES       2 - NO");
                craft = Convert.ToInt32(Console.ReadLine());
                if (craft == 1)
                    Crafting();
            }
        }
        #endregion
    }
}


