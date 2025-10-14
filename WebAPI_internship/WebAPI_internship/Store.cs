using WebAPI_internship.Models;

namespace WebAPI_internship
{
    public static class Store
    {
        public static List<User> Users = new List<User>();
        public static List<Project> Projects = new List<Project>();
        public static List<NodeGraph> Nodes = new List<NodeGraph>();
    }
}
