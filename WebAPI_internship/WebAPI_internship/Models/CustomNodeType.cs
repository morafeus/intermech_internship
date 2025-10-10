

namespace WebAPI_internship.Models
{
    public class CustomNodeType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string InputDefinitions { get; set; }
        public string OutputDefinitions { get; set; }

        public CustomNodeType(int id, string name, string description, string inputDefinitions, string outputDefinitions)
        {
            Id = id;
            Name = name;
            Description = description;
            InputDefinitions = inputDefinitions;
            OutputDefinitions = outputDefinitions;
        }
    }
}
