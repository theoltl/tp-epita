using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;

namespace Autochess
{
    public static class EventCreationWrapper
    {
        public static void EntityCreation(Entity entity)
        {
            HistoricManipulator.AddEvent(new Event.EntityCreation()
            {
                EntityId = entity.Id,
                Team = entity.Team,
                Position = entity.Position,
                Speed = entity.Speed,
                AttackCooldown = entity.AttackCooldown,
                MaxHealth = entity.MaxHealth,
                InitialArmor = entity.Armor,
                HandItemName = entity.MainItem != null ? entity.MainItem.Name : ""
            });
        }

        public static void EntityMoveEvent(Entity entity)
        {
            HistoricManipulator.AddEvent(new Event.EntityMoveEvent()
            {
                EntityId = entity.Id,
                NewPosition = entity.Position
            });
        }

        public static void EntityAttack(Entity entity, Entity target)
        {
            HistoricManipulator.AddEvent(new Event.EntityAttack()
            {
                EntityId = entity.Id,
                TargetId = target.Id
            });
        }

        public static void EntityTakeDamage(Entity entity, int amount)
        {
            HistoricManipulator.AddEvent(new Event.EntityTakeDamage()
            {
                EntityId = entity.Id,
                Amount = amount,
            });
        }

        public static void EntityHeal(Entity entity, int amount)
        {
            HistoricManipulator.AddEvent(new Event.EntityHeal()
            {
                EntityId = entity.Id,
                Amount = amount,
            });
        }

        public static void EntityGainArmor(Entity entity, int amount)
        {
            HistoricManipulator.AddEvent(new Event.EntityGainArmor()
            {
                EntityId = entity.Id,
                Amount = amount
            });
        }

        public static void EntityDie(Entity entity)
        {
            HistoricManipulator.AddEvent(new Event.EntityDie()
            {
                EntityId = entity.Id,
            });
        }

        public static void EmptyEvent()
        {
            HistoricManipulator.AddEvent(new Event());
        }

        public static void Explosion(ActionEvent.Explode explosion, Vector2 position)
        {
            HistoricManipulator.AddEvent(new Event.Explosion()
            {
                Position = position,
                Radius = explosion.Radius,
                DamageAtCenter = explosion.DamageAtCenter
            });
        }

        public static void ConsumeItem(Entity entity, String itemName)
        {
            HistoricManipulator.AddEvent(new Event.ConsumeItem()
            {
                EntityId = entity.Id,
                ItemName = itemName
            });
        }
        
        public static void EntityTeleport(Entity entity)
        {
            HistoricManipulator.AddEvent(new Event.EntityTeleport()
            {
                EntityId = entity.Id,
                NewPosition = entity.Position
            });
        }

        public static void EntityBuff(Entity entity, Buff buff)
        {
            HistoricManipulator.AddEvent(new Event.EntityBuff()
            {
                EntityId = entity.Id,
                BuffIndex = buff.BuffIndex
            });
        }
    }
}
