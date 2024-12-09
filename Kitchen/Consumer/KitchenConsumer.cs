using Kitchen.Consumer.Messages;
using Kitchen.DbServices;
using MassTransit;
using Newtonsoft.Json;
using Shared.Shared;

namespace Kitchen.Consumer;

public class KitchenConsumer : IConsumer<OrderDTO>
{
    private readonly AppDbContext _dbContext;

    public KitchenConsumer(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Consume(ConsumeContext<OrderDTO> context)
    {
        var jsonMessage = JsonConvert.SerializeObject(context.Message);
        Console.WriteLine($"OrderCreated message: {jsonMessage}");

        var message = context.Message;

        var result = ProcessMessageAsync(message);

        await context.Publish(result);
    }

    private async Task<string> ProcessMessageAsync(OrderDTO message)
    {
        var orderDto = message;

        // Преобразование OrderDTO в Order
        var order = new Order
        {
            Id = orderDto.Id,
            CustomerId = orderDto.CustomerId,
            OrderItems = System.Text.Json.JsonSerializer.Serialize(orderDto.OrderItems),
            TotalPrice = orderDto.TotalPrice,
            Status = orderDto.Status,
            CreatedAt = orderDto.CreatedAt,
            EstimatedCompletion = orderDto.EstimatedCompletion
        };

        // Сохранение в базу данных
        _dbContext.Orders.Add(order);
        await _dbContext.SaveChangesAsync();
        Console.WriteLine($"Заказ с Id={order.Id} сохранен в базу данных.");

        // Пока заглушка
        return "Processed data";
    }
}