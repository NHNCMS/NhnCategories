using NhnCommon.DataModel.Abstracts;
using NhnCommon.DataModel.Models;
using NhnCommon.Module.Categories.Abstracts;
using NhnCommon.Module.Categories.Extensions.Dtos;

namespace NhnCommon.Module.Categories.Concretes;

internal sealed class CategoryService : ICategoryService
{
    private readonly IPersister<CategoryModel> _persister;

    public CategoryService(IPersister<CategoryModel> persister)
    {
        _persister = persister;
    }

    public async Task<CategoryDto> GetCategory(string categoryId)
    {
        var categoryModel = await _persister.GetById(categoryId);
        return string.IsNullOrWhiteSpace(categoryModel.Id) ? throw new Exception() : categoryModel.ToDto();
    }

    public async Task<string> CreateCategory(CategoryWithoutIdDto newCategoryWithoutId)
    {
        var categoryModel = CategoryModel.CreateCategoryModel(newCategoryWithoutId);
        await _persister.Insert(categoryModel);

        return categoryModel.Id;
    }

    public async Task<string> ReplaceCategory(string categoryId, CategoryWithoutIdDto category)
    {
        var categoryModel = CategoryModel.ReplaceCategoryModel(categoryId, category);
        await _persister.Replace(categoryModel);

        return categoryModel.Id;
    }

    public async Task<string> UpdateCategory(string categoryId, CategoryPatchDto patchDto)
    {
        var propsToUpdate = patchDto.GetType().GetProperties()
            .ToDictionary(pi => pi.Name, pi => pi.GetValue(patchDto))
            .Where(pi => pi.Value != null)
            .ToDictionary(el => el.Key, el => el.Value!);

        await _persister.UpdateOne(categoryId, propsToUpdate);

        return categoryId;
    }

    public async Task<string> DeleteCategory(string categoryId)
    {
        await _persister.Delete(categoryId);

        return categoryId;
    }
}