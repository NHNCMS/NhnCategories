﻿using NhnCommon.DataModel.Abstracts;
using NhnCommon.DataModel.Models;
using NhnCommon.Module.Authors.Abstracts;
using NhnCommon.Module.Authors.Extensions.Dtos;

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

    public async Task<string> CreateAuthor(AuthorWithoutIdDto newAuthorWithoutId)
    {
        var authorModel = AuthorModel.CreateAuthorModel(newAuthorWithoutId);
        await _persister.Insert(authorModel);

        return authorModel.Id;
    }

    public async Task<string> ReplaceAuthor(string authorId, AuthorWithoutIdDto author)
    {
        var authorModel = AuthorModel.ReplaceAuthorModel(authorId, author);
        await _persister.Replace(authorModel);

        return authorModel.Id;
    }

    public async Task<string> UpdateAuthor(string authorId, AuthorPatchDto patchDto)
    {
        var propsToUpdate = patchDto.GetType().GetProperties()
            .ToDictionary(pi => pi.Name, pi => pi.GetValue(patchDto))
            .Where(pi => pi.Value != null)
            .ToDictionary(el => el.Key, el => el.Value!);

        await _persister.UpdateOne(authorId, propsToUpdate);

        return authorId;
    }

    public async Task<string> DeleteAuthor(string authorId)
    {
        await _persister.Delete(authorId);

        return authorId;
    }
}