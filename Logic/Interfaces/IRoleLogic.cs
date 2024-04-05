using Logic.Interfaces.GenericInterfaces;
using Models.Models;

namespace Logic.Interfaces
{
    public interface IRoleLogic : ICRUDLogic<Role>
    {
        Task<IEnumerable<UserRoleView>> GetRoleViews();
        Task<IEnumerable<string>> GetUserRolesAsString();
        Task<IEnumerable<UserRoleView>> GetUserRoleViewsByUserId(int userId);
        Task AddRolesToUser(int userId, IEnumerable<int> roles);
    }
}
