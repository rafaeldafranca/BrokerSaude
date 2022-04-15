using BrokerService.Domain.Interfaces.Services;
using BrokerService.Services.Interfaces;
using BrokerService.Services.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace BrokerService.Services
{
    public class ConsumerService : BackgroundService
    {
        private const string QUERIE_NAME = "broker_messages";
        private readonly ConnectionFactory _factory;
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IServiceProvider _serviceProvider;

        public ConsumerService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _factory = new ConnectionFactory
            {
                HostName = Environment.GetEnvironmentVariable("APP_RABBIT__SERVER__HOSTNAME")
            };

            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(QUERIE_NAME, false, false, false, null);

        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (sender, e) =>
             {
                 var contentArray = e.Body.ToArray();
                 var contentString = Encoding.UTF8.GetString(contentArray);
                 var message = JsonConvert.DeserializeObject<MessageModel>(contentString);
                 NotifyUser(message);
                 _channel.BasicAck(e.DeliveryTag, false);
             };

            _channel.BasicConsume(QUERIE_NAME, false, consumer);

            return Task.CompletedTask;
        }


        public void NotifyUser(MessageModel message)
        {

            if (message.From == "EmailMessage")
            {
                //var msg = JsonConvert.DeserializeObject<EmailMessageModel>(message.Content);
                var msg = new EmailMessageModel()
                {
                    Email = message.To,
                    Titulo = "Mensagem automatica do sistema Boa Saude",
                    Mensagem = message.Content
                };
                Enviar(msg);
            }
        }


        public void Enviar(EmailMessageModel email)
        {


            var fromAddress = new System.Net.Mail.MailAddress("COLOQUE_SEU_EMAIL", "Sistema");
            var toAddress = new System.Net.Mail.MailAddress(email.Email, email.Email);
            const string fromPassword = "COLOQUE_SUA_SENHA";

            var smtp = new System.Net.Mail.SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(fromAddress.Address, fromPassword)
            };

            using (var message = new System.Net.Mail.MailMessage(fromAddress, toAddress)
            {
                Subject = email.Titulo,
                Body = email.Mensagem
            })
            {
                smtp.Send(message);
            }

        }
    }
}
