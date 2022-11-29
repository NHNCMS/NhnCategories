using NhnCommon.Model.Author.Extensions.Dtos;

namespace NhnCommon.Module.Authors.Abstracts;

public interface IAuthorService
{
    Task<AuthorDto> GetAuthor(string authorId);

    Task<string> CreateAuthor(CreateAuthorDto newAuthor);

    Task<string> UpdateAuthor(string authorId);

    Task<string> DeleteAuthor(string authorId);
}