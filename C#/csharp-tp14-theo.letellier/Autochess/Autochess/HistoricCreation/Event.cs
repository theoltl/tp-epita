using System;
using System.Collections.Generic;
using System.Numerics;
using System.Xml.Serialization;

namespace Autochess
{
    [XmlInclude(typeof(EntityEvent))]
    [XmlInclude(typeof(Explosion))]
    public partial class Event
    {
        public List<Event> followingEvents = new List<Event>();

        public int CauseId;
        
        [XmlInclude(typeof(EntityCreation))]
        [XmlInclude(typeof(EntityMoveEvent))]
        [XmlInclude(typeof(EntityDie))]
        [XmlInclude(typeof(EntityAttack))]
        [XmlInclude(typeof(EntityTakeDamage))]
        [XmlInclude(typeof(EntityHeal))]
        [XmlInclude(typeof(EntityGainArmor))]
        [XmlInclude(typeof(ConsumeItem))]
        [XmlInclude(typeof(EntityTeleport))]
        [XmlInclude(typeof(EntityBuff))]
        public partial class EntityEvent : Event
        {
            public int EntityId;
        }

        public partial class EntityCreation : EntityEvent
        {
            public Team Team;
            public Vector2 Position;
            public float Speed;
            public float AttackCooldown;
            public int MaxHealth;
            public int InitialArmor;

            public string HandItemName;
        }

        public partial class EntityMoveEvent : EntityEvent
        {
            public Vector2 NewPosition;
        }

        public partial class EntityDie : EntityEvent
        {
        }
        
        public partial class EntityAttack : EntityEvent
        {
            public int TargetId;
        }
        
        public partial class EntityTakeDamage : EntityEvent
        {
            public int Amount;
        }
        
        public partial class EntityHeal : EntityEvent
        {
            public int Amount;
        }

        public partial class EntityGainArmor : EntityEvent
        {
            public int Amount;
        }

        public partial class Explosion : Event
        {
            public Vector2 Position;
            
            public float Radius;
            public int DamageAtCenter;
        }
        
        public partial class ConsumeItem : EntityEvent
        {
            public String ItemName;
        }

        public partial class EntityTeleport : EntityEvent
        {
            public Vector2 NewPosition;
        }

        public partial class EntityBuff : EntityEvent
        {
            public int BuffIndex;
        }
    }
}
