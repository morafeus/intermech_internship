using System.Text.Json.Serialization;

namespace WebAPI_internship.Models
{
    public class NodeGraph
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("name")]
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
