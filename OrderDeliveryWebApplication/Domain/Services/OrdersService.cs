using OrderDeliveryWebApplication.Domain.Models.Core;
using OrderDeliveryWebApplication.Domain.Models.Enums;
using OrderDeliveryWebApplication.Domain.Repositories;

namespace OrderDeliveryWebApplication.Domain.Services;

public class OrdersService
{
    private readonly IOrdersRepository _ordersRepository;

    public OrdersService(IOrdersRepository ordersRepository)
    {
        _ordersRepository = ordersRepository;
    }

    public async Task<Order[]> GetAllOrders()
    {
        return await _ordersRepository.GetAllOrders();
    }
    
    public async Task<Order?> GetOrderById(int id)
    {
        return await _ordersRepository.GetOrderById(id);
    }

    public async Task<bool> CreateOrder(Order order)
    {
        return await _ordersRepository.CreateOrder(order);
    }

    public async Task<UpdateOrderResult> UpdateOrder(Order order)
    {
        var existOrder = await _ordersRepository.GetOrderById(order.Id);

        if (existOrder is null)
        {
            return UpdateOrderResult.NotFound;
        }
        
        var isSuccess = await _ordersRepository.UpdateOrder(order);

        return isSuccess 
            ? UpdateOrderResult.Success 
            : UpdateOrderResult.UnknownError;
    }

    public async Task<bool> DeleteOrder(int id)
    {
        return await _ordersRepository.DeleteOrder(id);
    }
}