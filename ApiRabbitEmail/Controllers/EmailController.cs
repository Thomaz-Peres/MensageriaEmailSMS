using System;
using System.Text;
using System.Threading.Tasks;
using ApiRabbitEmail.Model;
using ApiRabbitEmail.Services;
using Autobem.BemMais.Core;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client.Core.DependencyInjection.Services;

namespace ApiRabbitEmail.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly ISendEmailService _sendEmailService;
        //readonly IQueueService _queueService;
        //readonly ISystemUser _systemUser;

        public EmailController(ISendEmailService sendEmailService)
        {
            _sendEmailService = sendEmailService;
            //_queueService = queueService;
            //_systemUser = systemUser;
        }

        [Permission(PermissionValidationType.RequireAuthenticatedOnly)]
        public async Task<IActionResult> InsertEmail(EmailModel model)
        {
            try
            {
                var result = await this._sendEmailService.SendEmail(model);
                return Ok(new { message = "Email enviado com sucesso" });
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
