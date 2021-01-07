using EnviarSMSRabbit.Model;
using RabbitMQ.Client.Core.DependencyInjection.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnviarSMSRabbit.Services
{
    public class SendSmsService : ISendSmsService
    {
        private readonly IQueueService _producingService;
        //private readonly ISystemUser _systemUser;

        /// <summary>
        /// Método construtor
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="configuration"></param>
        public SendSmsService(IQueueService producingService)
        {
            _producingService = producingService;
            //this._systemUser = this.GetService<ISystemUser>();
        }

        public async Task<SmsModel> SendSms(SmsModel smsModel)
        {
            var message = new SmsModel
            {
                Message = smsModel.Message,
                To = smsModel.To,
            };

            var mensagem = System.Text.Json.JsonSerializer.Serialize(message);
            Encoding.UTF8.GetBytes(mensagem);

            await _producingService.SendJsonAsync(
                mensagem,
                exchangeName: "sms",
                routingKey: "sms");

            return message;
        }
    }
}
