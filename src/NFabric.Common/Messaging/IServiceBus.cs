using System;

namespace NFabric.Common.Messaging
{
    public interface IServiceBus : IDisposable
    {
        void EnsureBoundedContext(BoundedContextDescriptor bc);

        IMessagePublisher CreateMessagePublisher();
        IMessageConsumer CreateMessageConsumer();

        //void CreateHeartbeatConsumer();
        //void CreateHeartbeatPublisher();
    }
}