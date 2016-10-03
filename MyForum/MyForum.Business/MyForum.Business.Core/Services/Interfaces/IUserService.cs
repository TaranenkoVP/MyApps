using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using MyForum.Business.Core.Entities;
using MyForum.Business.Core.Infrastructure;
using MyForum.Business.Core.Services.Common;

namespace MyForum.Business.Core.Services.Interfaces
{
    public interface IUserService : IService
    {
        Task<OperationDetails> CreateAsync(UserBusiness userBusiness);

        Task<ClaimsIdentity> AuthenticateAsync(UserBusiness userBusiness);

        Task<IList<UserLoginInfo>> GetLoginsAsync(string userId);

        Task<UserBusiness> FindByIdAsync(string userId);
    }
}