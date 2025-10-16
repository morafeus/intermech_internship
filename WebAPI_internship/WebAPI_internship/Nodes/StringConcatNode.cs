using DependencyLib;
using System.Text.Json;

namespace WebAPI_internship.Nodes
{
    public class StringConcatNode : NodeOperation
    {
        public override Dictionary<string, object> Execute(Dictionary<string, object> input)
        {
            string first = null;
            string second = null;

            if (!(input.TryGetValue("String1", out object xValue) && input.TryGetValue("String2", out object yValue)))
            {
                throw new Exception("отсутствуют требуемые параметры");
            }

            if(xValue is string)
            {
                first = (string)xValue;
            }
            else if(xValue is JsonElement xJson)
            {
                first = xJson.GetString();
            }

            if (yValue is string)
            {
                second = (string)yValue;
            }
            else if (yValue is JsonElement yJson)
            {
                second = yJson.GetString();
            }


            if (first != null && second != null)
            {
                var result = first + second;
                return new Dictionary<string, object> { { "Result", result } };
            }
            else
            {
                throw new Exception("некорректные значения параметров");
            }
        }
    }
}
