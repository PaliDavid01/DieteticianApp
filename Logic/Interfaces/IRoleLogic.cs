using Logic.Interfaces.GenericInterfaces;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IRoleLogic: ICRUDLogic<Role>
    {
        Task<IEnumerable<UserRoleView>> GetRoleViews();
        Task<IEnumerable<string>> GetUserRolesAsString();
        Task<IEnumerable<UserRoleView>> GetUserRoleViewsByUserId(int userId);
    }
}
