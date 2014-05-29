using System;

namespace NFabric.BoundedContext.Proxy
{
    [Serializable]
    public class SampleCommand
    {
        public int Time { get; private set;}

        public SampleCommand(int time)
        {
            Time = time;
        }
    }
}

