using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Text.RegularExpressions;

namespace Autochess
{
    public partial class Entity
    {
        #region Default Values

        public virtual int DefaultMaxHealth => 100;
        public virtual float DefaultRange => 0.25f;
        public virtual float DefaultAttackCooldown => 0.8f;

        public virtual float DefaultSpeed => 1f;
        public virtual int DefaultDamage => 3;

        public virtual int InitialArmor => 0;

        public virtual Class EntityClass => Class.Neutral;

        #endregion

        #region To Set Variables

        public Team Team { get; }
        protected Vector2 _position;

        public Vector2 Position
        {
            get => _position;
            protected set
            {
                EventCreationWrapper.EntityMoveEvent(this);
                _position = value;
            }
        }

        public MainItem MainItem { get; set; }

        public String Name { get; set; }

        public EntityStatistics EntityStat => Match.MatchStatistics.GetEntityStat(this);

        private Match _match;

        public Match Match
        {
            get
            {
                if (_match == null)
                    throw new Exception("This entity has never been added to a match");
                return _match;
            }
        }

        public void SetMatch(Match match)
        {
            _match = match;
            Match.MatchStatistics.AddEntity(this, entityInfo);
        }

        #endregion

        private float _attackRemainingCooldown = 0f;
        public int Health { get; set; }

        private int _armor;

        public int Armor
        {
            get => _armor;
            set
            {
                _armor = value;
                EntityStat.MaxArmor = Math.Max(EntityStat.MaxArmor, Armor);
            }
        }

        public bool IsDead { get; private set; }
        public int Id { get; private set; }

        public void SetId(int id)
        {
            Id = id;
        }

        private EntityInfo entityInfo;
        
        #region Constructor

        public Entity(EntityInfo entityInfo, Team team)
        {
            // Set important starter values
            this.entityInfo = entityInfo;
            Team = team;
        }

        #endregion

        
        public void PreMatch()
        {
            MainItem = (MainItem) Program.ItemBank.GetItem(entityInfo.MainItem);
            
            // Create entity data that stores the 
            _normal = new EntityData()
            {
                MaxHealth = DefaultMaxHealth,
                Range = MainItem?.Range ?? DefaultRange,
                AttackCooldown = MainItem?.AttackCooldown ?? DefaultAttackCooldown,
                Damage = MainItem?.Damage ?? DefaultDamage,
                Speed = DefaultSpeed,
            };
            
            // Init values
            Health = MaxHealth;
            IsDead = false;
            Armor = InitialArmor;

            Name = entityInfo.Name;
            _position = Utility.CalcPosition(entityInfo.InitialPosition, Team);

            // Equip Items
            if (MainItem != null)
                EquipItem(MainItem);

            if (entityInfo.Items != null)
                foreach (string itemName in entityInfo.Items)
                    EquipItem(Program.ItemBank.GetItem(itemName));
            
            
            // init events
            EventCreationWrapper.EntityCreation(this);
            HistoricManipulator.BeginOutcomeBlock();
            ExecuteEvents(ActionEvent.Time.AtInit);
            HistoricManipulator.EndOutcomeBlock();
        }


        #region Movement

        protected bool IsStuck;

        public void Move(Vector2 direction)
        {
            if (IsDead) return;

            // Add a little bit of cooldown (a entity can't move if its moving)
            _attackRemainingCooldown = 0.01f;

            // Compute the movement
            Vector2 movement = Vector2.Normalize(direction) * Speed * Program.TICK_DURATION;

            // Adjust the position thanks to collisions
            Vector2 newPosition = Utility.AdjustPosition(this, Position + movement, out IsStuck);

            // Update the traveled distance statistic of this entity
            EntityStat.TraveledDistance += Vector2.Distance(Position, newPosition);

            // Update the position
            Position = newPosition;
        }

        public bool MoveToward(Entity entity)
        {
            if (IsDead) return false;

            Vector2 direction = entity.Position - Position;

            // If the distance is less than the Range, return true
            // else move toward the target
            if (direction.Length() - Utility.ENTITY_HITBOX_RADIUS < Range)
                return true;

            Move(direction);
            return false;
        }

        #endregion

        #region Wrappers

        public void Attack(Entity target)
        {
            if (IsDead) return;

            if (_attackRemainingCooldown > 0f) return;
            _attackRemainingCooldown = AttackCooldown;

            if (Vector2.Distance(Position, target.Position) - Utility.ENTITY_HITBOX_RADIUS > Range) return;

            EventCreationWrapper.EntityAttack(this, target);
            HistoricManipulator.BeginOutcomeBlock();

            // If the entity has a MainItem, execute the main item attack actions
            if (MainItem != null)
            {
                foreach (ActionEvent.Action action in MainItem.AttackAction)
                    action.Execute(target);
            }

            WrappedAttack(target);
            HistoricManipulator.EndOutcomeBlock();
        }

        public int TakeDamage(int amount, Action killHook = null)
        {
            if (IsDead) return 0;
            EventCreationWrapper.EntityTakeDamage(this, amount);
            HistoricManipulator.BeginOutcomeBlock();
            amount = CalculateMaxDamage(amount);
            WrappedTakeDamage(amount, killHook);
            HistoricManipulator.EndOutcomeBlock();
            return amount;
        }

        public void Heal(int amount)
        {
            if (IsDead) return;
            amount = CalculateMaxHeal(amount);
            EventCreationWrapper.EntityHeal(this, amount);
            HistoricManipulator.BeginOutcomeBlock();
            WrappedHeal(amount);
            HistoricManipulator.EndOutcomeBlock();
        }

        public void GainArmor(int amount)
        {
            if (IsDead) return;

            EventCreationWrapper.EntityGainArmor(this, amount);
            HistoricManipulator.BeginOutcomeBlock();
            WrappedGainArmor(amount);
            HistoricManipulator.EndOutcomeBlock();
        }

        public void Die(Action killHook = null)
        {
            if (IsDead) return;
            EventCreationWrapper.EntityDie(this);
            HistoricManipulator.BeginOutcomeBlock();
            WrappedDie(killHook);
            HistoricManipulator.EndOutcomeBlock();
        }

        public void TickWrapper()
        {
            ExecuteEvents(ActionEvent.Time.EveryTick);
            Tick();
            if (_attackRemainingCooldown > 0f)
                _attackRemainingCooldown -= Program.TICK_DURATION;
        }

        #endregion

        public virtual void Tick()
        {
            Entity target = Utility.FindClosestEnemy(this);

            if (target == null)
                return;

            if (MoveToward(target))
                Attack(target);
        }
    }
}
