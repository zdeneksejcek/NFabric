using System;

namespace NFabric.Samples.Sales.Application
{
    public class Savable<T> : IDisposable
    {
        public T Object { get; private set; }
        private Action<T> Save { get; set; }

        public Savable(T @object, Action<T> save)
        {
            Object = @object;
            Save = save;
        }

        public void Dispose()
        {
            Save(Object);
        }
    }
}
