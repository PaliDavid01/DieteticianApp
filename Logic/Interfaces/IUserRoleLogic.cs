using Logic.Interfaces.GenericInterfaces;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IUserRoleLogic: ICRUDLogic<UserRole>
    {
        public ICollection<string> GetUserRolesWithNames(int userId);
    }
}
