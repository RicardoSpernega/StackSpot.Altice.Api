using Altice.Api.IntegrationTests.Utils;
using Altice.Application.CreateForm;
using Altice.Application.Form;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Altice.Api.IntegrationTests.Controllers
{
    [Collection(nameof(TestFixtureCollection))]
    public class FormControllerTests
    {
        private readonly TestFixture<Startup> _testFixture;

        public FormControllerTests(TestFixture<Startup> testFixture)
        {
            _testFixture = testFixture;
        }

        [Fact]
        public async Task Should_Form_Create_Return_Success()
        {
            var command = new CreateFormCommand
            {
                Nome = "Teste",
                Email = "teste@teste.com",
                DataNascimento = DateTime.Now.AddDays(-30),
                Morada = "Santos",
                Nif = "10203020"

            };

            var content = new HttpRequestMessage(HttpMethod.Post, $"Form/new-form")
            {
                Content = new StringContent(JsonSerializer.Serialize(command), Encoding.UTF8, "application/json")
            };

            var response = await _testFixture._client.SendAsync(content);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Should_Hello_World_Create_Return_Bad_Request()
        {
            var command = new CreateFormCommand
            {
                Nome = "Teste",
            };

            var content = new HttpRequestMessage(HttpMethod.Post, $"Form/new-form")
            {
                Content = new StringContent(JsonSerializer.Serialize(command), Encoding.UTF8, "application/json")
            };

            var response = await _testFixture._client.SendAsync(content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Should_Form_Get_Return_Success()
        {
            var command = new ListFormCommand
            {
                Email = "rica"
            };

            var content = new HttpRequestMessage(HttpMethod.Get, $"Form")
            {
                Content = new StringContent(JsonSerializer.Serialize(command), Encoding.UTF8, "application/json")
            };

            var response = await _testFixture._client.SendAsync(content);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Should_Form_Get_Return_Bad_Request()
        {
            var command = new CreateFormCommand
            {
            };

            var content = new HttpRequestMessage(HttpMethod.Post, $"Form/new-form")
            {
                Content = new StringContent(JsonSerializer.Serialize(command), Encoding.UTF8, "application/json")
            };

            var response = await _testFixture._client.SendAsync(content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
