using Microsoft.Extensions.DependencyInjection;
using NhnCommon.Module.Categories.Abstracts;
using NhnCommon.Module.Categories.Concretes;

namespace NhnCommon.Module.Categories;

public static class CategoriesHelper
{
    public static IServiceCollection AddCategoryServices(this IServiceCollection services)
    {
        services.AddScoped<ICategoryService, CategoryService>();

        return services;
    }
}