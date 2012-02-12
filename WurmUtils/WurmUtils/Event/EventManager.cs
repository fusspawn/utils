using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WurmUtils.Event
{
    public class EventManager
    {
        public static List<EventHandler> EventHandlers = new List<EventHandler>();
        public static void RouteEvent(string EventMessage) {
            foreach(EventHandler eh in EventHandlers)
            {
                foreach (string handles in eh.EventsToHandle) {
                    if (EventMessage.Contains(handles))
                        eh.OnEvent(EventMessage);
                }
            }
        }
    }
}
