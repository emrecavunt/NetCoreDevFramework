using DevFramework.Core.CrossCuttingConcerns.Logging;
using DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net;
using MrAdvice.Sharp.Aspects;
using MrAdvice.Sharp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevFramework.Core.Aspects.MrAdvice.ExceptionAspects
{
    [Serializable]
    public class ExceptionLogAspect : OnExceptionAspect
    {
        private Type _loggerType;
        private LoggerService _loggerService;
        public ExceptionLogAspect(Type loggerType)
        {
            _loggerType = loggerType;
        }
        public override void OnException(MethodExecutionArgs args)
        {
            if (_loggerType.BaseType != typeof(LoggerService))
            {
                throw new Exception("Wrong logger type");
            }
            _loggerService = (LoggerService)Activator.CreateInstance(_loggerType);
            if (!_loggerService.IsInfoEnabled)
            {
                return;
            }
            try
            {

                var logParamaters = args.Method.GetParameters().Select((t, i) => new LogParameter
                {
                    Name = t.Name,
                    Type = t.ParameterType.Name,
                    Value = args.Arguments.Contains(i)
                });

                var logDetail = new LogDetail
                {
                    FullName = args.Method.DeclaringType == null ? null : args.Method.DeclaringType.Name,
                    MethodName = args.MethodName,
                    Parameters = logParamaters.ToList()
                };
                _loggerService.Error(logDetail);
            }
            catch (Exception)
            {

            }
            base.OnException(args);
        }
    }
}
