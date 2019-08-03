using System.Security.Principal;

namespace KutuphaneOtomasyon.Core.Entity.Identity
{
    public class Identity : IIdentity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string AuthenticationType { get; set; }

        public bool IsAuthenticated { get; set; }

        public string[] Roles { get; set; }
    }
}