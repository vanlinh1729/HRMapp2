using HRMapp2.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace HRMapp2.Permissions;

public class HRMapp2PermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(HRMapp2Permissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(HRMapp2Permissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<HRMapp2Resource>(name);
    }
}
