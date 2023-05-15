namespace WonderlandTycoon
{
    public class Game
    {
        private long score;
        private long money;
        private int nbRound;
        private int round;
        private Map map;
        
        public long Score
        {
            get { return score; }
        }
        
        
        public long Money
        {
            get { return money; }
        }

        public int NbRound
        {
            get { return nbRound; }
        }


        public int Round
        {
            get { return round; }
        }

        public Map Map
        {
            get { return map; }
        }

        public long Income
        {
            get { return map.GetIncome(map.GetPopulation()); }
        }
        
        public Game(string name, int nbRound, long initialMoney)
        {
            TycoonIO.GameInit(name, nbRound, initialMoney);
            map = new Map(name);
            money = initialMoney;
            this.nbRound = nbRound;
            round = 1;
            score = 0;
        }


        public long Launch(Bot bot)
        {
            bot.Start(this);
            
            while (round < nbRound)
            {
                bot.Update(this);
                Update();
                ++round;
            }
            
            return score;
        }
        
        
        public void Update()
        {
            TycoonIO.GameUpdate();
            long income = map.GetIncome(map.GetPopulation());
            score += income;
            money += income;
        }


        public bool Build(int i, int j, Building.BuildingType type)
        {
            if (map.Build(i, j, ref money, type))
            {
                TycoonIO.GameBuild(i, j, type);
                return true;
            }

            return false;
        }
        
        
        public bool Upgrade(int i, int j)
        {
            if (map.Upgrade(i, j, ref money))
            {
                TycoonIO.GameUpgrade(i, j);
                return true;
            }
            
            return false;
        }
        
        
        
        
    }
}
