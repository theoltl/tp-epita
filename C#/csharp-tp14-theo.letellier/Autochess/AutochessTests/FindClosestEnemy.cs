using System.Numerics;
using Autochess;
using NUnit.Framework;

namespace AutochessTests
{
    [TestFixture]
    public class FindClosestEnemy
    {
        private Match _match;

        private Autochess.Entity _entityRed1;
        private Autochess.Entity _entityRed2;
        private Autochess.Entity _entityWhite1;
        private Autochess.Entity _entityWhite2;

        [SetUp]
        public void SetUp()
        {
            Program.ItemBank = new ItemBank();

            _match = new Match(null, null);

            _entityRed1 = new Autochess.Entity(new EntityInfo() {Name = "Red 1"}, Team.Red);
            _entityRed2 = new Autochess.Entity(new EntityInfo() {Name = "Red 2", InitialPosition = new Vector2(2, 2)},
                Team.Red);

            _entityWhite1 = new Autochess.Entity(new EntityInfo() {Name = "White 1", InitialPosition = new Vector2(2, 2)},
                Team.White);
            _entityWhite2 = new Autochess.Entity(new EntityInfo() {Name = "White 2", InitialPosition = new Vector2(4, 4)},
                Team.White);

            _match.AddEntity(_entityRed1);
            _match.AddEntity(_entityRed2);
            _match.AddEntity(_entityWhite1);
            _match.AddEntity(_entityWhite2);
        }

        [Test, Sequential]
        public void Basic([Values(0, 1, 2, 3)] int source, [Values(3, 3, 1, 1)] int closest)
        {
            Autochess.Entity[] units = new[] {_entityRed1, _entityRed2, _entityWhite1, _entityWhite2};

            Assert.AreEqual(units[closest].Name, Utility.FindClosestEnemy(units[source]).Name);
        }
        
        
        [Test, Sequential]
        public void WithDeadUnits([Values(0, 1, 2, 3)] int source, [Values(2, 2, 0, 0)] int closest)
        {
            Autochess.Entity[] units = new[] {_entityRed1, _entityRed2, _entityWhite1, _entityWhite2};

            _entityRed2.Die();
            _entityWhite2.Die();
            
            Assert.AreEqual(units[closest].Name, Utility.FindClosestEnemy(units[source]).Name);
        }
    }
}
