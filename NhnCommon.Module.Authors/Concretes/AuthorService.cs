using NhnCommon.DataModel.Abstracts;
using NhnCommon.DataModel.Models;
using NhnCommon.Model.Author.Extensions.Dtos;
using NhnCommon.Module.Authors.Abstracts;

namespace NhnCommon.Module.Authors.Concretes;

internal sealed class AuthorService : IAuthorService
{
    private readonly IPersister<AuthorModel> _persister;

    public AuthorService(IPersister<AuthorModel> persister)
    {
        _persister = persister;
    }

    public async Task<AuthorDto> GetAuthor(string authorId)
    {
        var authorModel = await _persister.GetById(authorId);
        return string.IsNullOrWhiteSpace(authorModel.Id) ? throw new Exception() : authorModel.ToDto();
    }

    public async Task<string> CreateAuthor(CreateAuthorDto newAuthor)
    {
        var authorModel = AuthorModel.CreateAuthorModel(newAuthor);
        await _persister.Insert(authorModel);

        return authorModel.Id;
    }

    public Task<string> UpdateAuthor(string authorId)
    {
        throw new NotImplementedException();
    }

    public Task<string> DeleteAuthor(string authorId)
    {
        throw new NotImplementedException();
    }
}