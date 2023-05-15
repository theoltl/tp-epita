using System;
using System.IO;
using System.Linq;
using System.Net;
using Autochess.PlayerConfiguration;

namespace Autochess
{
    public class Program
    {
        public const float TICK_DURATION = 0.1f;
        public const int MAX_MONEY = 1000;

        private const int MATCH_MAX_DURATION = 5000;

        private const string DefaultItemBankPath = "items.itembank";

        public static int Tick { get; set; }

        public static ItemBank ItemBank;

        static int Main(string[] args)
        {
            try
            {
                ItemBank = Utility.LoadItemBank(DefaultItemBankPath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 3;
            }

            if (args.Length < 2 || args.Length > 4)
            {
                Console.WriteLine("Usage: dotnet Autochess.dll --check config.playerconfig");
                Console.WriteLine("       dotnet Autochess.dll p1.playerconfig p2.playerconfig");
                Console.WriteLine("       dotnet Autochess.dll --generate folder count maxMoney");
                return 2;
            }


            if (args[0].Equals("--generate"))
            {
                ConfigGenerator.GenerateConfigs(args[1], int.Parse(args[2]), int.Parse(args[3]));
                return 0;
            }

            if (args[0].Equals("--check"))
            {
                PlayerConfig p = Serializer.Json.FromFile<PlayerConfig>(args[1]);
                p.CheckValidity(MAX_MONEY);
                return 0;
            }

            bool noWrite = args[^1].Equals("--no-write");


            string p1Path = args[0];
            string p2Path = args[1];


            PlayerConfig playerConfig1 = Serializer.Json.FromFile<PlayerConfig>(p1Path);
            PlayerConfig playerConfig2 = Serializer.Json.FromFile<PlayerConfig>(p2Path);

            playerConfig1.CheckValidity(MAX_MONEY);
            playerConfig2.CheckValidity(MAX_MONEY);

            ActionList.Init(ItemBank);

            Match match = new Match(p1Path, p2Path);

            match.SpawnEntities(playerConfig1, Team.Red);
            match.SpawnEntities(playerConfig2, Team.White);


            Team winningTeam = Team.Red;
            Tick = 0;
            for (; Tick < MATCH_MAX_DURATION; Tick++)
            {
                match.Tick();
                HistoricManipulator.NewTick();

                if (match.IsFinished(out winningTeam))
                    break;
            }

            match.MatchStatistics.Winner = winningTeam;
            match.MatchStatistics.MatchDuration = Tick;

            Console.WriteLine($"Winner is {winningTeam.ToString()} at tick {Tick}");

            if (!noWrite)
            {
                HistoricManipulator.Historic.WinningTeam = winningTeam;
                HistoricManipulator.Save(
                    $"{Path.GetFileNameWithoutExtension(p1Path)}_VS_{Path.GetFileNameWithoutExtension(p2Path)}.historic");
                match.MatchStatistics.ToFile(
                    $"{Path.GetFileNameWithoutExtension(p1Path)}_VS_{Path.GetFileNameWithoutExtension(p2Path)}.stats");
            }

            return (int)winningTeam;
        }
    }
}
