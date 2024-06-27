using Microsoft.EntityFrameworkCore;
using OrderDeliveryWebApplication.Data.Models;

namespace OrderDeliveryWebApplication.Data
{
    public class OrderDeliveryWebApplicationContext : DbContext
    {
        public OrderDeliveryWebApplicationContext (DbContextOptions<OrderDeliveryWebApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<OrderDbModel> Order { get; set; } = default!;
    }
}
