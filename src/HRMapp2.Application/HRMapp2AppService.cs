using System;
using System.Collections.Generic;
using System.Text;
using HRMapp2.Localization;
using Volo.Abp.Application.Services;

namespace HRMapp2;

/* Inherit your application services from this class.
 */
public abstract class HRMapp2AppService : ApplicationService
{
    protected HRMapp2AppService()
    {
        LocalizationResource = typeof(HRMapp2Resource);
    }
}
