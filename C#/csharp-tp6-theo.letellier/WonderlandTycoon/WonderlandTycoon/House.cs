using System.Collections.Generic;

namespace WonderlandTycoon
{
    public class House : Building
    {
        public const long BUILD_COST = 250;
        public static readonly long[] UPGRADE_COST = {750, 3000, 10000};
        public static readonly long[] HOUSING = {300, 500, 650, 750};

        private int lvl;
        public int Lvl
        {
            get { return lvl; }
            set { lvl = value; }
        }
        public House()
        {
            this.type = BuildingType.HOUSE;
            this.lvl = 0;
        }
        
        public long Housing()
        {
            return HOUSING[lvl];
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
