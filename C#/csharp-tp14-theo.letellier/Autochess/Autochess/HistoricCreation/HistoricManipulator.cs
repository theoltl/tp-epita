using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Autochess
{
    public static class HistoricManipulator
    {
        public static Historic Historic { get; private set; }

        private static readonly List<Event> eventStack = new List<Event>();
        private static Event _lastCreatedEvent;
        
        public static void Init()
        {
            Historic = new Historic()
            {
                Events = new List<List<Event>>(),
                TickDuration = Program.TICK_DURATION
            };
            
            NewTick();
        }

        public static void Save(string path)
        {
            Serializer.Xml.ToFile(path, Historic);
        }

        public static void NewTick()
        {
            Historic.Events.Add(new List<Event>());
            _lastCreatedEvent = null;
        }

        public static void AddEvent(Event newEvent)
        {
            newEvent.CauseId = ActionList.GetCause();
            
            _lastCreatedEvent = newEvent;

            if (eventStack.Count > 0)
                eventStack[0].followingEvents.Add(newEvent);
            else
                Historic.Events[Historic.Events.Count - 1].Add(newEvent);
        }

        
        public static void BeginOutcomeBlock()
        {
            if (_lastCreatedEvent == null)
                throw new NullReferenceException("No event was created at this point");
            eventStack.Insert(0, _lastCreatedEvent);
        }

        public static void EndOutcomeBlock()
        {
            eventStack.RemoveAt(0);
        }
    }
}
