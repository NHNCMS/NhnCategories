namespace NhnCommon.Module.Authors.Extensions.Dtos;

public record AuthorPatchDto
{
    public string? Name { get; init; }

    public string? Mail { get; init; }

    public string? Bio { get; init; }
}