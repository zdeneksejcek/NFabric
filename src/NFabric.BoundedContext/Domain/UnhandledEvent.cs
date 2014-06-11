using System;
using NFabric.Contracts;

namespace NFabric.BoundedContext.Domain
{
    public class UnhandledEvent : Exception
    {
        private const string UNHANDLED_MESSAGE = "Unhandled message type: {0}";

        public UnhandledEvent(IEvent @event) : base(string.Format(UNHANDLED_MESSAGE, @event.GetType().Name))
        {
            
        }
    }
}
