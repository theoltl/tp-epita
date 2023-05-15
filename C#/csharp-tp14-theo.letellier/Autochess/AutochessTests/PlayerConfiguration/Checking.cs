using System.Collections.Generic;
using System.IO;
using System.Numerics;
using Autochess;
using NUnit.Framework;

namespace AutochessTests
{
    public class CheckClassFunction : Checking
    {
        [Test]
        public void ThrowException()
        {
            Assert.Throws<InvalidDataException>(() =>
                PlayerConfig.CheckClass(Entity.Class.Mage, Entity.Class.Neutral));
            PlayerConfig.CheckClass(Entity.Class.Neutral, Entity.Class.Warrior);
            PlayerConfig.CheckClass(Entity.Class.Warrior, Entity.Class.Warrior);
        }

        [Test]
        public void ExceptionMessage()
        {
            InvalidDataException exception = Assert.Throws<InvalidDataException>(() =>
                PlayerConfig.CheckClass(Entity.Class.Mage, Entity.Class.Neutral));
            Assert.AreEqual("PlayerConfiguration: A Neutral can't have a Mage item.", exception.Message);

            exception = Assert.Throws<InvalidDataException>(() =>
                PlayerConfig.CheckClass(Entity.Class.Warrior, Entity.Class.Archer));
            Assert.AreEqual("PlayerConfiguration: A Archer can't have a Warrior item.", exception.Message);
        }
    }

    [TestFixture]
    public class Checking
    {
        private const int MaxMoney = 1000;

        [OneTimeSetUp]
        public void SetUp()
        {
            Program.ItemBank = new ItemBank
            {
                Items = new List<Item>
                {
                    new Item {Name = "1", ItemClass = Entity.Class.Mage},
                    new Item {Name = "2", ItemClass = Entity.Class.Warrior},
                    new Item {Name = "2.5", cost = 1500},
                    new MainItem {Name = "3", ItemClass = Entity.Class.Mage},
                    new MainItem {Name = "4", ItemClass = Entity.Class.Warrior},
                    new MainItem {Name = "5", cost = 1500}
                }
            };
        }

        public class CheckNoUnit : Checking
        {
            [Test]
            public void ThrowException()
            {
                Assert.Throws<InvalidDataException>(() =>
                    new PlayerConfig
                    {
                        Entities = new List<EntityInfo>()
                    }.CheckValidity(MaxMoney));
            }

            [Test]
            public void ExceptionMessage()
            {
                InvalidDataException exception = Assert.Throws<InvalidDataException>(() =>
                    new PlayerConfig
                    {
                        Entities = new List<EntityInfo>()
                    }.CheckValidity(MaxMoney));

                Assert.AreEqual("PlayerConfiguration: There are no entities in this configuration", exception.Message);
            }
        }

        public class CheckTooManyUnit : Checking
        {
            [Test]
            public void ThrowException()
            {
                List<EntityInfo> entities = new List<EntityInfo>();
                for (int i = 0; i < PlayerConfig.MAX_ENTITY_NUMBER + 1; i++)
                {
                    entities.Add(new EntityInfo {InitialPosition = Vector2.One * 0.1f * i});
                }

                Assert.Throws<InvalidDataException>(() =>
                    new PlayerConfig
                    {
                        Entities = entities
                    }.CheckValidity(MaxMoney));
            }

            [Test]
            public void ExceptionMessage()
            {
                List<EntityInfo> entities = new List<EntityInfo>();
                for (int i = 0; i < PlayerConfig.MAX_ENTITY_NUMBER + 1; i++)
                {
                    entities.Add(new EntityInfo {InitialPosition = Vector2.One * 0.1f * i});
                }

                InvalidDataException exception = Assert.Throws<InvalidDataException>(() =>
                    new PlayerConfig
                    {
                        Entities = entities
                    }.CheckValidity(MaxMoney));

                Assert.AreEqual("PlayerConfiguration: There are too many entities in this configuration",
                    exception.Message);
            }
        }

