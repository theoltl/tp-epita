using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Autochess
{
    public partial class ActionEvent
    {
        public partial class EntitySelector
        {
            public List<Entity> Execute(Entity source)
            {
                if (Self)
                    return new List<Entity> {source};

                List<Entity> result = new List<Entity>();

                foreach (Entity entity in source.Match.Entities)
                {
                    if (entity.Id == source.Id) continue;

                    if (Filters.All(filter => filter.SatisfiesFilter(source, entity)))
                        result.Add(entity);
                }

                if (UniqueFilter != null)
                {
                    Entity target = UniqueFilter.GetUniqueTarget(result, source);
                    return target == null ? new List<Entity>() : new List<Entity>() {target};
                }

                return result;
            }

            public abstract partial class EntityFilter
            {
                public abstract bool SatisfiesFilter(Entity target, Entity source);
            }

            public partial class TeamFilter : EntityFilter
            {
                public override bool SatisfiesFilter(Entity target, Entity source)
                {
                    switch (Team)
                    {
                        case TargetTeam.All:
                            return true;
                        case TargetTeam.Allies:
                            return (target.Team == source.Team);
                        case TargetTeam.Enemies:
                            return (target.Team != source.Team);
                        default:
                            return false;
                    }
                }
            }

            public partial class ClassFilter : EntityFilter
            {
                public override bool SatisfiesFilter(Entity target, Entity source)
                {
                    return target.EntityClass != ExcludedClass;
                }
            }

            public partial class DamagedFilter : EntityFilter
            {
                public override bool SatisfiesFilter(Entity target, Entity source)
                {
                    return target.Health < target.MaxHealth;
                }
            }

            public partial class DistanceFilter : EntityFilter
            {
                public override bool SatisfiesFilter(Entity target, Entity source)
                {
                    return MaxDistance * MaxDistance >= Vector2.DistanceSquared(source.Position, target.Position);
                }
            }

            public partial class UniqueTargetFilter
            {
                public float GetValue(Entity entity, Entity source)
                {
                    switch (Data)
                    {
                        case EntityData.MaxHealth:
                            return entity.MaxHealth;
                        case EntityData.Health:
                            return entity.Health;
                        case EntityData.Damage:
                            return entity.Damage;
                        case EntityData.Speed:
                            return entity.Speed;
                        case EntityData.Range:
                            return entity.Range;
                        case EntityData.AttackCooldown:
                            return entity.AttackCooldown;
                        case EntityData.Distance:
                            return Vector2.DistanceSquared(source.Position, entity.Position);
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                public bool Compare(float a, float b)
                {
                    switch (Mode)
                    {
                        case ComparisonMode.Lowest:
                            return a < b;
                        case ComparisonMode.Highest:
                            return a > b;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                public Entity GetUniqueTarget(List<Entity> entities, Entity source)
                {
                    if (entities == null || entities.Count == 0)
                        return null;
                    if (entities.Count == 1)
                        return entities[0];

                    float val = GetValue(entities[0], source);
                    Entity target = entities[0];

                    foreach (Entity entity in entities)
                    {
                        float v = GetValue(entity, source);
                        if (Compare(v, val))
                        {
                            val = v;
                            target = entity;
                        }
                    }

                    return target;
                }
            }
        }
    }
}
