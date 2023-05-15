using System;
using System.Numerics;

namespace Autochess
{
    public class Archer : Entity
    {
        #region Default Values
        
        public override int DefaultMaxHealth => 80;
        public override float DefaultRange => 2f;
        public override float DefaultSpeed => 1.5f;
        public override Class EntityClass => Class.Archer;

        #endregion

        public Archer(EntityInfo entityInfo, Team team) : base(entityInfo, team)  { }
        
        private bool _isFleeing;

        private const float FLEE_RADIUS = 3f;
        private float fleeingDuration;
        private const float MAX_FLEEING_DURATION = 5f;
        
        public override void Tick()
        {
            Entity target = Utility.FindClosestEnemy(this);

            if (target == null)
                return;

            if (!_isFleeing || fleeingDuration >= MAX_FLEEING_DURATION)
            {
                if (MoveToward(target))
                    Attack(target);
                if (Vector2.Distance(Position, target.Position) < Range - FLEE_RADIUS)
                    _isFleeing = true;
            }
            else
            {
                Move(Position - target.Position);
                if (Vector2.Distance(Position, target.Position) > Range)
                    _isFleeing = false;
                fleeingDuration += Program.TICK_DURATION;
            }
        }

    }
}
