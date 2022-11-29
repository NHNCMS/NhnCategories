using NhnCommon.Model.Author.Extensions.Dtos;
using NhnCommon.Module.Authors;
using NhnCommon.Module.Authors.Endpoints;

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

        endpointGroup.MapGet("{id}", AuthorsEndpoints.HandleGetAuthor)
            .Produces(StatusCodes.Status200OK, typeof(AuthorDto))
            .Produces(StatusCodes.Status404NotFound)
            .WithName("GetAuthor");

        endpointGroup.MapPost(string.Empty, AuthorsEndpoints.HandleCreateAuthor)
            .Produces(StatusCodes.Status201Created, typeof(IdDto))
            .WithName("CreateAuthor");

        endpointGroup.MapPut("{id}", AuthorsEndpoints.HandleReplaceAuthor)
            .Produces(StatusCodes.Status200OK, typeof(IdDto))
            .Produces(StatusCodes.Status404NotFound)
            .WithName("ReplaceAuthor");

        endpointGroup.MapDelete("{id}", AuthorsEndpoints.HandleDeleteAuthor)
            .Produces(StatusCodes.Status202Accepted)
            .Produces(StatusCodes.Status404NotFound)
            .WithName("DeleteAuthor");

        return endpoints;
    }
}