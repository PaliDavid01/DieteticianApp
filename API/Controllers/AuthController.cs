using API.Interfaces;
using AutoMapper;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.UserDTOs;
using Models.Models;
using Models.Storage;
using System.Security.Cryptography;
using System.Text;

namespace API.Controllers 
{ 
    [ApiController]
    [Route("[controller]")]
    public class AuthController: ControllerBase
    {
        private readonly IUserLogic _userLogic;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        public AuthController(IUserLogic userLogic, IMapper mapper, ITokenService tokenService)
        {
            this._mapper = mapper;
            this._userLogic = userLogic;
            this._tokenService = tokenService;
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
            //tokenservice here


        }

        [HttpPost("register")]
        public async Task<int> Register(RegisterDTO userDTO)
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

            _userLogic.Create(user);

            // tokenservice here
            return (await _userLogic.FindAsync(t => t.Email == userDTO.Email)).FirstOrDefault().UserId;
        }
    }
}
