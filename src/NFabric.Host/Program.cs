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

namespace NFabric.Host
{
	class MainClass
	{
		public static void Main(string[] args)
		{
            var assembly = typeof(NFabric.Samples.Sales.BoundedContext).Assembly;

            var inspector = new NFabric.BoundedContext.Inspector(assembly);
            var handledMessages = inspector.GetHandledMessages();

            var bus = CreateRabbitBus();
            var disp = new MessageDispatcher(bus);

            for (var i = 0; i < 0; i++)
            {
                disp.DispatchCommand(
                    new NFabric.Samples.Sales.Commands.SalesOrder.CreateSalesOrder(Guid.NewGuid(), Guid.NewGuid()));

                disp.DispatchEvents(
                    new NFabric.Samples.Sales.Events.SalesOrder.SalesOrderCreated(Guid.NewGuid(), Guid.NewGuid()));
            }

            var bc = new BoundedContextDescriptor(
                         "Sales",
                         new List<string>{ "CreateSalesOrder", "AddSalesOrderLine" },
                         new List<string>{ "SalesOrderCreated", "SalesOrderLineAdded" });

            // deploy BC
            //bus.EnsureBoundedContext(bc);

            var container = new Container("NFabric.Samples.Sales", "NFabric.BoundedContext");
            var cons = bus.CreateMessageConsumer();

            var consume = cons.Consume("Sales", (m) => {
                    var results = container.Execute(m);
            });

            System.Console.ReadLine();

            consume.Dispose();
            bus.Dispose();
        }

        private static IServiceBus CreateRabbitBus() {
            var assembly = Assembly.LoadFile("NFabric.Infrastructure.RabbitMQ.dll");
            var bus = assembly.CreateInstance("NFabric.Infrastructure.RabbitMQ.RabbitMQServiceBus", false, BindingFlags.CreateInstance, null, new object[] {"host=localhost"}, null, null) as IServiceBus;

            return bus;
        }
	}
}