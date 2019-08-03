using System;
using System.Reflection;
using KutuphaneOtomasyon.Business.CrossCuttingConcerns.Logging.Log4Net;
using KutuphaneOtomasyon.Entities.Response.Concrete;
using PostSharp.Aspects;
using PostSharp.Extensibility;

namespace KutuphaneOtomasyon.Business.Aspects.ExceptionAspects
{
    [MulticastAttributeUsage(MulticastTargets.Method, TargetExternalMemberAttributes = MulticastAttributes.Instance)]    
    [Serializable]
    public class ExceptionLogAspect : OnExceptionAspect
    {
        private Type _loggerType;
        private LoggerService _loggerService;

        public ExceptionLogAspect(Type loggerType)
        {
            _loggerType = loggerType;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            _loggerService = (LoggerService)Activator.CreateInstance(_loggerType);
            base.RuntimeInitialize(method);
        }

        public override void OnException(MethodExecutionArgs args)
        {
            try
            {
                args.FlowBehavior = FlowBehavior.Return;
                if (_loggerService != null)
                {
                    _loggerService.Error(" Exception type : " + args.Exception.Message + " Method : " + args.Method.Name + " Controller : " + args.Instance);
                }

                args.ReturnValue = new DataResponse
                {
                    Mesaj = "Sistem Hatası",
                    Tamamlandi = false,
                };
            }
            catch (Exception ex)
            {
                if (_loggerService != null)
                {
                    _loggerService.Error(" Exception type : " + ex.Message + " Method : " + args.Method.Name + " Controller : " + args.Instance);
                }
                args.ReturnValue = new DataResponse
                {
                    Mesaj = "Sistem Hatası",
                    Tamamlandi = false,
                };
            }

        }

    }
}