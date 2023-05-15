using System.Collections.Generic;
using System.Xml.Serialization;

namespace Autochess
{
    public partial class ActionEvent
    {
        public partial class EntitySelector
        {
            public bool Self;
            public List<EntityFilter> Filters;

            public UniqueTargetFilter UniqueFilter;
            
            [XmlInclude(typeof(TeamFilter))]
            [XmlInclude(typeof(ClassFilter))]
            [XmlInclude(typeof(DamagedFilter))]
            [XmlInclude(typeof(DistanceFilter))]
            public abstract partial class EntityFilter { }

            public partial class TeamFilter : EntityFilter
            {
                public enum TargetTeam
                {
                    All,
                    Allies,
                    Enemies
                }
                
                public TargetTeam Team;
            }

            public partial class ClassFilter : EntityFilter
            {
                public Entity.Class ExcludedClass;
            }
            
            public partial class DamagedFilter : EntityFilter {}

            public partial class DistanceFilter : EntityFilter
            {
                public float MaxDistance;
            }
            
            public partial class UniqueTargetFilter
            {
                public enum EntityData
                {
                    MaxHealth,
                    Health,
                    Damage,
                    Speed,
                    Range,
                    AttackCooldown,
                    Distance
                }

                public EntityData Data;
                
                public enum ComparisonMode
                {
                    Lowest,
                    Highest
                }

                public ComparisonMode Mode;
            }
        }
    }
}
