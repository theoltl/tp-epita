using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Autochess
{
    public partial class Match
    {
        public readonly List<Entity> Entities = new List<Entity>();
        public readonly MatchStatistics MatchStatistics;
        
        private readonly Dictionary<Team, int> _entitiesAlive;
        private List<Buff.ActiveBuff> _activeBuffs = new List<Buff.ActiveBuff>();

        private Team teamOfLastEntityToDie;

        public Match(string redConfigPath, string whiteConfigPath)
        {
            HistoricManipulator.Init();

            MatchStatistics = new MatchStatistics(redConfigPath, whiteConfigPath);
            
            _entitiesAlive = new Dictionary<Team, int>();
            foreach (Team team in Enum.GetValues(typeof(Team)))
                _entitiesAlive[team] = 0;
        }

        public bool IsFinished(out Team winningTeam)
        {
            List<KeyValuePair<Team, int>> tmp = _entitiesAlive.Where(pair => pair.Value > 0).ToList();

            if (tmp.Count == 1)
            {
                winningTeam = tmp[0].Key;
                return true;
            }

            if (tmp.Count == 0)
            {
                Console.Write("That was close! but... ");
                winningTeam = teamOfLastEntityToDie;
                return true;
            }

            winningTeam = Team.Red;
            return false;
        }

        public void Tick()
        {
            // Destroy buffs that worn off
            _activeBuffs = _activeBuffs.Where(x =>
            {
                if (x.DurationLeft < 0f)
                {
                    x.Destroy();
                    return false;
                }

                return true;
            }).ToList();

            // Wore off currently active buffs
            foreach (Buff.ActiveBuff activeBuff in _activeBuffs)
            {
                activeBuff.DurationLeft -= Program.TICK_DURATION;
            }


            foreach (Entity entity in Entities)
                entity.TickWrapper();
            
            // Remove dead entities from the list
            for (int i = 0; i < Entities.Count;)
            {
                if (Entities[i].IsDead)
                {
                    _entitiesAlive[Entities[i].Team]--;
                    Entities.RemoveAt(i);
                }
                else
                    i++;
            }
        }

        public void AddEntity(Entity entity)
        {
            Entities.Add(entity);
            _entitiesAlive[entity.Team]++;
            entity.SetId(Entities.Count - 1);

            entity.SetMatch(this);
            
            entity.PreMatch();
        }

        public void AddBuff(Buff.ActiveBuff activeBuff)
        {
            _activeBuffs.Add(activeBuff);
        }
    }
}
