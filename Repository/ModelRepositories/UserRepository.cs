using Models.Models;
using Repository.GenericRepository;
using Repository.Interfaces;

namespace Repository.ModelRepositories
{
    public class UserRepository : CRUDRepository<User>, IUserRepository
    {
        public UserRepository(DataBaseContext dbctx) : base(dbctx)
        {

        }

    }
}
