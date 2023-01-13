using Microsoft.Extensions.DependencyInjection;
using NhnCommon.Module.Tags.Abstracts;
using NhnCommon.Module.Tags.Concretes;

namespace NhnCommon.Module.Tags;

public static class TagsHelper
{
    public static IServiceCollection AddTagServices(this IServiceCollection services)
    {
        services.AddScoped<ITagService, TagService>();

        return services;
    }
}