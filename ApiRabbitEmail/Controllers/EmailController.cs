using System;
using System.Threading.Tasks;
using ApiRabbitEmail.Model;
using ApiRabbitEmail.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiRabbitEmail.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly ISendEmailService _sendEmailService;

        public EmailController(ISendEmailService sendEmailService)
        {
            _sendEmailService = sendEmailService;
        }

        public async Task<IActionResult> InsertEmail(EmailModel model)
        {
            try
            {
                var result = await this._sendEmailService.SendEmail(model);
                return Ok(new { message = "Email enviado com sucesso" });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
