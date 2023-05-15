namespace WonderlandTycoon
{
    public class Shop : Building
    {
        public const long BUILD_COST = 300;
        public static readonly long[] UPGRADE_COST = {2500, 10000, 50000};
        public static readonly long[] INCOME = {7, 8, 9, 10};

        private int lvl;
        
        public int Lvl
        {
            get { return lvl; }
        }
        
        public Shop()
        {
            this.type = BuildingType.SHOP;
            this.lvl = 0;
        }
        
        public long Income(long population)
        {
            return INCOME[lvl] * (population / 100);
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
