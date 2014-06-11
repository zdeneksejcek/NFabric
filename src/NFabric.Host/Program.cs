using System;
using System.IO;
using System.Reflection;
using NFabric.Common;
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

            ConsolePublisher.WriteBCInfo(bc.GetName(), bc.GetHandledMessages());

            var cons = bus.CreateMessageConsumer();

            using (var consume = cons.Consume(bc.GetName(), m => Consume(m, bc, mongo)))
   		    {
   		        Console.ReadLine();

                Environment.Exit(0);
   		    }
        }

        private static MongoEventStreamRepository GetMongo() {
            return new MongoEventStreamRepository();
        }

        private static IServiceBus CreateRabbitBus() {
            var bus = new Infrastructure.RabbitMQ.RabbitMQServiceBus("host=localhost");

            return bus;
        }
	}
}