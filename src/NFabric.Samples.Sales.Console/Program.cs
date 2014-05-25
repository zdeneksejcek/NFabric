using System;
using NFabric.Samples.Sales.Domain.Model.SalesOrders;
using MongoDB.Bson;
using System.Diagnostics;
using NFabric.Samples.Sales.Port;
using NFabric.Client;
using NFabric.Samples.Sales.Domain.Model.Customers;

namespace NFabric.Samples.Sales.Console
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            /*
             * MongoDB.Driver.MongoClient client = new MongoDB.Driver.MongoClient();
            var eventsCollection = client.GetServer().GetDatabase("nfabric").GetCollection("events");

            for (int i = 0; i < 50; i++)
            {
                var document = new BsonDocument {
                        {"_id", Guid.NewGuid()},
                        { "name", "Prague" },
                        { "city", "Praha" }
                };

                eventsCollection.Insert(document);
            } */

            var so = new SalesOrder(new CustomerId(Guid.NewGuid()), new WarehouseId(Guid.NewGuid()));
            so.Lines.Add(
                new ProductId(Guid.NewGuid()),
                new SalesOrderLineQuantity(5));

            var disp = new CommandDispatcher(new RabbitMQGateway());

            disp.Dispatch(
                new CreateSalesOrder(Guid.NewGuid(), Guid.NewGuid()));

            System.Console.WriteLine("Hello World!");
        }
    }
}