using NhnCommon.DataModel.Abstracts;
using NhnCommon.Model.Author.Extensions.Dtos;

namespace NhnCommon.DataModel.Models;

public class AuthorModel : ModelBase
{
    public string Id { get; private set; } = string.Empty;

    public string Name { get; private set; } = string.Empty;

    public string Mail { get; private set; } = string.Empty;

    public string Bio { get; private set; } = string.Empty;

    protected AuthorModel()
    {
    }

    public AuthorDto ToDto() =>
        new()
        {
            Id = Id,
            Name = Name,
            Mail = Mail,
            Bio = Bio,
        };
}