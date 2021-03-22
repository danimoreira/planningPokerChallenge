using System;
using System.Text;
using RabbitMQ.Client;

namespace PlanningPocker.Util.Messaging
{
    public class ConfigurationRabbitMQ
    {
        private static readonly string _url = "amqps://yksheilx:8txj34sYwJ8kyDVUkJ3wHwBZpSV5vf8l@jackal.rmq.cloudamqp.com/yksheilx";

        public void SendMessage(string message){
            var factory = new ConnectionFactory
            {
                Uri = new Uri(_url)
            };
            
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            
            var queueName = "Votes";
            bool durable = true;
            bool exclusive = false;
            bool autoDelete = false;

            channel.QueueDeclare(queueName, durable, exclusive, autoDelete, null);

            channel.QueueBind(queue: queueName,
                  exchange: "AllVotes",
                  routingKey: "");

            var data = Encoding.UTF8.GetBytes(message);
            var exchangeName = "AllVotes";
            var routingKey = "";
            channel.BasicPublish(exchangeName, routingKey, null, data);    
        }

    }
}