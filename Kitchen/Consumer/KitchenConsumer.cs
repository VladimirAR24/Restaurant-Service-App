using Kitchen.Consumer.Messages;
using MassTransit;

namespace Kitchen.Consumer;

public class KitchenConsumer : IConsumer<YourMessage>
{
    public async Task Consume(ConsumeContext<YourMessage> context)
    {
        var message = context.Message;

        // Выполните алгоритмическую обработку данных
        var result = ProcessMessage(message);

        // Отправка результатов в другую очередь
        await context.Publish(new YourResultMessage { Result = result });
    }

    private string ProcessMessage(YourMessage message)
    {
        // Ваш алгоритм обработки данных
        return "Processed data";
    }
}