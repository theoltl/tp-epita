using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Autochess
{
    [XmlInclude(typeof(MainItem))]
    public partial class Item
    {
        public String Name;
        public String Description;

        public int cost = 0;

        public List<ActionEvent> ItemEvents;
        
        public Entity.Class ItemClass;
    }
}
