using Newtonsoft.Json;
using NLog;
using NLog.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Layout
{
    public class MyJsonLayout :JsonLayout 
    {
        //protected override void RenderFormattedMessage(LogEventInfo logEvent, StringBuilder target)
        //{

        //    var logEvent = new SerializableLogEvent(logEvent);
        //    var json = JsonConvert.SerializeObject(logEvent, Formatting.Indented);

        //    base.RenderFormattedMessage(json, target);
        //}
        //protected override void InitializeLayout()
        //{
        //    var logEvent = new SerializableLogEvent()
        //    base.InitializeLayout();
        //}
    }
}
