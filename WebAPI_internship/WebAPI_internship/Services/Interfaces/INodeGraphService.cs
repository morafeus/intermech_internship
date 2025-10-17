using WebAPI_internship.Models;

namespace WebAPI_internship.Services.Interfaces
{
    public interface INodeGraphService
    {
        public Task<List<NodeGraph>> GetNodes(Guid projectId, Guid userId);
        public Task<NodeGraph> GetNodeById(Guid id, Guid userId);
        public Task<NodeGraph> AddNode(Guid projId, string name, string jsonData, Guid userId);
        public Task<NodeGraph> ChangeNode(Guid projId, Guid userId, string? name, string? jsonData);
        public Task<NodeGraph> RemoveNode(Guid id, Guid userId);
    }
}
