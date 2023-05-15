using System.Collections.Generic;

namespace Autochess
{
    public class ActionList
    {
        private static readonly List<ActionEvent.Action> _actions = new List<ActionEvent.Action>();
        private static readonly List<Buff> _buffs = new List<Buff>();

        public static void Init(ItemBank itemBank)
        {
            foreach (Item item in itemBank.Items)
            {
                if (item is MainItem mainItem)
                {
                    foreach (ActionEvent.Action action in mainItem.AttackAction)
                    {
                        action.InitId();
                    }
                }

                foreach (ActionEvent actionEvent in item.ItemEvents)
                {
                    actionEvent.InitActions();
                }
            }
        }

        public static ActionEvent.Action ActionFromId(int id)
        {
            return id < 0 ? null : _actions[id];
        }
        
        public static void AddActionToList(ActionEvent.Action action)
        {
            action.Id = _actions.Count;
            _actions.Add(action);
        }

        private static List<int> idStack = new List<int>();

        public static int GetCause()
        {
            if (idStack.Count > 0)
                return idStack[0];
            return -1;
        }
        
        public static void StartCause(int Id)
        {
            idStack.Insert(0, Id);
        }

        public static void EndCause()
        {
            idStack.RemoveAt(0);
        }
        
        
        public static void AddBuffToList(Buff buff)
        {
            buff.BuffIndex = _buffs.Count;
            _buffs.Add(buff);
        }

        public static Buff GetBuff(int index)
        {
            return _buffs[index];
        }
    }
    
    public partial class ActionEvent
    {
        public void InitActions()
        {
            foreach (Action action in Outcome)
            {
                action.InitId();
            }
        }

        public partial class Action
        {
            public int Id;

            public virtual void InitId()
            {
                ActionList.AddActionToList(this);
            }
        }

        public partial class ExecuteActions
        {
            public override void InitId()
            {
                base.InitId();
                foreach (Action action in Actions)
                {
                    action.InitId();
                }
            }
        }

        public partial class AddBuff : Action
        {
            public override void InitId()
            {
                base.InitId();

                ActionList.AddBuffToList(Buff);

                if (Buff is Buff.Event buffEvent)
                {
                    buffEvent.ActionEvent.InitActions();
                }
            }
        }
    }
}
