using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WurmRunner
{
    class Program
    {
        public static void Main(string[] args)
        {
            var Parser = new WurmUtils.Event.EventParser();
            while (true) {
                System.Threading.Thread.Sleep(100);
                Parser.OnEventLogTick();
            }
        }
    }
}
