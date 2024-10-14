using APIRecicheck.Data.Contexts;
using APIRecicheck.Data.Repository;
using APIRecicheck.Models;

namespace APIRecicheck.Services
{
    public class AuthService : IAuthService
    {
        private List<UserModel> _users = new List<UserModel>
             {
                 new UserModel { UserId = 1, Username = "Leandro", Password = "123456", Role = "analista" },
                 new UserModel { UserId = 2, Username = "Gabriel", Password = "123456", Role = "operador" },
                 new UserModel { UserId = 3, Username = "Roberto", Password = "123456", Role = "gerente" },
             };


        public UserModel Authenticate(string username, string password)
        {
            // Aqui você normalmente faria a verificação de senha de forma segura
            return _users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}
