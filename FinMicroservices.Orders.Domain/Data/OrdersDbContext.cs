using FinMicroservices.Orders.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FinMicroservices.Orders.Domain.Data;

public class OrdersDbContext: DbContext
{
    public OrdersDbContext(DbContextOptions<OrdersDbContext> options) : base(options)
    {
        if (Database.GetPendingMigrations().Any())
        {
            Database.Migrate();
        }
    }
    public DbSet<CustomerEntity> Customers { get; set; } = null!;
    //корзина товаров
    public DbSet<CartEntity> Carts { get; set; } = null!;
    public DbSet<CartItemEntity> CartItems { get; set; } = null!;
    public DbSet<OrderEntity> Orders { get; set; } = null!;
    
}