
using Microsoft.AspNetCore.Mvc.Testing;

namespace Web_API_Tests
{
    public class TestFactory<IProgram> : WebApplicationFactory<IProgram> where IProgram : class
    {
    }
}
