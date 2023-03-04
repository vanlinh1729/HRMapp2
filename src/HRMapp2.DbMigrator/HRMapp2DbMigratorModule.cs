using HRMapp2.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace HRMapp2.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(HRMapp2EntityFrameworkCoreModule),
    typeof(HRMapp2ApplicationContractsModule)
    )]
public class HRMapp2DbMigratorModule : AbpModule
{

}
