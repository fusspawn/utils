using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WurmUtils.Reporting
{
    public class StatsManager
    {
        private static  Dictionary<string, int> Stats = new Dictionary<string, int>();

        public static int Decr(string key) {
            if (!Stats.ContainsKey(key))
                Set(key, 1);
            else
                Set(key, Get(key) - 1);

            return Get(key);
        }
        public static int Incr(string key) {
            if (!Stats.ContainsKey(key))
                Set(key, 1);
            else
                Set(key, Get(key) + 1);

            return Get(key);
        }
        public static int Set(string key, int val) {
            Stats[key] = val;
            return Get(key);
        }
        public static int Get(string Key) {
            if (!Stats.ContainsKey(Key))
                return 0;
            else
               return Stats[Key];
        }
    }
}
