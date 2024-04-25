using Models.Models;
using Repository.Interfaces;
using Repository.ModelRepositories.GenericRepository;

namespace Repository.ModelRepositories
{
    public class UserRepository : CRUDRepository<User>, IUserRepository
    {
        public UserRepository(DataBaseContext dbctx) : base(dbctx)
        {

        }

    }
}
