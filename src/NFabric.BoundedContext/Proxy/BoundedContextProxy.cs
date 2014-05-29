using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;

namespace NFabric.BoundedContext.Proxy
{
    public class BoundedContextProxy : MarshalByRefObject, IBoundedContextProxy
    {
        public IList<object> ExecuteCommand(object obj)
        {
            return new List<object>();
        }
    }
}