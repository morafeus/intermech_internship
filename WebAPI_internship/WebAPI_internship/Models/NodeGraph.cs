namespace WebAPI_internship.Models
{
    public class NodeGraph
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string JsonData { get; set; }

        public int ProjectId { get; set; }

        public NodeGraph(int id, string name, int projectId, string jsonData)
        {
            Id = id;
            Name = name;
            ProjectId = projectId;
            JsonData = jsonData;
        }
    }
}
