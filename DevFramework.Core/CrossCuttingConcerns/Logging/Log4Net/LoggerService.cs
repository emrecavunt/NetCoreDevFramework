using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net
{
    [Serializable]
    public class LoggerService
    {
        private Logger _logger;

        public LoggerService(Logger logger)
        {
            _logger = logger;
        }

        public bool IsInfoEnabled => _logger.IsInfoEnabled;
        public bool IsDebugEnabled => _logger.IsDebugEnabled;
        public bool IsWarnEnabled => _logger.IsWarnEnabled;
        public bool IsFatalEnabled => _logger.IsFatalEnabled;
        public bool IsErrorEnabled => _logger.IsErrorEnabled;


        public void Info(object logMessage)
        {
           if(IsInfoEnabled)
            {
                _logger.Info(logMessage);
            }
        }
        public void Debug(object logMessage)
        {
            if (IsInfoEnabled)
            {
                _logger.Debug(logMessage);
            }
        }
        public void Warn(object logMessage)
        {
            if (IsInfoEnabled)
            {
                _logger.Warn(logMessage);
            }
        }
        public void Fatal(object logMessage)
        {
            if (IsInfoEnabled)
            {
                _logger.Fatal(logMessage);
            }
        }
        public void Error(object logMessage)
        {
            if (IsInfoEnabled)
            {
                _logger.Error(logMessage);
            }
        }
    }
}
