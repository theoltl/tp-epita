namespace WonderlandTycoon
{
    public class Tile
    {
        public enum Biome
        {
            SEA, MOUNTAIN, PLAIN
        }
        private int lvl;
        
        private Biome biome;
        private Building building;
        
        public Biome GetBiome
        {
            get { return biome; }
        }
         
        public Building GetBuilding
        {
            get { return building; }
        }
        
        public int Lvl
        {
            get { return lvl; }
        }
        
        public Tile(Biome b)
        {
            this.biome = b;
            this.building = null;
        }

        public bool Build(ref long money, Building.BuildingType type)
        {
            if (building == null && biome == Biome.PLAIN)
            {
                switch (type)
                {
                    case Building.BuildingType.SHOP:
                        if (Shop.BUILD_COST <= money)
                        {
                            money -= Shop.BUILD_COST;
                            building = new Shop();
                            return true;
                            
                        }
                        break;
                    
                    case Building.BuildingType.HOUSE:
                        if (House.BUILD_COST <= money)
                        {
                            money -= House.BUILD_COST;
                            building = new House();
                            return true;
                        }
                        break;
                    
                    case Building.BuildingType.ATTRACTION:
                        if (Attraction.BUILD_COST <= money)
                        {
                            money -= Attraction.BUILD_COST;
                            building = new Attraction();
                            return true;
                        }

                        break;
                    
                    
                }
            }

            return false;

        }

        public bool Upgrade(ref long money)
        {
            if (building != null)
            {
                switch (building.Type)
                {
                    case Building.BuildingType.ATTRACTION:
                        if (money >= Attraction.UPGRADE_COST[((Attraction) building).Lvl] && ((Attraction) building).Lvl < 4)
                            return ((Attraction) building).Upgrade(ref money);
                        
                        break;
                    
                    case Building.BuildingType.HOUSE:
                        if (money >= House.UPGRADE_COST[((House) building).Lvl] && ((House) building).Lvl < 4)
                            return ((House) building).Upgrade(ref money);
                        
                        break;
                    
                    case Building.BuildingType.SHOP:
                        if (money >= Shop.UPGRADE_COST[((Shop) building).Lvl] && ((Shop) building).Lvl < 4)
                            return ((Shop) building).Upgrade(ref money);
                        
                        break;
                }    
            }
            
            return false;
        }
        
        
        public long GetHousing()
        {
            if (building == null || building.Type != Building.BuildingType.HOUSE)
                return 0;

            return House.HOUSING[lvl];
        }
        
        
        public long GetAttractiveness()
        {
            if (building == null || building.Type != Building.BuildingType.ATTRACTION)
                return 0;

            return Attraction.ATTRACTIVENESS[lvl];
        }
        
        
        public long GetIncome(long population)
        {
            if (building == null || building.Type != Building.BuildingType.SHOP)
                return 0;

            return ((Shop) building).Income(population);
        }

        public bool IsBuildable(Tile tile)
        {
            if (tile.GetBiome == Biome.PLAIN && building == null)
                    return true;
            return false;
        }
    }
}
