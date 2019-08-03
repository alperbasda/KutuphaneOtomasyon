using System;
using System.Text;
using System.Web;
using System.Web.Security;

namespace KutuphaneOtomasyon.Business.Helpers
{
    public class AuthenticationHelper
    {
        public static void CreateAuthCookie(string userName,int id, string[] roles)
        {
            var authTicket = new FormsAuthenticationTicket(1, userName, DateTime.Now, DateTime.Now.AddDays(7), true, CreateAuthText(id,userName,roles));
            string encTicket = FormsAuthentication.Encrypt(authTicket);
            HttpContext.Current.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
        }

        public static string CreateAuthText(int id, string userName, string[] roles)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(id);
            stringBuilder.Append("|");
            stringBuilder.Append(userName);
            stringBuilder.Append("|");
            for (int i = 0; i < roles.Length; i++)
            {
                stringBuilder.Append(roles[i]);
                if (i < roles.Length - 1)
                    stringBuilder.Append(",");
            }
            
            

            return stringBuilder.ToString();
        }
    }
}