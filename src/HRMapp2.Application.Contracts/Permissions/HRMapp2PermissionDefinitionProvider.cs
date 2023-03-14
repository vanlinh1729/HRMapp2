using HRMapp2.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace HRMapp2.Permissions;

public class HRMapp2PermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(HRMapp2Permissions.GroupName, L("Permission:HRMApp"));
        //Define your own permissions here. Example:
        //myGroup.AddPermission(HRMapp2Permissions.MyPermission1, L("Permission:MyPermission1"));
        
        var departmentPermission = myGroup.AddPermission(HRMapp2Permissions.Department.Default, L("Permission:Department"));
        departmentPermission.AddChild(HRMapp2Permissions.Department.Create, L("Permission:Create"));
        departmentPermission.AddChild(HRMapp2Permissions.Department.Update, L("Permission:Update"));
        departmentPermission.AddChild(HRMapp2Permissions.Department.Delete, L("Permission:Delete"));

        var employeePermission = myGroup.AddPermission(HRMapp2Permissions.Employee.Default, L("Permission:Employee"));
        employeePermission.AddChild(HRMapp2Permissions.Employee.Create, L("Permission:Create"));
        employeePermission.AddChild(HRMapp2Permissions.Employee.Update, L("Permission:Update"));
        employeePermission.AddChild(HRMapp2Permissions.Employee.Delete, L("Permission:Delete"));

        
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<HRMapp2Resource>(name);
    }
}
