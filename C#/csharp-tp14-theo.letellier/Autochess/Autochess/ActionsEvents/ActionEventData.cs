using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Serialization;

namespace Autochess
{
    public partial class ActionEvent
    {
        public enum Time
        {
            EveryTick,
            AtInit,
            AtDeath,
            AtAttack,
            AtHurt,
            AtHeal,
            AtKill,
            AtLowHealth,
            AtLoseArmor,
            AtGainArmor,
            AtNoMoreArmor,
        } 

        public Time Moment;

        public List<Action> Outcome;

        [XmlInclude(typeof(AddBuff))]
        [XmlInclude(typeof(DealDamage))]
        [XmlInclude(typeof(Heal))]
        [XmlInclude(typeof(GainArmor))]
        [XmlInclude(typeof(ExecuteActions))]
        [XmlInclude(typeof(Explode))]
        [XmlInclude(typeof(ConsumeItem))]
        public partial class Action
        {
            public EntitySelector Target;

            
        }
        
        public partial class AddBuff : Action
        {
            public Buff Buff;
        }

        public partial class DealDamage : Action
        {
            public int Amount;
        }

        public partial class Heal : Action
        {
            public int Amount;
        }

        public partial class GainArmor : Action
        {
            public int Amount;
        }

        public partial class ExecuteActions : Action
        {
            public List<Action> Actions;
        }


        public partial class Explode : Action
        {
            public int DamageAtCenter;
            public float Radius;
        }

        public partial class ConsumeItem : Action
        {
            public String ItemName;
        }

        public partial class Debug : Action
        {
            public Action<Entity> toExecute;
        }
    }
}
