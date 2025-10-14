namespace WebAPI_internship.Models.Nodes
{
    public abstract class NodeOperation
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public abstract Dictionary<string, object> Execute(Dictionary<string, object> input);
    }
}
