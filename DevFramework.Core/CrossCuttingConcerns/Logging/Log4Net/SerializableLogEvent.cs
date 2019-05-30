using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net
{
    [Serializable]
    public class SerializableLogEvent 
    {
        private SerializableLogEvent _serializableLogEvent;

        public SerializableLogEvent(SerializableLogEvent serializableLogEvent)
        {
            _serializableLogEvent = serializableLogEvent;
        }
        public string UserName => _serializableLogEvent.UserName;
        public object MessageObject => _serializableLogEvent.MessageObject;
    
    }
}
