using System;
using System.Web;
using System.Web.Security;
using KutuphaneOtomasyon.Core.Entity.Identity;

namespace KutuphaneOtomasyon.Business.Helpers
{
    public static class BusinessWebHelper
    {
        public static int GetAuthId()
        {
            try
            {
                if (!HttpContext.Current.User.Identity.IsAuthenticated) return 0;
                var user = (Identity)HttpContext.Current.User.Identity;
                return user.Id;
            }
            catch
            {
                return 0;
            }
        }
    }
}