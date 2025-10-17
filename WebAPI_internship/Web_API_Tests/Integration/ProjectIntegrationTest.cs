

using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;
using WebAPI_internship.Models;

namespace Web_API_Tests.Integration
{
    public class ProjectIntegrationTest
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
        public async Task AddProject()
        {
            const string testName = "Alexey";
            const string testPassword = "Password123";

            const string projName = "first project";
            const string projDescription = "my first project description";

            var responseRegistration = await _client.PostAsync($"https://localhost:7276/signup?name={testName}&password={testPassword}", new StringContent(""));
            var responseAuthorization = await _client.PostAsync($"https://localhost:7276/signin?name={testName}&password={testPassword}", new StringContent(""));

            var token = await responseAuthorization.Content.ReadAsStringAsync();

            _client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", token);

            var responseProject = await _client.PostAsync($"https://localhost:7276/api/projects?name={projName}&description={projDescription}", new StringContent(""));

            Assert.That(responseProject.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task AddProjectBad()
        {
            const string testName = "Alexey";
            const string testPassword = "Password123";

            const string projName = "";
            const string projDescription = "my first project description";

            var responseRegistration = await _client.PostAsync($"https://localhost:7276/signup?name={testName}&password={testPassword}", new StringContent(""));
            var responseAuthorization = await _client.PostAsync($"https://localhost:7276/signin?name={testName}&password={testPassword}", new StringContent(""));

            var token = await responseAuthorization.Content.ReadAsStringAsync();

            _client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", token);

            var responseProject = await _client.PostAsync($"https://localhost:7276/api/projects?name={projName}&description={projDescription}", new StringContent(""));

            Assert.That(responseProject.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        [Test]
        public async Task GetProjects()
        {
            const string testName = "Alexey";
            const string testPassword = "Password123";

            const string projName = "first project";
            const string projDescription = "my first project description";

            var responseRegistration = await _client.PostAsync($"https://localhost:7276/signup?name={testName}&password={testPassword}", new StringContent(""));
            var responseAuthorization = await _client.PostAsync($"https://localhost:7276/signin?name={testName}&password={testPassword}", new StringContent(""));

            var token = await responseAuthorization.Content.ReadAsStringAsync();

            _client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", token);

            var responseProject = await _client.PostAsync($"https://localhost:7276/api/projects?name={projName}&description={projDescription}", new StringContent(""));
            var responseGetProject = await _client.GetAsync($"https://localhost:7276/api/projects");

            Assert.That(responseGetProject.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task ChangeProject()
        {
            const string testName = "Alexey";
            const string testPassword = "Password123";

            const string projName = "first project";
            const string projDescription = "my first project description";
            const string projDescriptionNew = "my first project description change";

            var responseRegistration = await _client.PostAsync($"https://localhost:7276/signup?name={testName}&password={testPassword}", new StringContent(""));
            var responseAuthorization = await _client.PostAsync($"https://localhost:7276/signin?name={testName}&password={testPassword}", new StringContent(""));

            var token = await responseAuthorization.Content.ReadAsStringAsync();

            _client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", token);

            var responseProject = await _client.PostAsync($"https://localhost:7276/api/projects?name={projName}&description={projDescription}", new StringContent(""));
            var responseStream = await responseProject.Content.ReadAsStreamAsync();

            var oldProj = await JsonSerializer.DeserializeAsync<Project>(responseStream);

            var responsePutProject = await _client.PutAsync($"https://localhost:7276/api/projects/{oldProj.Id}?description={projDescriptionNew}", new StringContent(""));
            responsePutProject.EnsureSuccessStatusCode();
            var changeResponseStream = await responsePutProject.Content.ReadAsStreamAsync();

            var newProj = await JsonSerializer.DeserializeAsync<Project>(changeResponseStream);

            Assert.That(oldProj.Description, Is.Not.EqualTo(newProj.Description));

        }

        [Test]
        public async Task DeleteProject()
        {
            const string testName = "Alexey";
            const string testPassword = "Password123";

            const string projName = "first project";
            const string projDescription = "my first project description";

            var responseRegistration = await _client.PostAsync($"https://localhost:7276/signup?name={testName}&password={testPassword}", new StringContent(""));
            var responseAuthorization = await _client.PostAsync($"https://localhost:7276/signin?name={testName}&password={testPassword}", new StringContent(""));

            var token = await responseAuthorization.Content.ReadAsStringAsync();

            _client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", token);

            var responseProject = await _client.PostAsync($"https://localhost:7276/api/projects?name={projName}&description={projDescription}", new StringContent(""));
            var responseStream = await responseProject.Content.ReadAsStreamAsync();

            var oldProj = await JsonSerializer.DeserializeAsync<Project>(responseStream);

            var responseDelProject = await _client.PutAsync($"https://localhost:7276/api/projects/{oldProj.Id}", new StringContent(""));

            Assert.That(responseDelProject.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        }
    }
}
