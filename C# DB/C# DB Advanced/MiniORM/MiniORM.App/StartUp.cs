namespace MiniORM.App
{
    using Data;
    using Data.Entities;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var connectionString = "Server=DESKTOP-ALVILK7;Database=MiniORM;Integrated Security=True";

            var context = new MiniORM(connectionString);

            context.Employees.Add(new Employee
            {
                FirstName = "Stamen",
                LastName = "Stavov",
                DepartmentId = context.Departments.First().Id,
                IsEmployed = true
            });

            var employee = context.Employees.Last();
            employee.FirstName = "Slavcho";
            employee.MiddleName = "Mitkov";

            context.SaveChanges();
        }
    }
}

