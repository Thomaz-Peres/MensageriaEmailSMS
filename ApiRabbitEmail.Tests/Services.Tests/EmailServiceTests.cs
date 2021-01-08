using ApiRabbitEmail.Model;
using ApiRabbitEmail.Services;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace ApiRabbitEmail.Tests.Services.Tests
{
    [TestFixture]
    class EmailServiceTests
    {
        private ISendEmailService _service;
        private Mock<ISendEmailService> _serviceMock;

        [Test]
        public async Task E_Possivel_Enviar_O_Email()
        {
            string to = "";
            string subject = "teste";
            string message = "Testando service";

            var email = new EmailModel
            {
                To = to,
                Subject = subject,
                Message = message
            };

            _serviceMock = new();
            _serviceMock.Setup(m => m.SendEmail(email)).ReturnsAsync(email);
            _service = _serviceMock.Object;

            var result = await _service.SendEmail(email);
            Assert.NotNull(result);
        }
    }
}
