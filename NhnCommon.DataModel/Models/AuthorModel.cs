using NhnCommon.DataModel.Abstracts;
using NhnCommon.Model.Author.Extensions.Dtos;

namespace NhnCommon.DataModel.Models;

public class AuthorModel : ModelBase
{
    protected AuthorModel()
    {
    }

    public string Name { get; private set; } = string.Empty;

    public string Mail { get; private set; } = string.Empty;

    public string Bio { get; private set; } = string.Empty;

    public static AuthorModel CreateAuthorModel(AuthorWithoutIdDto dto)
    {
        return new AuthorModel
        {
            Id = Guid.NewGuid().ToString(),
            Name = dto.Name,
            Mail = dto.Mail,
            Bio = dto.Bio
        };
    }


    public static AuthorModel ReplaceAuthorModel(string authorId, AuthorWithoutIdDto dto)
    {
        return new AuthorModel
        {
            Id = authorId,
            Name = dto.Name,
            Mail = dto.Mail,
            Bio = dto.Bio
        };
    }

    public AuthorDto ToDto()
    {
        return new AuthorDto
        {
            Id = Id,
            Name = Name,
            Mail = Mail,
            Bio = Bio
        };
    }
}