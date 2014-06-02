using System;
using EasyNetQ;

namespace NFabric.Infrastructure.RabbitMQ
{
    public class Logger : IEasyNetQLogger
    {
        public void DebugWrite(string format, params object[] args)
        {

        }

        public void InfoWrite(string format, params object[] args)
        {

        }

        public void ErrorWrite(string format, params object[] args)
        {

            System.Console.WriteLine(format, args);
        }

        public void ErrorWrite(Exception exception)
        {
            System.Console.WriteLine(exception.Message);
        }
    }
}

