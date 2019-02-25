namespace MiniORM.App.Data
{
    using Entities;
    public class MiniORM : DbContext
    {
        public MiniORM(string connectionString)
            : base(connectionString)
        {
        }

        public DbSet<Employee> Employees { get; }

        public DbSet<Department> Departments { get; }

        public DbSet<Project> Projects { get; }

        public DbSet<EmployeesProject> EmployeesProjects { get; }
    }
}
