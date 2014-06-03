using System;
using System.Reflection;
using System.Collections.Generic;

namespace NFabric.BoundedContext
{
    public class AutoBoundedContext : IBoundedContext
    {
        private Inspector _inspector;

        public AutoBoundedContext(Assembly assembly)
        {
            _inspector = new Inspector(assembly);
        }

        public string GetName()
        {
            return _inspector.GetBoundedContextName();
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
            return _inspector.GetHandledMessages();
        }
    }
}