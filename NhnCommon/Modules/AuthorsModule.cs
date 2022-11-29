using Microsoft.AspNetCore.Mvc;
using NhnCommon.Model.Author.Extensions.Dtos;
using NhnCommon.Module.Authors;
using NhnCommon.Module.Authors.Abstracts;

namespace NhnCommon.Modules;

public class AuthorsModule : IModule
{
    public bool IsEnabled => false;
    public int Order => 0;

    public IServiceCollection RegisterModule(WebApplicationBuilder builder)
    {
        builder.Services.AddAuthorServices();
        
        return builder.Services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/v1/authors/{id}", HandleGetAuthors)
            .Produces(StatusCodes.Status200OK, typeof(AuthorDto))
            .WithName("GetAuthors")
            .WithTags("Authors");

        return endpoints;
    }

    private static async Task<AuthorDto> HandleGetAuthors(IAuthorService service, [FromRoute] string id)
    {
       return await service.GetAuthor(id);
    }
}