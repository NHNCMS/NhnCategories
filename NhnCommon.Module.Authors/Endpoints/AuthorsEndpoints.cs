using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NhnCommon.Model.Author.Extensions.Dtos;
using NhnCommon.Module.Authors.Abstracts;

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
            var idAuthor = await service.UpdateAuthor(id, author);
            return Results.Ok(new IdDto(idAuthor));
        }
        catch (Exception)
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