using ApiRabbitEmail.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiRabbitEmail.Services
{
    public interface ISendEmailService
    {
        public Task<EmailModel> SendEmail(EmailModel emailEntity);
    }
}
