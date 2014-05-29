using System;
using NFabric.BoundedContext;
using System.Reflection;

namespace NFabric.Samples.Sales
{
    public class ListensToEvents : IListensToEvents
    {
        public System.Collections.Generic.IEnumerable<string> GetEvents()
        {
            return new EventsAutoReflector(Assembly.GetExecutingAssembly()).GetEvents();
        }
    }
}