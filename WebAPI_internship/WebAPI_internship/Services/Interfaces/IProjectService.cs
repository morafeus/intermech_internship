using WebAPI_internship.Models;

namespace WebAPI_internship.Services.Interfaces
{
    public interface IProjectService
    {
        public Task<List<Project>> GetProjects(Guid userId);
        public Task<Project> AddProject(string name, string description, Guid userId);
        public Task<Project> ChangeProject(Guid projId, Guid userId, string? name, string? description);
        public Task<Project> RemoveProject(Guid projId, Guid userId);
    }
}
