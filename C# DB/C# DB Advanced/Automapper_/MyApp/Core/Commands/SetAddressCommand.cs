namespace MyApp.Core.Commands
{
    using AutoMapper;
    using MyApp.Core.Commands.Contracts;
    using MyApp.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class SetAddressCommand : ICommand
    {
        private readonly MyAppContext context;
        private readonly Mapper mapper;

        public SetAddressCommand(MyAppContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] inputArgs)
        {
            var employeeID = int.Parse(inputArgs[0]);
            var address = string.Join(" ", inputArgs.Skip(1).ToArray());

            var employee = context.Employees.FirstOrDefault(x => x.Id == employeeID);

            if (employee == null)
            {
                throw new ArgumentNullException($"There is no such employee with ID {employeeID} ");
            }

            employee.Address = address;

            context.SaveChanges();

            return $"Successfully added address to employee!";
        }
    }
}
