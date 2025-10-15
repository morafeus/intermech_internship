
using Serilog;
using WebAPI_internship.Models.Nodes;

namespace WebAPI_internship.Nodes
{
    public class ConsoleLogNode : NodeOperation
    {
        public override Dictionary<string, object> Execute(Dictionary<string, object> input)
        {
            if (!input.TryGetValue("Value", out object value))
            {
                Log.Warning("отсутствуют требуемые параметры");
                throw new Exception("отсутствуют требуемые параметры");
            }

            Log.Information($"объект, который был передан: {value}");

            return new Dictionary<string, object>() { { "Result", value} };
        }
    }
}
