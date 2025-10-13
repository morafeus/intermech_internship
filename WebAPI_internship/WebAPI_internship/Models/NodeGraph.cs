namespace WebAPI_internship.Models
{
    public class NodeGraph
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string JsonData { get; set; }

        public Guid ProjectId { get; set; }

        public NodeGraph(string name, Guid projectId, string jsonData)
        {
            Id = Guid.NewGuid();
            Name = name;
            ProjectId = projectId;
            JsonData = jsonData;
        }
    }
}
