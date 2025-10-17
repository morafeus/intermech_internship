using WebAPI_internship.Models;
using WebAPI_internship.Services.Interfaces;

namespace WebAPI_internship.Services
{
    public class NodeGraphService : INodeGraphService
    {
        public async Task<List<NodeGraph>> GetNodes(Guid projectId, Guid userId)
        {
            var proj = Store.Projects.Where(p => (p.Id == projectId) && (p.UserId == userId)).FirstOrDefault();

            if (proj == null)
                throw new Exception("у вас нет доступа к данному проекту");

            var nodes = Store.Nodes.Where(n => n.ProjectId == projectId).ToList();

            if (nodes != null)
            {
                return nodes;
            }
            else
            {
                throw new Exception("у данного проекта нет нод");
            }
        }

        public async Task<NodeGraph> GetNodeById(Guid id, Guid userId)
        {
            var node = Store.Nodes.Where(n => n.Id == id).FirstOrDefault();
            if (node == null)
                throw new Exception("в проекте нет ноды с таким айди");

            var proj = Store.Projects.Where(p => (p.Id == node.ProjectId) && (p.UserId == userId)).FirstOrDefault();
            if (proj == null)
                throw new Exception("у вас нет доступа к проекту, которому принадлежит эта нода");

            return node;
        }

        public async Task<NodeGraph> AddNode(Guid projId, string name, string jsonData, Guid userId)
        {
            var proj = Store.Projects.Where(p => (p.Id == projId) && (p.UserId == userId)).FirstOrDefault();

            if (proj != null)
            {
                var node = new NodeGraph(name, proj.Id, jsonData);
                Store.Nodes.Add(node);
                return node;
            }
            else
            {
                throw new Exception("такого проекта нет");
            }
        }

        public async Task<NodeGraph> ChangeNode(Guid id, Guid userId, string? name, string? jsonData)
        {
            var node = Store.Nodes.Where(n => n.Id == id).FirstOrDefault();
            if (node == null)
                throw new Exception("в проекте нет ноды с таким айди");

            var proj = Store.Projects.Where(p => (p.Id == node.ProjectId) && (p.UserId == userId)).FirstOrDefault();
            if (proj == null)
                throw new Exception("у вас нет доступа к проекту, которому принадлежит эта нода");

            node.Name = name ?? node.Name;
            node.JsonData = jsonData ?? node.JsonData;

            return node;
        }

        public async Task<NodeGraph> RemoveNode(Guid id, Guid userId)
        {
            var node = Store.Nodes.Where(n => n.Id == id).FirstOrDefault();
            if (node == null)
                throw new Exception("в проекте нет ноды с таким айди");

            var proj = Store.Projects.Where(p => (p.Id == node.ProjectId) && (p.UserId == userId)).FirstOrDefault();
            if (proj == null)
                throw new Exception("у вас нет доступа к проекту, которому принадлежит эта нода");

            Store.Nodes.Remove(node);

            return node;
        }
    }
}
