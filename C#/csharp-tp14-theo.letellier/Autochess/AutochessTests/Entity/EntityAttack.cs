using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Autochess;
using NUnit.Framework;

namespace AutochessTests.Unit
{
    [TestFixture]
    public class EntityAttack
    {
        private Match _match;
        
        private Entity _entityRed;
        private Entity _entityWhite;
        
        [SetUp]
        public void SetUp()
        {
            Program.ItemBank = new ItemBank();

            _match = new Match(null, null);
            _entityRed = new Entity(new EntityInfo(), Team.Red);
            _entityWhite = new Entity(new EntityInfo {InitialPosition = Vector2.UnitX * Utility.ARENA_LENGTH}, Team.White);

            _match.AddEntity(_entityRed);
            _match.AddEntity(_entityWhite);
        }

        [Test]
        public void ExecuteEvents()
        {
            Entity executeOnSelf = null;
            
            _entityRed.EquipItem(new Item
            {
                ItemEvents = new List<ActionEvent>
                {
                    new ActionEvent
                    {
                        Moment = ActionEvent.Time.AtAttack,
                        Outcome = new List<ActionEvent.Action>
                        {
                            new ActionEvent.Debug
                            {
                                Target = new ActionEvent.EntitySelector {Self = true},
                                toExecute = unit => executeOnSelf = unit
                            }
                        }
                    }
                }
            });
            
            _entityRed.Attack(_entityWhite);
            
            Assert.AreEqual(_entityRed, executeOnSelf);
        }

        [Test]
        public void CallTakeDamage()
        {
            _entityRed.Attack(_entityWhite);
            
            Assert.True(HistoricManipulator.Historic.Events.Count == 1);

            Event e = HistoricManipulator.Historic.Events[0].Last();
            
            Assert.AreEqual(typeof(Event.EntityAttack), e.GetType());

            Event followingEvent = e.followingEvents[0];
            
            Assert.AreEqual(typeof(Event.EntityTakeDamage), followingEvent.GetType());
        }
        
        [Test]
        public void CallTakeDamageKillHookAtKillEvent()
        {
            _entityWhite.TakeDamage(_entityWhite.Health - 1);

            Entity qze = null;
            
            _entityRed.EquipItem(new Item
            {
                ItemEvents = new List<ActionEvent>
                {
                    new ActionEvent
                    {
                        Moment = ActionEvent.Time.AtKill,
                        Outcome = new List<ActionEvent.Action>
                        {
                            new ActionEvent.Debug
                            {
                                Target = new ActionEvent.EntitySelector {Self = true},
                                toExecute = unit => qze = unit
                            }
                        }
                    }
                }
            });
            _entityRed.Attack(_entityWhite);
            
            Assert.AreEqual(_entityRed, qze);
        }
        
        [Test]
        public void CallTakeDamageKillHookStatKills()
        {
            _entityWhite.TakeDamage(_entityWhite.Health - 1);
            _entityRed.Attack(_entityWhite);
            
            Assert.AreEqual(1, _entityRed.EntityStat.Kills);
        }

        [Test]
        public void UpdateUnitStat()
        {
            _entityRed.AttackCooldown = 0;
            
            _entityRed.Attack(_entityWhite);
            Assert.AreEqual(_entityRed.Damage, _entityRed.EntityStat.TotalDamageDealt);
            
            _entityRed.Attack(_entityWhite);
            Assert.AreEqual(2 * _entityRed.Damage, _entityRed.EntityStat.TotalDamageDealt);
        }
    }
}
