namespace SoftUni
{
    using Microsoft.EntityFrameworkCore;
    using SoftUni.Data;
    using SoftUni.Models;
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using (var context = new SoftUniContext())
            {

                //P3 Console.WriteLine(GetEmployeesFullInformation(context));

                //P4 Console.WriteLine(GetEmployeesWithSalaryOver50000(context));

                //P5 Console.WriteLine(GetEmployeesFromResearchAndDevelopment(context));

                //P6 Console.WriteLine(AddNewAddressToEmployee(context));

                //P7 Console.WriteLine(GetEmployeesInPeriod(context));

                //P8 Console.WriteLine(GetAddressesByTown(context));

                //P9 Console.WriteLine(GetEmployee147(context));

                //P10 Console.WriteLine(GetDepartmentsWithMoreThan5Employees(context));

                //P11 Console.WriteLine(GetLatestProjects(context));

                //P12 Console.WriteLine(IncreaseSalaries(context));

                //P13 Console.WriteLine(GetEmployeesByFirstNameStartingWithSa(context));

                //P14 Console.WriteLine(DeleteProjectById(context));

                //P15 Console.WriteLine(RemoveTown(context));
            }
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var sb = new StringBuilder();
            var employees = context.Employees
                .OrderBy(e => e.EmployeeId);

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} {emp.MiddleName} {emp.JobTitle} {emp.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var sb = new StringBuilder();
            var employees = context.Employees
                .Where(e => e.Salary > 50_000)
                .OrderBy(e => e.FirstName);

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} - {emp.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees
                .Include(e => e.Department)
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName);

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} from {emp.Department.Name} - ${emp.Salary:F2}");
            }

            return sb.ToString().TrimEnd();

        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var address = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            context.Addresses.Add(address);

            var employee = context.Employees
                .FirstOrDefault(e => e.LastName == "Nakov");

            employee.Address = address;

            context.SaveChanges();

            var employees = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Select(a => a.Address.AddressText)
                .Take(10);

            foreach (var emp in employees)
            {
                sb.AppendLine(emp);
            }

            return sb.ToString().TrimEnd();

        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.EmployeesProjects
                    .Any(s => s.Project.StartDate.Year >= 2001 &&
                               s.Project.StartDate.Year <= 2003))
                .Select(x => new
                {
                    EmployeeFullName = x.FirstName + " " + x.LastName,
                    ManagerFullName = x.Manager.FirstName + " " + x.Manager.LastName,
                    Projects = x.EmployeesProjects.Select(p => new
                    {
                        ProjectName = p.Project.Name,
                        StartDate = p.Project.StartDate,
                        EndDate = p.Project.EndDate
                    })
                })
                .Take(10);

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.EmployeeFullName} - Manager: {emp.ManagerFullName}");

                foreach (var project in emp.Projects)
                {

                    var startDate = project.StartDate.ToString("M/d/yyyy h:mm:ss tt");
                    var endDate = project.EndDate.HasValue ?
                        project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt")
                        : "not finished";

                    sb.AppendLine($"--{project.ProjectName} - {startDate} - {endDate}");
                }
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var addresses = context.Addresses
                .Select(a => new
                {
                    a.AddressText,
                    TownName = a.Town.Name,
                    EmployeesCount = a.Employees.Count
                })
                .OrderByDescending(a => a.EmployeesCount)
                .ThenBy(a => a.TownName)
                .ThenBy(a => a.AddressText)
                .Take(10);

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.TownName} - {address.EmployeesCount} employees");
            }

            return sb.ToString();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var sb = new StringBuilder();
            var emp147 = context.Employees
                .Where(e => e.EmployeeId == 147)
                .Include(ep => ep.EmployeesProjects)
                .Select(x => new
                {
                    FullName = x.FirstName + " " + x.LastName,
                    JobTitle = x.JobTitle,
                    Projects = x.EmployeesProjects.Select(p => new
                    {
                        Name = p.Project.Name
                    })
                })
                .First();

            sb.AppendLine($"{emp147.FullName} - {emp147.JobTitle}");
            foreach (var proj in emp147.Projects.OrderBy(p => p.Name))
            {
                sb.AppendLine($"{proj.Name}");
            }


            return sb.ToString();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var departments = context.Departments
                               .Where(d => d.Employees.Count > 5)
                               .OrderBy(d => d.Employees.Count)
                               .ThenBy(d => d.Name)
                               .Select(d => new
                               {
                                   DepartmentName = d.Name,
                                   ManagerName = $"{d.Manager.FirstName} {d.Manager.LastName}",
                                   Employees = d.Employees.Select(e => new
                                   {
                                       EmployeeFirstName = e.FirstName,
                                       EmployeeLastName = e.LastName,
                                       e.JobTitle,
                                   })
                                   .OrderBy(e => e.EmployeeFirstName)
                                   .ThenBy(e => e.EmployeeLastName)
                               })
                               .ToList();

            foreach (var department in departments)
            {
                sb.AppendLine($"{department.DepartmentName} - {department.ManagerName}");

                foreach (var employee in department.Employees)
                {
                    sb.AppendLine($"{employee.EmployeeFirstName} {employee.EmployeeLastName} - {employee.JobTitle}");
                }
            }

            return sb.ToString();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name);

            foreach (var project in projects)
            {
                sb.AppendLine(project.Name)
                    .AppendLine(project.Description)
                    .AppendLine(project.StartDate.ToString("M/d/yyyy h:mm:ss tt"));
            }

            return sb.ToString();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.Department.Name == "Engineering" ||
                        e.Department.Name == "Tool Design" ||
                        e.Department.Name == "Marketing" ||
                        e.Department.Name == "Information Services")
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName);

            foreach (var employee in employees)
            {
                employee.Salary *= 1.12m;
            }

            context.SaveChanges();

            var employeesAfteIncreasedSalary = employees
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .Select(e => new
                {
                    Name = $"{e.FirstName} {e.LastName}",
                    Salary = $"{e.Salary:F2}"
                });

            foreach (var employee in employeesAfteIncreasedSalary)
            {
                sb.AppendLine($"{employee.Name} (${employee.Salary:F2})");
            }

            return sb.ToString();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .Select(e => new
                {
                    Name = $"{e.FirstName} {e.LastName}",
                    JobTitle = e.JobTitle,
                    Salary = e.Salary
                });

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.Name} - {employee.JobTitle} - (${employee.Salary:F2})");
            }

            return sb.ToString();
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var projectId = 2;
            var employeesProjects = context.EmployeesProjects
                .Where(e => e.ProjectId == projectId);
            foreach (var employeesProject in employeesProjects)
            {
                context.EmployeesProjects.Remove(employeesProject);
            }

            var projectToRemove = context.Projects
                .Find(projectId);
            context.Projects.Remove(projectToRemove);

            context.SaveChanges();

            var projects = context.Projects
                .Take(10)
                .Select(p => p.Name);

            foreach (var project in projects)
            {
                sb.AppendLine($"{project}");
            }

            return sb.ToString();
        }

        public static string RemoveTown(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var town = context.Towns
                .FirstOrDefault(t => t.Name == "Seattle");

            var addresses = town.Addresses.ToList();
            var addressesCount = addresses.Count();

            foreach (var address in addresses)
            {
                foreach (var employee in address.Employees)
                {
                    employee.AddressId = null;
                }
            }

            context.RemoveRange(addresses);
            context.Remove(town);
            context.SaveChanges();

            sb.AppendLine($"{addressesCount} addresses in Seattle were deleted");

            return sb.ToString().TrimEnd();
        }
    }
}


