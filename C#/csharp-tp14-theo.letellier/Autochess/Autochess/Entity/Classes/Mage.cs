using System;
using System.Numerics;

namespace Autochess
{
    public class Mage : Entity
    {
        #region Default Values
        
        public override int DefaultMaxHealth => 90;
        public override float DefaultRange => 2f;
        public override float DefaultSpeed => 1.2f;
        public override Class EntityClass => Class.Mage;

        #endregion
        
        private const int TELEPORT_USES = 3;
        private int teleportUseLeft;
        
        public Mage(EntityInfo entityInfo, Team team) : base(entityInfo, team)
        {
            teleportUseLeft = TELEPORT_USES;
        }

        private const float SAFE_DISTANCE = 3f;
        
        private bool IsSpotSafe(Vector2 newPosition)
        {
            if (newPosition.X < 0 || newPosition.Y < 0 || newPosition.X > Utility.ARENA_LENGTH ||
                newPosition.Y > Utility.ARENA_WIDTH)
                return false;

            foreach (Entity entity in Match.Entities)
            {
                if (Vector2.Distance(Position, newPosition) <
                    Utility.ENTITY_HITBOX_RADIUS * 2f + (entity.Team == Team ? 0 : SAFE_DISTANCE))
                    return false;
            }

            return true;
        }

        private const int TELEPORT_TRY = 20;
        private const int TELEPORT_RADIUS = 8;

        private void TeleportToSafety(Entity enemy)
        {
            Vector2 dir = enemy.Position - Position;
            float angle = MathF.Atan2(dir.X, dir.Y);
            for (int i = 0; i < TELEPORT_TRY; i++)
            {
                Vector2 newPosition = Position + new Vector2(MathF.Cos(angle),MathF.Sin(angle)) * TELEPORT_RADIUS;
                if (IsSpotSafe(newPosition))
                {
                    _position = newPosition;
                    EventCreationWrapper.EntityTeleport(this);
                    return;
                }

                angle += 1.44f;
            }
        }

        private const float TRIGGER_RADIUS = 2f;

        public override void Tick()
        {
            Entity target = Utility.FindClosestEnemy(this);

            if (target == null)
                return;

            if (MoveToward(target))
                Attack(target);

            if (teleportUseLeft > 0)
            {
                if (Vector2.Distance(Position, target.Position) < TRIGGER_RADIUS)
                {
                    teleportUseLeft--;
                    TeleportToSafety(target);
                }
            }
        }
    }
}
