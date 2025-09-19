namespace FinMicroservices.Orders.Domain.Models;

public class CustomerEntity : BaseEntity
{
    public string? Name { get; set; } = null!;
    
    public List<OrderEntity>? Orders { get; set; }
}