using Microsoft.AspNetCore.Mvc;
using NhnCommon.Model.Author.Extensions.Dtos;
using NhnCommon.Module.Authors.Abstracts;
using NhnCommon.Module.Authors.Concretes;

namespace NhnCommon.Modules;

public class AuthorsModule : IModule
{
    public bool IsEnabled => true;
    public int Order => 0;

    public IServiceCollection RegisterModule(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IAuthorService, AuthorService>();
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

    private async Task<AuthorDto> HandleGetAuthors(IAuthorService service, [FromRoute] string id)
    {
       return await service.GetAuthor(id);
    }
}