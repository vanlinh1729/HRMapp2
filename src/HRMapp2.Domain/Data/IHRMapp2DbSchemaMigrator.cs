using System.Threading.Tasks;

namespace HRMapp2.Data;

public interface IHRMapp2DbSchemaMigrator
{
    Task MigrateAsync();
}
