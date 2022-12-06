using NhnCommon.DataModel.Abstracts;
using NhnCommon.Module.Categories.Extensions.Dtos;

namespace NhnCommon.DataModel.Models;

public class CategoryModel : ModelBase
{
    protected CategoryModel()
    {
    }

    public string Name { get; private set; } = string.Empty;
    public string Type { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;

    public static CategoryModel CreateCategoryModel(CategoryWithoutIdDto dto)
    {
        return new CategoryModel
        {
            Id = Guid.NewGuid().ToString(),
            Name = dto.Name,
            Type = dto.Type,
            Description = dto.Description
        };
    }

    public static CategoryModel ReplaceCategoryModel(string id, CategoryWithoutIdDto dto)
    {
        return new CategoryModel
        {
            Id = id,
            Name = dto.Name,
            Type = dto.Type,
            Description = dto.Description
        };
    }

    public CategoryDto ToDto()
    {
        return new CategoryDto
        {
            Id = Id,
            Name = Name,
            Type = Type,
            Description = Description
        };
    }
}