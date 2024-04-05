using Logic.Interfaces;
using Logic.Logic.GenericLogic;
using Models.Models;
using Repository.Interfaces;

namespace Logic.Logic
{
    public class RoleLogic : CRUDLogic<Role>, IRoleLogic
    {
        private readonly IRoleRepository _repository;
        public RoleLogic(IRoleRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<string>> GetUserRolesAsString()
        {
            return _repository.GetRoleViews().ContinueWith(t => t.Result.Select(r => r.RoleName));
        }

        public async Task<IEnumerable<UserRoleView>> GetRoleViews()
        {
            return await _repository.GetRoleViews();
        }

        public async Task<IEnumerable<UserRoleView>> GetUserRoleViewsByUserId(int userId)
        {
            return await _repository.GetUserRoleViewsByUserId(userId);
        }

        public async Task AddRolesToUser(int userId, IEnumerable<int> roles)
        {
            await _repository.AddRolesToUser(userId, roles);
        }
    }
}
