namespace HRMapp2.Permissions;

public static class HRMapp2Permissions
{
    public const string GroupName = "HRMapp2";
    public class Department
    {
        public const string Default = GroupName + ".Department";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public class Employee
    {
        public const string Default = GroupName + ".Employee";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";
}
