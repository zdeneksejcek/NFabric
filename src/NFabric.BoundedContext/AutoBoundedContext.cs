﻿using System;
using System.Reflection;
using System.Collections.Generic;
using NFabric.Common.Messaging;
using NFabric.BoundedContext.Domain;
using System.Linq;
using NFabric.BoundedContext.Persistence;

namespace NFabric.BoundedContext
{
    public class AutoBoundedContext : IBoundedContext
    {
        private string _bcName;
        private ServiceRegistry _registry;
        private HandledMessages _handledMessages;
        private ServiceActivator _activator;

        public AutoBoundedContext(Assembly assembly, IEventsReader reader)
        {
            var inspector = new Inspector(assembly);

            _bcName = inspector.GetBoundedContextName();
            _registry = inspector.GetRegistry();
            _activator = new ServiceActivator(new SequencedEventsReader(reader, _registry), assembly);
            _handledMessages = inspector.GetHandledMessages();
        }

        public UncommitedMessage[] ExecuteMessage(Message message)
        {
            try {
                var serviceDescriptor = _registry.GetCommandService(message.BoundedContext, message.Name);
                var deserializedMessage =  Serializer.Deserialize(message.Body, serviceDescriptor.MessageType);

                UncommitedMessage[] uncommitedMessages = null;

                _activator.ExecuteHandleMethod(
                    serviceDescriptor.Implementation,
                    serviceDescriptor.MessageType, deserializedMessage, (repository) => {
                        uncommitedMessages = CreateUncommitedMessages(repository.UncommitedEvents);
                });

                return uncommitedMessages ?? new UncommitedMessage[0];
            } catch (Exception ex) {
                return new UncommitedMessage[0];
            }
        }

        private UncommitedMessage[] CreateUncommitedMessages(IList<SequencedEvent> uncommitedEvents) {
            return uncommitedEvents.Select(
                p => new UncommitedMessage(
                    "event",
                    GetName(),
                    p.Event.GetType().Name,
                    p.AggregateId,
                    p.Sequence,
                    p.CreatedOn,
                    Serializer.Serialize(p.Event))).ToArray();
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