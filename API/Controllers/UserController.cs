using API.Interfaces;
using AutoMapper;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.UserDTOs;
using Models.Storage;
using System.Security.Cryptography;
using System.Text;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController: ControllerBase
    {
        private readonly ILogic<AppUser> _userLogic;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        public UserController(ILogic<AppUser> userLogic, IMapper mapper, ITokenService tokenService)
        {
            this._mapper = mapper;
            this._userLogic = userLogic;
            this._tokenService = tokenService;
        }
        [HttpPost]
        public ActionResult<string> Login(LoginDTO loginUser) 
        {
            var user = _userLogic.Get(loginUser.Email);
            
            if (user == null) return Unauthorized("Wrong email or password!");

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginUser.Password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i])
                {
                    return Unauthorized("Wrong email or password!");
                }
            }
            var token = _tokenService.CreateToken(user);
            return token;
            //tokenservice here


        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDTO userDTO)
        {
            if(!UserExists(userDTO.Email)) return BadRequest();

            var user = _mapper.Map<AppUser>(userDTO);
            ;
            using var hmac = new HMACSHA512();
            
            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password));
            user.PasswordSalt = hmac.Key;

            _userLogic.Create(user);

            // tokenservice here
            return Ok();
        }

        private bool UserExists(string email)
        {
            return _userLogic.Get(email) == null;
        }
    }
}
