using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WurmUtils.Event;
using WindowsInput;
using WurmUtils.InputTools;

namespace WurmUtils.EventHandlers
{
    public class Fishing : WurmUtils.Event.EventHandler
    {
        public Fishing()
            : base()
        {
            EventsToHandle.Add("You catch a");
            EventsToHandle.Add("You seem to catch something but it escapes.");
        }

        public override void OnEvent(string Message)
        {
            Console.WriteLine("Fishing Event: Wait Then Cast");
            Stamina();
            InputManager.SendAction("FISH");
        }
    }
}
