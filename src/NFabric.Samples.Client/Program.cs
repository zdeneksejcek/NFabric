using System;
using NFabric.Common;
using NFabric.Common.Messaging;
using NFabric.Samples.Sales.Commands;

namespace NFabric.Samples.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var bus = CreateRabbitBus();
            var disp = new MessageDispatcher(bus);

            var cons = bus.CreateMessageConsumer();

            //var ids  = mongo.GetSOs();
            //var rand = new Random();

            //var container = new Container("NFabric.Samples.Sales", "NFabric.BoundedContext", mongo);

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(
                new Sales.Commands.SalesOrder.CreateSalesOrder(
                    Guid.NewGuid(),
                    Guid.NewGuid(),
                    new DateTimeUtc(DateTime.UtcNow),
                    new DateTimeUtc(DateTime.UtcNow),
                    new DateTimeUtc(DateTime.UtcNow)));

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

            for (var i = 0; i < 50; i++)
            {
                disp.DispatchMessage(
                    new UncommitedMessage("command", "Sales", "CreateSalesOrder", Guid.NewGuid(), 0, DateTime.UtcNow, json));

                //disp.DispatchCommand(
                //new NFabric.Samples.Sales.Commands.SalesOrder.CreateSalesOrder(Guid.NewGuid(), Guid.NewGuid()));

                //disp.DispatchEvents(
                //    new NFabric.Samples.Sales.Events.SalesOrder.SalesOrderCreated(Guid.NewGuid(), Guid.NewGuid()));
            }
            // deploy BC
            //bus.EnsureBoundedContext(bc);


            //System.Console.ReadLine();

            //consume.Dispose();
            //bus.Dispose();

        }

        private static IServiceBus CreateRabbitBus()
        {
            var bus = new Infrastructure.RabbitMQ.RabbitMQServiceBus("host=localhost");

            return bus;
        }
    }
}
