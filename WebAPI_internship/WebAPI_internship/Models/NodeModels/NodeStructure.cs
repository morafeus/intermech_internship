namespace WebAPI_internship.Models.NodeModels
{
    public class NodeStructure
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Dictionary<string, object> Params { get; set; } = new();

        public Dictionary<Guid, Input> Inputs { get; set; } = new();
    }

    public class Input
    {
        public string OutputName { get; set; }
        public string InputName { get; set; }
    }

    public class JsonData
    {
        public List<NodeStructure> nodes { get; set; } = new();
    }
}
