using WebAPI_internship.Nodes;
using WebAPI_internship.Services.Interfaces;

namespace WebAPI_internship.Services
{
    public class NodeExecutorService : INodeExecutorService
    {
        private readonly Dictionary<string, Type> _nodeTypeMap = new()
        {
            { "AddNumberNode", typeof(AddNumberNode) },
            { "StringConcatNode", typeof(StringConcatNode) },
            { "ConsoleLogNode", typeof(ConsoleLogNode) }
        };

        public Task<object> ExecuteAsync(string jsonData)
        {
            throw new NotImplementedException();
        }
    }
}
