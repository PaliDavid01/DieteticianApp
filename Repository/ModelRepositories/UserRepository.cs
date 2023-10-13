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
    public class UserRepository : GenericRepository<AppUser>, IRepository<AppUser>
    {
        public UserRepository(DatabaseContext dbctx):base(dbctx)
        {
                
        }

        public override AppUser Read(string id)
        {
            return (base.dbContext as DatabaseContext).AppUsers.FirstOrDefault(t => t.Email == id);
        }

        public override void Update(AppUser item)
        {
            var oldInDatabase = Read(item.Id);
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
