namespace MyApp.Core.Commands
{
    using AutoMapper;
    using MyApp.Core.Commands.Contracts;
    using MyApp.Core.ViewModels;
    using MyApp.Data;
    using System.Linq;

    public class EmployeePersonalInfoCommand : ICommand
    {
        private readonly MyAppContext context;
        private readonly Mapper mapper;

        public EmployeePersonalInfoCommand(MyAppContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] inputArgs)
        {

            var employeeId = int.Parse(inputArgs[0]);

            var employee = context.Employees
                .FirstOrDefault(x => x.Id == employeeId);

            var employeeInformation = this.mapper
                .CreateMappedObject<EmployeePersonalInfoDto>(employee);

            var result = employeeInformation.ToString();

            return result;
        }
    }
}