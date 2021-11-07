namespace DesignPattern.Creational
{
    /// <summary>
    /// 抽象工厂（Abstract Factory）
    /// 提供一个接口，用于创建相关的对象家族。
    /// </summary>
    public class AbstractFactory
    {
        public AbstractFactory()
        {
            var client = new SqlServerUserManager();

            var user = client.CreateOrGetUser("fakeUser");

            var department = client.CreateOrGetDepartment("fakeDepartment");

            user.Department = department;
        }
    }



    /// <summary>
    /// 用户/部门管理
    /// 可能实体会存储在不同类型的数据库
    /// </summary>
    public abstract class AbstractUserManager
    {

        public abstract IUser CreateOrGetUser(string name);


        public abstract IDepartment CreateOrGetDepartment(string name);


        /// <summary>
        /// 抽象产品用户，与抽象产品部门相关
        /// </summary>
        public interface IUser
        {
            /// <summary>
            /// 更改或者设置名称
            /// </summary>
            public string UserName { get; set; }

            /// <summary>
            /// 为用户设置部门
            /// </summary>
            /// <param name="department"></param>
            public IDepartment Department { get; set; }

        }

        /// <summary>
        /// 部门
        /// </summary>
        public interface IDepartment
        {
            /// <summary>
            /// 更改或者设置名称
            /// </summary>
            public string DepartmentName { get; set; }
        }
    }

    /// <summary>
    /// SQLServer简单实现
    /// </summary>
    public class SqlServerUserManager : AbstractUserManager
    {

        public override IDepartment CreateOrGetDepartment(string name)
        {
            //从SqlServer读取DepartmentName = name的角色,没有则创建
            return new SqlServerDepartment
            {
                DepartmentName = name
            };
        }

        public override IUser CreateOrGetUser(string name)
        {
            //从SqlServer读取DepartmentName = name的角色,没有则创建
            return new SqlServerUser
            {
                UserName = name
            };
        }



        /// <summary>
        /// 使用Protected不用暴露细节，如有需要也可使用Public
        /// </summary>
        protected class SqlServerUser : IUser
        {
            private string name;

            private SqlServerDepartment department;

            public string UserName
            {
                get { return name; }
                set { name = value; }
            }

            public IDepartment Department

            {
                get
                {
                    return department;
                }
                set
                {
                    department = (SqlServerDepartment)value;
                }
            }

        }

        protected class SqlServerDepartment : IDepartment
        {
            private string name;

            public string DepartmentName
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;
                }
            }
        }
    }
}
