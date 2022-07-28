using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Altice.Api.IntegrationTests.Utils;
using Altice.Application.CreateHelloWorld;
using Altice.Domain.Enums;
using Xunit;

namespace Altice.Api.IntegrationTests.Controllers
{
    [Collection(nameof(TestFixtureCollection))]
    public class HelloWorldControllerTests
    {
        private readonly TestFixture<Startup> _testFixture;

        public HelloWorldControllerTests(TestFixture<Startup> testFixture)
        {
            _testFixture = testFixture;
        }

        [Fact]
        public async Task Should_Hello_World_Create_Return_Success()
        {
            var command = new CreateHelloWorldCommand
            {
                UserName = "test",
                Level = UserLevel.Admin
            };

            var content = new HttpRequestMessage(HttpMethod.Post, $"HelloWorld")
            {
                Content = new StringContent(JsonSerializer.Serialize(command), Encoding.UTF8, "application/json")
            };

            var response = await _testFixture._client.SendAsync(content);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Should_Hello_World_Create_Return_Bad_Request()
        {
            var command = new CreateHelloWorldCommand
            {
                Level = UserLevel.Admin
            };

            var content = new HttpRequestMessage(HttpMethod.Post, $"HelloWorld")
            {
                Content = new StringContent(JsonSerializer.Serialize(command), Encoding.UTF8, "application/json")
            };

            var response = await _testFixture._client.SendAsync(content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}