using System;

namespace NFabric.BoundedContext.Domain
{
    public class SequencedEvent
    {
        public int Sequence { get; private set; }
        public object Event { get; private set; }

        public SequencedEvent(int sequence, object @event) {
            Sequence = sequence;
            Event = @event;
        }

    }
}

