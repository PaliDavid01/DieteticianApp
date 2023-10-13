using Logic.Interfaces;
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
    public class UserLogic : ILogic<AppUser>
    {
        private readonly IRepository<AppUser> _repository;
        public UserLogic(IRepository<AppUser> repository)
        {
            this._repository = repository;
        }
        public void Create(AppUser item)
        {
            this._repository.Create(item);
        }

        public void Delete(string Id)
        {
            this._repository.Delete(Id);
        }

        public IQueryable<AppUser> GetAll()
        {
            return this._repository.ReadAll();
        }

        public AppUser Get(string Id)
        {
            return this._repository.Read(Id);
        }

        public void Update(AppUser item)
        {
            this._repository.Update(item);
        }
    }
}
