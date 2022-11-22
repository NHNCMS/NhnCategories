using Microsoft.Extensions.DependencyInjection;
using NhnCommon.Module.Authors.Abstracts;
using NhnCommon.Module.Authors.Concretes;

namespace NhnCommon.Module.Authors;

public static class AuthorsHelper
{
    public static IServiceCollection AddAuthorServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthorService, AuthorService>();

        return services;
    }
}