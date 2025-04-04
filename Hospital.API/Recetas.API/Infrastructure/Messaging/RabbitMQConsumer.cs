/* using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recetas.API.Infrastructure.Messaging
{
    public class RabbitMQConsumer
    {
        private readonly string _queueName = "recetasQueue";
        private readonly string _hostName = "localhost";

        public void StartListening()
        {
            var factory = new ConnectionFactory() { HostName = _hostName };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.QueueDeclare(queue: _queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var receta = JsonConvert.DeserializeObject<Receta>(message);

                Console.WriteLine($"Receta recibida: {receta.Codigo} para {receta.NombrePaciente}");
            };

            channel.BasicConsume(queue: _queueName, autoAck: true, consumer: consumer);
        }
    }
}*/