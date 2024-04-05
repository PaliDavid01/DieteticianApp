using API.Interfaces;
using AutoMapper;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.UserDTOs;
using Models.Models;
using System.Security.Cryptography;
using System.Text;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserLogic _userLogic;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly IRoleLogic _roleLogic;
        public AuthController(IUserLogic userLogic, IMapper mapper, ITokenService tokenService, IRoleLogic roleLogic)
        {
            this._mapper = mapper;
            this._userLogic = userLogic;
            this._tokenService = tokenService;
            _roleLogic = roleLogic;
        }
        [HttpPost]
        public async Task<LoginResponseDTO> Login(LoginDTO loginUser)
        {
            var user = (await _userLogic.GetUserByEmail(loginUser.Email)).FirstOrDefault();

            if (user == null) throw new ArgumentNullException();

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginUser.Password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i])
                {
                    throw new Exception("Wrong email or password");
                }
            }
            var response = _mapper.Map<LoginResponseDTO>(user);
            response.token = this._tokenService.CreateToken(user);
            return response;

        }

        [HttpPost("register")]
        public async Task<LoginResponseDTO> Register(RegisterDTO userDTO)
        {
            var user = new User()
            {
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Email = userDTO.Email,
            };
            using var hmac = new HMACSHA512();

            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password));
            user.PasswordSalt = hmac.Key;

            var createdUSer = await _userLogic.CreateAsync(user);

            await _roleLogic.AddRolesToUser(createdUSer.UserId, userDTO.Roles.Select(t => t.RoleId));

            var response = _mapper.Map<LoginResponseDTO>(user);
            response.token = this._tokenService.CreateToken(user);
            return response;
        }
    }
}
