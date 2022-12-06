using NhnCommon.Module.Categories;
using NhnCommon.Module.Categories.Endpoints;
using NhnCommon.Module.Categories.Extensions.Dtos;
using NhnCommon.Module.Shared.Extensions.Dtos;

namespace NhnCommon.Modules;

public class CategoriesModule : IModule
{
    public bool IsEnabled => true;
    public int Order => 0;

    public IServiceCollection RegisterModule(WebApplicationBuilder builder)
    {
        builder.Services.AddCategoryServices();

        return builder.Services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var endpointGroup = endpoints.MapGroup("v1/categories").WithTags("Categories");

        endpointGroup.MapGet("{id}", CategoriesEndpoints.HandleGetCategory)
            .Produces(StatusCodes.Status200OK, typeof(CategoryDto))
            .Produces(StatusCodes.Status404NotFound)
            .WithName("GetCategory");

        endpointGroup.MapPost(string.Empty, CategoriesEndpoints.HandleCreateCategory)
            .Produces(StatusCodes.Status201Created, typeof(IdDto))
            .WithName("CreateCategory");

        endpointGroup.MapPut("{id}", CategoriesEndpoints.HandleReplaceCategory)
            .Produces(StatusCodes.Status200OK, typeof(IdDto))
            .Produces(StatusCodes.Status404NotFound)
            .WithName("ReplaceCategory");

        endpointGroup.MapPatch("{id}", CategoriesEndpoints.HandlePatchCategory)
            .Produces(StatusCodes.Status200OK, typeof(IdDto))
            .Produces(StatusCodes.Status404NotFound)
            .WithName("UpdateCategory");

        endpointGroup.MapDelete("{id}", CategoriesEndpoints.HandleDeleteCategory)
            .Produces(StatusCodes.Status202Accepted)
            .Produces(StatusCodes.Status404NotFound)
            .WithName("DeleteCategory");

        return endpoints;
    }
}