using System.Collections.Generic;
using System.Linq;
using Autochess;
using NUnit.Framework;

namespace AutochessTests.Unit
{
    public class EntityTakeDamage
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
        public void CalculateMaxDamage(
            [Values(100, 10, 5, 10)] int health,
            [Values(0, 10, 5, 20)] int armor,
            [Values(10, 15, 15, 50)] int damage,
            [Values(10, 15, 10, 30)] int expectedResult)
        {
            _entityRed.Health = health;
            _entityRed.Armor = armor;

            int result = _entityRed.CalculateMaxDamage(damage);

            Assert.AreEqual(expectedResult, result);
        }


        [Test]
        public void UpdateUnitStat([Values(0, 10, 50)] int damage1, [Values(5, 15, 25)] int damage2)
        {
            _entityRed.TakeDamage(damage1);
            Assert.AreEqual(damage1, _entityRed.EntityStat.TotalDamageReceived);
            _entityRed.TakeDamage(damage2);
            Assert.AreEqual(damage1 + damage2, _entityRed.EntityStat.TotalDamageReceived);
        }

        [Test, Sequential]
        public void ArmorLoss(
            [Values(0, 10, 50, 35)] int initialArmor, 
            [Values(5, 15, 20, 20)] int damage,
            [Values(0, 0, 30, 15)] int newArmor)
        {
            _entityRed.Armor = initialArmor;
            _entityRed.TakeDamage(damage);
            Assert.AreEqual(newArmor, _entityRed.Armor);
        }

        [Test, Sequential]
        public void ArmorUpdateUnitStat(
            [Values(0, 10, 50, 35)] int initialArmor, 
            [Values(5, 15, 20, 20)] int damage,
            [Values(0, 10, 20, 20)] int armorLoss,
            [Values(0, 10, 40, 35)] int armorLossAfterSecondAttack)
        {
            _entityRed.Armor = initialArmor;
            _entityRed.TakeDamage(damage);
            Assert.AreEqual(armorLoss, _entityRed.EntityStat.TotalArmorLoss);
            _entityRed.TakeDamage(damage);
            Assert.AreEqual(armorLossAfterSecondAttack, _entityRed.EntityStat.TotalArmorLoss);
            
        }

        [Test, Sequential]
        public void ArmorExecuteEventAtLoseArmor(
            [Values(0, 5)] int initialArmor,
            [Values(false, true)] bool shouldExecuteEvent)
        {
            Entity selfRef = null;
            _entityRed.EquipItem(new Item
            {
                ItemEvents = new List<ActionEvent>
                {
                    new ActionEvent
                    {
                        Moment = ActionEvent.Time.AtLoseArmor,
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

            _entityRed.Armor = initialArmor;

            _entityRed.TakeDamage(5);
            
            Assert.AreEqual(shouldExecuteEvent, selfRef != null);
        }
        
        [Test, Sequential]
        public void ArmorExecuteEventAtNoMoreArmor(
            [Values(0, 5, 15)] int initialArmor,
            [Values(0, 5, 10)] int damage,
            [Values(false, true, false)] bool shouldExecuteEvent)
        {
            Entity selfRef = null;
            _entityRed.EquipItem(new Item
            {
                ItemEvents = new List<ActionEvent>
                {
                    new ActionEvent
                    {
                        Moment = ActionEvent.Time.AtNoMoreArmor,
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

            _entityRed.Armor = initialArmor;

            _entityRed.TakeDamage(damage);
            
            Assert.AreEqual(shouldExecuteEvent, selfRef != null);
        }


        [Test, Sequential]
        public void ArmorReduceHealthDamage(
            [Values(0, 5, 15)] int initialArmor,
            [Values(0, 15, 10)] int damage,
            [Values(0, 10, 0)] int newAmount)
        {
            _entityRed.Armor = initialArmor;

            int oldHealth = _entityRed.Health;

            _entityRed.TakeDamage(damage);

            Assert.AreEqual(oldHealth - newAmount, _entityRed.Health);
        }
        
        [Test, Sequential]
        public void BasicTakeDamage(
            [Values(0, 15, 30)] int damage,
            [Values(100, 85, 70)] int newHealth)
        {
            _entityRed.TakeDamage(damage);
            Assert.AreEqual(newHealth, _entityRed.Health);
        }

        [Test, Sequential]
        public void ExecuteEventAtHurt(
            [Values(0, 0, 15, 15)] int initialArmor,
            [Values(0, 10, 10, 20)] int damage,
            [Values(false, true, false, true)] bool shouldBeCalled)
        {
            Entity selfRef = null;
            
            _entityRed.EquipItem(new Item
            {
                ItemEvents = new List<ActionEvent>
                {
                    new ActionEvent
                    {
                        Moment = ActionEvent.Time.AtHurt,
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
            
            _entityRed.Armor = initialArmor;
            _entityRed.TakeDamage(damage);
            
            Assert.AreEqual(shouldBeCalled, selfRef != null);
        }
        
        [Test, Sequential]
        public void ExecuteEventAtLowHealth(
            [Values(0, 85, 10, 90)] int damage,
            [Values(false, true, false, true)] bool shouldBeCalled)
        {
            Entity selfRef = null;
            
            _entityRed.EquipItem(new Item
            {
                ItemEvents = new List<ActionEvent>
                {
                    new ActionEvent
                    {
                        Moment = ActionEvent.Time.AtLowHealth,
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
            
            _entityRed.TakeDamage(damage);
            
            Assert.AreEqual(shouldBeCalled, selfRef != null);
        }

        [Test, Sequential]
        public void ExecuteDieIfHealthIs0(
            [Values(0, 100)] int damage,
            [Values(false, true)] bool shouldBeCalled)
        {
            _entityRed.TakeDamage(damage);

            if (shouldBeCalled)
            {
                Event e = HistoricManipulator.Historic.Events[0].Last().followingEvents[0];
                Assert.AreEqual(e.GetType(), typeof(Event.EntityDie));
            }
            Assert.Pass();
        }
    }
}
