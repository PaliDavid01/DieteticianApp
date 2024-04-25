﻿using Models.Models;
using Repository.Interfaces.GenericInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IUserRoleRepository : IRecipeRepository<UserRole>
    {
        ICollection<string> GetUserRolesWithNames(int userId);
    }
}
