using RabbitMQ.Client;
using System;
using System.Runtime.CompilerServices;

//Nugget RabbitMq.Client install
namespace RabbitMQ_Test
{
    class Program
    {
        private const string HostName = "localhost";
        private const string UserName = "guest";
        private const string Password = "guest";

        static void Main(string[] args)
        {

            Console.WriteLine("Starting RabbitMq Queue Creator");
            Console.WriteLine("");
            Console.WriteLine("");

            var connectionFactory = new RabbitMQ.Client.ConnectionFactory() { 
                Password = Password,
                UserName = UserName,
                HostName = HostName
            };

            var connection = connectionFactory.CreateConnection();
            var model = connection.CreateModel();

            model.QueueDeclare("MyQueue", true, false, false, null);
            Console.WriteLine("Queue create!");

            model.ExchangeDeclare("MyExchange", ExchangeType.Topic);
            Console.WriteLine("Exchange create!");

            model.QueueBind("MyQueue", "MyExchange", "cars");
            Console.WriteLine("Exchange and queue bound");
            
            Console.ReadLine();
        }
    }
}
