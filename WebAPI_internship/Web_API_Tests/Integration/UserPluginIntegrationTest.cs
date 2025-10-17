using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net;
using System.Net.Http.Headers;

namespace Web_API_Tests.Integration
{
    public class UserPluginIntegrationTest
    {
        private TestFactory<Program> _factory;
        private HttpClient _client;

        [SetUp]
        public void Setup()
        {
            _factory = new TestFactory<Program>();
            _client = new HttpClient();
        }

        [TearDown]
        public void TearDown()
        {
            _factory?.Dispose();
            _client?.Dispose();
        }

        [Test]
        public async Task GetNodes()
        {
            const string testName = "Alexey";
            const string testPassword = "Password123";

            const string path = "\"..\\..\\WebAPI_internship\\ClientCustomNodes\\bin\\Debug\\ClientCustomNodes.dll\"";

            var responseRegistration = await _client.PostAsync($"https://localhost:7276/signup?name={testName}&password={testPassword}", new StringContent(""));
            var responseAuthorization = await _client.PostAsync($"https://localhost:7276/signin?name={testName}&password={testPassword}", new StringContent(""));

            var token = await responseAuthorization.Content.ReadAsStringAsync();

            _client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", token);

            var responsedll = await _client.GetAsync($"https://localhost:7276/load?path={path}");

            Assert.That(responsedll.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
