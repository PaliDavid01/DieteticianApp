using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IUserLogic: ILogic<User>
    {
        User GetUserByEmail(string email);
    }
}
