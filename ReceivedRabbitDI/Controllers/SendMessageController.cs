using Comtele.Sdk.Services;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using ReceivedRabbitDI.Models;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ReceivedRabbitDI.Controllers
{
    public class SendMessageController : ControllerBase
    {
        /// <summary>
        /// EndPoint para enviar o email
        /// </summary>
        /// <param name="emailEntity"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<string>> SendEmail([FromBody] EmailModel emailEntity)
        {
            var userEmail = "";     //  Email que vai enviar a mensagem
            var password = "";      //  Senha que do email que vai enviar a mensagem

            try
            {
                var mail = new MailMessage();
                var smtp = new SmtpClient("smtp.live.com");

                mail.From = new MailAddress(userEmail);
                mail.To.Add(emailEntity.To);
                mail.Subject = emailEntity.Subject;
                mail.Body = emailEntity.Message;

                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential(userEmail, password);

                await smtp.SendMailAsync(mail);
                return Ok(new { message = "Email enviado com sucesso" });
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// EndPoint para enviar o SMS
        /// </summary>
        /// <param name="smsEntity"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<string>> SendSms([FromBody] SmsModel smsEntity)
        {
            string API_KEY = "";    // Chave do comtele
            try
            {
                var textMessageService = new TextMessageService(API_KEY);
                var result = await textMessageService.SendAsync(
                    "",                             // Sender: Id de requisicao da sua aplicacao para ser retornado no relatorio, pode ser passado em branco.
                    smsEntity.Message,              // Content: Conteudo da mensagem a ser enviada
                    new string[] { smsEntity.To }   // Receivers: Numero de telefone que vai ser enviado o SMS.
                    );

                return Ok(new { message = "SMS enviado com sucesso" });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
