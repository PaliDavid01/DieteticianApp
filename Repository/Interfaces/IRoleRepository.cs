﻿using Models.Models;
using Repository.Interfaces.GenericInterfaces;

namespace Repository.Interfaces
{
    public interface IRoleRepository : ICRUDRepository<Role>
    {
        Task<IEnumerable<UserRoleView>> GetRoleViews();
        Task<IEnumerable<UserRoleView>> GetUserRoleViewsByUserId(int userId);
        Task AddRolesToUser(int userId, IEnumerable<int> roles);
    }
}
