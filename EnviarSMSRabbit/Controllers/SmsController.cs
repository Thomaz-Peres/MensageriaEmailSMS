using EnviarSMSRabbit.Model;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client.Core.DependencyInjection.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnviarSMSRabbit.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SmsController : ControllerBase
    {
        readonly IQueueService _queueService;
        public SmsController(IQueueService queueService)
        {
            _queueService = queueService;
        }

        public async Task<IActionResult> InsertSms(SmsModel model)
        {
            var message = new SmsModel
            {
                Message = model.Message,
                To = model.To
            };

            var mensagem = System.Text.Json.JsonSerializer.Serialize(message);
            Encoding.UTF8.GetBytes(mensagem);

            await _queueService.SendJsonAsync(
                mensagem,
                exchangeName: "sms",
                routingKey: "sms");

            Console.WriteLine(" [x] Sent {0}", mensagem);

            return Accepted(message);
        }
    }
}
