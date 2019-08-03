using System;
using System.Linq;
using System.Reflection;
using KutuphaneOtomasyon.Business.CrossCuttingConcerns.Logging;
using KutuphaneOtomasyon.Business.CrossCuttingConcerns.Logging.Log4Net;
using PostSharp.Aspects;
using PostSharp.Extensibility;

namespace KutuphaneOtomasyon.Business.Aspects.LogAspects.Log4Net
{
    [Serializable]
    [MulticastAttributeUsage(MulticastTargets.Method, TargetExternalMemberAttributes = MulticastAttributes.Instance)]
    public class LogAspect : OnMethodBoundaryAspect
    {
        private Type _loggerType;
        private LoggerService _loggerService;

        public LogAspect(Type loggerType)
        {
            _loggerType = loggerType;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            if (_loggerType.BaseType != typeof(LoggerService))
            {
                throw new Exception("Yanlış Loglama tipi");
            }

            _loggerService = (LoggerService)Activator.CreateInstance(_loggerType);
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            var logParameter = args.Method.GetParameters().Select((t, i) => new LogParameter
            {
                Name = t.Name,
                Type = t.ParameterType.Name,
                Values = args.Arguments.GetArgument(i),
            }).ToList();
            var logDetail = new LogDetail
            {
                FullName = args.Method.DeclaringType == null ? null : args.Method.DeclaringType.Name,
                MethodName = args.Method.Name,
                Parameters = logParameter,
            };
            _loggerService.Info(logDetail);
        }
    }
}