using Models.Models;
using Models.Storage;

namespace API.Interfaces;

public interface ITokenService
{
    string CreateToken(User user);
}
