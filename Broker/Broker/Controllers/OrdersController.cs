using Broker.Consumer.Messages;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Shared;
using Shared.Shared;

namespace Broker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public OrdersController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderDTO orderDto)
        {
            var order = new OrderDTO
            {
                Id = 123,
                CustomerId = 123,
                OrderItems = new List<OrderItem>
    {
        new OrderItem { DishName = "Салат Цезарь", Quantity = 2, Price = 350.00m },
        new OrderItem { DishName = "Пицца Маргарита", Quantity = 1, Price = 600.00m }
    },
                TotalPrice = 1300.00m,
                Status = "Pending",
                CreatedAt = DateTime.UtcNow,
                EstimatedCompletion = 30
            };

            await _publishEndpoint.Publish(order);

            return Ok();
        }
    }
}
