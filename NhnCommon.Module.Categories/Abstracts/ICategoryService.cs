using NhnCommon.Module.Categories.Extensions.Dtos;

namespace NhnCommon.Module.Categories.Abstracts;

public interface ICategoryService
{
    Task<CategoryDto> GetCategory(string categoryId);

    Task<string> CreateCategory(CategoryWithoutIdDto newCategoryWithoutId);

    Task<string> ReplaceCategory(string categoryId, CategoryWithoutIdDto category);

    Task<string> UpdateCategory(string categoryId, CategoryPatchDto patchDto);

    Task<string> DeleteCategory(string CategoryId);
}