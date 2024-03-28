using Microsoft.EntityFrameworkCore;
using Models.Models;
using Repository.GenericRepository;
using Repository.Interfaces;

namespace Repository.ModelRepositories
{
    public class EcodeRepository : CRUDRepository<Ecode>, IEcodeRepository
    {
        public EcodeRepository(DataBaseContext dbContext) : base(dbContext)
        {
        }
    }
}
