using NhnCommon.DataModel.MongoDb;
using NhnCommon.Shared.Configuration;

namespace NhnCommon.Modules;

public class MongoDbModule : IModule
{
    public bool IsEnabled => true;
    public int Order => 0;

    public IServiceCollection RegisterModule(WebApplicationBuilder builder)
    {
        builder.Services.AddOptions<AppSettings>()
            .Bind(builder.Configuration.GetSection(AppSettings.SectionName));

        builder.Services.AddMongoDbPersister();

        return builder.Services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints) => endpoints;

}