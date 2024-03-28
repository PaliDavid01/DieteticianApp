﻿using Models.Models;
using Repository.Interfaces.GenericInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IRoleRepository: ICRUDRepository<Role>
    {
        Task<IEnumerable<UserRoleView>> GetRoleViews();
        Task<IEnumerable<UserRoleView>> GetUserRoleViewsByUserId(int userId);
    }
}
