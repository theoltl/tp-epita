using System.Collections.Generic;
using System.Xml.Serialization;

namespace Autochess
{
    public partial class MainItem : Item
    {
        public float AttackCooldown;
        public int Damage;
        public float Range;

        public List<ActionEvent.Action> AttackAction;
    }
}
