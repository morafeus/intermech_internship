using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net;
using System.Net.Http.Headers;

namespace Web_API_Tests.Integration
{
    public class UserIntegrationTest
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
        public async Task GetUsersTest()
        {
            const string testName = "Alexey";
            const string testPassword = "Password123";

            var responseRegistration = await _client.PostAsync($"https://localhost:7276/signup?name={testName}&password={testPassword}", new StringContent(""));
            var responseAuthorization = await _client.PostAsync($"https://localhost:7276/signin?name={testName}&password={testPassword}", new StringContent(""));

            var token = await responseAuthorization.Content.ReadAsStringAsync();

            _client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", token);

            var respnoseUsers = await _client.GetAsync($"https://localhost:7276/getAll");

            Assert.That(respnoseUsers.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task GetMe()
        {
            const string testName = "Alexey";
            const string testPassword = "Password123";

            var responseRegistration = await _client.PostAsync($"https://localhost:7276/signup?name={testName}&password={testPassword}", new StringContent(""));
            var responseAuthorization = await _client.PostAsync($"https://localhost:7276/signin?name={testName}&password={testPassword}", new StringContent(""));

            var token = await responseAuthorization.Content.ReadAsStringAsync();

            _client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", token);

            var respnoseUsers = await _client.GetAsync($"https://localhost:7276/getMe");

            Assert.That(respnoseUsers.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
