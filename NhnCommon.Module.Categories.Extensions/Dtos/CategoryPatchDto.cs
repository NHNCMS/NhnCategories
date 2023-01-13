namespace NhnCommon.Module.Categories.Extensions.Dtos;

public record CategoryPatchDto
{
    public string? Name { get; init; }

    public string? Type { get; init; }

    public string? Description { get; init; }
}