using System;
using NFabric.BoundedContext.Proxy;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using NFabric.Host.Messaging;

namespace NFabric.Host
{
	class MainClass
	{
		public static void Main(string[] args)
		{
            //var container = new Container("NFabric.Samples.Sales", "NFabric.BoundedContext");

            //var message = new Messaging.Message("Super Type");

            //container.ExecuteCommand(message);

            Messaging.IServiceBus bus = CreateRabbitBus();

            var bc = new BoundedContextDescriptor(
                         "Sales",
                         new List<string>{ "CreateSalesOrder", "AddSalesOrderLine" },
                         new List<string>{ "SalesOrderCreated", "SalesOrderLineAdded" });

            bus.EnsureBoundedContext(bc);

            var pub = bus.CreateMessagePublisher();

            bus.Dispose();
        }

        private static Messaging.IServiceBus CreateRabbitBus() {
            var assembly = Assembly.LoadFile("NFabric.Infrastructure.RabbitMQ.dll");
            var bus = assembly.CreateInstance("NFabric.Infrastructure.RabbitMQ.RabbitMQServiceBus", false, BindingFlags.CreateInstance, null, new object[] {"host=localhost"}, null, null) as Messaging.IServiceBus;

            return bus;
        }
	}
}