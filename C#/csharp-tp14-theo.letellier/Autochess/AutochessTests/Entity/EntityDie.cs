using System.Collections.Generic;
using Autochess;
using NUnit.Framework;

namespace AutochessTests.Unit
{
    [TestFixture]
    public class EntityDie
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

        [Test]
        public void SetIsDeadToTrue()
        {
            _entityRed.Die();
            Assert.IsTrue(_entityRed.IsDead);
        }
        
        [Test]
        public void ExecuteEventAtDeath()
        {
            Entity selfRef = null;
            _entityRed.EquipItem(new Item
            {
                ItemEvents = new List<ActionEvent>
                {
                    new ActionEvent
                    {
                        Moment = ActionEvent.Time.AtDeath,
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
            
            _entityRed.Die();
            
            Assert.AreEqual(_entityRed, selfRef);
        }

        [Test]
        public void UpdateUnitStat(
            [Values(0, 50, 120)] int tick)
        {
            Program.Tick = tick;
            
            _entityRed.Die();

            Assert.IsFalse(_entityRed.EntityStat.Survived);
            Assert.AreEqual(tick, _entityRed.EntityStat.Lifetime);
        }

        [Test]
        public void CallKillHook()
        {
            bool called = false;
            
            _entityRed.Die(() => called = true);

            Assert.IsTrue(called);
        }
    }
}
