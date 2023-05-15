using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.Serialization;


namespace Autochess
{
    public partial class PlayerConfig
    {
        public List<EntityInfo> Entities;
    }
     
    [DataContract]
    public class EntityInfo
    {
        [DataMember]
        public string Name;
        
        [DataMember]
        public Entity.Class Class;
        
        [DataMember]
        public string MainItem;
        
        [DataMember]
        public Vector2 InitialPosition;
        
        [DataMember]
        public List<string> Items;
    }
}
