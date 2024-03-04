using Microsoft.EntityFrameworkCore;
using Models.Models;
using Models.Storage;
using Repository.Database;
using Repository.GenericRepository;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ModelRepositories
{
    public class UserRepository : GenericRepository<User>, IRepository<User>
    {
        public UserRepository(DataBaseContext dbctx):base(dbctx)
        {
                
        }

        public override User Read(int id)
        {
            return (base.dbContext as DataBaseContext).Users.FirstOrDefault(t => t.UserId == id);
        }

        public override void Update(User item)
        {
            var oldInDatabase = Read(item.UserId);
            foreach (var prop in oldInDatabase.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(oldInDatabase, prop.GetValue(item));
                }
            }
            dbContext.SaveChanges();
        }
    }
}
