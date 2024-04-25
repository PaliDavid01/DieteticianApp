using Microsoft.EntityFrameworkCore;
using Models.Models;
using Repository.Interfaces;
using Repository.ModelRepositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ModelRepositories
{
    public class UserRoleRepository : CRUDRepository<UserRole>, IUserRoleRepository
    {
        
        public UserRoleRepository(DataBaseContext dbContext) : base(dbContext)
        {
        }

        public ICollection<string> GetUserRolesWithNames(int userId)
        {
            return _dbContext.UserRoles.Where(t => t.UserId == userId).Join(_dbContext.Roles, userRole => userRole.RoleId, role => role.RoleId, (userRole, role) => role.RoleName).ToList();
        }
    }
}
