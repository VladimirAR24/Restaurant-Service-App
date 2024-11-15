using Kitchen.Consumer.Messages;
using MassTransit;

namespace Kitchen.Consumer;

public class KitchenConsumer : IConsumer<YourMessage>
{
    public async Task Consume(ConsumeContext<YourMessage> context)
    {
        var message = context.Message;

        var result = ProcessMessage(message);

        await context.Publish(new YourResultMessage { Result = result });
    }

    private string ProcessMessage(YourMessage message)
    {
        // Пока заглушка
        return "Processed data";
    }
}