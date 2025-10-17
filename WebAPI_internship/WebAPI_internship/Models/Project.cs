using System.Text.Json.Serialization;

namespace WebAPI_internship.Models
{
    public class Project
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        public string Name { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public List<NodeGraph> Nodes { get; set; }  

        public Project() { }

        public Project( string name, string description, Guid userId)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            UserId = userId;
            Nodes = new List<NodeGraph>();
        }
    }
}
