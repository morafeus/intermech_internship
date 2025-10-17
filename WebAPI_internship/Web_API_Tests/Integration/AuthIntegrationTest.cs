using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net;
using System.Net.Http;

namespace Web_API_Tests;

public class AuthIntegrationTest
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
    [Order(0)]
    public async Task SingUpTest()
    {
        const string testName = "Alexey";
        const string testPassword = "Password123";

        var response = await _client.PostAsync($"https://localhost:7276/signup?name={testName}&password={testPassword}", new StringContent(""));
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    [Test]
    [Order(2)]
    public async Task SingUpTestBad()
    {
        const string testName = "Alexey";
        const string testPassword = "";

        var response = await _client.PostAsync($"https://localhost:7276/signup?name={testName}&password={testPassword}", new StringContent(""));
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
    }

    [Test]
    [Order(3)]
    public async Task SingUpTestBad1()
    {
        const string testName = "Alexey";
        const string testPassword = "Password123";

        var responseResult = await _client.PostAsync($"https://localhost:7276/signup?name={testName}&password={testPassword}", new StringContent(""));
        Assert.That(responseResult.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
    }

    [Test]
    [Order(1)]
    public async Task SingInTest()
    {
        const string testName = "Alexey";
        const string testPassword = "Password123";


        var response = await _client.PostAsync($"https://localhost:7276/signin?name={testName}&password={testPassword}", new StringContent(""));
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }
    [Test]
    [Order(4)]
    public async Task SingInTestBad()
    {
        const string testName = "Alexey";
        const string testPassword = "Password1222";


        var response = await _client.PostAsync($"https://localhost:7276/signin?name={testName}&password={testPassword}", new StringContent(""));
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
    }
}
