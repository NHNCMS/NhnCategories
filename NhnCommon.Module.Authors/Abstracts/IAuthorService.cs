using NhnCommon.Model.Author.Extensions.Dtos;

namespace NhnCommon.Module.Authors.Abstracts;

public interface IAuthorService
{
    Task<AuthorDto> GetAuthor(string authorId);

    Task<string> CreateAuthor(AuthorWithoutIdDto newAuthorWithoutId);

    Task<string> UpdateAuthor(string authorId, AuthorWithoutIdDto newAuthorWithoutId);

    Task<string> DeleteAuthor(string authorId);
}