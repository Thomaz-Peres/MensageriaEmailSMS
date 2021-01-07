using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReceivedRabbitDI.Models
{
    public class EmailModel
    {
        public string Subject { get; set; }
        public string To { get; set; }
        public string Message { get; set; }
    }
}
