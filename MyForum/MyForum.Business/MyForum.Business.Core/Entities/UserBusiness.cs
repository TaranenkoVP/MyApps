using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MyForum.Business.Core.Infrastructure.Mappers;
using MyForum.Data.Core.Common.Models;
using MyForum.Data.Core.Models.Identity;

namespace MyForum.Business.Core.Entities
{
    public class UserBusiness : IMapFrom<ApplicationUser>
    {

        #region Constructors

        public UserBusiness()
        {

        }

        #endregion Constructors
        //public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        //{
        //    var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
        //    return userIdentity;
        //}

        public string Photo { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
        public string PasswordHash { get; set; }
        


    }
}
