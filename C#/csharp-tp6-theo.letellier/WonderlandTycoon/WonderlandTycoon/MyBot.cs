using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace WonderlandTycoon
{
    public class MyBot : Bot
    {
        public List<object> Constructionsz = new List<object>
        {
            (0, Building.BuildingType.HOUSE, 250), (1, Building.BuildingType.HOUSE, 750), (2, Building.BuildingType.HOUSE, 3000), (3, Building.BuildingType.HOUSE, 10000),
            (0, Building.BuildingType.SHOP, 300), (1, Building.BuildingType.SHOP, 2500), (2, Building.BuildingType.SHOP, 10000), (3, Building.BuildingType.SHOP, 50000),
            (0, Building.BuildingType.ATTRACTION, 10000), (1, Building.BuildingType.ATTRACTION, 5000), (2, Building.BuildingType.ATTRACTION, 10000), (3, Building.BuildingType.ATTRACTION, 45000)
        };
        
        internal class Constructions
        {
            private int level;
            private Building.BuildingType build;
            private int price;
           
  
            public Constructions(int level, Building.BuildingType build, int price)
            {
                this.level = level;
                this.build = build;
                this.price = price;
            }
            
            List<Constructions> Constructionss = new List<Constructions> {
                (0, Building.BuildingType.HOUSE, 250), (1, Building.BuildingType.HOUSE, 750), (2, Building.BuildingType.HOUSE, 3000), (3, Building.BuildingType.HOUSE, 10000),
                (0, Building.BuildingType.SHOP, 300), (1, Building.BuildingType.SHOP, 2500), (2, Building.BuildingType.SHOP, 10000), (3, Building.BuildingType.SHOP, 50000),
                (0, Building.BuildingType.ATTRACTION, 10000), (1, Building.BuildingType.ATTRACTION, 5000), (2, Building.BuildingType.ATTRACTION, 10000), (3, Building.BuildingType.ATTRACTION, 45000)
            };
            
            
        }
        
        

        public override void Start(Game game)
        {
            // Nothing to do...
        }

        public override void Update(Game game)
        {
            
            if (game.Map.GetAttractiveness() < game.Map.GetHousing())
                ;
            
        }

        public override void End(Game game)
        {
            // Nothing to do...
        }
        
    }
}