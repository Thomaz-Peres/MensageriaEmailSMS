using System;
using System.Text;
using System.Threading.Tasks;
using ApiRabbitEmail.Model;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Core.DependencyInjection.Services;

namespace ApiRabbitEmail.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        readonly IQueueService _queueService;
        public EmailController(IQueueService queueService)
        {
            _queueService = queueService;
        }

        public async Task<IActionResult> InsertEmail(EmailModel model)
        {
            var message = new EmailModel
            {
                Message = model.Message,
                Subject = model.Subject,
                To = model.To
            };

            var mensagem = System.Text.Json.JsonSerializer.Serialize(message);
            Encoding.UTF8.GetBytes(mensagem);

            await _queueService.SendJsonAsync(
                mensagem,
                exchangeName: "email",
                routingKey: "email");

            Console.WriteLine(" [x] Sent {0}", mensagem);

            return Accepted(message);
            
            //try
            //{
            //    var factory = new ConnectionFactory() { HostName = "localhost" };
            //    using (var connection = factory.CreateConnection())
            //    using (var channel = connection.CreateModel())
            //    {
            //        channel.QueueDeclare(queue: "email",
            //                             durable: false,
            //                             exclusive: false,
            //                             autoDelete: false,
            //                             arguments: null);
            //
            //        string message = System.Text.Json.JsonSerializer.Serialize(model);
            //        var body = Encoding.UTF8.GetBytes(message);
            //
            //        channel.BasicPublish(exchange: "",
            //                             routingKey: "email",
            //                             basicProperties: null,
            //                             body: body);
            //        Console.WriteLine(" [x] Sent {0}", message);
            //    }
            //    return Accepted(model);
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }
    }
}