        public class CheckClassItems : Checking
        {
            [Test]
            public void CheckClassMainItem()
            {
                Assert.Throws<InvalidDataException>(() =>
                    new PlayerConfig
                    {
                        Entities = new List<EntityInfo>
                        {
                            new EntityInfo
                            {
                                Class = Entity.Class.Mage,
                                MainItem = "4"
                            }
                        }
                    }.CheckValidity(MaxMoney));
            }
            
            [Test]
            public void CheckClassItem()
            {
                Assert.Throws<InvalidDataException>(() =>
                    new PlayerConfig
                    {
                        Entities = new List<EntityInfo>
                        {
                            new EntityInfo
                            {
                                Class = Entity.Class.Mage,
                                Items = new List<string>
                                {
                                    "2"
                                }
                            }
                        }
                    }.CheckValidity(MaxMoney));
            }
            
            [Test]
            public void ExceptionMessage()
            {
                InvalidDataException exception = Assert.Throws<InvalidDataException>(() =>
                    new PlayerConfig
                    {
                        Entities = new List<EntityInfo>
                        {
                            new EntityInfo
                            {
                                Class = Entity.Class.Mage,
                                MainItem = "4"
                            }
                        }
                    }.CheckValidity(MaxMoney));

                Assert.AreEqual("PlayerConfiguration: A Mage can't have a Warrior item.", exception.Message);
            }
        }

        public class CheckSamePosition
        {
            [Test]
            public void ThrowException()
            {
                Assert.Throws<InvalidDataException>(() =>
                    new PlayerConfig
                    {
                        Entities = new List<EntityInfo>
                        {
                            new EntityInfo
                            {
                                Class = Entity.Class.Mage,
                                InitialPosition = Vector2.Zero
                            },
                            new EntityInfo
                            {
                                Class = Entity.Class.Warrior,
                                InitialPosition = Vector2.Zero
                            }
                        }
                    }.CheckValidity(MaxMoney));
            }

            [Test]
            public void ExceptionMessage()
            {
                InvalidDataException exception = Assert.Throws<InvalidDataException>(() =>
                    new PlayerConfig
                    {
                        Entities = new List<EntityInfo>
                        {
                            new EntityInfo
                            {
                                Class = Entity.Class.Mage,
                                InitialPosition = Vector2.Zero
                            },
                            new EntityInfo
                            {
                                Class = Entity.Class.Warrior,
                                InitialPosition = Vector2.Zero
                            }
                        }
                    }.CheckValidity(MaxMoney));

                Assert.AreEqual("PlayerConfiguration: You can't have two entities in the same space",
                    exception.Message);
            }
        }

        public class CheckUnitsOutsideArena
        {
            [Test]
            public void ThrowException()
            {
                Assert.Throws<InvalidDataException>(() =>
                    new PlayerConfig
                    {
                        Entities = new List<EntityInfo>
                        {
                            new EntityInfo {InitialPosition = new Vector2(-1, 5)}
                        }
                    }.CheckValidity(MaxMoney));

                Assert.Throws<InvalidDataException>(() =>
                    new PlayerConfig
                    {
                        Entities = new List<EntityInfo>
                        {
                            new EntityInfo {InitialPosition = new Vector2(5, -1)}
                        }
                    }.CheckValidity(MaxMoney));

                Assert.Throws<InvalidDataException>(() =>
                    new PlayerConfig
                    {
                        Entities = new List<EntityInfo>
                        {
                            new EntityInfo {InitialPosition = new Vector2(Utility.ARENA_LENGTH + 1, 5)}
                        }
                    }.CheckValidity(MaxMoney));

                Assert.Throws<InvalidDataException>(() =>
                    new PlayerConfig
                    {
                        Entities = new List<EntityInfo>
                        {
                            new EntityInfo {InitialPosition = new Vector2(5, Utility.ARENA_WIDTH + 1)}
                        }
                    }.CheckValidity(MaxMoney));
            }

