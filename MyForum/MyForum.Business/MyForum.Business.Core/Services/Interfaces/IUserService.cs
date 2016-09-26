using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using MyForum.Business.Core.Entities;
using MyForum.Business.Core.Infrastructure;
using MyForum.Business.Core.Services.Common;

namespace MyForum.Business.Core.Services.Interfaces
{
    public interface IUserService : IBaseService
    {
        Task<OperationDetails> Create(UserBusiness userBusiness);
        Task<ClaimsIdentity> Authenticate(UserBusiness userBusiness);
        Task<IList<UserLoginInfo>> GetLoginsAsync(string userId);
        UserBusiness FindById(string userId);
    }
}
