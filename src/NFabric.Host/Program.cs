using System;
using System.IO;
using System.Reflection;
using NFabric.Common.Messaging;
using NFabric.BoundedContext;
using NFabric.Infrastructure.Mongo;

namespace NFabric.Host
{
	class MainClass
	{
	    private static void Consume(Message m, AutoBoundedContext bc, MongoEventStreamRepository mongo)
	    {
            var uncommitedMessages = bc.ExecuteMessage(m);
            mongo.Append(uncommitedMessages);
	    }

   		public static void Main(string[] args)
   		{
   		    var arguments = new Arguments.Arguments(args);
   		    var makeAboslute = Environment.CurrentDirectory + Path.DirectorySeparatorChar + arguments.BCFileName;

            var assembly = Assembly.LoadFile(makeAboslute);

            var bus = CreateRabbitBus();
            //var disp = new MessageDispatcher(bus);

            var mongo = GetMongo();

            var bc = new AutoBoundedContext(assembly, mongo);

            var cons = bus.CreateMessageConsumer();

            using (var consume = cons.Consume(bc.GetName(), m => Consume(m, bc, mongo)))
   		    {
   		        Console.ReadLine();
   		    }

            //var ids  = mongo.GetSOs();
            //var rand = new Random();

            //var container = new Container("NFabric.Samples.Sales", "NFabric.BoundedContext", mongo);

            //string json = Newtonsoft.Json.JsonConvert.SerializeObject(
            //    new NFabric.Samples.Sales.Commands.SalesOrder.CreateSalesOrder(Guid.NewGuid(), Guid.NewGuid()));

            //while (false)
            //{
            //    var id = ids[rand.Next(0, 5000)];

            //    string jsonNewLine = Newtonsoft.Json.JsonConvert.SerializeObject(
            //        new NFabric.Samples.Sales.Commands.SalesOrder.AddSalesOrderLine(id, Guid.NewGuid(), rand.Next(1, 100)
            //        ));

            //    disp.DispatchMessage(
            //        new UncommitedMessage("command", "Sales", "AddSalesOrderLine", id, 0, DateTime.UtcNow, jsonNewLine));
            //}

            //if (false) { Guid id = Guid.Empty;
            ////foreach (var id in ids) {
            //        string jsonNewLine = Newtonsoft.Json.JsonConvert.SerializeObject(
            //                new NFabric.Samples.Sales.Commands.SalesOrder.AddSalesOrderLine(id, Guid.NewGuid(), rand.Next(1, 100)
            //            ));

            //        disp.DispatchMessage(
            //            new UncommitedMessage("command", "Sales", "AddSalesOrderLine", id, 0, DateTime.UtcNow, jsonNewLine));
            //    }



            //for (var i = 0; i < 0; i++)
            //{
            //        disp.DispatchMessage(
            //            new UncommitedMessage("command", "Sales", "CreateSalesOrder", Guid.NewGuid(), 0, DateTime.UtcNow, json));

            //        //disp.DispatchCommand(
            //        //new NFabric.Samples.Sales.Commands.SalesOrder.CreateSalesOrder(Guid.NewGuid(), Guid.NewGuid()));

            //        disp.DispatchEvents(
            //            new NFabric.Samples.Sales.Events.SalesOrder.SalesOrderCreated(Guid.NewGuid(), Guid.NewGuid()));
            //}
            // deploy BC
            //bus.EnsureBoundedContext(bc);


            //System.Console.ReadLine();

            //consume.Dispose();
            //bus.Dispose();
        }

        private static Infrastructure.Mongo.MongoEventStreamRepository GetMongo() {
            return new Infrastructure.Mongo.MongoEventStreamRepository();
        }

        private static IServiceBus CreateRabbitBus() {
            var bus = new Infrastructure.RabbitMQ.RabbitMQServiceBus("host=172.16.0.166");

            return bus;
        }
	}
}