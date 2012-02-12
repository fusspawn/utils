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
    public class FoodDrink : WurmUtils.Event.EventHandler
    {
        private int TickCount = 0;

        public FoodDrink() 
            : base() {
                EventsToHandle.Add("Tick");
        }

        public override void OnEvent(string Message)
        {
            if (TickCount > (10 * 60 * 10)) { 
                
            }
        }
    }
}
