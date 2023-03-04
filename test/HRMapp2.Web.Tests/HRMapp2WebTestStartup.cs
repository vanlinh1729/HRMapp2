using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace HRMapp2;

public class HRMapp2WebTestStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication<HRMapp2WebTestModule>();
    }

    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        app.InitializeApplication();
    }
}
