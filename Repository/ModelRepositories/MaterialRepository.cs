using Microsoft.EntityFrameworkCore;
using Models.Storage;
using Repository.Database;
using Repository.GenericRepository;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ModelRepositories
{
    public class MaterialRepository : GenericRepository<Material>, IRepository<Material>
    {
        public MaterialRepository(MaterialDBContext dbContext) : base(dbContext)
        {
        }

        public override Material Read(string id)
        {
            return (base.dbContext as MaterialDBContext).Materials.FirstOrDefault(t => t.Id == id);
        }

        public override void Update(Material item)
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
