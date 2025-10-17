using WebAPI_internship.Models;

namespace WebAPI_internship.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<User> CreateNewUser(string name, string password, string description);
        public Task<string> LoginUser(string name, string password);
    }
}
