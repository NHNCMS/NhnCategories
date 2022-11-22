using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using NhnCommon.Model.Author.Extensions.Dtos;
using Xunit;

namespace NhnCommon.Tests;

[Collection("Integration Fixture")]
public class AuthorModuleTest
{
    private readonly AppHttpClientFixture _integrationFixture;

    public AuthorModuleTest(AppHttpClientFixture integrationFixture)
    {
        _integrationFixture = integrationFixture;
    }

    [Fact]
    public async Task Can_Invoke_GetAuthors()
    {
        var authorId = "pippo";
        var expectedAuthor = new AuthorDto();

        var getResult = await _integrationFixture.Client.GetAsync($"/v1/authors/{authorId}");
        
        Assert.Equal(HttpStatusCode.OK, getResult.StatusCode);

        var getResponse = await getResult.Content.ReadFromJsonAsync<AuthorDto>();
        Assert.Equal(expectedAuthor, getResponse);
    }
}