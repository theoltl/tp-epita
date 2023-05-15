using System.Collections.Generic;

namespace Autochess
{
    public partial class MatchStatistics
    {
        public Team Winner;
        
        public string RedConfigPath;
        public TeamStatistics RedStats = new TeamStatistics();

        public string WhiteConfigPath;
        public TeamStatistics WhiteStats = new TeamStatistics();
        
        public int MatchDuration;
    }

    public partial class TeamStatistics
    {
        public List<EntityStatistics> EntityStatistics;
    }

    public partial class EntityStatistics
    {
        public EntityInfo Entity;
        
        public int TotalDamageDealt;
        public int TotalDamageReceived;

        public int TotalHealReceived;
        
        public int MaxArmor;
        public int TotalArmorLoss;
        public int TotalArmorGain;
        
        public int Kills;
        public float TraveledDistance;

        public bool Survived = true;
        public float Lifetime;
    }
}
