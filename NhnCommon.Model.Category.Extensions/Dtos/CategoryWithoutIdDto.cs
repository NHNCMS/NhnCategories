namespace NhnCommon.Model.Category.Extensions.Dtos;

public record CategoryWithoutIdDto
{
    public string Name { get; init; } = string.Empty;

    public string Type { get; init; } = string.Empty;

    public string Description { get; init; } = string.Empty;
}