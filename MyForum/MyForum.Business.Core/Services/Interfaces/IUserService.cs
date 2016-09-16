using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MyForum.Business.Core.Entities;

namespace MyForum.Business.Core.Services.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<ClaimsIdentity> Authenticate(UserBusiness userDto);
        Task SetInitialData(UserBusiness adminDto, List<string> roles);
    }
}
