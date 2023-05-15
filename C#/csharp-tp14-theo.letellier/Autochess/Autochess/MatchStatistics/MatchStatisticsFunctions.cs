using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Autochess
{
    public partial class MatchStatistics
    {
        public MatchStatistics() { }
        
        public void ToFile(string path)
        {
            Serializer.Json.ToFile(this, path);
        }
        
        private Dictionary<Entity, EntityStatistics> _entitiesStatistics = new Dictionary<Entity, EntityStatistics>();

        public MatchStatistics(string redConfigPath, string whiteConfigPath)
        {
            RedConfigPath = redConfigPath;
            WhiteConfigPath = whiteConfigPath;
        }

        public EntityStatistics GetEntityStat(Entity entity)
        {
            return _entitiesStatistics[entity];
        }

        public void AddEntity(Entity entity, EntityInfo entityInfo)
        {
            EntityStatistics us = new EntityStatistics(entityInfo);

            if (entity.Team == Team.Red)
                RedStats.EntityStatistics.Add(us);
            else
                WhiteStats.EntityStatistics.Add(us);
            
            _entitiesStatistics[entity] = us;

        }

    }

    public partial class TeamStatistics
    {
        public TeamStatistics()
        {
            EntityStatistics = new List<EntityStatistics>();
        }
    }

    public partial class EntityStatistics
    {
        public EntityStatistics() {}
        
        public EntityStatistics(EntityInfo entityInfo)
        {
            Entity = entityInfo;
        }
        
    }
}
