using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Kafka.Public;
using Kafka.Public.Loggers;
using System.Threading.Tasks;
using System.Threading;
using System.Text;
using Newtonsoft.Json;
using BLL.Service;
using AutoMapper;
using CartingService.Api.BLL.Models;
using CartingService.Api.Web.Models;
using Microsoft.Extensions.Configuration;

namespace CartingService.Api.Web.Service
{
    public class KafkaConsumerHostedService : IHostedService
    {
        private readonly ILogger<KafkaConsumerHostedService> logger;
        private IConfiguration configuration;
        private readonly IMessageService messageService;
        private readonly IMapper mapper;
        private ClusterClient cluster;
        public KafkaConsumerHostedService(IMapper mapper, ILogger<KafkaConsumerHostedService> logger, IMessageService messageService, IConfiguration configuration)
        {
            this.messageService = messageService;
            this.configuration = configuration;
            this.mapper = mapper;
            this.logger = logger;
            cluster = new ClusterClient(new Configuration()
            {
                Seeds = "localhost:9092"
            }, new ConsoleLogger());
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var host = configuration.GetSection("Kafka").GetValue<string>("Host");
            cluster.ConsumeFromLatest(host);
            cluster.MessageReceived += record =>
            {
                var productMessage = JsonConvert.DeserializeObject<ProductMessage>(Encoding.UTF8.GetString(record.Value as byte[]));
                var updateProduct = mapper.Map<UpdateProduct>(productMessage);
                messageService.UpdateProduct(updateProduct);
            };
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            cluster?.Dispose();
            return Task.CompletedTask;
        }
    }
}
