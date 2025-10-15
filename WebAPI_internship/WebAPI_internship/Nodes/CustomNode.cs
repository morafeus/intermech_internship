using WebAPI_internship.Models.Nodes;
using WebAPI_internship.Services.Interfaces;

namespace WebAPI_internship.Nodes
{
    public class CustomNode : NodeOperation
    {
        private readonly string _nodeGraph;
        private readonly INodeExecutorService _service;

        public CustomNode(string nodeGraph, INodeExecutorService service)
        {
            _nodeGraph = nodeGraph;
            _service = service;
        }

        public override Dictionary<string, object> Execute(Dictionary<string, object> input)
        {
            throw new NotImplementedException();
        }
    }
}
