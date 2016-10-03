using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using MyForum.Business.Core.Entities;
using MyForum.Business.Core.Infrastructure;

namespace MyForum.Business.Core.Services.Interfaces
{
    public interface IUserService
    {
        Task<OperationDetails> Create(UserBusiness userBusiness);
        Task<ClaimsIdentity> Authenticate(UserBusiness userBusiness);
        Task<IList<UserLoginInfo>> GetLoginsAsync(string userId);
        UserBusiness FindById(string userId);
    }
}