using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

namespace NFabric.BoundedContext
{
    public class Inspector
    {
        private Assembly _assembly;

        public Inspector(Assembly assembly)
        {
            _assembly = assembly;
        }

        public HandledMessages GetHandledMessages() {
            var eventTypes = GetHandledTypes(typeof(IEventHandler<>));
            var commandTypes = GetHandledTypes(typeof(ICommandHandler<>));
            var descriptors = GetDescriptors("event", eventTypes).Concat(GetDescriptors("command", commandTypes));

            return new HandledMessages(descriptors.ToList());
        }

        public IList<MessageDescriptor> GetDescriptors(string messageType, Type[] types) {
            return types.Select(
                p=>new MessageDescriptor(messageType, p.Name, GetBoundedContextName(p))
            ).ToList();
        }

        private Type[] GetHandledTypes(Type genericType) {
            var interfaces = _assembly.GetExportedTypes().SelectMany(p=>p.GetInterfaces()).Where(
                x => x.IsGenericType && x.GetGenericTypeDefinition() == genericType
            );

            return interfaces.Select(p=>GetFirstGenericArgument(p)).ToArray();
        }

        private Type GetFirstGenericArgument(Type type) {
            return type.GetGenericArguments().FirstOrDefault();
        }

        private string GetBoundedContextName(Type type) {
            var attr = type.Assembly.GetCustomAttributes(typeof(AssemblyProductAttribute)).FirstOrDefault() as AssemblyProductAttribute;

            return attr.Product;
        }

        public string GetBoundedContextName() {
            var attr = _assembly.GetCustomAttributes(typeof(AssemblyProductAttribute)).FirstOrDefault() as AssemblyProductAttribute;

            return attr.Product;
        }

        public ServiceRegistry GetRegistry() {
            var eventHandlersDescriptors = GetEventHandlersDescriptors(ServiceType.EventHandler, typeof(IEventHandler<>)); 
            var commandHandlersDescriptors = GetEventHandlersDescriptors(ServiceType.CommandHandler, typeof(ICommandHandler<>)); 

            var bothLists = eventHandlersDescriptors.Concat(commandHandlersDescriptors).ToList();

            return new ServiceRegistry(bothLists);
        }

        private static IList<ServiceTuple> GetServiceTuples(Type type, Type genericType) {
            var interfaces = type.GetInterfaces().Where(x => x.IsGenericType && x.GetGenericTypeDefinition() == genericType);

            return interfaces.Select(p=>new ServiceTuple(type,p)).ToList();
        }

        private IList<ServiceDescriptor> GetEventHandlersDescriptors(ServiceType serviceType, Type genericType) {
            return _assembly.GetExportedTypes().SelectMany(p => GetServiceTuples(p, genericType))
                .Select(p=>
                    new ServiceDescriptor(
                        serviceType,
                        p.Service,
                        GetFirstGenericArgument(p.Inter),
                        GetBoundedContextName(p.Service)
                    )).ToList();
        }

        private class ServiceTuple {
            public Type Service { get; private set; }
            public Type Inter { get; private set; }

            public ServiceTuple(Type service, Type inter) {
                Service = service;
                Inter = inter;
            }
        }

    }
}