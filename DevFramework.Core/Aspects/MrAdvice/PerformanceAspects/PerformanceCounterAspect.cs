using MrAdvice.Sharp.Aspects;
using MrAdvice.Sharp.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DevFramework.Core.Aspects.MrAdvice.PerformanceAspects
{
    [Serializable]
    public class PerformanceCounterAspect : OnMethodBoundaryAspect
    {
        private int _interval;
        private Stopwatch _stopwatch;

        public PerformanceCounterAspect(int interval = 5)
        {
            _interval = interval;
        }
        
        public override void OnEntry(MethodExecutionArgs args)
        {
            _stopwatch.Start();
            base.OnEntry(args);
        }
        public override void OnExit(MethodExecutionArgs args)
        {
            _stopwatch.Stop();
            if (_stopwatch.Elapsed.TotalSeconds > _interval) ;
            {
                 
            }
            base.OnExit(args);
        }
    }
}
