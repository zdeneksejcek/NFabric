using System;
using NFabric.Samples.Sales.Domain.Model.SalesOrder;
using MongoDB.Bson;
using System.Diagnostics;

namespace NFabric.Samples.Sales.Console
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Process proc = Process.GetCurrentProcess();


            MongoDB.Driver.MongoClient client = new MongoDB.Driver.MongoClient();
            var eventsCollection = client.GetServer().GetDatabase("nfabric").GetCollection("events");


            for (int i = 0; i < 50; i++)
            {
                var document = new BsonDocument {
                        {"_id", Guid.NewGuid()},
                        { "name", "Prague" },
                        { "city", "Praha" }
                };

                eventsCollection.Insert(document);
            }

            var so = new SalesOrder(new CustomerId(Guid.NewGuid()), new NFabric.Samples.Sales.Port.WarehouseId());
            //so.AddLine(null, null);

            NFabric.Client.CommandDispatcher disp = new NFabric.Client.CommandDispatcher(new RabbitMQGateway());
            disp.Dispatch(
                new CreateSalesOrder(Guid.NewGuid(), Guid.NewGuid()));

            System.Console.WriteLine("Hello World!");
        }
    }
}