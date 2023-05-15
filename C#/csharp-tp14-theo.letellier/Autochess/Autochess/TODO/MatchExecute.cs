using System;

namespace Autochess
{
    public partial class Match
    {
        public void SpawnEntities(PlayerConfig playerConfig, Team team)
        {
            foreach (var entityInfo in playerConfig.Entities)
            {
                switch (entityInfo.Class)
                {
                    case Entity.Class.Neutral:
                        AddEntity(new Entity(entityInfo, team));
                        break;
                    case Entity.Class.Warrior:
                        AddEntity(new Warrior(entityInfo, team));
                        break;
                    case Entity.Class.Archer:
                        AddEntity(new Archer(entityInfo, team));
                        break;
                    case Entity.Class.Mage:
                        AddEntity(new Mage(entityInfo, team));
                        break;
                }
            }
        }
    }
}
