using System;
using System.Collections.Generic;
using System.Linq;

namespace NFabric.BoundedContext
{
    public class ServiceRegistry
    {
        public IList<ServiceDescriptor> _services;

        public ServiceRegistry(IList<ServiceDescriptor> services)
        {
            _services = services;
        }

        public ServiceDescriptor GetCommandService(string messageBC, string messageName) {
            var serviceDescriptor = _services.FirstOrDefault(p => p.MessageBC == messageBC && p.MessageName == messageName);

            return serviceDescriptor;
        }

        public ServiceDescriptor[] GetEventServices() {
            return null;
        }
    }
}

