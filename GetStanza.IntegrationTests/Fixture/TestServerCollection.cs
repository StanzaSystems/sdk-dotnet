using Xunit;

namespace GetStanza.IntegrationTests.Fixture;

[CollectionDefinition(TestCollections.ApiIntegration)]
public class TestServerCollection : ICollectionFixture<TestServerFixture> { }
