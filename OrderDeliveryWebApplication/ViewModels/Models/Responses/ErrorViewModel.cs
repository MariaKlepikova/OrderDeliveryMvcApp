namespace OrderDeliveryWebApplication.ViewModels.Models.Responses;

public class ErrorViewModel
{
    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}