using Logic.Interfaces;
using Logic.Logic.GenericLogic;
using Models.Models;
using Repository.Interfaces;
using System;

namespace Logic.Logic
{
    public class UserRoleLogic : CRUDLogic<UserRole>, IUserRoleLogic
    {
        private readonly IUserRoleRepository _repository;
        public UserRoleLogic(IUserRoleRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public ICollection<string> GetUserRolesWithNames(int userId)
        {
            return _repository.GetUserRolesWithNames(userId);
        }
    }
}
