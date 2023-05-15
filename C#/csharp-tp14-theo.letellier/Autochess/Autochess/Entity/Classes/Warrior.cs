using System.Numerics;

namespace Autochess
{
    public class Warrior : Entity
    {
        #region Default Values
        
        public override int DefaultMaxHealth => 100;
        public override float DefaultRange => 0.5f;
        public override float DefaultSpeed => 0.9f;
        public override Class EntityClass => Class.Warrior;

        public override int InitialArmor => 20;

        #endregion

        public Warrior(EntityInfo entityInfo, Team team) : base(entityInfo, team)
        {
        }
    }
}
