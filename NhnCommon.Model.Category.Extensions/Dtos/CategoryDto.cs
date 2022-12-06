namespace NhnCommon.Model.Category.Extensions.Dtos;

public record CategoryDto
{
    public string Id { get; init; } = string.Empty;

    public string Name { get; init; } = string.Empty;

    public string Type { get; init; } = string.Empty;

    public string Description { get; init; } = string.Empty;
}