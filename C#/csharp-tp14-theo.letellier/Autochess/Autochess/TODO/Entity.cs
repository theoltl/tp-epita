using System;
using System.Reflection;

namespace Autochess
{
    public partial class Entity
    {
        private void WrappedAttack(Entity target)
        {
            EntityStat.TotalDamageDealt += target.TakeDamage(Damage);
  
            ExecuteEvents(ActionEvent.Time.AtAttack);
            void Killhook()
            {
                ExecuteEvents(ActionEvent.Time.AtKill);
                EntityStat.Kills += 1;
            }

            if (target.IsDead)
            {
                Killhook();
            }
        }

        public int CalculateMaxDamage(int initialDamage)
        {
            int max = Armor + Health;
            
            if (initialDamage > max)
                return max;
            
            return initialDamage;
        }

        public const float LOW_HEALTH_RATIO = 0.2f;

        
        private void WrappedTakeDamage(int amount, Action killHook = null)
        {
            int armure = Armor;
            int vie = Health;

            if (amount > 0 && Armor > 0)
                ExecuteEvents(ActionEvent.Time.AtLoseArmor);

            (Armor, amount) = (Armor - amount, amount - Armor);

            if (Armor <= 0)
            {
                Armor = 0;

                if (armure > 0)
                    ExecuteEvents(ActionEvent.Time.AtNoMoreArmor);
               
                if (amount > 0)
                    ExecuteEvents(ActionEvent.Time.AtHurt);
            }

            if (amount < 0)
                amount = 0;
            
            EntityStat.TotalArmorLoss += armure - Armor;
            
            Health -= amount;
            if ((float) Health / MaxHealth < LOW_HEALTH_RATIO)
                ExecuteEvents(ActionEvent.Time.AtLowHealth);
            
            if (Health <= 0)
            {
                Health = 0;
                Die(killHook);
            }
            
            EntityStat.TotalDamageReceived += vie - Health;

        }

        public int CalculateMaxHeal(int initialHeal)
        {
            if (initialHeal + Health >= MaxHealth)
                return MaxHealth - Health;
            
            return initialHeal;
        }

        private void WrappedHeal(int amount)
        {
            Health += amount;
            ExecuteEvents(ActionEvent.Time.AtHeal);
            EntityStat.TotalHealReceived += amount;
        }

        private void WrappedGainArmor(int amount)
        {
            Armor += amount;
            ExecuteEvents(ActionEvent.Time.AtGainArmor);
            EntityStat.TotalArmorGain += amount;
        }

        private void WrappedDie(Action killHook = null)
        {
            if (killHook != null)
            {
                killHook.Invoke();
            }

            else
            {
                IsDead = true;
                EntityStat.Survived = false;
                EntityStat.Lifetime = Program.Tick;
                ExecuteEvents(ActionEvent.Time.AtDeath);
            }
            
        }
    }
}
