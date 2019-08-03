using System;
using System.Linq;
using System.Web.Security;
using KutuphaneOtomasyon.Core.Entity.Identity;

namespace KutuphaneOtomasyon.Business.Helpers
{
    public class SecurityUtilities
    {
        public Identity FormAuthToIdentity(FormsAuthenticationTicket ticket)
        {
            var identity = new Identity
            {
                Name = SetName(ticket),
                Roles = SetRoles(ticket),
                AuthenticationType = SetAuthType(),
                IsAuthenticated = SetIsAuthenticated(),
                Id = Convert.ToInt32(SetId(ticket)),
            };

            return identity;
        }

        private bool SetIsAuthenticated()
        {
            return true;
        }

        private string SetAuthType()
        {
            return "Forms";
        }

        private string SetId(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            return data[0];
        }

        private string[] SetRoles(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            return data[2].Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        }

        private string SetName(FormsAuthenticationTicket ticket)
        {
            return ticket.Name;
        }
        
    }
}