using System;
using System.Linq;
using NFabric.BoundedContext;

namespace NFabric.Host
{
    public class ConsolePublisher
    {
        public static void WriteBCInfo(string bcName, HandledMessages messages)
        {
            Console.WriteLine("BC Loaded: " + bcName);

            var commands =
                messages
                    .Messages.Where(p => p.MessageType == "command")
                    .Select(p => GetMessageFullName(p.MessageBC, p.MessageName))
                    .ToArray();

            var events =
                messages
                    .Messages.Where(p => p.MessageType == "event")
                    .Select(p => GetMessageFullName(p.MessageBC, p.MessageName))
                    .ToArray();

            Console.WriteLine("Commands:");
            foreach (var command in commands)
                WriteGreen(command);

            Console.WriteLine("Events:");
            foreach (var @event in events)
                WriteGreen(@event);
        }

        private static void WriteGreen(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t" + text);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private static string GetMessageFullName(string bc, string name)
        {
            return String.Format("{0}.{1}", bc, name);
        }
    }
}
