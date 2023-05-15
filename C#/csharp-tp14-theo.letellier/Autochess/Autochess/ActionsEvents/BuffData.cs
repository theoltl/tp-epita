using System.Xml.Serialization;

namespace Autochess
{
    [XmlInclude(typeof(Stat))]
    [XmlInclude(typeof(Event))]
    public partial class Buff
    {
        public int BuffIndex;
        
        public bool IsForever;
        public float Duration;

        public partial class Stat : Buff
        {
            public partial class EntityModifier
            {
                public enum EntityStat
                {
                    MaxHealth,
                    Damage,
                    Speed,
                    Range,
                    AttackCooldown
                }

                public EntityStat ModifiedStat;
        
                public enum Operation
                {
                    Add,
                    Multiply
                }

                public Operation Type;

                public float Value;
            }
            
            public EntityModifier Modifier;
        }

        public partial class Event : Buff
        {
            public ActionEvent ActionEvent;
        }
    }
}
