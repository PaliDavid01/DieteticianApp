using Microsoft.EntityFrameworkCore;
using Models.Models;
using Models.Storage;
using Repository.Database;
using Repository.GenericRepository;
using Repository.Interfaces;
using Repository.Interfaces.GenericInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ModelRepositories
{
    public class UserRepository : CRUDRepository<User>, IUserRepository
    {
        public UserRepository(DataBaseContext dbctx):base(dbctx)
        {
                
        }

    }
}
