using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using SongWei.Triggers;

namespace Triggers.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var imTrigger = new ImpulseTigger();
            Debug.Assert(imTrigger.State == false);
            imTrigger.Reset();
            Debug.Assert(imTrigger.State == false);
            imTrigger.Trigging(null);
            Debug.Assert(imTrigger.State == true);
            imTrigger.Reset();
            imTrigger.Trigging(() => Debug.Assert(imTrigger.State == true));
            imTrigger.Reset(() => Debug.Assert(imTrigger.State == false));
            var n2Trigger = new LeveledImpulseTigger(1);
            Debug.Assert(n2Trigger.State == 0);
            n2Trigger.Relaxing();
            Debug.Assert(n2Trigger.State == 0);
            n2Trigger.Stimulating(null);
            Debug.Assert(n2Trigger.State == 1);
            n2Trigger.Stimulating(null);
            Debug.Assert(n2Trigger.State == 1);
            n2Trigger.Relaxing(() => Debug.Assert(n2Trigger.State == 0));
            n2Trigger.Stimulating(() => Debug.Assert(n2Trigger.State == 1));
        }
    }
}
