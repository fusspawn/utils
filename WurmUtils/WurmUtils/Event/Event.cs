using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WurmUtils.Event
{
    public class EventHandler
    {
        public virtual void OnEvent(string Message) { }
    }
}
