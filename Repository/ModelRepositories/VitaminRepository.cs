using Microsoft.EntityFrameworkCore;
using Models.Models;
using Repository.GenericRepository;
using Repository.Interfaces;

namespace Repository.ModelRepositories
{
    public class VitaminRepository : CRUDRepository<Vitamin>, IVitaminRepository
    {
        public VitaminRepository(DataBaseContext dbContext) : base(dbContext)
        {
        }
    }
}
