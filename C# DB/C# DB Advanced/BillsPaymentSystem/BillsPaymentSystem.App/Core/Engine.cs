﻿namespace BillsPaymentSystem.App.Core
{
    using BillsPaymentSystem.App.Core.Contracts;
    using BillsPaymentSystem.Data;
    using System;
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }
        public void Run()
        {
            string input;
            while ((input = Console.ReadLine()) != "Ënd")
            {
                string[] inputParams = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                using (BillsPaymentSystemContext context = new BillsPaymentSystemContext())
                {
                    string result = this.commandInterpreter.Read(inputParams, context);
                    Console.WriteLine(result);
                }
            }

        }
    }
}
