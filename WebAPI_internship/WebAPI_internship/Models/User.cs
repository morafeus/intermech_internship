namespace WebAPI_internship.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PasswordHash { get; set; }

        public List<Project> Projects { get; set; }

        public User(int id, string name, string description, string passwordHash)
        {
            Id = id;
            Name = name;
            Description = description;
            PasswordHash = passwordHash;
        }
    }
}
