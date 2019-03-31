namespace MyApp.Core
{
    using MyApp.Core.Contracts;
    using System;
    using Microsoft.Extensions.DependencyInjection;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Engine : IEngine
    {
        private readonly IServiceProvider provider;

        public Engine(IServiceProvider provider)
        {
            this.provider = provider;
        }

        public void Run()
        {
            while (true)
            {

                string[] inputArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                var commandInterpreter = this.provider.GetService<ICommandInterpreter>();

                try
                {
                    string result = commandInterpreter.Read(inputArgs);

                    Console.WriteLine(result);
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentException argEx)
                {
                    Console.WriteLine(argEx.Message);
                }
            }
        }
    }
}
