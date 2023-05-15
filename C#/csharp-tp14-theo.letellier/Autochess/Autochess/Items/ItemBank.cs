using System.Collections.Generic;

namespace Autochess
{
    public class ItemBank
    {
        public List<Item> Items;
        
        public Item GetItem(string name)
        {
            return Items?.Find(item => item.Name == name);
        }
    }
}
