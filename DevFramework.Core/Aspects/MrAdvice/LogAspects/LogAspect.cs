using DevFramework.Core.CrossCuttingConcerns.Logging;
using DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net;
using MrAdvice.Sharp.Aspects;
using MrAdvice.Sharp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace DevFramework.Core.Aspects.MrAdvice.LogAspects
{
    [AttributeUsage(AttributeTargets.All,AllowMultiple =true)]
    [Serializable]
    public class LogAspect : OnMethodBoundaryAspect
    {
        private Type _loggerType;
        private LoggerService _loggerService;
        public LogAspect(Type loggerType)
        {
            _loggerType = loggerType;
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            if(_loggerType.BaseType!=typeof(LoggerService))
            {
                throw new Exception("Wrong logger type");
            }
            _loggerService = (LoggerService)Activator.CreateInstance(_loggerType);
            if(!_loggerService.IsInfoEnabled)
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
                _loggerService.Info(logDetail);
            }
            catch (Exception)
            {

            }

            base.OnEntry(args);
        }


    }
}
