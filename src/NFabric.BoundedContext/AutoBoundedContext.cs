using System;
using System.Reflection;
using System.Collections.Generic;
using NFabric.Common.Messaging;

namespace NFabric.BoundedContext
{
    public class AutoBoundedContext : IBoundedContext
    {
        private string _bcName;
        private ServiceRegistry _registry;
        private HandledMessages _handledMessages;
        private ServiceActivator _activator;

        public AutoBoundedContext(Assembly assembly)
        {
            var inspector = new Inspector(assembly);

            _activator = new ServiceActivator(assembly);
            _bcName = inspector.GetBoundedContextName();
            _registry = inspector.GetRegistry();
            _handledMessages = inspector.GetHandledMessages();
        }

        public Message[] ExecuteMessage(Message message)
        {
            var serviceDescriptor = _registry.GetCommandService(message.BoundedContext, message.Name);
            var deserializedMessage =  Serializer.Deserialize(message.Body, serviceDescriptor.MessageType);

            _activator.ExecuteHandleMethod(
                serviceDescriptor.Implementation,
                serviceDescriptor.MessageType, deserializedMessage, (repository) => {
                
            });

            return new Message[0];
        }

        public string GetName()
        {
            return _bcName;
        }

        public HandledMessages GetHandledMessages()
        {
            return _handledMessages;
        }


    }
}