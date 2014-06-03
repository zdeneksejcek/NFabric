using System;
using System.Reflection;
using System.Collections.Generic;

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

            _activator = new ServiceActivator();
            _bcName = inspector.GetBoundedContextName();
            _registry = inspector.GetRegistry();
            _handledMessages = inspector.GetHandledMessages();
        }

        public string GetName()
        {
            return _bcName;
        }

        public IList<object> ExecuteCommand(object command)
        {

            throw new NotImplementedException();
        }

        public IList<object> ExecuteEvent(object @event)
        {
            throw new NotImplementedException();
        }

        public HandledMessages GetHandledMessages()
        {
            return _handledMessages;
        }
    }
}