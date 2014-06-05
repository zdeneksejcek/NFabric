using System;
using NFabric.BoundedContext.Proxy;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using NFabric.Common.Messaging;
using NFabric.Common;
using NFabric.BoundedContext;

namespace NFabric.Host
{
	class MainClass
	{
		public static void Main(string[] args)
		{
            var assembly = typeof(NFabric.Samples.Sales.Port.ProductId).Assembly;

            var bc = new AutoBoundedContext(assembly);

            var container = new Container("NFabric.Samples.Sales", "NFabric.BoundedContext");
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(
                new NFabric.Samples.Sales.Commands.SalesOrder.CreateSalesOrder(Guid.NewGuid(), Guid.NewGuid()));
            /*

            Stopwatch sw = new Stopwatch();
            sw.Start();

            for(int i=0; i<10000; i++)
                {
                    //bc.ExecuteMessage(new Message("command", "Sales", "CreateSalesOrder", json));

                    var results = container.Execute(new Message("command", "Sales", "CreateSalesOrder", json));
                    //Console.Write(".");
                }

            sw.Stop();
            System.Console.ReadLine();
            container.Unload();
            System.Console.ReadLine();
            Console.WriteLine("Elapsed time: {0}", sw.ElapsedMilliseconds);

            */
            //new AutoBoundedContext(assembly).ExecuteMessage(new Message("command", "Sales", "CreateSalesOrder", ""));

            //var inspector = new NFabric.BoundedContext.Inspector(assembly);

            var bus = CreateRabbitBus();
            var disp = new MessageDispatcher(bus);

            for (var i = 0; i < 500000; i++)
            {
                    disp.DispatchMessage(
                        new UncommitedMessage("command", "Sales", "CreateSalesOrder", Guid.NewGuid(), DateTime.UtcNow, json));

                    //disp.DispatchCommand(
                    //new NFabric.Samples.Sales.Commands.SalesOrder.CreateSalesOrder(Guid.NewGuid(), Guid.NewGuid()));

                    /*
                disp.DispatchEvents(
                    new NFabric.Samples.Sales.Events.SalesOrder.SalesOrderCreated(Guid.NewGuid(), Guid.NewGuid()));
                    */
            }

            // deploy BC
            //bus.EnsureBoundedContext(bc);

            var cons = bus.CreateMessageConsumer();

            var consume = cons.Consume("Sales", (m) => {
                    bc.ExecuteMessage(m);
                    //var results = container.Execute(m);
            });

            //System.Console.ReadLine();

            //consume.Dispose();
            //bus.Dispose();
        }

        private static IServiceBus CreateRabbitBus() {
            //var assembly = Assembly.LoadFile("NFabric.Infrastructure.RabbitMQ.dll");
            //var bus = assembly.CreateInstance("NFabric.Infrastructure.RabbitMQ.RabbitMQServiceBus", false, BindingFlags.CreateInstance, null, new object[] {"host=localhost"}, null, null) as IServiceBus;

            var bus = new NFabric.Infrastructure.RabbitMQ.RabbitMQServiceBus("host=localhost");

            return bus;
        }
	}
}