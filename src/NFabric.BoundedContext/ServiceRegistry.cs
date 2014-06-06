using System;
using System.Collections.Generic;
using System.Linq;

namespace NFabric.BoundedContext
{
    public class ServiceRegistry
    {
        public IList<ServiceDescriptor> _services;
        private IList<MessageDescriptorWithType> _descriptors;

        public ServiceRegistry(IList<ServiceDescriptor> services, IList<MessageDescriptorWithType> descriptors)
        {
            _services = services;
            _descriptors = descriptors;
        }

        public ServiceDescriptor GetCommandService(string messageBC, string messageName) {
            var serviceDescriptor = _services.FirstOrDefault(p => p.ServiceType == ServiceType.CommandHandler && p.MessageBC == messageBC && p.MessageName == messageName);

            return serviceDescriptor;
        }

        public ServiceDescriptor[] GetEventServices(string messageBC, string messageName) {
            return _services.Where(p => p.ServiceType == ServiceType.EventHandler && p.MessageBC == messageBC && p.MessageName == messageName).ToArray();
        }

        public MessageDescriptorWithType GetMessageDescriptor(string type, string name, string boundedContext) {
            return _descriptors.FirstOrDefault(p=>p.MessageType == type && p.MessageName == name && p.MessageBC == boundedContext);
        }
    }
}