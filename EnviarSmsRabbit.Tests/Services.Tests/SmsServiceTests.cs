using EnviarSMSRabbit.Model;
using EnviarSMSRabbit.Services;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace EnviarSmsRabbit.Tests.Services.Tests
{
    [TestFixture]
    public class SmsServiceTests
    {
        private ISendSmsService _service;
        private Mock<ISendSmsService> _serviceMock;
        
        [Test]
        public async Task E_Possivel_Enviar_O_Email()
        {
            string to = "";
            string message = "Testando service";

            var sms = new SmsModel
            {
                To = to,
                Message = message
            };

            _serviceMock = new();
            _serviceMock.Setup(m => m.SendSms(sms)).ReturnsAsync(sms);
            _service = _serviceMock.Object;

            var result = await _service.SendSms(sms);
            Assert.NotNull(result);
        }
    }
}
