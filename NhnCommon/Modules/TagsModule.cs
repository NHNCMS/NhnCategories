using NhnCommon.Module.Shared.Extensions.Dtos;
using NhnCommon.Module.Tags;
using NhnCommon.Module.Tags.Endpoints;
using NhnCommon.Module.Tags.Extensions.Dtos;

namespace NhnCommon.Modules;

public class TagsModule : IModule
{
    public bool IsEnabled => false;
    public int Order => 0;

    public IServiceCollection RegisterModule(WebApplicationBuilder builder)
    {
        builder.Services.AddTagServices();

        return builder.Services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var endpointGroup = endpoints.MapGroup("v1/tags").WithTags("Tags");

        endpointGroup.MapGet("{id}", TagsEndpoints.HandleGetTag)
            .Produces(StatusCodes.Status200OK, typeof(TagDto))
            .Produces(StatusCodes.Status404NotFound)
            .WithName("GetTag");

        endpointGroup.MapPost(string.Empty, TagsEndpoints.HandleCreateTag)
            .Produces(StatusCodes.Status201Created, typeof(IdDto))
            .WithName("CreateTag");

        endpointGroup.MapPut("{id}", TagsEndpoints.HandleReplaceTag)
            .Produces(StatusCodes.Status200OK, typeof(IdDto))
            .Produces(StatusCodes.Status404NotFound)
            .WithName("ReplaceTag");

        endpointGroup.MapPatch("{id}", TagsEndpoints.HandlePatchTag)
            .Produces(StatusCodes.Status200OK, typeof(IdDto))
            .Produces(StatusCodes.Status404NotFound)
            .WithName("UpdateTag");

        endpointGroup.MapDelete("{id}", TagsEndpoints.HandleDeleteTag)
            .Produces(StatusCodes.Status202Accepted)
            .Produces(StatusCodes.Status404NotFound)
            .WithName("DeleteTag");

        return endpoints;
    }
}