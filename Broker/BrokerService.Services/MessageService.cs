using BrokerService.Domain.Interfaces.Repositories;
using BrokerService.Domain.Interfaces.Services;
using BrokerService.Services.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace BrokerService.Services
{
    public class MessageService : IMessageService
    {
        private readonly ConnectionFactory _factory;
        private readonly IUsuarioRepo _usuarioRepo;
        private const string QUERIE_NAME = "broker_messages";

        public MessageService(IUsuarioRepo usuarioRepo)
        {
            _usuarioRepo = usuarioRepo;
            _factory = new ConnectionFactory
            {
                HostName = Environment.GetEnvironmentVariable("APP_RABBIT__SERVER__HOSTNAME") ?? "localhost"
            };
        }
        public bool SendMessage(MessageModel message)
        {
            try
            {
                using (var cn = _factory.CreateConnection())
                {
                    using (var channel = cn.CreateModel())
                    {
                        channel.QueueDeclare(QUERIE_NAME, false, false, false, null);
                        var messageString = JsonConvert.SerializeObject(message);
                        var messageBytes = Encoding.UTF8.GetBytes(messageString);

                        channel.BasicPublish(exchange: ""
                            , routingKey: QUERIE_NAME
                            , basicProperties: null
                            , body: messageBytes);
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }


    }
}