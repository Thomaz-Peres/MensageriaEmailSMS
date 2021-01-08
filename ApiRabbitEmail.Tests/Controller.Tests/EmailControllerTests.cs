using ApiRabbitEmail.Controllers;
using ApiRabbitEmail.Model;
using ApiRabbitEmail.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace ApiRabbitEmail.Tests.Controller.Tests
{
    [TestFixture]
    public class EmailControllerTests
    {
        [Test]
        public async Task E_Possivel_Enviar_A_Mensagem()
        {
            var serviceMock = new Mock<ISendEmailService>();
            string to = "";
            string subject = "teste";
            string message = "Testando controller";

            serviceMock.Setup(m => m.SendEmail(It.IsAny<EmailModel>())).ReturnsAsync(new EmailModel
            {
                To = to,
                Subject = subject,
                Message = message
            });

            var controller = new EmailController(serviceMock.Object);

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("https://localhost:5000");
            controller.Url = url.Object;

            var email = new EmailModel
            {
                To = to,
                Subject = subject,
                Message = message
            };

            var result = await controller.InsertEmail(email);
            Assert.True(result is OkObjectResult);
        }
    }
}
