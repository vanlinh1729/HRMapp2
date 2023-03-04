using Volo.Abp.Modularity;

namespace HRMapp2;

[DependsOn(
    typeof(HRMapp2ApplicationModule),
    typeof(HRMapp2DomainTestModule)
    )]
public class HRMapp2ApplicationTestModule : AbpModule
{

}
