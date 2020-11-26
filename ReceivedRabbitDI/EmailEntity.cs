using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReceivedRabbitDI
{
    public class EmailEntity
    {
        public string Subject { get; set; }
        public string To { get; set; }
        public string Message { get; set; }
    }
}
