using WebAPI_internship.Models.Nodes;

namespace WebAPI_internship.Nodes
{
    public class StringConcatNode : NodeOperation
    {
        public override Dictionary<string, object> Execute(Dictionary<string, object> input)
        {
            if (!(input.TryGetValue("x", out object xValue) && input.TryGetValue("y", out object yValue)))
            {
                throw new Exception("отсутствуют требуемые параметры");
            }

            var x = input["x"] as string;
            var y = input["y"] as string;

            if (x != null && y != null)
            {
                var result = x.Concat(y);
                return new Dictionary<string, object> { { "Result", result } };
            }
            else
            {
                throw new Exception("некорректные значения параметров");
            }
        }
    }
}
