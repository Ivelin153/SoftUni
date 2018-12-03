namespace FestivalManager.Entities.Factories
{
    using Contracts;
    using Entities.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class InstrumentFactory : IInstrumentFactory
    {
        public IInstrument CreateInstrument(string type)
        {
            Type className = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == type);
            var ctors = className.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
            IInstrument instrument = (IInstrument)ctors[0].Invoke(new object[] { });
            return instrument;
        }
    }
}