using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using WurmUtils.Event;
using WindowsInput;
using WurmUtils.InputTools;

namespace WurmUtils.EventHandlers
{
    public class ToFarAway : WurmUtils.Event.EventHandler
    {
        public ToFarAway()
            : base()
        {
            EventsToHandle.Add("You are too far away to do that.");
        }

        public override void OnEvent(string Message)
        {
            Console.WriteLine("To Far Away: Handling Event: {0}", Message);
            InputManager.HoldKey(VirtualKeyCode.VK_W, 2000);
            Console.WriteLine("Should be in range now");
            InputManager.SendAction(InputManager.CurrentAction);
            base.OnEvent(Message);
        }
    }
}
