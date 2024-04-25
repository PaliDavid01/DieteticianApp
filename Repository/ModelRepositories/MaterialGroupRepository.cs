
using Microsoft.EntityFrameworkCore;
using Models.Models;
using Repository.Interfaces;
using Repository.ModelRepositories.GenericRepository;

namespace Repository.ModelRepositories
{
    public class MaterialGroupRepository : CRUDRepository<MaterialGroup>, IMaterialGroupRepository
    {
        public MaterialGroupRepository(DataBaseContext dbContext) : base(dbContext)
        {
        }
    }
}
