namespace WebAPI_internship.Models
{
    public class Project
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public List<NodeGraph> Nodes { get; set; }  

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
