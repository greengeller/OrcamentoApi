using Microsoft.AspNetCore.Mvc;
using OrcamentoApi.Domain.Models;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace OrcamentoApi.Controllers
{
    [Route("api/[controller]")]
    public class MensagemController : ControllerBase
    {
        private readonly ConnectionFactory _factory;
        private const string Orcamento = "messages";

        public MensagemController()
        {
            _factory = new ConnectionFactory
            {
                HostName = "localhost",
                Port = 49154,
                UserName = "guest",
                Password = "guest",
            };
        }

        [HttpPost]
        public IActionResult PostMessage([FromBody] Orcamento orcamento)
        {
            using (var connection = _factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(
                    queue: Orcamento,
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                    var stringfiedMessage = JsonSerializer.Serialize(orcamento);

                    var bytesMessage = Encoding.UTF8.GetBytes(stringfiedMessage);

                        channel.BasicPublish(
                        exchange: "",
                        routingKey: Orcamento,
                        basicProperties: null,
                        body: bytesMessage);

                }
            }
                return Accepted();
        }
    }
}






