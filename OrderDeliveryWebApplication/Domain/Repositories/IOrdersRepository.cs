using OrderDeliveryWebApplication.Domain.Models.Core;

namespace OrderDeliveryWebApplication.Domain.Repositories;

public interface IOrdersRepository
{
    Task<Order[]> GetAllOrders(); 

    Task<Order?> GetOrderById(int id);

    Task<bool> CreateOrder(Order order);

    Task<bool> UpdateOrder(Order order);

    Task<bool> DeleteOrder(int id);
}