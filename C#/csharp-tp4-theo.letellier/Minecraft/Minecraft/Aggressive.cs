using System;

namespace Minecraft
{
    public class Aggressive : Entity
    {
        # region Constructor

        private int strength;
        
        public Aggressive(MobType type, int hp, string noise, Blocks loot,
            int strength) : base (type, hp, noise, loot)
        {
            this.type = type;
            this.hp = hp;
            this.noise = noise;
            this.loot = loot;
            this.strength = strength;
        }
        
        #endregion
        
        #region Methods
        
        public override void WhoAmI()
        {
            Console.WriteLine("I'm aggressive ! {0}", noise);
        }
        
        public void Attack(Entity entity)
        {
            entity.GetHurt(strength);
            if (entity.Hp < 1)
                Console.WriteLine("{0} has been killed",entity.Type);
        }

        #endregion
    }
}