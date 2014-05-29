using System;
using NFabric.BoundedContext.Proxy;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using System.Collections.Generic;

namespace NFabric.Host
{
	class MainClass
	{
		public static void Main(string[] args)
		{
            var container = new Container("NFabric.Samples.Sales", "NFabric.BoundedContext");

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            Parallel.For(0, 5000, (i) => {
                container.ExecuteCommand("Command you want " + i);
            });

            sw.Stop();

            System.Console.WriteLine("Time elapsed: " + sw.ElapsedMilliseconds);

            foreach (string @event in container.ListenedEvents)
                System.Console.WriteLine(@event);
        }
	}
}