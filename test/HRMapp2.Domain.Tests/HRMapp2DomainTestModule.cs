using HRMapp2.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace HRMapp2;

[DependsOn(
    typeof(HRMapp2EntityFrameworkCoreTestModule)
    )]
public class HRMapp2DomainTestModule : AbpModule
{

}
