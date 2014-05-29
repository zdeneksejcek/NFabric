using System;

namespace NFabric.BoundedContext
{
    public interface ICommandHandler<TCommand>
    {
        void Handle(TCommand command);
    }
}