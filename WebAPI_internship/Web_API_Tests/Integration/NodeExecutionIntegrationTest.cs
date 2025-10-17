using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebAPI_internship.Models;

namespace Web_API_Tests.Integration
{
    public class NodeExecutionIntegrationTest
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
        public async Task ExecuteNode()
        {
            const string testName = "Alexey";
            const string testPassword = "Password123";

            const string projName = "first project";
            const string projDescription = "my first project description";

            const string nodeName = "first node";
            const string nodeNameChange = "second node";
            const string jsonData = "{\r\n         \"nodes\": [\r\n           {\r\n             \"Id\": \"b2c3d4e5-0001-4000-0000-000000000011\",\r\n             \"Name\": \"AddNumberNode\", \r\n             \"Params\": {\r\n               \"A\": 10,\r\n               \"B\": 20\r\n             },\r\n             \"Inputs\": {}\r\n           },\r\n           {\r\n           \"Id\": \"c3d4e5f6-0001-4000-0000-000000000022\",\r\n             \"Name\": \"MultipleNumberNode\", \r\n             \"Params\": {\r\n               \"B\": 5\r\n             },\r\n             \"Inputs\": {\r\n              \"A\": {\r\n                   \"NodeId\": \"b2c3d4e5-0001-4000-0000-000000000011\",\r\n                 \"OutputName\": \"Result\"\r\n               }\r\n           }\r\n       },\r\n           {\r\n           \"Id\": \"d4e5f6c7-0001-4000-0000-000000000033\",\r\n             \"Name\": \"ConsoleLogNode\", \r\n             \"Params\": { },\r\n             \"Inputs\": {\r\n               \"Value\": {\r\n                  \"NodeId\": \"c3d4e5f6-0001-4000-0000-000000000022\",\r\n                 \"OutputName\": \"Result\"\r\n               }\r\n           }\r\n       },\r\n           {\r\n           \"Id\": \"e5f6c7d8-0001-4000-0000-000000000044\",\r\n             \"Name\": \"StringConcatNode\", \r\n              \"Params\": {\r\n               \"String1\": \"Hello\", \r\n               \"String2\": \"World\"\r\n             },\r\n             \"Inputs\": { }\r\n      }]\r\n    }";

            const string path = "\"..\\..\\WebAPI_internship\\ClientCustomNodes\\bin\\Debug\\ClientCustomNodes.dll\"";

            var responseRegistration = await _client.PostAsync($"https://localhost:7276/signup?name={testName}&password={testPassword}", new StringContent(""));
            var responseAuthorization = await _client.PostAsync($"https://localhost:7276/signin?name={testName}&password={testPassword}", new StringContent(""));

            var token = await responseAuthorization.Content.ReadAsStringAsync();

            _client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", token);

            var responseProject = await _client.PostAsync($"https://localhost:7276/api/projects?name={projName}&description={projDescription}", new StringContent(""));
            var responseStream = await responseProject.Content.ReadAsStreamAsync();
            var oldProj = await JsonSerializer.DeserializeAsync<Project>(responseStream);

            var responseNode = await _client.PostAsync($"https://localhost:7276/api/nodegraph?projectId={oldProj.Id}&name={nodeName}&jsonData={jsonData}", new StringContent(""));
            var responseStreamNode = await responseNode.Content.ReadAsStreamAsync();
            var nodeId = await JsonSerializer.DeserializeAsync<NodeGraph>(responseStreamNode);


            var responseDll = await _client.GetAsync($"https://localhost:7276/load?path={path}");
            responseDll.EnsureSuccessStatusCode();

            var responseExecuteNode = await _client.PostAsync($"https://localhost:7276/api/nodegraph/{nodeId.Id}/execute", new StringContent(""));

            Assert.That(responseExecuteNode.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task ExecuteNodeNoDll()
        {
            const string testName = "Alexey";
            const string testPassword = "Password123";

            const string projName = "first project";
            const string projDescription = "my first project description";

            const string nodeName = "first node";
            const string nodeNameChange = "second node";
            const string jsonData = "{\r\n         \"nodes\": [\r\n           {\r\n             \"Id\": \"b2c3d4e5-0001-4000-0000-000000000011\",\r\n             \"Name\": \"AddNumberNode\", \r\n             \"Params\": {\r\n               \"A\": 10,\r\n               \"B\": 20\r\n             },\r\n             \"Inputs\": {}\r\n           },\r\n           {\r\n           \"Id\": \"c3d4e5f6-0001-4000-0000-000000000022\",\r\n             \"Name\": \"MultipleNumberNode\", \r\n             \"Params\": {\r\n               \"B\": 5\r\n             },\r\n             \"Inputs\": {\r\n              \"A\": {\r\n                   \"NodeId\": \"b2c3d4e5-0001-4000-0000-000000000011\",\r\n                 \"OutputName\": \"Result\"\r\n               }\r\n           }\r\n       },\r\n           {\r\n           \"Id\": \"d4e5f6c7-0001-4000-0000-000000000033\",\r\n             \"Name\": \"ConsoleLogNode\", \r\n             \"Params\": { },\r\n             \"Inputs\": {\r\n               \"Value\": {\r\n                  \"NodeId\": \"c3d4e5f6-0001-4000-0000-000000000022\",\r\n                 \"OutputName\": \"Result\"\r\n               }\r\n           }\r\n       },\r\n           {\r\n           \"Id\": \"e5f6c7d8-0001-4000-0000-000000000044\",\r\n             \"Name\": \"StringConcatNode\", \r\n              \"Params\": {\r\n               \"String1\": \"Hello\", \r\n               \"String2\": \"World\"\r\n             },\r\n             \"Inputs\": { }\r\n      }]\r\n    }";

            const string path = "\"..\\..\\WebAPI_internship\\ClientCustomNodes\\bin\\Debug\\ClientCustomNodes.dll\"";

            var responseRegistration = await _client.PostAsync($"https://localhost:7276/signup?name={testName}&password={testPassword}", new StringContent(""));
            var responseAuthorization = await _client.PostAsync($"https://localhost:7276/signin?name={testName}&password={testPassword}", new StringContent(""));

            var token = await responseAuthorization.Content.ReadAsStringAsync();

            _client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", token);

            var responseProject = await _client.PostAsync($"https://localhost:7276/api/projects?name={projName}&description={projDescription}", new StringContent(""));
            var responseStream = await responseProject.Content.ReadAsStreamAsync();
            var oldProj = await JsonSerializer.DeserializeAsync<Project>(responseStream);

            var responseNode = await _client.PostAsync($"https://localhost:7276/api/nodegraph?projectId={oldProj.Id}&name={nodeName}&jsonData={jsonData}", new StringContent(""));
            var responseStreamNode = await responseNode.Content.ReadAsStreamAsync();
            var nodeId = await JsonSerializer.DeserializeAsync<NodeGraph>(responseStreamNode);



            var responseExecuteNode = await _client.PostAsync($"https://localhost:7276/api/nodegraph/{nodeId.Id}/execute", new StringContent(""));

            Assert.That(responseExecuteNode.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
