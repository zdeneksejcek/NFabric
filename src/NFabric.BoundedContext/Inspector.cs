﻿using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

namespace NFabric.BoundedContext
{
    public class Inspector
    {
        private Assembly _assembly;
        private IBoundedContextDescriptor _bcDescriptor;

        public Inspector(Assembly assembly)
        {
            _assembly = assembly;
            _bcDescriptor = CreateBCDescriptor();
        }

        private IBoundedContextDescriptor CreateBCDescriptor() {
            var bcDescriptorType = _assembly.GetExportedTypes().FirstOrDefault(p=>typeof(IBoundedContextDescriptor).IsAssignableFrom(p));
            if (bcDescriptorType != null)
                return Activator.CreateInstance(bcDescriptorType) as IBoundedContextDescriptor;

            return null;
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

        public IList<MessageDescriptorWithType> GetDescriptorsWithTypes() {
            /*
            var eventTypes = GetHandledTypes(typeof(IEventHandler<>));
            var commandTypes = GetHandledTypes(typeof(ICommandHandler<>));

            var eventDescriptors = eventTypes.Select(
                p => new MessageDescriptorWithType("event", p.Name, GetBoundedContextName(p), p)).ToList();

            var commandDescriptors = commandTypes.Select(
                p => new MessageDescriptorWithType("command", p.Name, GetBoundedContextName(p), p)).ToList();

            return commandDescriptors.Concat(eventDescriptors).ToList();
            */

            return _bcDescriptor.GetMessageDescriptors();
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

        public string GetMessageName(Type type) {
            return type.Name;
        }

        public string GetBoundedContextName(Type type) {
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

            return new ServiceRegistry(bothLists, GetDescriptorsWithTypes());
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