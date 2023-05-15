using System;
using System.Collections.Generic;

namespace Autochess
{
    public partial class Entity
    {
        private delegate void ActionEventHandler(Entity entity);
        private Dictionary<ActionEvent.Time,ActionEventHandler> _itemEventHandlers;

        private void InitEventHandler()
        {
            _itemEventHandlers = new Dictionary<ActionEvent.Time, ActionEventHandler>();
            foreach (ActionEvent.Time time in Enum.GetValues(typeof(ActionEvent.Time)))
                _itemEventHandlers[time] = entity => {};
        }

        public void EquipItem(Item item)
        {
            if (item == null) return;
            
            if (_itemEventHandlers == null)
                InitEventHandler();
            
            foreach (ActionEvent itemEvent in item.ItemEvents)
            {
                _itemEventHandlers[itemEvent.Moment] += itemEvent.Execute;
            }
        }
        
        public void UnequipItem(Item item)
        {
            foreach (ActionEvent itemEvent in item.ItemEvents)
                _itemEventHandlers[itemEvent.Moment] -= itemEvent.Execute;
        }

        public void ExecuteEvents(ActionEvent.Time moment)
        {
            if (_itemEventHandlers == null)
                InitEventHandler();
            
            _itemEventHandlers[moment].Invoke(this);
        }
    }
}
