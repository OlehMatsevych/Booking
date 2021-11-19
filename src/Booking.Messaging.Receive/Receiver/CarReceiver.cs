using Booking.Messaging.Receive.Options;
using System;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System.Text.Json;
using System.Text;
using RabbitMQ.Client.Events;
using System.Collections.Generic;

namespace Booking.Messaging.Receive.Receiver
{
    public class CarReceiver : ICarReceiver
    {
        private readonly string _queueName;
        private readonly string _hostName;
        private readonly string _userName;
        private readonly string _password;

        private IConnection _connection;

        public CarReceiver(IOptions<RabbitMqConfiguration> options)
        {
            _queueName = options.Value.QueueName;
            _hostName = options.Value.Hostname;
            _userName = options.Value.UserName;
            _password = options.Value.Password;
            CreateConnection();
        }
        public IEnumerable<string> ReceiveCar()
        {
            var data = new List<string>();
            if (_connection != null)
            {
                using (var channel = _connection.CreateModel())
                {
                    channel.QueueDeclare(
                        queue: _queueName,
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null
                    );
                    var consumer = new EventingBasicConsumer(channel);
                    
                    consumer.Received += (model, e) =>
                    {
                        var body = e.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        data.Add(message);
                    };
                    channel.BasicConsume(
                        queue: _queueName,
                        autoAck: true,
                        consumer: consumer
                        );
                }
            }
            return data;
        }
        private void CreateConnection()
        {
            var factory = new ConnectionFactory
            {
                HostName = _hostName,
                UserName = _userName,
                Password = _password
            };
            _connection = factory.CreateConnection();

            if (_connection == null)
            {
                throw new Exception("Connection failury");
            }
        }
    }
}
