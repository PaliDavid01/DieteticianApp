
using Microsoft.EntityFrameworkCore;
using Models.Models;
using Repository.GenericRepository;
using Repository.Interfaces;

namespace Repository.ModelRepositories
{
    public class BaseMaterialRepository : CRUDRepository<BaseMaterial>, IBaseMaterialRepository
    {
        public BaseMaterialRepository(DataBaseContext dbContext) : base(dbContext)
        {
        }
    }
}
