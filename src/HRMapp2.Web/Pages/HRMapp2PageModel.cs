using HRMapp2.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace HRMapp2.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class HRMapp2PageModel : AbpPageModel
{
    protected HRMapp2PageModel()
    {
        LocalizationResourceType = typeof(HRMapp2Resource);
    }
}
