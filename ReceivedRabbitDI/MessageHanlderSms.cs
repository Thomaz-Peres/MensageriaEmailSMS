using RabbitMQ.Client.Core.DependencyInjection;
using RabbitMQ.Client.Core.DependencyInjection.MessageHandlers;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ReceivedRabbitDI
{
    public class MessageHanlderSms : IMessageHandler
    {
        public MessageHanlderSms()
        {
        }

        public void Handle(BasicDeliverEventArgs eventArgs, string matchingRoute)
        {
            var payload = eventArgs.GetMessage();
            //var message = Encoding.UTF8.GetBytes(payload);
            var email = JsonSerializer.Deserialize<SmsModel>(payload);

            var mensagem = new EmailEntity
            {
                To = email.To,
                Message = email.Message
            };
            Console.WriteLine($"Mensagem {mensagem.Message}, To {mensagem.To}");
        }
    }
}
