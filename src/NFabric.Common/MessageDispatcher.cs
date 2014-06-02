using System;
using System.Linq;
using NFabric.Common.Messaging;
using System.Reflection;
using System.Collections.Generic;

namespace NFabric.Common
{
    public class MessageDispatcher
    {
        IServiceBus _bus;
        MessageSerializer _serializer = new MessageSerializer();

        public MessageDispatcher(IServiceBus bus)
        {
            _bus = bus;
        }

        public void DispatchMessage(Message message) {
            _bus.CreateMessagePublisher().Publish(message);
        }

        public void DispatchCommand(object command) {
            string bcName = GetBoundedContextName(command);
            string commandName = GetMessageName(command);
            string body = _serializer.Serialize(command);

            var commandMessage = new Message("command", bcName, commandName, body);

            _bus.CreateMessagePublisher().Publish(commandMessage);
        }

        public void DispatchEvents(params object[] events) {
            var eventMessages = new List<Message>();
            foreach (var e in events)
            {
                string bcName = GetBoundedContextName(e);
                string commandName = GetMessageName(e);
                string body = _serializer.Serialize(e);

                    var eventMessage = new Message("event", bcName, commandName, body);
                eventMessages.Add(eventMessage);
            }

            _bus.CreateMessagePublisher().Publish(eventMessages.ToArray());
        }

        private string GetBoundedContextName(object obj) {
            var attribute = obj.GetType().Assembly.GetCustomAttributes(typeof(AssemblyProductAttribute)).FirstOrDefault() as AssemblyProductAttribute;

            return attribute.Product;
        }

        private string GetMessageName(object obj) {
            return obj.GetType().Name;
        }

    }
}