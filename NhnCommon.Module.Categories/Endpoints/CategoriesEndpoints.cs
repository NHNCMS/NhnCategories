using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NhnCommon.Module.Categories.Abstracts;
using NhnCommon.Module.Categories.Extensions.Dtos;
using NhnCommon.Module.Shared.Extensions.Dtos;

namespace NhnCommon.Module.Categories.Endpoints;

public static class CategoriesEndpoints
{
    public static async Task<IResult> HandleCreateCategory(ICategoryService service,
        [FromBody] CategoryWithoutIdDto category)
    {
        var createdCategoryId = await service.CreateCategory(category);
        return Results.Created($"/{createdCategoryId}", new IdDto(createdCategoryId));
    }

    public static async Task<IResult> HandleDeleteCategory(ICategoryService service, [FromRoute] string id)
    {
        try
        {
            var idCategory = await service.DeleteCategory(id);
            return Results.Ok(new IdDto(idCategory));
        }
        catch (Exception)
        {
            return Results.NotFound();
        }
    }

    public static async Task<IResult> HandleReplaceCategory(ICategoryService service, [FromRoute] string id,
        [FromBody] CategoryWithoutIdDto category)
    {
        try
        {
            var idAuthor = await service.ReplaceCategory(id, category);
            return Results.Ok(new IdDto(idAuthor));
        }
        catch (Exception)
        {
            return Results.NotFound();
        }
    }

    public static async Task<IResult> HandlePatchCategory(ICategoryService service, [FromRoute] string id,
        [FromBody] CategoryPatchDto body)
    {
        try
        {
            var idAuthor = await service.UpdateCategory(id, body);
            return Results.Ok(new IdDto(idAuthor));
        }
        catch
        {
            return Results.NotFound();
        }
    }

    public static async Task<IResult> HandleGetCategory(ICategoryService service, [FromRoute] string id)
    {
        try
        {
            return Results.Ok(await service.GetCategory(id));
        }
        catch (Exception)
        {
            return Results.NotFound();
        }
    }
}