using System.Text;
using System.Text.Json;

namespace SSTTEK.Services.Services.Concrete
{
    public class RabbitMQPublisherService
    {
        private readonly RabbitMQClientService _rabbitMQClientService;

        public RabbitMQPublisherService(RabbitMQClientService rabbitMQClientService)
        {
            _rabbitMQClientService = rabbitMQClientService;
        }

        public void Publish( model) //TODO : M
        {
            var channel = _rabbitMQClientService.Connect();

            var bodyString = JsonSerializer.Serialize(model);

            var bodyByte = Encoding.UTF8.GetBytes(bodyString);

            var properties = channel.CreateBasicProperties();

            properties.Persistent = true;

            channel.BasicPublish(exchange: RabbitMQClientService.ExchangeName,
                                routingKey: RabbitMQClientService.RoutingMail,
                                basicProperties: properties,
                                body: bodyByte);
        }
    }
}
