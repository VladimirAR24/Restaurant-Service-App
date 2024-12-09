namespace Shared
{
    namespace Shared
    {
        public class OrderDTO
        {
            public int Id { get; set; } // Уникальный идентификатор заказа
            public int CustomerId { get; set; } // Имя клиента
            public List<OrderItem> OrderItems { get; set; } // Список блюд
            public decimal TotalPrice { get; set; } // Общая сумма заказа
            public string Status { get; set; } // Статус заказа (Pending, In Progress, Completed)
            public DateTime CreatedAt { get; set; } // Время создания заказа
            public int EstimatedCompletion { get; set; } // Предполагаемое время завершения заказа
        }

        public class OrderItem
        {
            public string DishName { get; set; } // Название блюда
            public int Quantity { get; set; } // Количество
            public decimal Price { get; set; } // Цена за единицу
        }
    }

}