using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace NhnCommon.Tests;

public class AppHttpClientFixture
{
    public readonly HttpClient Client;

    public AppHttpClientFixture()
    {
        var app = new ProjectsApplication();
        Client = app.CreateClient();
        //Client.DefaultRequestHeaders.Add("Authorization", AdminToken);
    }

    private class ProjectsApplication : WebApplicationFactory<Program>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));

                Log.Logger = new LoggerConfiguration()
                    .WriteTo.File("Logs\\NhnCommon.log")
                    .CreateLogger();
            });

            return base.CreateHost(builder);
        }
    }
}