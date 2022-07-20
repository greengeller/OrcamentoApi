using Microsoft.Extensions.Options;
using OrcamentoApi.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Hosting;

namespace OrcamentoApi
{
    public class ProcessMessageConsumer : BackgroundService 
    {
        private readonly RabbitMqConfiguration _configuration;
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IServiceProvider _serviceProvider;

        public ProcessMessageConsumer(IOptions<RabbitMqConfiguration> option, IServiceProvider serviceProvider )
        {
            _configuration = option.Value;
            _serviceProvider = serviceProvider;

            var factory = new ConnectionFactory
            {
                HostName = _configuration.Host,
                Port = 49154

            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(
                        queue: _configuration.Queue,
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);
        }
        
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (sender, eventArgs) =>
            {
                var contentArray = eventArgs.Body.ToArray();
                var contentString = Encoding.UTF8.GetString(contentArray);
                var message = JsonSerializer.Deserialize<Orcamento>(contentString);

                //NotifyUser(message);

                _channel.BasicAck(eventArgs.DeliveryTag, false);
            };

            _channel.BasicConsume(_configuration.Queue, false, consumer);

            return Task.CompletedTask;
        }

        //public void NotifyUser(Orcamento orcamento)
        //{
        //    using (var scope = _serviceProvider.CreateScope())
        //    {
        //        var notificationService = scope.ServiceProvider.GetRequiredService<INotificationService>();

        //        notificationService.NotifyUser(orcamento.Id, orcamento.ValorTotal, orcamento.ProdutoId);
        //    }
        //}
    }
}
