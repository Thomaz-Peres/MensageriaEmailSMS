using ApiRabbitEmail.Model;
using RabbitMQ.Client.Core.DependencyInjection.Services;
using System;
using System.Text;
using System.Threading.Tasks;

namespace ApiRabbitEmail.Services
{
    public class SendEmailService : ISendEmailService
    {
        private readonly IQueueService _producingService;
        //private readonly ISystemUser _systemUser;

        /// <summary>
        /// Método construtor
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="configuration"></param>
        public SendEmailService(IQueueService producingService)
        {
            _producingService = producingService;
            //this._systemUser = this.GetService<ISystemUser>();
        }

        public async Task<EmailModel> SendEmail(EmailModel emailEntity)
        {
            //var systemId = _systemUser.CompanyId;

            var message = new EmailModel
            {
                Message = emailEntity.Message,
                Subject = emailEntity.Subject,
                To = emailEntity.To,
                CompanyId = Guid.NewGuid()
            };

            var mensagem = System.Text.Json.JsonSerializer.Serialize(message);
            Encoding.UTF8.GetBytes(mensagem);

            await _producingService.SendJsonAsync(
                mensagem,
                exchangeName: "email",
                routingKey: "email");

            return message;
        }
    }
}
