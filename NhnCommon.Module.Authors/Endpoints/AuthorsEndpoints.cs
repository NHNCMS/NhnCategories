using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NhnCommon.Module.Authors.Abstracts;
using NhnCommon.Module.Authors.Extensions.Dtos;
using NhnCommon.Module.Shared.Extensions.Dtos;

namespace NhnCommon.Module.Authors.Endpoints;

public static class AuthorsEndpoints
{
    public static async Task<IResult> HandleCreateAuthor(IAuthorService service, [FromBody] AuthorWithoutIdDto author)
    {
        var createdAuthorId = await service.CreateAuthor(author);
        return Results.Created($"/{createdAuthorId}", new IdDto(createdAuthorId));
    }

    public static async Task<IResult> HandleDeleteAuthor(IAuthorService service, [FromRoute] string id)
    {
        try
        {
            var idAuthor = await service.DeleteAuthor(id);
            return Results.Ok(new IdDto(idAuthor));
        }
        catch (Exception)
        {
            return Results.NotFound();
        }
    }

    public static async Task<IResult> HandleReplaceAuthor(IAuthorService service, [FromRoute] string id,
        [FromBody] AuthorWithoutIdDto author)
    {
        try
        {
            var idAuthor = await service.ReplaceAuthor(id, author);
            return Results.Ok(new IdDto(idAuthor));
        }
        catch (Exception)
        {
            return Results.NotFound();
        }
    }

    public static async Task<IResult> HandlePatchAuthor(IAuthorService service, [FromRoute] string id,
        [FromBody] AuthorPatchDto body)
    {
        try
        {
            var idAuthor = await service.UpdateAuthor(id, body);
            return Results.Ok(new IdDto(idAuthor));
        }
        catch
        {
            return Results.NotFound();
        }
    }

    public static async Task<IResult> HandleGetAuthor(IAuthorService service, [FromRoute] string id)
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