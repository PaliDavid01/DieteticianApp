using Microsoft.EntityFrameworkCore;
using Models.Models;
using Repository.GenericRepository;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ModelRepositories
{
    public class RoleRepository : CRUDRepository<Role>, IRoleRepository
    {
        private readonly DataBaseContext _dbContext;
        public RoleRepository(DataBaseContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<UserRoleView>> GetRoleViews()
        {
            return await _dbContext.UserRoleViews.ToListAsync();
        }

        public async Task<IEnumerable<UserRoleView>> GetUserRoleViewsByUserId(int userId)
        {
            return await _dbContext.UserRoleViews.Where(t => t.UserId == userId).ToListAsync();
        }
    }
}
