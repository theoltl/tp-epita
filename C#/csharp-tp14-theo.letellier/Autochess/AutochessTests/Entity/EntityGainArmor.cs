using System.Collections.Generic;
using Autochess;
using NUnit.Framework;

namespace AutochessTests.Unit
{
    [TestFixture]
    public class EntityGainArmor
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
        public void GainArmor(
            [Values(100, 80, 20)] int initialArmor,
            [Values(150, 130, 70)] int expectedResult)
        {
            _entityRed.Armor = initialArmor;

            _entityRed.GainArmor(50);
            
            Assert.AreEqual(expectedResult, _entityRed.Armor);
        }

        [Test]
        public void ExecuteEventAtGainArmor()
        {
            Entity selfRef = null;
            _entityRed.EquipItem(new Item
            {
                ItemEvents = new List<ActionEvent>
                {
                    new ActionEvent
                    {
                        Moment = ActionEvent.Time.AtGainArmor,
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
            
            _entityRed.GainArmor(50);
            
            Assert.AreEqual(_entityRed, selfRef);
        }
    }
}
