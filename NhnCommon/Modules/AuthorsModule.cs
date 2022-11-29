using Microsoft.AspNetCore.Mvc;
using NhnCommon.Model.Author.Extensions.Dtos;
using NhnCommon.Module.Authors;
using NhnCommon.Module.Authors.Abstracts;

namespace NhnCommon.Modules;

public class AuthorsModule : IModule
{
    public bool IsEnabled => true;
    public int Order => 0;

    public IServiceCollection RegisterModule(WebApplicationBuilder builder)
    {
        builder.Services.AddAuthorServices();

        return builder.Services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var endpointGroup = endpoints.MapGroup("v1/authors").WithTags("Authors");

        endpointGroup.MapGet("{id}", HandleGetAuthor)
            .Produces(StatusCodes.Status200OK, typeof(AuthorDto))
            .Produces(StatusCodes.Status404NotFound)
            .WithName("GetAuthor");

        endpointGroup.MapPost(string.Empty, HandleCreateAuthor)
            .Produces(StatusCodes.Status201Created, typeof(IdDto))
            .WithName("CreateAuthor");

        return endpoints;
    }

    private static async Task<IResult> HandleCreateAuthor(IAuthorService service, [FromBody] CreateAuthorDto author)
    {
        var createdAuthorId = await service.CreateAuthor(author);
        return Results.Created($"/{createdAuthorId}", new IdDto(createdAuthorId));
    }

    private static async Task<IResult> HandleGetAuthor(IAuthorService service, [FromRoute] string id)
    {
        try
        {
            return Results.Ok(await service.GetAuthor(id));
        }
        catch (Exception)
        {
            return Results.NotFound();
        }
    }
}