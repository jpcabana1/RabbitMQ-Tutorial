using RabbitMQ.Client;
using System;
using System.Runtime.CompilerServices;
using System.Text;

//Nugget RabbitMq.Client install
namespace RabbitMQ_Test
{
    class Program
    {
        private const string HostName = "localhost";
        private const string UserName = "guest";
        private const string Password = "guest";
        private const string QueueName = "MasterQueue";
        private const string ExchangeName = "MyExchange";
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
            var properties = model.CreateBasicProperties();
            //Vai ser guardade na memória se o server for desligado a mensagem vai estar salva
            properties.Persistent = true;
            

            model.QueueDeclare(QueueName, true, false, false, null);
            Console.WriteLine("Queue create!");

            model.ExchangeDeclare(ExchangeName, ExchangeType.Topic);
            Console.WriteLine("Exchange create!");

            model.QueueBind(QueueName, ExchangeName, "Trucks");
            Console.WriteLine("Exchange and queue bound");

            //serizalize
            byte[] messageBuffer = Encoding.Default.GetBytes("This is my message");

            //Send message
            model.BasicPublish(ExchangeName, "cars", properties, messageBuffer);

      
            Console.WriteLine("message sent");
            Console.ReadLine();


        }
    }
}
