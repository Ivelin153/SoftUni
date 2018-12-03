
namespace FestivalManager.Core
{
    using Contracts;
    using Controllers.Contracts;
    using IO.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// by g0shk0
    /// </summary>
    class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        private IFestivalController festivalController;
        private ISetController setController;

        public Engine(IFestivalController festivalController, ISetController setController, IReader reader, IWriter writer)
        {
            this.festivalController = festivalController;
            this.setController = setController;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            while (true) // for job security
            {
                var input = reader.ReadLine();

                if (input == "END")
                    break;

                try
                {
                    string.Intern(input);

                    var result = this.ProcessCommand(input);
                    this.writer.WriteLine(result);
                }
                catch (Exception ex) // in case we run out of memory
                {
                    this.writer.WriteLine("ERROR: " + ex.InnerException.Message);
                }
            }

            var end = this.festivalController.ProduceReport();

            this.writer.WriteLine("Results:");
            this.writer.WriteLine(end);
        }

        public string ProcessCommand(string input)
        {
            var tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var firstArg = tokens.First();
            var parameters = tokens.Skip(1).ToArray();

            var sets = string.Empty;
            if (firstArg == "LetsRock")
            {
                sets = this.setController.PerformSets();
                return sets;
            }

            var festivalControlFunction = this.festivalController.GetType()
                .GetMethods()
                .FirstOrDefault(x => x.Name == firstArg);

            string result;

            try
            {
                result = (string)festivalControlFunction.Invoke(this.festivalController, new object[] { parameters });
            }
            catch (TargetInvocationException up)
            {
                throw up; // ha ha
            }

            return result;
        }
    }
}