using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Autochess.PlayerConfiguration
{
    public class ConfigGenerator
    {
        public static void GenerateConfigs(string folder, int count, int maxMoney)
        {
            int k = 0;
            for (int i = 0; i < count; k++)
            {
                if (File.Exists(Path.Combine(folder, $"config{k}.playerconfig")))
                    continue;
                GenerateConfig(Path.Combine(folder, $"config{k}.playerconfig"), maxMoney);
                i++;
            }
        }

        private const double EQUIP_ITEMS = 0.7d;

        private static void GenerateConfig(string path, int maxMoney)
        {
            PlayerConfig playerConfig = new PlayerConfig()
                {Entities = new List<EntityInfo>()};

            int count = 0;

            playerConfig.Entities.Add(RandomEntity(ref count, maxMoney));

            while (count < maxMoney)
            {
                Entity.Class c = playerConfig.Entities.Last().Class;
                List<Item> items = Program.ItemBank.Items.FindAll(item =>
                        (item.ItemClass == c || item.ItemClass == Entity.Class.Neutral) && !(item is MainItem))
                    .SelectMany(item => Enumerable.Repeat(item, 2)).ToList();


                while (random.NextDouble() < EQUIP_ITEMS)
                {
                    Shuffle(items);
                    for (int i = 0; i < items.Count; i++)
                    {
                        Item item = items[i];
                        if (item.cost + count < maxMoney)
                        {
                            count += item.cost;
                            playerConfig.Entities.Last().Items.Add(item.Name);
                            items.RemoveAt(i);
                            break;
                        }
                    }
                }

                if (playerConfig.Entities.Count >= PlayerConfig.FREE_ENTITIES)
                {
                    if (count + PlayerConfig.EXTRA_ENTITY_COST > maxMoney ||
                        playerConfig.Entities.Count >= PlayerConfig.MAX_ENTITY_NUMBER)
                        break;

                    count += PlayerConfig.EXTRA_ENTITY_COST;
                }

                playerConfig.Entities.Add(RandomEntity(ref count, maxMoney));
            }

            try
            {
                playerConfig.CheckValidity(maxMoney);
            }
            catch (Exception)
            {
                GenerateConfig(path, maxMoney);
                return;
            }
            
            Serializer.Json.ToFile(playerConfig, path);
        }

        private static Random random = new Random();

        private static EntityInfo RandomEntity(ref int count, int maxMoney)
        {
            Entity.Class c = (Entity.Class) random.Next(1, 4);
            EntityInfo entityInfo = new EntityInfo()
            {
                Class = c,
                Items = new List<string>(),
                Name = names[random.Next(names.Length)],
                InitialPosition = new Vector2(
                    random.Next(100) / 10f,
                    random.Next(100) / 10f),
            };
            if (c != Entity.Class.Neutral)
            {
                if (random.NextDouble() < 0.8f)
                {
                    List<Item> mainItems = Program.ItemBank.Items
                        .FindAll(item => item.ItemClass == c && item is MainItem)
                        .ToList();

                    Shuffle(mainItems);

                    foreach (Item item in mainItems)
                    {
                        if (item.cost + count < maxMoney)
                        {
                            entityInfo.MainItem = item.Name;
                            count += item.cost;
                            break;
                        }
                    }
                }
            }

            return entityInfo;
        }

        private static string[] names =
        {
            "Alice", "Dinah", "Bill", "Pat", "Lory", "Frog-Footman", "Dormouse", "Elsie", "Lacie", "Tillie", "Rose"
        };

        private static void Shuffle<T>(IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
