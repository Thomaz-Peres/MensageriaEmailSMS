using RabbitMQ.Client.Core.DependencyInjection;
using RabbitMQ.Client.Core.DependencyInjection.MessageHandlers;
using RabbitMQ.Client.Events;
using ReceivedRabbitDI.Controllers;
using ReceivedRabbitDI.Models;
using System;
using System.Text.Json;

namespace ReceivedRabbitDI.Handlers
{
    public class MessageHandlerEmail : IMessageHandler
    {
        private readonly SendMessageController _sendMessageController;
        public MessageHandlerEmail(SendMessageController sendMessageController)
        {
            _sendMessageController = sendMessageController;
        }

        public async void Handle(BasicDeliverEventArgs eventArgs, string matchingRoute)
        {
            var payload = eventArgs.GetMessage();
            //var message = Encoding.UTF8.GetBytes(payload);
            var email = JsonSerializer.Deserialize<EmailModel>(payload);

            var mensagem = new EmailModel
            {
                Subject = email.Subject,
                To = email.To,
                Message = email.Message
            };

            Console.WriteLine($"Mensagem {mensagem.Message}, To {mensagem.To}, Subject {mensagem.Subject}");
            await _sendMessageController.SendEmail(mensagem);
        }
    }
}
