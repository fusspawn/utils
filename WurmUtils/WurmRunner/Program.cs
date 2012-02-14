using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WurmUtils.Event;
using WurmUtils.EventHandlers;
using WurmUtils.InputTools;

namespace WurmRunner
{
    class Program
    {
        public static void Main(string[] args)
        {

            if (!WurmUtils.InputTools.InputManager.SetWindow("Wurm Online (LWJGL+AWT) 3.1.2"))
                WurmUtils.InputTools.InputManager.SetWindow("Wurm Online (LWJGL+AWT) 3.1.2 [unstable]");

            var Parser = new WurmUtils.Event.EventParser();

            EventManager.EventHandlers.Add(new Mining());
            EventManager.EventHandlers.Add(new Prospecting());
            EventManager.EventHandlers.Add(new ToFarAway());
            EventManager.EventHandlers.Add(new Fishing());


            ScreenShotManager.TakescreenShot();

            while (true) {
                System.Threading.Thread.Sleep(100);
                Parser.OnEventLogTick();
                ScreenShotManager.ResetFrame();
            }

            ScreenShotManager.TakescreenShot();
        }
    }
}
