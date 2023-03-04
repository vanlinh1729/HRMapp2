using HRMapp2.Departments;
using HRMapp2.Employees;
using HRMapp2.Projects;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace HRMapp2.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class HRMapp2DbContext :
    AbpDbContext<HRMapp2DbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules
    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Project> Projects { get; set; }


    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public HRMapp2DbContext(DbContextOptions<HRMapp2DbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        builder.Entity<Department>(b =>
        {
            b.ToTable(HRMapp2Consts.DbTablePrefix + "Departments" + HRMapp2Consts.DbSchema);
            b.ConfigureByConvention();

            b.Property(x => x.DepartmentName)
                .HasMaxLength(DepartmentConsts.MaxNameLength)
                .IsRequired();
            b.Property(x => x.DepartmentManager)
                .HasMaxLength(DepartmentConsts.MaxNameLength)
                .IsRequired();
            b.Property(x => x.DepartmentLocation)
                .HasMaxLength(DepartmentConsts.MaxNameLength)
                .IsRequired();
            
            
        });

        builder.Entity<Employee>(b =>
        {
            b.ToTable(HRMapp2Consts.DbTablePrefix + "Employees" + HRMapp2Consts.DbSchema);
            b.ConfigureByConvention();

            b.Property(x => x.EmployeeName)
                .HasMaxLength(ProjectConsts.MaxNameLength)
                .IsRequired();
            b.Property(x => x.EmployeeSupervisor)
                .HasMaxLength(ProjectConsts.MaxNameLength)
                .IsRequired();
            b.Property(x => x.EmployeeAddress)
                .HasMaxLength(ProjectConsts.MaxNameLength)
                .IsRequired();
            b.Property(x => x.EmployeeSex)
                .HasMaxLength(ProjectConsts.MaxNameLength)
                .IsRequired();

            b.HasOne<Department>().WithMany(e=>e.Employees).HasForeignKey(x => x.DepartmentId).IsRequired();
            
        });

        builder.Entity<Project>(b =>
        {
            b.ToTable(HRMapp2Consts.DbTablePrefix + "Projects" + HRMapp2Consts.DbSchema);
            b.ConfigureByConvention();

            b.Property(x => x.ProjectName)
                .HasMaxLength(ProjectConsts.MaxNameLength)
                .IsRequired();
            b.Property(x => x.ProjectLocation)
                .HasMaxLength(ProjectConsts.MaxNameLength)
                .IsRequired();
           
        });
        
        builder.Entity<DepartmentProject>(b =>
        {
            b.ToTable(HRMapp2Consts.DbTablePrefix + "DepartmentProjects" + HRMapp2Consts.DbSchema);
            b.ConfigureByConvention();

            //define composite key
            
            b.HasKey(x => new { x.DepartmentId, x.ProjectId });

            //many-to-many configuration
            
            b.HasOne<Department>().WithMany(x=>x.Projects).HasForeignKey(dp=>dp.DepartmentId).IsRequired();
            b.HasOne<Project>().WithMany(x=>x.Departments).HasForeignKey(x => x.ProjectId).IsRequired();

            b.HasIndex(x => new { x.DepartmentId, x.ProjectId });
        });
        
        builder.Entity<EmployeeProject>(b =>
        {
            b.ToTable(HRMapp2Consts.DbTablePrefix + "EmployeeProjects" + HRMapp2Consts.DbSchema);
            b.ConfigureByConvention();

            //define composite key
            b.HasKey(x => new { x.EmployeeId, x.ProjectId });

            //many-to-many configuration
            b.HasOne<Employee>().WithMany(x => x.Projects).HasForeignKey(x => x.EmployeeId).IsRequired();
            b.HasOne<Project>().WithMany(x=>x.Employees).HasForeignKey(x => x.ProjectId).IsRequired();

            b.HasIndex(x => new { x.EmployeeId, x.ProjectId });
        });






        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(HRMapp2Consts.DbTablePrefix + "YourEntities", HRMapp2Consts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
    }
}