            [Test]
            public void ExceptionMessage()
            {
                InvalidDataException exception = Assert.Throws<InvalidDataException>(() =>
                    new PlayerConfig
                    {
                        Entities = new List<EntityInfo>
                        {
                            new EntityInfo {InitialPosition = new Vector2(-1, 5)}
                        }
                    }.CheckValidity(MaxMoney));

                Assert.AreEqual("PlayerConfiguration: You can't have entities outside the allowed space",
                    exception.Message);

                exception = Assert.Throws<InvalidDataException>(() =>
                    new PlayerConfig
                    {
                        Entities = new List<EntityInfo>
                        {
                            new EntityInfo {InitialPosition = new Vector2(5, -1)}
                        }
                    }.CheckValidity(MaxMoney));

                Assert.AreEqual("PlayerConfiguration: You can't have entities outside the allowed space",
                    exception.Message);

                exception = Assert.Throws<InvalidDataException>(() =>
                    new PlayerConfig
                    {
                        Entities = new List<EntityInfo>
                        {
                            new EntityInfo {InitialPosition = new Vector2(Utility.ARENA_LENGTH + 1, 5)}
                        }
                    }.CheckValidity(MaxMoney));

                Assert.AreEqual("PlayerConfiguration: You can't have entities outside the allowed space",
                    exception.Message);

                exception = Assert.Throws<InvalidDataException>(() =>
                    new PlayerConfig
                    {
                        Entities = new List<EntityInfo>
                        {
                            new EntityInfo {InitialPosition = new Vector2(5, Utility.ARENA_WIDTH + 1)}
                        }
                    }.CheckValidity(MaxMoney));

                Assert.AreEqual("PlayerConfiguration: You can't have entities outside the allowed space",
                    exception.Message);
            }
        }

        public class CheckTotalCost : Checking
        {
            [Test]
            public void CheckCostMainItem()
            {
                Assert.Throws<InvalidDataException>(() =>
                    new PlayerConfig
                    {
                        Entities = new List<EntityInfo>
                        {
                            new EntityInfo
                            {
                                Class = Entity.Class.Mage,
                                MainItem = "5"
                            }
                        }
                    }.CheckValidity(MaxMoney));
            }

            [Test]
            public void CheckCostItem()
            {
                Assert.Throws<InvalidDataException>(() =>
                    new PlayerConfig
                    {
                        Entities = new List<EntityInfo>
                        {
                            new EntityInfo
                            {
                                Class = Entity.Class.Mage,
                                Items = new List<string>
                                {
                                    "2.5"
                                }
                            }
                        }
                    }.CheckValidity(MaxMoney));
            }

            [Test]
            public void CheckCostExtraUnits()
            {
                Assert.Throws<InvalidDataException>(() =>
                    new PlayerConfig
                    {
                        Entities = new List<EntityInfo>
                        {
                            new EntityInfo(),
                            new EntityInfo(),
                            new EntityInfo(),

                            new EntityInfo(),
                            new EntityInfo(),
                            new EntityInfo()
                        }
                    }.CheckValidity(290));
            }

            [Test]
            public void ExceptionMessage()
            {
                InvalidDataException exception = Assert.Throws<InvalidDataException>(() =>
                    new PlayerConfig
                    {
                        Entities = new List<EntityInfo>
                        {
                            new EntityInfo
                            {
                                Class = Entity.Class.Mage,
                                MainItem = "5"
                            }
                        }
                    }.CheckValidity(MaxMoney));

                Assert.AreEqual("PlayerConfiguration: Configuration costs too much.", exception.Message);
            }
        }

        

