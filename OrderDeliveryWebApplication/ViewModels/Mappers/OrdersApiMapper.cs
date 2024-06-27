using OrderDeliveryWebApplication.Domain.Models.Core;
using OrderDeliveryWebApplication.ViewModels.Models.Requests;
using OrderDeliveryWebApplication.ViewModels.Models.Responses;

namespace OrderDeliveryWebApplication.ViewModels.Mappers;

public static class OrdersApiMapper
{
    public static Order ToDomain(CreateOrderControllerRequest request)
    {
        return new Order
        {
            Id = default,
            SenderCity = request.SenderCity,
            SenderAddress = request.SenderAddress,
            RecipientCity = request.RecipientCity,
            RecipientAddress = request.RecipientAddress,
            CargoWeight = request.CargoWeight,
            PickUpDate = request.PickUpDate
        };
    }
    
    public static Order ToDomain(UpdateOrderControllerRequest request, int id)
    {
        return new Order
        {
            Id = id,
            SenderCity = request.SenderCity,
            SenderAddress = request.SenderAddress,
            RecipientCity = request.RecipientCity,
            RecipientAddress = request.RecipientAddress,
            CargoWeight = request.CargoWeight,
            PickUpDate = request.PickUpDate
        };
    }

    public static OrderControllerResponse ToControllerResponse(Order domain)
    {
        return new OrderControllerResponse
        {
            Id = domain.Id,
            SenderCity = domain.SenderCity,
            SenderAddress = domain.SenderAddress,
            RecipientCity = domain.RecipientCity,
            RecipientAddress = domain.RecipientAddress,
            CargoWeight = domain.CargoWeight,
            PickUpDate = domain.PickUpDate
        };
    }

    public static UpdateOrderControllerRequest ToUpdateRequestModel(Order domain)
    {
        return new UpdateOrderControllerRequest
        {
            SenderCity = domain.SenderCity,
            SenderAddress = domain.SenderAddress,
            RecipientCity = domain.RecipientCity,
            RecipientAddress = domain.RecipientAddress,
            CargoWeight = domain.CargoWeight,
            PickUpDate = domain.PickUpDate
        };
    }
}