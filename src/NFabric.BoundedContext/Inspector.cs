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
            var eventTypes = GetTypes(typeof(IEventHandler<>));
            var commandTypes = GetTypes(typeof(ICommandHandler<>));
            var descriptors = GetDescriptors("event", eventTypes).Concat(GetDescriptors("command", commandTypes));

            return new HandledMessages(descriptors.ToList());
        }

        public IList<MessageDescriptor> GetDescriptors(string messageType, Type[] types) {
            return types.Select(
                p=>new MessageDescriptor(messageType, p.Name, GetBoundexContextName(p))
            ).ToList();
        }

        private Type[] GetTypes(Type genericType) {
            var interfaces = _assembly.GetExportedTypes().SelectMany(p=>p.GetInterfaces()).Where(
                x => x.IsGenericType && x.GetGenericTypeDefinition() == genericType
            );

            return interfaces.Select(p=>p.GetGenericArguments().FirstOrDefault()).ToArray();
        }

        private string GetBoundexContextName(Type type) {
            var attr = type.Assembly.GetCustomAttributes(typeof(AssemblyProductAttribute)).FirstOrDefault() as AssemblyProductAttribute;

            return attr.Product;
        }

        public string GetBoundedContextName() {
            var attr = _assembly.GetCustomAttributes(typeof(AssemblyProductAttribute)).FirstOrDefault() as AssemblyProductAttribute;

            return attr.Product;
        }
    }
}