        public class CheckSecondMainItem : Checking
        {
            [Test]
            public void ThrowException()
            {
                Assert.Throws<InvalidDataException>(() =>
                    new PlayerConfig
                    {
                        Entities = new List<EntityInfo>
                        {
                            new EntityInfo
                            {
                                Class = Entity.Class.Mage,
                                Items = new List<string>
                                {
                                    "3"
                                }
                            }
                        }
                    }.CheckValidity(MaxMoney));
            }

            [Test]
            public void ExceptionMessage()
            {
                InvalidDataException exception = Assert.Throws<InvalidDataException>(() =>
                    new PlayerConfig
                    {
                        Entities = new List<EntityInfo>
                        {
                            new EntityInfo
                            {
                                Class = Entity.Class.Mage,
                                Items = new List<string>
                                {
                                    "3"
                                }
                            }
                        }
                    }.CheckValidity(MaxMoney));

                Assert.AreEqual("PlayerConfiguration: An entity can't have more than 1 Main Item", exception.Message);
            }
        }

        public class CheckItemAsMainItem : Checking
        {
            [Test]
            public void ThrowException()
            {
                Assert.Throws<InvalidDataException>(() =>
                    new PlayerConfig
                    {
                        Entities = new List<EntityInfo>
                        {
                            new EntityInfo
                            {
                                Class = Entity.Class.Mage,
                                MainItem = "1"
                            }
                        }
                    }.CheckValidity(MaxMoney));
            }

            [Test]
            public void ExceptionMessage()
            {
                InvalidDataException exception = Assert.Throws<InvalidDataException>(() =>
                    new PlayerConfig
                    {
                        Entities = new List<EntityInfo>
                        {
                            new EntityInfo
                            {
                                Class = Entity.Class.Mage,
                                MainItem = "1"
                            }
                        }
                    }.CheckValidity(MaxMoney));

                Assert.AreEqual("PlayerConfiguration: You can't equip an Item as a Main Item", exception.Message);
            }
        }

        public class CheckNoMoreThan2Items : Checking
        {
            [Test]
            public void ThrowException()
            {
                Assert.Throws<InvalidDataException>(() =>
                    new PlayerConfig
                    {
                        Entities = new List<EntityInfo>
                        {
                            new EntityInfo
                            {
                                Class = Entity.Class.Mage,
                                Items = new List<string>
                                {
                                    "1", "1", "1"
                                }
                            }
                        }
                    }.CheckValidity(MaxMoney));
            }

            [Test]
            public void ExceptionMessage()
            {
                InvalidDataException exception = Assert.Throws<InvalidDataException>(() =>
                    new PlayerConfig
                    {
                        Entities = new List<EntityInfo>
                        {
                            new EntityInfo
                            {
                                Class = Entity.Class.Mage,
                                Items = new List<string>
                                {
                                    "1", "1", "1"
                                }
                            }
                        }
                    }.CheckValidity(MaxMoney));

                Assert.AreEqual("PlayerConfiguration: An entity can't have more than 2 of the same item",
                    exception.Message);
            }
        }

        public class Valid : Checking
        {
            [Test]
            public void Valid1()
            {
                new PlayerConfig
                {
                    Entities = new List<EntityInfo>
                    {
                        new EntityInfo
                        {
                            Class = Entity.Class.Mage,
                            Items = new List<string> {"1", "1"}
                        }
                    }
                }.CheckValidity(MaxMoney);
            }

            [Test]
            public void Valid2()
            {
                new PlayerConfig
                {
                    Entities = new List<EntityInfo>
                    {
                        new EntityInfo
                        {
                            Class = Entity.Class.Mage,
                            MainItem = "3",
                            Items = new List<string> {"1"},
                            InitialPosition = Vector2.One
                        },
                        new EntityInfo
                        {
                            Class = Entity.Class.Warrior,
                            MainItem = "4",
                            Items = new List<string> {"2"},
                            InitialPosition = Vector2.Zero
                        }
                    }
                }.CheckValidity(MaxMoney);
            }
        }
    }
}
