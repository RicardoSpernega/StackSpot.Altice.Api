using System;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using WireMock.Server;

namespace Altice.Api.IntegrationTests.Utils
{
    public class TestFixture<TStartup> : IDisposable where TStartup : class
    {
        public HttpClient _client;
        public WireMockServer _mockServer;
        private TestServer _server;

        public TestFixture()
        {
            _server = new TestServer(new WebHostBuilder().ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.AddJsonFile("appsettings.json");
            })
                .UseStartup<Startup>()
                .UseEnvironment("Development"));

            _client = _server.CreateClient();

            _mockServer = WireMockBuilder.Build();
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}