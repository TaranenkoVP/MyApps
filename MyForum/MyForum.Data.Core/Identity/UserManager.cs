﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using MyForum.Data.Core.Models.Identity;

namespace MyForum.Data.Core.Identity
{
    public class UserManager : UserManager<ApplicationUser>
    {
        public UserManager(IUserStore<ApplicationUser> store)
                : base(store)
        {
        }
    }
}
