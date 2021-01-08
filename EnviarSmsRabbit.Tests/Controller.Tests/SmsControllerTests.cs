using EnviarSMSRabbit.Controllers;
using EnviarSMSRabbit.Model;
using EnviarSMSRabbit.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace EnviarSmsRabbit.Tests.Controller.Tests
{
    [TestFixture]
    public class SmsControllerTests
    {
        [Test]
        public async Task E_Possivel_Enviar_A_Mensagem()
        {
            var serviceMock = new Mock<ISendSmsService>();
            string to = "";
            string message = "Testando controller";

            serviceMock.Setup(m => m.SendSms(It.IsAny<SmsModel>())).ReturnsAsync(new SmsModel
            {
                To = to,
                Message = message
            });

            var controller = new SmsController(serviceMock.Object);

            Mock<IUrlHelper> url = new();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("https://localhost:5000");
            controller.Url = url.Object;

            var sms = new SmsModel
            {
                To = to,
                Message = message
            };

            var result = await controller.InsertSms(sms);
            Assert.True(result is OkObjectResult);
        }
    }
}
