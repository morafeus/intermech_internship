namespace WebAPI_internship.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PasswordHash { get; set; }

        public List<Project> Projects { get; set; }

        public User(string name, string description, string passwordHash)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            PasswordHash = passwordHash;
            Projects = new List<Project>();
        }
    }
}
