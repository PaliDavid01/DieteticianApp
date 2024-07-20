using Logic.Interfaces;
using Logic.Logic.GenericLogic;
using Models.Models;
using Repository.Interfaces;


namespace Logic.Logic
{
    public class UserLogic : CRUDLogic<User>, IUserLogic
    {
        IUserRepository _repository;
        public UserLogic(IUserRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<User>> GetUserByEmail(string email)
        {
            return _repository.FindAsync(t => t.Email == email);
        }
    }
}
