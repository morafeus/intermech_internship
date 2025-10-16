
using DependencyLib;
using System.Text.Json;
using WebAPI_internship.Models.NodeModels;
using WebAPI_internship.Services.Interfaces;

namespace WebAPI_internship.Services
{
    public class NodeExecutorService : INodeExecutorService
    {
        private Dictionary<Guid, Dictionary<string, object>> _result = new();

        public async Task<Dictionary<Guid, Dictionary<string, object>>> ExecuteAsync(string jsonData)
        {

            var graph = JsonSerializer.Deserialize<JsonData>(jsonData);
            if(graph == null || !graph.nodes.Any())
            {
                throw new Exception("пустой граф");
            }

            foreach(var node in graph.nodes)
            {
                if (!Store.NodeTypeMap.TryGetValue(node.Name, out Type nodeType))
                {
                    throw new Exception("ноды с таким именем не существует");
                }

                var input = CreateParams(node);

                var nodeInstance = (NodeOperation)Activator.CreateInstance(nodeType);

                var output = nodeInstance.Execute(input);

                _result.Add(node.Id, output);
            }

            return _result;
        }

        private Dictionary<string, object> CreateParams(NodeStructure node)
        {
            var result = new Dictionary<string, object>();

            foreach(var param in node.Inputs)
            {
                var nodeId = param.Value.NodeId;
                var outputName = param.Value.OutputName;

                var paramName = param.Key;

                if(_result.TryGetValue(nodeId, out var value))
                {
                    result.Add(paramName, value[outputName]);
                }
            }

            foreach(var param in node.Params)
            {
                result.Add(param.Key, param.Value);
            }

            return result;
        }
    }
}
