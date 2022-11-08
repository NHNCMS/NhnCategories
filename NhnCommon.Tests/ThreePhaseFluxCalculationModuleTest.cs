using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using NhnCommon.Models;
using Xunit;

namespace NhnCommon.Tests;

[Collection("Integration Fixture")]
public class BrewUpModuleTest
{
    private readonly AppHttpClientFixture _integrationFixture;

    public BrewUpModuleTest(AppHttpClientFixture integrationFixture)
    {
        _integrationFixture = integrationFixture;
    }

    [Fact]
    public async Task Can_Say_HelloWorld()
    {
        var body = new HelloRequest
        {
            Name = "NhN Tester"
        };

        var stringJson = JsonSerializer.Serialize(body);
        var httpContent = new StringContent(stringJson, Encoding.UTF8, "application/json");
        var postResult = await _integrationFixture.Client.PostAsync("/v1/brewup", httpContent);

        Assert.Equal(HttpStatusCode.OK, postResult.StatusCode);

        var postResponse = await postResult.Content.ReadFromJsonAsync<string>();
        Assert.Equal($"Hello {body.Name} from BrewUp", postResponse);
    }
}