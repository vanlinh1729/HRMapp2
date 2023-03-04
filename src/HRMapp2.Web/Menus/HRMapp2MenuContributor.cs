﻿using System.Threading.Tasks;
using HRMapp2.Localization;
using HRMapp2.MultiTenancy;
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
                l["Menu:Home"],
                "~/",
                icon: "fas fa-home",
                order: 0
            )
            
        );
        
        context.Menu.Items.Insert(
            1,
            new ApplicationMenuItem(
                "Departments",
                l["Departments"],
                "/departments",
                icon: "fas fa-home",
                order: 0
            )
            
        );
        context.Menu.Items.Insert(
            1,
            new ApplicationMenuItem(
                "Employees",
                l["Employees"],
                "/employees",
                icon: "fas fa-home",
                order: 0
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
