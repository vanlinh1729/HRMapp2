using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace HRMapp2.Web;

[Dependency(ReplaceServices = true)]
public class HRMapp2BrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "HRMapp2";
    
}
