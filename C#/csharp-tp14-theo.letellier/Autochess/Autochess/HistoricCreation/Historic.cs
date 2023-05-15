using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Xml.Serialization;

namespace Autochess
{
    public class Historic
    {
        public float TickDuration;

        public Team WinningTeam;
        
        public List<List<Event>> Events;
    }
}
