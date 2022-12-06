namespace NhnCommon.Model.Author.Extensions.Dtos;

public record AuthorWithoutIdDto
{
    public string Name { get; init; } = string.Empty;

    public string Mail { get; init; } = string.Empty;

    public string Bio { get; init; } = string.Empty;
}