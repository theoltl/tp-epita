using System;
using System.Collections.Generic;

namespace Autochess
{
    
    public class EntityData
    {
        public int MaxHealth;
        public float Range;
        public float AttackCooldown;
        public int Damage;
        public float Speed;

        public EntityData Clone()
        {
            return new EntityData()
            {
                AttackCooldown = AttackCooldown,
                Damage = Damage,
                MaxHealth = MaxHealth,
                Speed = Speed,
                Range = Range
            };
        }
    }
    
    public partial class Entity
    {
        private EntityData _normal;
        
        
        private bool _recalculate = true;

        private EntityData _data;
        public EntityData Data
        {
            get
            {
                if (_recalculate)
                {
                    _data = _normal.Clone();
                    foreach (Buff.ActiveBuff activeBuff in _activeBuffs)
                    {
                        if (activeBuff.Buff is Buff.Stat statBuff)
                            statBuff.Modifier.Execute(ref _data);
                    }

                    Health = Math.Min(_data.MaxHealth, Health);
                    _recalculate = false;
                }

                return _data;
            }
        }
        
        private readonly List<Buff.ActiveBuff> _activeBuffs = new List<Buff.ActiveBuff>();

        public void AddBuff(Buff.ActiveBuff activeBuff)
        {
            _recalculate = true;
            _activeBuffs.Add(activeBuff);

            if (activeBuff.Buff is Buff.Event eventBuff)
                _itemEventHandlers[eventBuff.ActionEvent.Moment] += eventBuff.ActionEvent.Execute;
        }

        public void RemoveBuff(Buff.ActiveBuff activeBuff)
        {
            _recalculate = true;
            _activeBuffs.Remove(activeBuff);
            if (activeBuff.Buff is Buff.Event eventBuff)
            {
                _itemEventHandlers[eventBuff.ActionEvent.Moment] -= eventBuff.ActionEvent.Execute;
            }
        }
        
        
        
        public int MaxHealth
        {
            get => Data.MaxHealth;
            set => Data.MaxHealth = value;
        }

        public float Speed => Data.Speed;
        public int Damage => Data.Damage;
        public float Range => Data.Range;
        public float AttackCooldown
        {
            get => Data.AttackCooldown;
            set => Data.AttackCooldown = value;
        }
    }
}
