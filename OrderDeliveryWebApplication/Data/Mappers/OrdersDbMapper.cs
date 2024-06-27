using OrderDeliveryWebApplication.Data.Models;
using OrderDeliveryWebApplication.Domain.Models.Core;

namespace OrderDeliveryWebApplication.Data.Mappers;

public static class OrdersDbMapper
{
    public static OrderDbModel ToDbModel(Order order)
    {
        return new OrderDbModel
        {
            Id = order.Id,
            SenderCity = order.SenderCity,
            SenderAddress = order.SenderAddress,
            RecipientCity = order.RecipientCity,
            RecipientAddress = order.RecipientAddress,
            CargoWeight = order.CargoWeight,
            PickUpDate = order.PickUpDate
        };
    }

    public static Order ToDomain(OrderDbModel order)
    {
        return new Order
        {
            Id = order.Id,
            SenderCity = order.SenderCity,
            SenderAddress = order.SenderAddress,
            RecipientCity = order.RecipientCity,
            RecipientAddress = order.RecipientAddress,
            CargoWeight = order.CargoWeight,
            PickUpDate = order.PickUpDate
        };
    }
}