using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace HRMapp2.Data;

/* This is used if database provider does't define
 * IHRMapp2DbSchemaMigrator implementation.
 */
public class NullHRMapp2DbSchemaMigrator : IHRMapp2DbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
