using Xunit;

namespace NhnCommon.Tests;

[CollectionDefinition("Integration Fixture")]
public abstract class IntegrationCollectionFixture : ICollectionFixture<AppHttpClientFixture>
{   
}