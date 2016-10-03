using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyForum.Data.Core.Models.Identity;

namespace MyForum.Data.Core.Identity
{
    public class RoleManager : RoleManager<ApplicationRole>
    {
        public RoleManager(RoleStore<ApplicationRole> store)
            : base(store)
        {
        }
    }
}