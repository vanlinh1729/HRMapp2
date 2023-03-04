using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HRMapp2.Data;
using Volo.Abp.DependencyInjection;

namespace HRMapp2.EntityFrameworkCore;

public class EntityFrameworkCoreHRMapp2DbSchemaMigrator
    : IHRMapp2DbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreHRMapp2DbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the HRMapp2DbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<HRMapp2DbContext>()
            .Database
            .MigrateAsync();
    }
}
