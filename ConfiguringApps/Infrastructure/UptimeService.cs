using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ConfiguringApps.Infrastructure
{
    public class UptimeService
    {
        private readonly Stopwatch timer;

        public UptimeService()
        {
            timer = Stopwatch.StartNew();
        }

        public long Uptime => timer.ElapsedMilliseconds;
    }
}
