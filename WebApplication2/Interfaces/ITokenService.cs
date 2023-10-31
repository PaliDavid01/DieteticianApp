using Models.Storage;

namespace API.Interfaces;

public interface ITokenService
{
    string CreateToken(AppUser user);
}
