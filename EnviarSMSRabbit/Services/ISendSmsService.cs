using EnviarSMSRabbit.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnviarSMSRabbit.Services
{
    public interface ISendSmsService
    {
        public Task<SmsModel> SendSms(SmsModel smsModel);
    }
}
