using WebAPI_internship.Models;

namespace WebAPI_internship.Services.Interfaces
{
    public interface IUserService
    {
        public Task<User> GetUserProfile(User user);
    }
}
