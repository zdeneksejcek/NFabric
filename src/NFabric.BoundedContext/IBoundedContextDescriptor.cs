using System;
using System.Collections.Generic;

namespace NFabric.BoundedContext
{
    public interface IBoundedContextDescriptor
    {
        IList<MessageDescriptorWithType> GetMessageDescriptors();
    }
}

