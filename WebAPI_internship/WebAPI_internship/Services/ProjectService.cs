using Microsoft.AspNetCore.Hosting.Server;
using WebAPI_internship.Models;
using WebAPI_internship.Services.Interfaces;

namespace WebAPI_internship.Services
{
    public class ProjectService : IProjectService
    {
        public async Task<List<Project>> GetProjects(Guid userId)
        {
            var projects = Store.Projects.Where(p => p.UserId == userId).ToList();
            return projects;
        }

        public async Task<Project> AddProject(string name, string description, Guid userId)
        {
            var project = new Project(name, description, userId);
            Store.Projects.Add(project);
            return project;
        }

        public async Task<Project> ChangeProject(Guid projId, Guid userId, string? name, string? description)
        {
            var proj = Store.Projects.Where(p => (p.Id == projId) && (p.UserId == userId)).FirstOrDefault();

            if (proj != null)
            {
                proj.Name = name ?? proj.Name;
                proj.Description = description ?? proj.Description;
                return proj;
            }
            else
            {
                throw new Exception("такого элемента в списке нет");
            }
        }

        public async Task<Project> RemoveProject(Guid projId, Guid userId)
        {
            var proj = Store.Projects.Where(p => (p.Id == projId) && (p.UserId == userId)).FirstOrDefault();

            if (proj != null)
            {
                Store.Projects.Remove(proj);
                return proj;
            }
            else
            {
                throw new Exception("такого элемента в списке нет");
            }
        }
    }
}
