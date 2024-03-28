using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Interfaces;
using Logic.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Models.Models;

namespace API.Services;

public class TokenService : ITokenService
{
    private readonly SymmetricSecurityKey _key;
    private readonly IUserRoleLogic _userRoleLogic;
    public TokenService(IConfiguration config, IUserRoleLogic userRoleLogic)
    {
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
        _userRoleLogic = userRoleLogic;
    }
    //https://ravindradevrani.medium.com/net-7-jwt-authentication-and-role-based-authorization-5e5e56979b67
    public string CreateToken(User user)
    {
        var claims = new List<Claim>(){
            new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName),
            new Claim(ClaimTypes.Email, user.Email),
        };

        var roles = _userRoleLogic.GetUserRolesWithNames(user.UserId);
        var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
        
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var tokenDescriptor = new SecurityTokenDescriptor(){
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(7),
            SigningCredentials = creds
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);

    }
}
