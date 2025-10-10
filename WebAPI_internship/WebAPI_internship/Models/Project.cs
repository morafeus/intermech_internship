namespace WebAPI_internship.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int UserId { get; set; }
        public List<NodeGraph> Nodes { get; set; }  

        public Project(int id, string name, string description, int userId)
        {
            Id = id;
            Name = name;
            Description = description;
            UserId = userId;
        }
    }
}
