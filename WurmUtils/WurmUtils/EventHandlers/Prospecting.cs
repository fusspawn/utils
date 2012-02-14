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
    public class Prospecting : WurmUtils.Event.EventHandler
    {
        public Prospecting() : base() {
            EventsToHandle.Add("You would mine");
        }

        public override void OnEvent(string Message)
        {
            Console.WriteLine("Prospect: Handling Event: {0}", Message);
            Stamina();
            InputTools.InputManager.SendAction("PROSPECT");
            Console.WriteLine("Mining: PROSPECT event sent");
            Console.WriteLine("Prospecting for the: " + StatsManager.Incr("Times Prospected") + " Time. ");
            
            base.OnEvent(Message);
        }
    }
}
