namespace WebAPI_internship.Models.NodeModels
{
    public class UserDefinedNode
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public string Name { get; set; }

        public Dictionary<string, string> Inputs { get; set; }
        public Dictionary<string, string> Outputs { get; set; }

        public string NodeJsonData { get; set; }

        public UserDefinedNode(Guid userId, string name, Dictionary<string, string> inputs, Dictionary<string, string> outputs, string nodeJsonData)
        {
            UserId = userId;
            Name = name;
            Inputs = inputs;
            Outputs = outputs;
            NodeJsonData = nodeJsonData;
        }
    }
}
