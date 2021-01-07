using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRabbitEmail.Model
{
    public class EmailModel
    {
        public EmailModel()
        {
            IDUser = Guid.NewGuid();
        }

        public Guid CompanyId { get; set; }
        public Guid IDUser { get; set; }
        public string Subject { get; set; }
        public string To { get; set; }
        public string Message { get; set; }
    }
}
