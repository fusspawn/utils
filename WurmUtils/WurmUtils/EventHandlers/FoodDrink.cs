using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WurmUtils.Event;
using WindowsInput;
using WurmUtils.InputTools;

using System.Drawing;

namespace WurmUtils.EventHandlers
{
    public class FoodDrink : WurmUtils.Event.EventHandler
    {
        private int TickCount = 0;
        private Color WaterColor = Color.White;
        private Color FoodColor = Color.White;
        private Color StaminaColor = Color.White;

        private List<System.Drawing.Point> WaterScanLocations = new List<System.Drawing.Point>();
        private List<System.Drawing.Point> FoodScanLocations = new List<System.Drawing.Point>();
        private List<System.Drawing.Point> StaminaScanLocations = new List<System.Drawing.Point>();

        public FoodDrink() 
            : base() {
                EventsToHandle.Add("Tick");
        }

        public override void OnEvent(string Message)
        {
            if (TickCount > (10 * 60 * 10)) {
                ScanLocations();
            }
        }

        private void ScanLocations()
        {
            bool WaterOkay = false;
            foreach(System.Drawing.Point WPoint in WaterScanLocations)
                if((ScreenShotManager.GetScreenColor(WPoint.X, WPoint.Y) == WaterColor))
                     WaterOkay = true;

            bool FoodOkay = false;
            foreach(System.Drawing.Point WPoint in FoodScanLocations)
                if((ScreenShotManager.GetScreenColor(WPoint.X, WPoint.Y) == FoodColor))
                     FoodOkay = true;


            if (!WaterOkay) {
                Console.WriteLine("Thirsty. Attempting to Drink");
                Drink();
            }

            if (!FoodOkay) {
                Console.WriteLine("Hungry. Attempting to Eat");
                Eat();
            }
        }

        private void Eat()
        {
            throw new NotImplementedException();
        }

        private void Drink()
        {
            throw new NotImplementedException();
        }
    }
}
