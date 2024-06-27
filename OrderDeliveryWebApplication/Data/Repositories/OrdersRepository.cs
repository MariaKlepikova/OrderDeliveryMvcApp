using Microsoft.EntityFrameworkCore;
using OrderDeliveryWebApplication.Data.Mappers;
using OrderDeliveryWebApplication.Domain.Models.Core;
using OrderDeliveryWebApplication.Domain.Repositories;

namespace OrderDeliveryWebApplication.Data.Repositories;

public class OrdersRepository : IOrdersRepository
{
    private readonly OrderDeliveryWebApplicationContext _context;

    public OrdersRepository(OrderDeliveryWebApplicationContext context)
    {
        _context = context;
    }
    
    public async Task<Order[]> GetAllOrders()
    {
        var orders = await _context.Order.ToListAsync();

        return orders.Select(OrdersDbMapper.ToDomain).ToArray();
    }

    public async Task<Order?> GetOrderById(int id)
    {
        var order = await _context.Order.FirstOrDefaultAsync(m => m.Id == id);

        return order is null
            ? null
            : OrdersDbMapper.ToDomain(order);
    }

    public async Task<bool> CreateOrder(Order order)
    {
        var dbModel = OrdersDbMapper.ToDbModel(order);
        
        _context.Order.Add(dbModel);
        
        var changesCount = await _context.SaveChangesAsync();

        return changesCount > 0;
    }

    public async Task<bool> UpdateOrder(Order order)
    {
        var editedOrder = OrdersDbMapper.ToDbModel(order);

        var storedOrder = await _context.Order.FirstAsync(x => x.Id == order.Id);
        
        
        _context.Entry(storedOrder).CurrentValues.SetValues(editedOrder);
        
        
        // _context.Entry(storedOrder).State = EntityState.Detached; // открепляем объект, чтобы ef не следил за ним
        //
        // _context.Order.Attach(editedOrder); 
        // _context.Entry(editedOrder).State = EntityState.Modified;
        
        

        /*
        existedOrder.SenderCity = order.SenderCity;
        existedOrder.SenderAddress = order.SenderAddress;
        existedOrder.RecipientCity = order.RecipientCity;
        existedOrder.RecipientAddress = order.RecipientAddress;
        existedOrder.CargoWeight = order.CargoWeight;
        existedOrder.PickUpDate = order.PickUpDate;
        */
        
        
        var changesCount = await _context.SaveChangesAsync();

        return changesCount > 0;
    }

    public async Task<bool> DeleteOrder(int id)
    {
        var deletedRows = await _context.Order
            .Where(order => order.Id == id)
            .ExecuteDeleteAsync();

        return deletedRows > 0;
    }
}