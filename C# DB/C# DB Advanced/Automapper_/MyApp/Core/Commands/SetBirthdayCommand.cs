namespace MyApp.Core.Commands
{
    using AutoMapper;
    using MyApp.Core.Commands.Contracts;
    using MyApp.Data;
    using System;
    using System.Globalization;
    using System.Linq;

    public class SetBirthdayCommand : ICommand
    {

        private readonly MyAppContext context;
        private readonly Mapper mapper;

        public SetBirthdayCommand(MyAppContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] inputArgs)
        {
            var employeeId = int.Parse(inputArgs[0]);
            var date = DateTime.TryParseExact(inputArgs[1], "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result);

            var employee = context.Employees.FirstOrDefault(x => x.Id == employeeId);

            if (employee == null)
            {
                throw new ArgumentNullException($"There is no employee with ID: {employeeId}!");
            }
            if (!date)
            {
                throw new ArgumentException("Not correct input birthdate! Cant be parse :)");
            }

            employee.Birthday = result;
            this.context.SaveChanges();

            return $"Successfully set the birthday to the employee!";
        }
    }
}
