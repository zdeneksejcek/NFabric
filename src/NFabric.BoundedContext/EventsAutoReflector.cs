using System;
using System.Reflection;
using System.Collections.Generic;

namespace NFabric.BoundedContext
{
    public class EventsAutoReflector : IListensToEvents
    {
        private Assembly Assembly { get; set; }

        public EventsAutoReflector(Assembly assembly)
        {
            Assembly = assembly;
        }

        public System.Collections.Generic.IEnumerable<string> GetEvents()
        {
            return new List<string>
            {
                    "Event A",
                    "Event B",
                    "Event C"
            };
        }
    }
}

