using Logic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleLogic _roleLogic;
        private readonly IUserRoleLogic _userRoleLogic;
        public RoleController(IRoleLogic roleLogic, IUserRoleLogic userRoleLogic)
        {
            this._roleLogic = roleLogic;
            _userRoleLogic = userRoleLogic;
        }
        #region Create
        [HttpPost]
        public Task<Role> CreateRole(Role role)
        {
            return _roleLogic.CreateAsync(role);
        }
        [HttpPost("CreateUserRole")]
        public Task<UserRole> CreateUserRole(UserRole userRole)
        {
            return _userRoleLogic.CreateAsync(userRole);
        }
        #endregion

        #region Read
        [HttpGet]
        public Task<IEnumerable<Role>> GetRoles()
        {
            return _roleLogic.ReadAllAsync();
        }
        [HttpGet("GetRolesByUserId")]
        public async Task<IEnumerable<UserRole>> GetRolesByUserId(int userId)
        {
            return await _userRoleLogic.FindAsync(t => t.UserId == userId);
        }
        [HttpGet("GetRoleViews")]
        public Task<IEnumerable<UserRoleView>> GetRoleViews()
        {
            return _roleLogic.GetRoleViews();
        }
        [HttpGet("GetUserRoleViewsByUserId")]
        public Task<IEnumerable<UserRoleView>> GetUserRoleViewsByUserId(int userId)
        {
            return _roleLogic.GetUserRoleViewsByUserId(userId);
        }
        [HttpGet("GetUserRoles")]
        public async Task<IEnumerable<Role>> GetUserRoles()
        {
            return await _roleLogic.ReadAllAsync();
        }
        #endregion

    }
}
