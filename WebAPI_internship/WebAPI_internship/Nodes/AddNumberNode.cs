using WebAPI_internship.Models.Nodes;

namespace WebAPI_internship.Nodes
{
    public class AddNumberNode : NodeOperation
    {
        public override Dictionary<string, object> Execute(Dictionary<string, object> input)
        {
            if (!(input.TryGetValue("x", out object xValue) && input.TryGetValue("y", out object yValue)))
            {
                throw new Exception("отсутствуют требуемые параметры");
            }

            if (xValue is int x && yValue is int y)
            {
                return new Dictionary<string, object> { { "Result", x + y } };
            }
            else
            {
                throw new Exception("неверный тип параметров");
            }
        }
    }
}
