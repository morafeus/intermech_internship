using WebAPI_internship.Models;
using WebAPI_internship.Models.NodeModels;
using WebAPI_internship.Nodes;

namespace WebAPI_internship
{
    public static class Store
    {
        public static List<User> Users = new List<User>();
        public static List<Project> Projects = new List<Project>();
        public static List<NodeGraph> Nodes = new List<NodeGraph>();
        public static List<UserDefinedNode> UserNodes = new List<UserDefinedNode>();


        public static Dictionary<string, Type> NodeTypeMap = new()
        {
            { "AddNumberNode", typeof(AddNumberNode) },
            { "StringConcatNode", typeof(StringConcatNode) },
            { "ConsoleLogNode", typeof(ConsoleLogNode) }
        };
    }
}
