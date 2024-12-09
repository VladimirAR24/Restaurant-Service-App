using Broker.Consumer.Messages;
using MassTransit;
using Shared;
using Shared.Shared;

namespace Broker.Consumer;

public class BrokerConsumer : IConsumer<OrderDTO>
{
    public async Task Consume(ConsumeContext<OrderDTO> context)
    {
        var message = context.Message;



        var result = ProcessMessage(message);//TODO: Сделать create message orderDTO

        await context.Publish(result);
    }

    private string ProcessMessage(OrderDTO message)
    {
        // Пока заглушка
        return "Processed data";
    }
}