using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;
using WurmUtils.InputTools;

namespace WurmUtils.Event
{
    public class EventHandler
    {
        public int MinStamDelay = 2000;
        public int MaxStamDelay = 3500;
        private Random R = new Random();
        public bool NeedsScreenShot = false;
        public System.Drawing.Point StamCheckLocation = new System.Drawing.Point(170, 60);
        public int StamFullColor = 99;

        public EventHandler() {
        }

        public List<string> EventsToHandle = new List<string>();
        public virtual void OnEvent(string Message) { }
        
        public void Stamina() {
            bool HasStamina = false;
            
            while (!HasStamina) 
            {
                int StamGreen = ScreenShotManager.GetScreenColor(StamCheckLocation.X, StamCheckLocation.Y).G;
                if (StamGreen != StamFullColor)
                {
                    Console.WriteLine("No Stamina Yet. Waiting. Green was: " + StamGreen);
                    Thread.Sleep(1000);
                }
                else 
                {
                    HasStamina = true;
                    Console.WriteLine("Stamina Full");
                }


                ScreenShotManager.ResetFrame();
            }

            Thread.Sleep(500);
            
            /*
            int StamRand = R.Next(MinStamDelay, MaxStamDelay);
            Console.WriteLine("Sleeping for stamina: " + StamRand.ToString());
            Thread.Sleep(StamRand);
             * */
        }
    }
}
