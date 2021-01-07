using EnviarSMSRabbit.Model;
using EnviarSMSRabbit.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EnviarSMSRabbit.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SmsController : ControllerBase
    {
        readonly ISendSmsService _smsService;
        public SmsController(ISendSmsService smsService)
        {
            _smsService = smsService;
        }

        public async Task<IActionResult> InsertSms(SmsModel model)
        {
            try
            {
                var result = await this._smsService.SendSms(model);
                return Ok(new { message = "Email enviado com sucesso" });
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
