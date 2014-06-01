using System;
using System.Reflection;
using System.Collections.Generic;

namespace NFabric.BoundedContext
{
    public class EventHandlersAutoReflector : IListensToEvents
    {
        private Assembly Assembly { get; set; }

        public EventHandlersAutoReflector(Assembly assembly)
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

