using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using WurmUtils.Event;
using WindowsInput;
using WurmUtils.Reporting;

namespace WurmUtils.EventHandlers
{
    public class Mining : WurmUtils.Event.EventHandler
    {
        public Mining() : base() {
            EventsToHandle.Add("You mine some");
        }

        public override void OnEvent(string Message)
        {
            Console.WriteLine("Mining: Handling Event: {0}", Message);
            Console.WriteLine("Sleeping 1.5 sec for Stamina");
            Stamina();
            InputTools.InputManager.SendAction("MINE_FORWARD");
            Console.WriteLine("Mining: MINE_FORWARD event sent");
            Console.WriteLine("Mining for the: " + StatsManager.Incr("Times Mined") + " Time. ");
            base.OnEvent(Message);
        }
    }
}
