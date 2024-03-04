using Logic.Interfaces;
using Models.Models;
using Models.Storage;
using Repository.Interfaces;
using Repository.ModelRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Logic
{
    public class UserLogic : IUserLogic
    {
        private readonly IRepository<User> _repository;
        public UserLogic(IRepository<User> repository)
        {
            this._repository = repository;
        }
        public void Create(User item)
        {
            this._repository.Create(item);
        }

        public void Delete(int Id)
        {
            this._repository.Delete(Id);
        }

        public IQueryable<User> GetAll()
        {
            return this._repository.ReadAll();
        }

        public User Get(int Id)
        {
            return this._repository.Read(Id);
        }

        public void Update(User item)
        {
            this._repository.Update(item);
        }

        public User GetUserByEmail(string email)
        {
            return this._repository.ReadAll().Where(x => x.Email == email).FirstOrDefault();
        }
    }
}
