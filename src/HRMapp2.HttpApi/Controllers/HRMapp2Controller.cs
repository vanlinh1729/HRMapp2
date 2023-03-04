using HRMapp2.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace HRMapp2.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class HRMapp2Controller : AbpControllerBase
{
    protected HRMapp2Controller()
    {
        LocalizationResource = typeof(HRMapp2Resource);
    }
}
