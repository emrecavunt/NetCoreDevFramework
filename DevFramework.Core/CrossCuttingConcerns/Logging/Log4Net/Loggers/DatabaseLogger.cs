using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using NLog;

namespace DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers
{
    public class DatabaseLogger : LoggerService
    {
        public DatabaseLogger() : base(LogManager.GetLogger("DatabaseLogger"))
        {
             
        }
    }
}
