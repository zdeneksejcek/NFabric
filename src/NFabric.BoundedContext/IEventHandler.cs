using System;

namespace NFabric.BoundedContext
{
    public interface IEventHandler<TEvent>
    {
        void Handle(TEvent @event);
    }
}