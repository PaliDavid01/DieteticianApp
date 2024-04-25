using Microsoft.EntityFrameworkCore;
using Models.Models;
using Repository.Interfaces;
using Repository.ModelRepositories.GenericRepository;

namespace Repository.ModelRepositories
{
    public class VitaminRepository : CRUDRepository<Vitamin>, IVitaminRepository
    {
        public VitaminRepository(DataBaseContext dbContext) : base(dbContext)
        {
        }
    }
}
