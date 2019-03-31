namespace MyApp.Core.Commands
{
    using MyApp.Core.Commands.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    class ExitCommand : ICommand
    {
        public string Execute(string[] inputArgs)
        {
            Environment.Exit(Environment.ExitCode);
            return "Program closed!";
        }
    }
}
