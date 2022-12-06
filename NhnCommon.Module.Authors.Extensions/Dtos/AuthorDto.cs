namespace NhnCommon.Module.Authors.Extensions.Dtos;

public record AuthorDto
{
    public string Id { get; init; } = string.Empty;
    
    public string Name { get; init; } = string.Empty;
    
    public string Mail { get; init; } = string.Empty;
    
    public string Bio { get; init; } = string.Empty;
}