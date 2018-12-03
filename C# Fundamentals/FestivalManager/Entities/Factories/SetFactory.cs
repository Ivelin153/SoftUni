namespace FestivalManager.Entities.Factories
{
    using Contracts;
    using Entities.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class SetFactory : ISetFactory
    {
        public ISet CreateSet(string name, string type)
        {
            Type className = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == type);
            var ctors = className.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
            ISet set = (ISet)ctors[0].Invoke(new object[] { name });
            return set;
        }
    }
}