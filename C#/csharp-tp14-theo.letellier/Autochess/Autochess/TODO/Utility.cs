using System;
using System.Collections.Generic;
using System.Numerics;

namespace Autochess
{
    public static partial class Utility
    {
        public static Entity FindClosestEnemy(Entity source)
        {
            List<Entity> Ennemies = new List<Entity>();
            
            for (int i = 0; i < source.Match.Entities.Count; i++)
            {
                if (!source.Match.Entities[i].IsDead)
                    if (source.Match.Entities[i].Team != source.Team)
                        Ennemies.Add(source.Match.Entities[i]);
            }
            
            float min = Vector2.Distance(source.Position, Ennemies[0].Position);
            Entity closest = Ennemies[0];
            
            for (int i = 0; i < Ennemies.Count; i++)
            {
                float temp = Vector2.Distance(source.Position, Ennemies[i].Position);
                if (temp < min)
                {
                    min = temp;
                    closest = Ennemies[i];
                }
            }

            return closest;
        }
    }
}
