using System;

namespace Autochess
{
    public partial class Buff
    {
        public class ActiveBuff
        {
            private Entity target;

            public float DurationLeft;

            public Buff Buff;
            public ActiveBuff(Buff buff, Entity target)
            {
                this.Buff = buff;
                DurationLeft = buff.Duration;
                this.target = target;
            }
            
            public void Destroy()
            {
                target.RemoveBuff(this);
            }
        }
        
        

        public void AddToEntity(Entity target)
        {
            ActiveBuff activeBuff = new ActiveBuff(this, target);
            target.AddBuff(activeBuff);
            EventCreationWrapper.EntityBuff(target, this);
            if (!IsForever)
            {
                target.Match.AddBuff(activeBuff);
            }
        }

        public partial class Stat
        {
            public partial class EntityModifier
            {
                private float Operate(float input) 
                {
                    switch (Type)
                    {
                        case Operation.Add:
                            return input + Value;
                        case Operation.Multiply:
                            return input * Value;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
        
                public void Execute(ref EntityData data)
                {
                    switch (ModifiedStat)
                    {
                        case EntityStat.MaxHealth:
                            data.MaxHealth = (int)Operate(data.MaxHealth);
                            break;
                        case EntityStat.Damage:
                            data.Damage = (int)Operate(data.Damage);
                            break;
                        case EntityStat.Speed:
                            data.Speed = Operate(data.Speed);
                            break;
                        case EntityStat.Range:
                            data.Range = Operate(data.Range);
                            break;
                        case EntityStat.AttackCooldown:
                            data.AttackCooldown = Operate(data.AttackCooldown);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }
        }
    }
}
