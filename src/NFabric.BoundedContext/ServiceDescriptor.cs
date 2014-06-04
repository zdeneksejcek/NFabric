using System;

namespace NFabric.BoundedContext
{
    public class ServiceDescriptor
    {
        public ServiceType ServiceType { get; private set; }
        public Type Implementation { get; private set; }
        public Type MessageType { get; private set; }
        public string MessageName { get; private set; }
        public string MessageBC { get; private set; }

        public ServiceDescriptor(ServiceType serviceType, Type implementation, Type messageType, string messageBC)
        {
            ServiceType = serviceType;
            Implementation = implementation;
            MessageType = messageType;
            MessageName = messageType.Name;
            MessageBC = messageBC;
        }
    }
}