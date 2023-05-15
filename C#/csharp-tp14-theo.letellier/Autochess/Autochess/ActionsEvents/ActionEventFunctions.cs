using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime;
using System.Xml.Serialization;

namespace Autochess
{
    public partial class ActionEvent
    {
        public void Execute(Entity entity)
        {
            if (Moment == Time.AtLowHealth && (float)entity.Health / entity.MaxHealth > Entity.LOW_HEALTH_RATIO) return;
                
            foreach (Action action in Outcome)
            {
                action.Execute(entity);
            }
        }

        public  partial class Action
        {
            protected virtual void ExecuteOn(Entity entity)
            {}

            public void Execute(Entity entity)
            {
                List<Entity> targets = Target.Execute(entity);
                
                if (targets.Count == 0)
                    return;
                ActionList.StartCause(Id);
                foreach (Entity target in targets)
                {
                    ExecuteOn(target);
                }
                ActionList.EndCause();
            }
        }

        public partial class AddBuff : Action
        {
            protected override void ExecuteOn(Entity entity)
            {
                Buff.AddToEntity(entity);
            }
        }

        public partial class DealDamage : Action
        {
            protected override void ExecuteOn(Entity entity)
            {
                entity.TakeDamage(Amount);
            }
        }

        public partial class Heal : Action
        {
            protected override void ExecuteOn(Entity entity)
            {
                entity.Heal(Amount);
            }
        }
        
        public partial class GainArmor : Action
        {
            protected override void ExecuteOn(Entity entity)
            {
                entity.GainArmor(Amount);
            }
        }

        public partial class ExecuteActions : Action
        {
            protected override void ExecuteOn(Entity entity)
            {
                EventCreationWrapper.EmptyEvent();
                HistoricManipulator.BeginOutcomeBlock();
                
                foreach (Action action in Actions)
                {
                    action.Execute(entity);
                }
                
                HistoricManipulator.EndOutcomeBlock();
            }
        }

        public partial class Explode : Action
        {
            protected override void ExecuteOn(Entity entity)
            {
                EventCreationWrapper.Explosion(this, entity.Position);
                
                HistoricManipulator.BeginOutcomeBlock();
                
                List<Tuple<float, Entity>> targets = new List<Tuple<float, Entity>>();

                foreach (Entity target in entity.Match.Entities)
                {
                    float ds = Vector2.Distance(entity.Position, target.Position);
                    if (ds > Radius * Radius) continue;
                    
                    targets.Add(new Tuple<float, Entity>(ds / (Radius * Radius), target));
                }

                foreach (Tuple<float,Entity> target in targets)
                {
                    target.Item2.TakeDamage((int)(DamageAtCenter * (1f - target.Item1)));
                }
                
                HistoricManipulator.EndOutcomeBlock();
            }
        }

        public partial class ConsumeItem : Action
        {
            protected override void ExecuteOn(Entity entity)
            {
                EventCreationWrapper.ConsumeItem(entity, ItemName);
                entity.UnequipItem(Item);
            }
        }

        public partial class Debug : Action
        {
            protected override void ExecuteOn(Entity entity)
            {
                toExecute.Invoke(entity);
            }
        }
    }
}
