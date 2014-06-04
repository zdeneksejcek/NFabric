using System;
using System.Collections.Generic;

namespace NFabric.BoundedContext
{
    public class ServiceRegistry
    {
        public IList<ServiceDescriptor> _services;

        public ServiceRegistry(IList<ServiceDescriptor> services)
        {
            _services = services;
        }

        public ServiceDescriptor GetCommandService() {
            return null;
        }

        public ServiceDescriptor[] GetEventServices() {
            return null;
        }
    }
}

