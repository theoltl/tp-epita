using System;

namespace WhiteRabbit
{
    internal class Program
    {
     
     //Return the current time in the real world
        public static void WhatTimeIsIt()
        {
            int hour = DateTime.Now.Hour;
            int minute = DateTime.Now.Minute;
            Console.WriteLine("Il est " + hour + ":" + minute);
        }
        
      
        //Return the Wonderland quarter
        public static uint WhatQuarterIsIt(uint minutes)
        {
            if (minutes == 0 || minutes > 45 )
            {
                return 0;
            }
            else if (minutes < 16)
            {
                return 15;
            }
            else if (minutes < 31 )
            {
                return 30;
            }
            else
            {
                return 45;
            }
        }
        
        
        //Return the Wonderland hour
        public static uint WhatHourIsIt(uint hours)
        {
            if (hours < 3 || hours > 11 && hours < 15)
            {
                return 12;
            }
            else if (hours < 8 || hours > 14 && hours < 20)
            {
                return 17;
            }
            else
            {
                return 23;
            }
        }

        
        //Display the Wonderland time with a clock.
        public static void DisplayWonderlandTime(int hours, int minutes)
        {

         #region Horloges

         string noonSharp = @"          
        _____
     _.'_____`._
   .'.-'  12 `-.`.
  /,' 11      1 `.\
 // 10    |     2 \\
;;        |        ::
|| 9      O      3 ||
::                 ;;
 \\ 8           4 //
  \`. 7       5 ,'/
   '.`-.__6__.-'.'
    ((-._____.-))
    _))       ((_
   '--'SSt    '--";

         string noonOneQuarter = @"     
        _____
     _.'_____`._
   .'.-'  12 `-.`.
  /,' 11      1 `.\
 // 10          2 \\
;;        |        ::
|| 9      O----  3 ||
::                 ;;
 \\ 8           4 //
  \`. 7       5 ,'/
   '.`-.__6__.-'.'
    ((-._____.-))
    _))       ((_
   '--'SSt    '--";
         string noonTwoQuarter = @"      
        _____
     _.'_____`._
   .'.-'  12 `-.`.
  /,' 11      1 `.\
 // 10          2 \\
;;        |        ::
|| 9      O      3 ||
::        |        ;;
 \\ 8     |     4 //
  \`. 7       5 ,'/
   '.`-.__6__.-'.'
    ((-._____.-))
    _))       ((_
   '--'SSt    '--";
         string noonThreeQuarter = @"     
        _____
     _.'_____`._
   .'.-'  12 `-.`.
  /,' 11      1 `.\
 // 10          2 \\
;;        |        ::
|| 9  ----O      3 ||
::                 ;;
 \\ 8           4 //
  \`. 7       5 ,'/
   '.`-.__6__.-'.'
    ((-._____.-))
    _))       ((_
   '--'SSt    '--";
         string FiveSharp = @"          
        _____
     _.'_____`._
   .'.-'  12 `-.`.
  /,' 11      1 `.\
 // 10    |     2 \\
;;        |        ::
|| 9      O      3 ||
::         \       ;;
 \\ 8           4 //
  \`. 7       5 ,'/
   '.`-.__6__.-'.'
    ((-._____.-))
    _))       ((_
   '--'SSt    '--";
         string FiveOneQuarter = @"      
        _____
     _.'_____`._
   .'.-'  12 `-.`.
  /,' 11      1 `.\
 // 10          2 \\
;;                 ::
|| 9      O----  3 ||
::         \       ;;
 \\ 8           4 //
  \`. 7       5 ,'/
   '.`-.__6__.-'.'
    ((-._____.-))
    _))       ((_
   '--'SSt    '--";
         string FiveTwoQuarter = @"      
        _____
     _.'_____`._
   .'.-'  12 `-.`.
  /,' 11      1 `.\
 // 10          2 \\
;;                 ::
|| 9      O      3 ||
::        |\       ;;
 \\ 8     |     4 //
  \`. 7       5 ,'/
   '.`-.__6__.-'.'
    ((-._____.-))
    _))       ((_
   '--'SSt    '--";
         string FiveThreeQuarter = @"  
        _____
     _.'_____`._
   .'.-'  12 `-.`.
  /,' 11      1 `.\
 // 10          2 \\
;;                 ::
|| 9  ----O      3 ||
::         \       ;;
 \\ 8           4 //
  \`. 7       5 ,'/
   '.`-.__6__.-'.'
    ((-._____.-))
    _))       ((_
   '--'SSt    '--";
         string ElevenSharp = @"      
        _____
     _.'_____`._
   .'.-'  12 `-.`.
  /,' 11      1 `.\
 // 10    |     2 \\
;;       \|        ::
|| 9      O      3 ||
::                 ;;
 \\ 8           4 //
  \`. 7       5 ,'/
   '.`-.__6__.-'.'
    ((-._____.-))
    _))       ((_
   '--'SSt    '--";
         string ElevenOneQuarter = @"   
        _____
     _.'_____`._
   .'.-'  12 `-.`.
  /,' 11      1 `.\
 // 10          2 \\
;;       \         ::
|| 9      O----  3 ||
::                 ;;
 \\ 8           4 //
  \`. 7       5 ,'/
   '.`-.__6__.-'.'
    ((-._____.-))
    _))       ((_
   '--'SSt    '--";
         string ElevenTwoQuarter = @"   
        _____
     _.'_____`._
   .'.-'  12 `-.`.
  /,' 11      1 `.\
 // 10          2 \\
;;       \         ::
|| 9      O      3 ||
::        |        ;;
 \\ 8     |     4 //
  \`. 7       5 ,'/
   '.`-.__6__.-'.'
    ((-._____.-))
    _))       ((_
   '--'SSt    '--";
         string ElevenThreeQuarter = @" 
        _____
     _.'_____`._
   .'.-'  12 `-.`.
  /,' 11      1 `.\
 // 10          2 \\
;;       \         ::
|| 9  ----O      3 ||
::                 ;;
 \\ 8           4 //
  \`. 7       5 ,'/
   '.`-.__6__.-'.'
    ((-._____.-))
    _))       ((_
   '--'SSt    '--";

         #endregion
         
         uint heure = WhatHourIsIt((uint) hours);
         uint min = WhatQuarterIsIt((uint) minutes);

         switch (heure)
         {
          case 12 when min == 0:
           Console.WriteLine(noonSharp);
           break;

          case 12 when min == 15:
           Console.WriteLine(noonOneQuarter);
           break;

          case 12 when min == 30:
           Console.WriteLine(noonTwoQuarter);
           break;

          case 12 when min == 45:
           Console.WriteLine(noonThreeQuarter);
           break;

          case 17 when min == 0:
           Console.WriteLine(FiveSharp);
           break;

          case 17 when min == 15:
           Console.WriteLine(FiveOneQuarter);
           break;

          case 17 when min == 30:
           Console.WriteLine(FiveTwoQuarter);
           break;

          case 17 when min == 45:
           Console.WriteLine(FiveThreeQuarter);
           break;

          case 23 when min == 0:
           Console.WriteLine(ElevenSharp);
           break;
          
          case 23 when min == 15:
           Console.WriteLine(ElevenOneQuarter);
           break;

          case 23 when min == 30:
           Console.WriteLine(ElevenTwoQuarter);
           break;

          case 23 when min == 45:
           Console.WriteLine(ElevenThreeQuarter);
           break;
         }
        }

        
        //Display the Rabbit according to the current time but in the Wonderland.
        public static void RabbitWhatTimeIsIt()
        {
         int hour = DateTime.Now.Hour;
         int minute = DateTime.Now.Minute;
         uint heure = WhatHourIsIt((uint) hour);

         #region Rabbits

         string NonLateRabbit = @"
             ,
            /|      __
           / |   ,-~ /
          Y :|  //  /
          | jj /( .^
          >-'~'-v'
         /       Y
        jo  o    |
       ( ~T~     j
        >._-' _./
       /   '~'  |
      Y     _,  |
     /| ;-'~ _  l
    / l/ ,-'~    \
    \//\/      .- \
     Y        /    Y--o
     l       I     !
     ]\      _\    /'\ 
    (' ~----( ~   Y.  )
~~~~~~~~~~~~~~~~~~~~~~~~~~
I'm late ! I'm late ! For a very important date ! No time to say hello ,
goodbye ! I'm late ! I'm late ! I'm late !";
         
         string LateRabbit = @"      
          ___      __
         /_  |   ,-~ /
          Y :|  //  /
          | jj /( .^
          >-'~'-v'
         /       Y
        jx  x    |
       ( ~T~     j
        >._-' _./
       /   '~'  |
      Y     _,  |
     /| ;-'~ _  l
    / l/ ,-'~    \
    \//\/      .- \
     Y        /    Y--o
     l       I     !
     ]\      _\    /'\ 
    (' ~----( ~   Y.  )
~~~~~~~~~~~~~~~~~~~~~~~~~~
You 're late , you 're late ! You need to submit your work . You 're late !";
          
         #endregion

         if (heure < 23)
         {
          DisplayWonderlandTime(hour, minute);
          Console.WriteLine(NonLateRabbit);
         }
         else
         {
          DisplayWonderlandTime(hour, minute);
          Console.WriteLine(LateRabbit);
         }

        }
        
        
        //BONUS !!
        
        #region Bonus!
        
        //Display the Wonderland time with a watch.
        public static void DisplayWonderlandTimeR(int hours, int minutes)
        {
         #region Montre
        string MnoonSharp = @"
       ,--.-----.--.
       |--|-----|--|
       |--|     |--|
       |  |-----|  |
     __|--|     |--|__
    /  |  |-----|  |  \
   /   \__|-----|__/   \
  /   ______---______   \/\
 /   /               \   \/
{   /     _     _   _ \   }
|  {   |  _| . | | | | }  |-,
|  |   | |_  . |_| |_| |  | |
|  {                   }  |-'
{   \                 /   }
 \   `------___------'   /\
  \     __|-----|__     /\/
   \   /  |-----|  \   /
    \  |--|     |--|  /
     --|  |-----|  |--
       |--|     |--|
       |--|-----|--|
       `--'-----`--'";

        string MnoonOneQuarter = @"
       ,--.-----.--.
       |--|-----|--|
       |--|     |--|
       |  |-----|  |
     __|--|     |--|__
    /  |  |-----|  |  \
   /   \__|-----|__/   \
  /   ______---______   \/\
 /   /               \   \/
{   /     _         _ \   }
|  {   |  _| .   | |_  }  |-,
|  |   | |_  .   |  _| |  | |
|  {                   }  |-'
{   \                 /   }
 \   `------___------'   /\
  \     __|-----|__     /\/
   \   /  |-----|  \   /
    \  |--|     |--|  /
     --|  |-----|  |--
       |--|     |--|
       |--|-----|--|
       `--'-----`--'";
        
        string MnoonTwoQuarter = @"
       ,--.-----.--.
       |--|-----|--|
       |--|     |--|
       |  |-----|  |
     __|--|     |--|__
    /  |  |-----|  |  \
   /   \__|-----|__/   \
  /   ______---______   \/\
 /   /               \   \/
{   /     _     _   _ \   }
|  {   |  _| .  _| | | }  |-,
|  |   | |_  .  _| |_| |  | |
|  {                   }  |-'
{   \                 /   }
 \   `------___------'   /\
  \     __|-----|__     /\/
   \   /  |-----|  \   /
    \  |--|     |--|  /
     --|  |-----|  |--
       |--|     |--|
       |--|-----|--|
       `--'-----`--'";
        
        string MnoonThreeQuarter = @"
       ,--.-----.--.
       |--|-----|--|
       |--|     |--|
       |  |-----|  |
     __|--|     |--|__
    /  |  |-----|  |  \
   /   \__|-----|__/   \
  /   ______---______   \/\
 /   /               \   \/
{   /     _         _ \   }
|  {   |  _| . |_| |_  }  |-,
|  |   | |_  .   |  _| |  | |
|  {                   }  |-'
{   \                 /   }
 \   `------___------'   /\
  \     __|-----|__     /\/
   \   /  |-----|  \   /
    \  |--|     |--|  /
     --|  |-----|  |--
       |--|     |--|
       |--|-----|--|
       `--'-----`--'";
        
        string MFiveSharp = @"
       ,--.-----.--.
       |--|-----|--|
       |--|     |--|
       |  |-----|  |
     __|--|     |--|__
    /  |  |-----|  |  \
   /   \__|-----|__/   \
  /   ______---______   \/\
 /   /               \   \/
{   /     _     _   _ \   }
|  {   |   | . | | | | }  |-,
|  |   |   | . |_| |_| |  | |
|  {                   }  |-'
{   \                 /   }
 \   `------___------'   /\
  \     __|-----|__     /\/
   \   /  |-----|  \   /
    \  |--|     |--|  /
     --|  |-----|  |--
       |--|     |--|
       |--|-----|--|
       `--'-----`--'";
        
        string MFiveOneQuarter = @"
       ,--.-----.--.
       |--|-----|--|
       |--|     |--|
       |  |-----|  |
     __|--|     |--|__
    /  |  |-----|  |  \
   /   \__|-----|__/   \
  /   ______---______   \/\
 /   /               \   \/
{   /     _         _ \   }
|  {   |   | .   | |_  }  |-,
|  |   |   | .   |  _| |  | |
|  {                   }  |-'
{   \                 /   }
 \   `------___------'   /\
  \     __|-----|__     /\/
   \   /  |-----|  \   /
    \  |--|     |--|  /
     --|  |-----|  |--
       |--|     |--|
       |--|-----|--|
       `--'-----`--'";
        
        string MFiveTwoQuarter = @"
       ,--.-----.--.
       |--|-----|--|
       |--|     |--|
       |  |-----|  |
     __|--|     |--|__
    /  |  |-----|  |  \
   /   \__|-----|__/   \
  /   ______---______   \/\
 /   /               \   \/
{   /     _     _   _ \   }
|  {   |   | .  _| | | }  |-,
|  |   |   | .  _| |_| |  | |
|  {                   }  |-'
{   \                 /   }
 \   `------___------'   /\
  \     __|-----|__     /\/
   \   /  |-----|  \   /
    \  |--|     |--|  /
     --|  |-----|  |--
       |--|     |--|
       |--|-----|--|
       `--'-----`--'";
        
        string MFiveThreeQuarter = @"
       ,--.-----.--.
       |--|-----|--|
       |--|     |--|
       |  |-----|  |
     __|--|     |--|__
    /  |  |-----|  |  \
   /   \__|-----|__/   \
  /   ______---______   \/\
 /   /               \   \/
{   /     _         _ \   }
|  {   |   | . |_| |_  }  |-,
|  |   |   | .   |  _| |  | |
|  {                   }  |-'
{   \                 /   }
 \   `------___------'   /\
  \     __|-----|__     /\/
   \   /  |-----|  \   /
    \  |--|     |--|  /
     --|  |-----|  |--
       |--|     |--|
       |--|-----|--|
       `--'-----`--'";
        
        string MElevenSharp = @"
       ,--.-----.--.
       |--|-----|--|
       |--|     |--|
       |  |-----|  |
     __|--|     |--|__
    /  |  |-----|  |  \
   /   \__|-----|__/   \
  /   ______---______   \/\
 /   /               \   \/
{   / _   _     _   _ \   }
|  {  _|  _| . | | | | }  |-,
|  | |_   _| . |_| |_| |  | |
|  {                   }  |-'
{   \                 /   }
 \   `------___------'   /\
  \     __|-----|__     /\/
   \   /  |-----|  \   /
    \  |--|     |--|  /
     --|  |-----|  |--
       |--|     |--|
       |--|-----|--|
       `--'-----`--'";
        
        string MElevenOneQuarter = @"
       ,--.-----.--.
       |--|-----|--|
       |--|     |--|
       |  |-----|  |
     __|--|     |--|__
    /  |  |-----|  |  \
   /   \__|-----|__/   \
  /   ______---______   \/\
 /   /               \   \/
{   / _   _         _ \   }
|  {  _|  _| .   | |_  }  |-,
|  | |_   _| .   |  _| |  | |
|  {                   }  |-'
{   \                 /   }
 \   `------___------'   /\
  \     __|-----|__     /\/
   \   /  |-----|  \   /
    \  |--|     |--|  /
     --|  |-----|  |--
       |--|     |--|
       |--|-----|--|
       `--'-----`--'";
        
        string MElevenTwoQuarter = @"
       ,--.-----.--.
       |--|-----|--|
       |--|     |--|
       |  |-----|  |
     __|--|     |--|__
    /  |  |-----|  |  \
   /   \__|-----|__/   \
  /   ______---______   \/\
 /   /               \   \/
{   / _   _     _   _ \   }
|  {  _|  _| .  _| | | }  |-,
|  | |_   _| .  _| |_| |  | |
|  {                   }  |-'
{   \                 /   }
 \   `------___------'   /\
  \     __|-----|__     /\/
   \   /  |-----|  \   /
    \  |--|     |--|  /
     --|  |-----|  |--
       |--|     |--|
       |--|-----|--|
       `--'-----`--'";
        
        string MElevenThreeQuarter = @"
       ,--.-----.--.
       |--|-----|--|
       |--|     |--|
       |  |-----|  |
     __|--|     |--|__
    /  |  |-----|  |  \
   /   \__|-----|__/   \
  /   ______---______   \/\
 /   /               \   \/
{   / _   _         _ \   }
|  {  _|  _| . |_| |_  }  |-,
|  | |_   _| .   |  _| |  | |
|  {                   }  |-'
{   \                 /   }
 \   `------___------'   /\
  \     __|-----|__     /\/
   \   /  |-----|  \   /
    \  |--|     |--|  /
     --|  |-----|  |--
       |--|     |--|
       |--|-----|--|
       `--'-----`--'";

        #endregion

        uint heure = WhatHourIsIt((uint) hours);
        uint min = WhatQuarterIsIt((uint) minutes);
        
        switch (heure)
         {
          case 12 when min == 0:
           Console.WriteLine(MnoonSharp);
           break;

          case 12 when min == 15:
           Console.WriteLine(MnoonOneQuarter);
           break;

          case 12 when min == 30:
           Console.WriteLine(MnoonTwoQuarter);
           break;

          case 12 when min == 45:
           Console.WriteLine(MnoonThreeQuarter);
           break;

          case 17 when min == 0:
           Console.WriteLine(MFiveSharp);
           break;

          case 17 when min == 15:
           Console.WriteLine(MFiveOneQuarter);
           break;

          case 17 when min == 30:
           Console.WriteLine(MFiveTwoQuarter);
           break;

          case 17 when min == 45:
           Console.WriteLine(MFiveThreeQuarter);
           break;

          case 23 when min == 0:
           Console.WriteLine(MElevenSharp);
           break;
          
          case 23 when min == 15:
           Console.WriteLine(MElevenOneQuarter);
           break;

          case 23 when min == 30:
           Console.WriteLine(MElevenTwoQuarter);
           break;

          case 23 when min == 45:
           Console.WriteLine(MElevenThreeQuarter);
           break;
         }
        }
        
        
        //Display the student according to the current time but in the Wonderland.
        public static void RabbitWhatTimeIsItV2()
        {
         int hour = DateTime.Now.Hour;
         int minute = DateTime.Now.Minute;
         uint heure = WhatHourIsIt((uint) hour);

         #region Rabbitv2


         string SleepyRabbit = @"
                                  Z         
                               Z                
     __     |\        
    \ ~-ˎ   | \            Z
     \  \\  |: Y      
     ^. )\ įį  |        Z
      ""v-""~""->     z 
      Y       /    z 
      |    _  _į    
      į     ~T~ )   
       /._ '-_.> 
        | ^ |         .--------------.    
     __.| `''.__      | \              |     
  .~~   `---'   ~.    |  .             :     
 /                `   |   `-.__________)     
|             ~       |  :             :   
|                     |  :  |              
|    _                |     |   [ ##   :   
 \    ~~-.            |  ,   oo_______.'   
  `_   ( \) _____/~~~~ `--___              
  | ~`-)  ) `-.   `---   ( - a:f -         
  |   '///`  | `-.                         
  |     | |  |    `-.                      
  |     | |  |       `-.                   
  |     | |\ |                             
  |     | | \|                             
   `-.  | |  |                             
      `-| ' ";
        
        string Rabbit = @"
                                                                             
     __     |\        
    \ ~-ˎ   | \            
     \  \\  |: Y      
     ^. )\ įį  |       
     ""v-""~""->      
      Y       /      YOU ARE LATE !! YOU NEED TO SUBMIT NOW !!
      |    O  Oį    
      į     ~T~ )   
       /._ '-_.> 
        | ^ |         .--------------.    
     __.| `''.__      | \              |     
  .~~   `---'   ~.    |  .             :     
 /                `   |   `-.__________)     
|             ~       |  :             :   
|                     |  :  |              
|    _                |     |   [ ##   :   
 \    ~~-.            |  ,   oo_______.'   
  `_   ( \) _____/~~~~ `--___              
  | ~`-)  ) `-.   `---   ( - a:f -         
  |   '///`  | `-.                         
  |     | |  |    `-.                      
  |     | |  |       `-.                   
  |     | |\ |                             
  |     | | \|                             
   `-.  | |  |                             
      `-| ' ";
        
        #endregion

         if (heure < 23)
         {
          DisplayWonderlandTimeR(hour, minute);
          Console.WriteLine(SleepyRabbit);
         }
         else
         {
          DisplayWonderlandTimeR(hour, minute);
          Console.WriteLine(Rabbit);
         }
        }


        #endregion

        
        //Main
        public static void Main(string[] str)
        {
         RabbitWhatTimeIsItV2();
        }
    } 
}