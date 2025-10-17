using WebAPI_internship.Models;
using WebAPI_internship.Services.Interfaces;

namespace WebAPI_internship.Services
{
    public class UserService : IUserService
    {
        public async Task<User> GetUserProfile(User user)
        {
            user.Projects = Store.Projects.Where(p => p.UserId == user.Id).ToList();

            foreach (var project in user.Projects)
            {
                project.Nodes = Store.Nodes.Where(n => n.ProjectId == project.Id).ToList();
            }
            return user;
        }
    }
}
