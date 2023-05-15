using System.Collections.Generic;
using Autochess;
using NUnit.Framework;

namespace AutochessTests.Unit
{
    [TestFixture]
    public class EntityHeal
    {
        private Match _match;

        private Entity _entityRed;

        [SetUp]
        public void SetUp()
        {
            Program.ItemBank = new ItemBank();

            _match = new Match(null, null);
            _entityRed = new Entity(new EntityInfo(), Team.Red);
            _match.AddEntity(_entityRed);
        }

        [Test, Sequential]
        public void CalculateMaxHeal(
            [Values(100, 80, 50, 20)] int initialHealth,
            [Values(0, 20, 50, 50)] int expectedResult)
        {
            _entityRed.Health = initialHealth;
            
            Assert.AreEqual(expectedResult, _entityRed.CalculateMaxHeal(50));
        }

        [Test, Sequential]
        public void Heal(
            [Values(100, 80, 20)] int initialHealth,
            [Values(100, 100, 70)] int expectedResult)
        {
            _entityRed.Health = initialHealth;

            _entityRed.Heal(50);
            
            Assert.AreEqual(expectedResult, _entityRed.Health);
        }
        
        [Test]
        public void TotalHealReceived()
        {
            _entityRed.Health = 20;
            _entityRed.Heal(50);
            Assert.AreEqual(50, _entityRed.EntityStat.TotalHealReceived);
            _entityRed.Heal(50);
            Assert.AreEqual(80, _entityRed.EntityStat.TotalHealReceived);
        }

        [Test]
        public void ExecuteEventAtHeal()
        {
            Entity selfRef = null;
            _entityRed.EquipItem(new Item
            {
                ItemEvents = new List<ActionEvent>
                {
                    new ActionEvent
                    {
                        Moment = ActionEvent.Time.AtHeal,
                        Outcome = new List<ActionEvent.Action>
                        {
                            new ActionEvent.Debug
                            {
                                Target = new ActionEvent.EntitySelector {Self = true},
                                toExecute = unit => selfRef = unit
                            }
                        }
                    }
                }
            });
            
            _entityRed.Heal(50);
            
            Assert.AreEqual(_entityRed, selfRef);
        }
    }
}
