using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReceivedRabbitDI.Models
{
    public class SmsModel
    {
        public string Message { get; set; }
        public string To { get; set; }
    }
}
