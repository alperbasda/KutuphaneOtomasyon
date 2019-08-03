using System;
using System.Threading;
using KutuphaneOtomasyon.Entities.Response.Concrete;
using PostSharp.Aspects;

namespace KutuphaneOtomasyon.Business.Aspects.AuthorizationAspects
{
    [Serializable]
    public class SecuredOperationAspect : OnMethodBoundaryAspect
    {
        public string Roles { get; set; }

        public override void OnEntry(MethodExecutionArgs args)
        {
            string[] roles = Roles.Split(',');
            bool isAuthorize = false;
            for (int i = 0; i < roles.Length; i++)
            {
                if (Thread.CurrentPrincipal.IsInRole(roles[i]))
                {
                    isAuthorize = true;
                    break;
                }
            }


            if (isAuthorize == false)
            {
                args.FlowBehavior = FlowBehavior.Return;
                args.ReturnValue = new DataResponse
                {
                    Tamamlandi = false,
                    Mesaj = "Bu işlem için yetkiniz yok",
                };
            }

        }
    }
}