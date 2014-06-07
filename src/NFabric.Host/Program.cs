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

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(
                new NFabric.Samples.Sales.Commands.SalesOrder.CreateSalesOrder(Guid.NewGuid(), Guid.NewGuid()));

            var bus = CreateRabbitBus();
            var disp = new MessageDispatcher(bus);

            var mongo = GetMongo();

            //var container = new Container("NFabric.Samples.Sales", "NFabric.BoundedContext", mongo);

            var bc = new AutoBoundedContext(assembly, mongo);
            var ids  = mongo.GetSOs();
            var rand = new Random();

            var cons = bus.CreateMessageConsumer();

            var consume = cons.Consume("Sales", (m) => {
                    //var results = container.Execute(m);
                    var uncommitedMessages = bc.ExecuteMessage(m);
                    mongo.Append(uncommitedMessages);

                    //var results = container.Execute(m);
                });

            while (false)
            {
                var id = ids[rand.Next(0, 5000)];

                string jsonNewLine = Newtonsoft.Json.JsonConvert.SerializeObject(
                    new NFabric.Samples.Sales.Commands.SalesOrder.AddSalesOrderLine(id, Guid.NewGuid(), rand.Next(1, 100)
                    ));

                disp.DispatchMessage(
                    new UncommitedMessage("command", "Sales", "AddSalesOrderLine", id, 0, DateTime.UtcNow, jsonNewLine));
            }

            if (false) { Guid id = Guid.Empty;
            //foreach (var id in ids) {
                    string jsonNewLine = Newtonsoft.Json.JsonConvert.SerializeObject(
                            new NFabric.Samples.Sales.Commands.SalesOrder.AddSalesOrderLine(id, Guid.NewGuid(), rand.Next(1, 100)
                        ));

                    disp.DispatchMessage(
                        new UncommitedMessage("command", "Sales", "AddSalesOrderLine", id, 0, DateTime.UtcNow, jsonNewLine));
                }



            for (var i = 0; i < 0; i++)
            {
                    disp.DispatchMessage(
                        new UncommitedMessage("command", "Sales", "CreateSalesOrder", Guid.NewGuid(), 0, DateTime.UtcNow, json));

                    //disp.DispatchCommand(
                    //new NFabric.Samples.Sales.Commands.SalesOrder.CreateSalesOrder(Guid.NewGuid(), Guid.NewGuid()));

                    /*
                disp.DispatchEvents(
                    new NFabric.Samples.Sales.Events.SalesOrder.SalesOrderCreated(Guid.NewGuid(), Guid.NewGuid()));
                    */
            }
            // deploy BC
            //bus.EnsureBoundedContext(bc);


            //System.Console.ReadLine();

            //consume.Dispose();
            //bus.Dispose();
        }

        private static NFabric.Infrastructure.Mongo.MongoEventStreamRepository GetMongo() {
            return new NFabric.Infrastructure.Mongo.MongoEventStreamRepository();
        }

        private static IServiceBus CreateRabbitBus() {
            //var assembly = Assembly.LoadFile("NFabric.Infrastructure.RabbitMQ.dll");
            //var bus = assembly.CreateInstance("NFabric.Infrastructure.RabbitMQ.RabbitMQServiceBus", false, BindingFlags.CreateInstance, null, new object[] {"host=localhost"}, null, null) as IServiceBus;

            var bus = new NFabric.Infrastructure.RabbitMQ.RabbitMQServiceBus("host=172.16.0.166");

            return bus;
        }
	}
}