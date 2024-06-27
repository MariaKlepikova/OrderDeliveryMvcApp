using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OrderDeliveryWebApplication.ViewModels.Models.Requests;

public class CreateOrderControllerRequest
{
    [DisplayName("Номер заказа")]
    [Required]
    public int Id { get; set; }
    
    [DisplayName("Город отправителя")] 
    [Required]
    public string? SenderCity { get; set; }
    
    [DisplayName("Адрес отправителя")] 
    [Required]
    public string? SenderAddress { get; set; }
    
    [DisplayName("Город получателя")] 
    [Required]
    public string? RecipientCity { get; set; }
    
    [DisplayName("Адрес получателя")] 
    [Required]
    public string? RecipientAddress { get; set; }
    
    [DisplayName("Вес груза")] 
    [Required]
    public decimal CargoWeight { get; set; }
    
    [DisplayName("Дата забора груза")] 
    [Required]
    [DataType(DataType.Date)]
    public DateTime PickUpDate { get; set; }
}