
using Microsoft.EntityFrameworkCore;
using Models.Models;
using Repository.GenericRepository;
using Repository.Interfaces;

namespace Repository.ModelRepositories
{
    public class MaterialGroupRepository : CRUDRepository<MaterialGroup>, IMaterialGroupRepository
    {
        public MaterialGroupRepository(DataBaseContext dbContext) : base(dbContext)
        {
        }
    }
}
