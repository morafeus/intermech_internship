
using WebAPI_internship.Models;
using WebAPI_internship.Services.Interfaces;

namespace WebAPI_internship.Services
{
    public class AuthService : IAuthService
    {
        private ITokenService _tokenService;

        public AuthService(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public async Task<User> CreateNewUser(string name, string password, string description)
        {
            var passwordHash = HashService.HashPassword(password);

            var user = new User(name, description, passwordHash);
            if (Store.Users.Where(u => u.Name == name).Any())
            {
                throw new Exception("пользоватль с таким именем уже есть");
            }

            Store.Users.Add(user);
            return user;
        }

        public async Task<string> LoginUser(string name, string password)
        {
            if (Store.Users.Where(u => u.Name == name).Any())
            {
                var user = Store.Users.Where(u => u.Name == name).FirstOrDefault();

                if (HashService.VerifyPassword(password, user.PasswordHash))
                {
                    var token = _tokenService.GenerateAccessToken(user.Id, user.Name);
                    return token;
                }
                else
                {
                    throw new Exception("неверный пароль");
                }
            }
            else
            {
                throw new Exception("пользователя с таким логином не существует");
            }
        }
    }
}
