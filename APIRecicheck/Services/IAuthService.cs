using APIRecicheck.Models;

namespace APIRecicheck.Services
{
    public interface IAuthService
    {
        UserModel Authenticate(string username, string password);

    }
}
