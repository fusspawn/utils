using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WurmUtils.Event
{
    public class EventParser
    {
        private List<String> LastEvents = new List<string>();
        public EventParser() {
            try { File.Copy(WurmUtils.Core.Static.LogsPath, "./event.tmp", true); }
            catch (Exception evnt)
            {
                Console.WriteLine(evnt.Message.ToString());
                return;
            }
            ProcessEventFile(false);
        }

        public void OnEventLogTick() {
            // This file could be locked.
            try  { File.Copy(WurmUtils.Core.Static.LogsPath, "./event.tmp", true); }
            catch (Exception evnt) {
                Console.WriteLine(evnt.Message.ToString());
                return;
            }
            ProcessEventFile();
        }


        void ProcessEventFile(bool ThrowEvents=true) {
            TextReader Reader = File.OpenText("event.tmp");
            String Line = Reader.ReadLine();
                
            while (Line != null)
            {
                if (!LastEvents.Contains(Line))
                {
                    LastEvents.Add(Line);
                    if (ThrowEvents)
                        EventManager.RouteEvent(Line);
                }
                Line = Reader.ReadLine();
            }
            Reader.Close();
        }
    }
}
