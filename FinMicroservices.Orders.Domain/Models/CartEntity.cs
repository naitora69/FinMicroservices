namespace FinMicroservices.Orders.Domain.Models;

public class CartEntity : BaseEntity
{
    public List<CartItemEntity>? CartItems { get; set; }
}