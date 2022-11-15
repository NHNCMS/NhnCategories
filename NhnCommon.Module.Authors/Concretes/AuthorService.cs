using NhnCommon.DataModel.Abstracts;
using NhnCommon.DataModel.Models;
using NhnCommon.Model.Author.Extensions.Dtos;
using NhnCommon.Module.Authors.Abstracts;

namespace NhnCommon.Module.Authors.Concretes;

public sealed class AuthorService : IAuthorService
{
    private readonly IPersister<AuthorModel> _persister;

    public AuthorService(IPersister<AuthorModel> persister)
    {
        _persister = persister;
    }

    public async Task<AuthorDto> GetAuthor(string authorId)
    {
        var authorModel = await _persister.GetById(new Guid(authorId)); 
        return authorModel.ToDto();
        
    }

    public Task<string> CreateAuthor(AuthorDto newAuthor)
    {
        throw new NotImplementedException();
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