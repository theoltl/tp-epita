using System;
using System.Collections.Generic;
using Autochess;
using NUnit.Framework;

namespace AutochessTests
{
    [TestFixture]
    public class PlayerConfigurationExecute
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            Program.ItemBank = new ItemBank()
            {
                Items = new List<Item>()
            };
        }
        
        [Test]
        public void TestAddedToMap([Values(0, 1, 2, 5)] int nb)
        {
            Match match = new Match(null, null);

            List<EntityInfo> Units = new List<EntityInfo>();
            for (int i = 0; i < nb; i++)
                Units.Add(new EntityInfo());
            
            PlayerConfig playerConfig = new PlayerConfig
            {
                Entities = Units
            };
            
            match.SpawnEntities(playerConfig, Team.Red);
            
            Assert.AreEqual(match.Entities.Count ,nb);
        }
        
        [Test]
        public void DifferentClasses([Values] Autochess.Entity.Class unitClass)
        {
            Match match = new Match(null, null);

            PlayerConfig playerConfig = new PlayerConfig
            {
                Entities = new List<EntityInfo>()
                {
                    new EntityInfo()
                    {
                        Class = unitClass
                    }
                }
            };
            
            match.SpawnEntities(playerConfig, Team.Red);
            
            Assert.AreEqual(match.Entities.Count,1);

            Type expectedType = unitClass switch
            {
                Autochess.Entity.Class.Neutral => typeof(Autochess.Entity),
                Autochess.Entity.Class.Warrior => typeof(Warrior),
                Autochess.Entity.Class.Archer => typeof(Archer),
                Autochess.Entity.Class.Mage => typeof(Mage),
                _ => null
            };

            Assert.AreEqual(match.Entities[0].GetType(), expectedType);
        }
        
        
    }
}
