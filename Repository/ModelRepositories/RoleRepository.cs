using Microsoft.EntityFrameworkCore;
using Models.Models;
using Repository.Interfaces;
using Repository.ModelRepositories.GenericRepository;

namespace Repository.ModelRepositories
{
    public class RoleRepository : CRUDRepository<Role>, IRoleRepository
    {
        private readonly DataBaseContext _dbContext;
        public RoleRepository(DataBaseContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddRolesToUser(int userId, IEnumerable<int> roles)
        {
            await _dbContext.UserRoles.AddRangeAsync(roles.Select(r => new UserRole { UserId = userId, RoleId = r }));
            await _dbContext.SaveChangesAsync();
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
