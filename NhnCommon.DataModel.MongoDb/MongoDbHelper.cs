using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using NhnCommon.DataModel.Abstracts;
using NhnCommon.DataModel.Models;
using NhnCommon.DataModel.MongoDb.Persisters;
using NhnCommon.Shared.Configuration;

namespace NhnCommon.DataModel.MongoDb;

public static class MongoDbHelper
{
    public static IServiceCollection AddMongoDbPersister(this IServiceCollection services)
    {
        //var mongoDbParameter = appSettings.Value.MongoDbParameters;

        services.AddSingleton(serviceProvider =>
        {
            var mongoDbParameter = serviceProvider
                .GetRequiredService<IOptions<AppSettings>>()
                .Value.MongoDbParameters;

            var client = new MongoClient(mongoDbParameter.ConnectionString);
            var database = client.GetDatabase(mongoDbParameter.DatabaseName);
            return database;
        });
        services.AddScoped<IPersister<AuthorModel>, Persister<AuthorModel>>();
        services.AddScoped<IPersister<CategoryModel>, Persister<CategoryModel>>();
        //services.AddScoped<IObjectPersister, ObjectPersister>();
        //services.AddScoped<ValidationHandler>();
        //services.AddFluentValidation(options =>
        //    options.RegisterValidatorsFromAssemblyContaining<ValidationHandler>());
        return services;
    }
}