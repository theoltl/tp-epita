using System;

namespace Minecraft
{
    #region dependencies
    public enum MobType
    {
        PLAYER,
        PIG,
        COW,
        OCELOT,
        ZOMBIE,
        CREEPER
    }
    #endregion

    public class Entity
    {
        #region Constructor

        protected string noise;

        protected MobType type;

        protected int hp;

        protected Blocks loot;
        
        protected bool isKo;

        public bool IsKO
        {
            get { return isKo; }
            set { isKo = value; }
        }
        public MobType Type
        {
            get { return type; }
            set { type = value; }
        }
        public int Hp
        {
            get { return hp; }
            set { hp = value; }
        }


        
        
        public Entity(MobType type,int hp,string noise, Blocks loot)
        {
            this.type = type;
            this.hp = hp;
            this.noise = noise;
            this.loot = loot;
        }
        
        #endregion
        
        #region Methods

        public virtual void WhoAmI()
        {
            Console.WriteLine("I'm an entity ! {0}", noise);
        }
        
        public virtual void Describe()
        {
            if (type == MobType.OCELOT)
                Console.WriteLine("I'm an {0} and I have {1} hp", type, hp);
            else
            {
                Console.WriteLine("I'm a {0} and I have {1} hp", type, hp);
            }
        }

        public Blocks GetHurt(int count)
        {
            if (hp - count > 0)
            {
                hp -= count;
                isKo = false;
                return new Blocks(Blocks.BlockType.NONE, 0);
            }
            else
            {
                hp = 0;
                isKo = true;
                return loot;
            }

        }
        
        #endregion

    }}