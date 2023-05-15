using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace Autochess
{
    public partial class PlayerConfig
    {
        public const int MAX_ENTITY_NUMBER = 10;

        public const int FREE_ENTITIES = 3;
        public const int EXTRA_ENTITY_COST = 100;

        public static void CheckClass(Entity.Class itemClass, Entity.Class entityClass)
        {
            if (itemClass != Entity.Class.Neutral)
                if (itemClass != entityClass)
                {
                    throw new InvalidDataException("PlayerConfiguration: A " + entityClass + 
                                                    " can't have a " + itemClass + " item.");
                }
        }

        public void CheckValidity(int maxMoney)
        {
            int money;
            if (Entities.Count < 1)
                throw new InvalidDataException(
                    "PlayerConfiguration: There are no entities in this configuration");
            
            if (Entities.Count > MAX_ENTITY_NUMBER)
                throw new InvalidDataException(
                    "PlayerConfiguration: There are too many entities in this configuration");
            
            if (Entities.Count - FREE_ENTITIES <= 0)
                money = 0;
            else
            {
                money = (Entities.Count - FREE_ENTITIES) * 100;
            }

            for (int i = 0; i < Entities.Count; i++)
            {
                int mainItemCount = 1;

                if (Entities[i].MainItem != null)
                {
                    CheckClass(Program.ItemBank.GetItem(Entities[i].MainItem).ItemClass, Entities[i].Class);
                    money += Program.ItemBank.GetItem(Entities[i].MainItem).cost;
                }

                if (money > maxMoney)
                    throw new InvalidDataException(
                        "PlayerConfiguration: Configuration costs too much.");
                
                
                if (Entities[i].Items != null)
                    foreach (var item in Entities[i].Items)
                    {
                        int countObject = 0;

                        foreach (var obj in Entities[i].Items)
                        {
                            if (item == obj)
                                countObject += 1;

                            if (countObject > 2)
                                throw new InvalidDataException(
                                    "PlayerConfiguration: An entity can't have more than 2 of the same item");
                        }

                        CheckClass(Program.ItemBank.GetItem(item).ItemClass, Entities[i].Class);

                        if (Program.ItemBank.GetItem(item).GetType() == typeof(MainItem))
                            mainItemCount += 1;

                        if (mainItemCount > 1)
                        {
                            throw new InvalidDataException(
                                "PlayerConfiguration: An entity can't have more than 1 Main Item");
                        }

                        money += Program.ItemBank.GetItem(item).cost;
                        
                        if (money > maxMoney)
                            throw new InvalidDataException(
                                "PlayerConfiguration: Configuration costs too much.");

                    }

                if (Entities[i].InitialPosition.X > Utility.ARENA_WIDTH || Entities[i].InitialPosition.X < 0 
                    || Entities[i].InitialPosition.Y > Utility.ARENA_WIDTH || Entities[i].InitialPosition.Y < 0)
                    throw new InvalidDataException(
                        "PlayerConfiguration: You can't have entities outside the allowed space");
                
                if (Entities[i].MainItem != null)
                    if (Program.ItemBank.GetItem(Entities[i].MainItem).GetType() != typeof(MainItem))
                        throw new InvalidDataException(
                                "PlayerConfiguration: You can't equip an Item as a Main Item");
                
            }

            for (int i = 0; i < Entities.Count - 1; i++)
            {
                for (int j = i + 1; j < Entities.Count; j++)
                {
                    if(Entities[i].InitialPosition == Entities[j].InitialPosition)
                        throw new InvalidDataException(
                            "PlayerConfiguration: You can't have two entities in the same space");
                }
            }




        }
    }
}
