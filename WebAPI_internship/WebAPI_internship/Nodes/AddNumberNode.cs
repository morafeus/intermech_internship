using System.Text.Json;
using WebAPI_internship.Models.Nodes;

namespace WebAPI_internship.Nodes
{
    public class AddNumberNode : NodeOperation
    {
        public override Dictionary<string, object> Execute(Dictionary<string, object> input)
        {
            int a = 0;
            int b = 0;

            if (!(input.TryGetValue("A", out object aValue) && input.TryGetValue("B", out object bValue)))
            {
                throw new Exception("отсутствуют требуемые параметры");
            }

            if(aValue is int)
            {
                a = (int)aValue;
            }
            else if(aValue is JsonElement aJson)
            {
                if(!aJson.TryGetInt32(out a))
                    throw new Exception("неверный тип параметров");
            }

            if (bValue is int)
            {
                b = (int)bValue;
            }
            else if (bValue is JsonElement bJson)
            {
                if (!bJson.TryGetInt32(out b))
                    throw new Exception("неверный тип параметров");
            }

            return new Dictionary<string, object> { { "Result", a + b } };

        }
    }
}
