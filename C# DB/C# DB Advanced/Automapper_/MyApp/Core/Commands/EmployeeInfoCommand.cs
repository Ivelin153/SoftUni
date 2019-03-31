namespace MyApp.Core.Commands
{
    using AutoMapper;
    using MyApp.Core.Commands.Contracts;
    using MyApp.Core.ViewModels;
    using MyApp.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class EmployeeInfoCommand : ICommand
    {
        private readonly MyAppContext context;

        private readonly Mapper mapper;

        public EmployeeInfoCommand(MyAppContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] inputArgs)
        {
            var employeeId = int.Parse(inputArgs[0]);

            var employee = context.Employees.FirstOrDefault(x => x.Id == employeeId);

            var employeeDto = this.mapper.CreateMappedObject<EmployeeInfoDto>(employee);

            return $"{employeeDto.Id} - {employeeDto.FirstName} {employeeDto.LastName} - ${employeeDto.Salary}";
        }
    }
}