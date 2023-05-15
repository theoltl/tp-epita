namespace WonderlandTycoon
{
    public class Attraction : Building
    {
        public const long BUILD_COST = 10000;
        public static readonly long[] UPGRADE_COST = {5000, 10000, 45000};
        public static readonly long[] ATTRACTIVENESS = {500, 1000, 1300, 1500};


        private int lvl;

        public int Lvl
        {
            get {return lvl;}
        }

        public Attraction()
        {
            this.type = BuildingType.ATTRACTION;
            this.lvl = 0;
        }

        public long Attractiveness()
        {
            return ATTRACTIVENESS[lvl];
        }

        public bool Upgrade(ref long money)
        {
            if (lvl > 2)
                return false;

            if (money >= UPGRADE_COST[lvl])
            { 
                money -= UPGRADE_COST[lvl];
                ++lvl;
                return true;
            }

            return false;
        }
    }
}
