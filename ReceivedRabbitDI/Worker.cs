using Microsoft.Extensions.Hosting;
using RabbitMQ.Client.Core.DependencyInjection.Services;
using System.Threading;
using System.Threading.Tasks;

namespace ReceivedRabbitDI
{
    public class Worker : BackgroundService
    {
        readonly IQueueService _queueService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="queueService"></param>
        public Worker(IQueueService queueService)
        {
            _queueService = queueService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _queueService.StartConsuming();
            await Task.CompletedTask;
        }
    }
}
