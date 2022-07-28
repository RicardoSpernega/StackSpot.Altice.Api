using Xunit;

namespace Altice.Api.IntegrationTests.Utils
{
    [CollectionDefinition(nameof(TestFixtureCollection))]
    public class TestFixtureCollection : ICollectionFixture<TestFixture<Startup>>
    {

    }
}