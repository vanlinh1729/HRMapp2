using System.Threading.Tasks;
using HRMapp2.Localization;
using HRMapp2.MultiTenancy;
using HRMapp2.Permissions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace HRMapp2.Web.Menus;

public class HRMapp2MenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<HRMapp2Resource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                HRMapp2Menus.Home,
                l["Trang chủ"],
                "~/",
                icon: "fas fa-home",
                order: 0
            ));

        

        context.Menu.Items.Insert(
            1,
            new ApplicationMenuItem(
                "Departments",
                l["Phòng ban"],
                "/departments",
                icon: "fas fa-building"

            ).RequirePermissions(HRMapp2Permissions.Department.Default)

        );

        context.Menu.Items.Insert(
            2,
            new ApplicationMenuItem(
                "Employees",
                l["Nhân viên"],
                "/employees",
                icon: "fas fa-user-circle"
            ).RequirePermissions(HRMapp2Permissions.Employee.Default)

        );

        context.Menu.AddItem(
            new ApplicationMenuItem("HRMapp.Recruitment", l["Tuyển dụng"],"", icon: "fas fa-bullhorn")
                .AddItem(new ApplicationMenuItem(
                    target: "_HRMapp.Recruitment", 
                    name: "Recruitment.Needs",
                    displayName: l["Nhu cầu nhân sự"],
                    url: "~/")
                ).AddItem(new ApplicationMenuItem(
                    target: "_HRMapp.Recruitment", 
                    name: "Recruitment.Plan",
                    displayName: l["Kế hoạch tuyển dụng"],
                    url: "~/")
                ).AddItem(new ApplicationMenuItem(
                    target: "_HRMapp.Recruitment", 
                    name: "Recruitment.Candidate",
                    displayName: l["Ứng viên"],
                    url: "~/")
                ).AddItem(new ApplicationMenuItem(
                    target: "_HRMapp.Recruitment", 
                    name: "Recruitment.Enterview1",
                    displayName: l["Phỏng vấn lần 1"],
                    url: "~/")
                ).AddItem(new ApplicationMenuItem(
                    target: "_HRMapp.Recruitment", 
                    name: "Recruitment.Enterview2",
                    displayName: l["Phỏng vấn lần 2"],
                    url: "~/")
                ).AddItem(new ApplicationMenuItem(
                    target: "_HRMapp.Recruitment", 
                    name: "Recruitment.ProbationStaff",
                    displayName: l["Nhân viên thử việc"],
                    url: "~/")
                ).RequirePermissions(HRMapp2Permissions.Department.Default));

        context.Menu.AddItem(
            new ApplicationMenuItem("HRMapp.DayOffs", l["Xin nghỉ"],"", icon: "fas fa-file-alt")
                .AddItem(new ApplicationMenuItem(
                    target: "_HRMapp.DayOffs", 
                    name: "DayOffs.AllLeaveApplication",
                    displayName: l["Tất cả đơn xin nghỉ"],
                    url: "~/")
                ).AddItem(new ApplicationMenuItem(
                    target: "_HRMapp.DayOffs", 
                    name: "DayOffs.DayOff",
                    displayName: l["Xin nghỉ"],
                    url: "~/")
                ).AddItem(new ApplicationMenuItem(
                    target: "_HRMapp.DayOffs", 
                    name: "DayOffs.DayOffCustom",
                    displayName: l["Xin đi sớm về muộn"],
                    url: "~/")
                ).AddItem(new ApplicationMenuItem(
                    target: "_HRMapp.DayOffs", 
                    name: "DayOffs.PublicDayOff",
                    displayName: l["Ngày nghỉ chung"],
                    url: "~/")
                ).RequirePermissions(HRMapp2Permissions.Department.Default));
        context.Menu.AddItem(
            new ApplicationMenuItem("HRMapp.Timekeeping", l["Chấm công"],"", icon: "fas fa-business-time")
                .AddItem(new ApplicationMenuItem(
                    target: "_HRMapp.Timekeeping", 
                    name: "Timekeeping.Month",
                    displayName: l["Chấm công theo tháng"],
                    url: "~/")
                ) .AddItem(new ApplicationMenuItem(
                    target: "_HRMapp.Timekeeping", 
                    name: "Timekeeping.Day",
                    displayName: l["Chấm công theo ngày"],
                    url: "~/")
                ) .AddItem(new ApplicationMenuItem(
                    target: "_HRMapp.Timekeeping", 
                    name: "Timekeeping.Config",
                    displayName: l["Cấu hình chấm công"],
                    url: "~/")
                ).RequirePermissions(HRMapp2Permissions.Department.Default));

        context.Menu.Items.Insert(
            7,
            new ApplicationMenuItem(
                "Payrolls",
                l["Bảng lương"],
                
                "~/",
                
                icon: "fas fa-table"

            ).RequirePermissions(HRMapp2Permissions.Department.Default)

        );
        context.Menu.Items.Insert(
            8,
            new ApplicationMenuItem(
                "Contracts",
                l["Hợp đồng"],
                "~/",
                    icon: "fas fa-pen"

            ).RequirePermissions(HRMapp2Permissions.Department.Default)

        );
        context.Menu.Items.Insert(
            9,
            new ApplicationMenuItem(
                "Insurances",
                l["Bảo hiểm"],
                "~/",
                icon: "fas fa-pen"
            ).RequirePermissions(HRMapp2Permissions.Department.Default)

        );
        context.Menu.Items.Insert(
            10,
            new ApplicationMenuItem(
                "Insurances",
                l["Liên hệ"],
                "/Contacts",
                icon: "fa fa-phone"
            )
        );

       


    if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);
    }
}
