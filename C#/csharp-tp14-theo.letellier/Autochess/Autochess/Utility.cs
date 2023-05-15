using System;
using System.IO;
using System.Numerics;

namespace Autochess
{
    public static partial class Utility
    {
        public const int MAX_COLLISION = 30;
        public const float ENTITY_HITBOX_RADIUS = 0.5f;

        public static Vector2 AdjustPosition(Entity entity, Vector2 newPosition, out bool stuck)
        {
            int collisionCount = 0;

            float dist = -1f;
            Vector2 collisionDirection;

            while (dist < 0f && collisionCount < MAX_COLLISION)
            {
                if (newPosition.X < 0 || newPosition.Y < 0 || newPosition.X > ARENA_LENGTH ||
                    newPosition.Y > ARENA_WIDTH)
                {
                    if (newPosition.X < 0) 
                        newPosition = new Vector2(0, newPosition.Y -Math.Sign(newPosition.Y) * newPosition.X);
                    
                    if (newPosition.Y < 0)
                        newPosition = new Vector2(newPosition.X -Math.Sign(newPosition.X) * newPosition.Y, 0);
                    
                    if (newPosition.X > ARENA_LENGTH) 
                        newPosition = new Vector2(ARENA_LENGTH, newPosition.Y -Math.Sign(newPosition.Y) * 
                            (newPosition.X - ARENA_LENGTH));
                    
                    if (newPosition.Y > ARENA_WIDTH) 
                        newPosition = new Vector2(newPosition.X -Math.Sign(newPosition.X) * 
                            (newPosition.Y - ARENA_WIDTH), ARENA_WIDTH);
                    
                    collisionCount++;
                    continue;
                }

                foreach (Entity other in entity.Match.Entities)
                {
                    if (entity.Id == other.Id || entity.IsDead) continue;

                    collisionDirection = newPosition - other.Position;
                    dist = collisionDirection.Length() - (2 * ENTITY_HITBOX_RADIUS);

                    if (dist < 0f)
                    {
                        collisionCount++;

                        if (Vector2.Dot(entity.Position - newPosition, -collisionDirection) < 0f)
                        {
                            collisionDirection += new Vector2(collisionDirection.Y, -collisionDirection.X);
                        }

                        newPosition -= Vector2.Normalize(collisionDirection) * dist;
                    }
                }
            }

            stuck = collisionCount == MAX_COLLISION;
            
            return newPosition;
        }

        public const int ARENA_LENGTH = 20;
        public const int ARENA_WIDTH = 10;

        public static Vector2 CalcPosition(Vector2 initialPosition, Team team)
        {
            if (team == Team.Red)
                return new Vector2(ARENA_LENGTH - initialPosition.X, initialPosition.Y);
            return initialPosition;
        }

        public static ItemBank LoadItemBank(string path)
        {
            ItemBank result = Serializer.Xml.FromFile<ItemBank>(path);
            if (result == null)
                throw new InvalidDataException("Unable to load the Item Bank");
            return result;
        }
    }
}
