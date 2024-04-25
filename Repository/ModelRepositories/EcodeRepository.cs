using Microsoft.EntityFrameworkCore;
using Models.Models;
using Repository.Interfaces;
using Repository.ModelRepositories.GenericRepository;

namespace Repository.ModelRepositories
{
    public class EcodeRepository : CRUDRepository<Ecode>, IEcodeRepository
    {
        public EcodeRepository(DataBaseContext dbContext) : base(dbContext)
        {
        }
    }
}
