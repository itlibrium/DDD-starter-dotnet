using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using MyCompany.Crm.Sales.Orders;

namespace MyCompany.Crm.Sales
{
    [UsedImplicitly(ImplicitUseTargetFlags.Members)]
    public class SalesDbContext : DbContext
    {
        public DbSet<OrderData> Orders { get; set; }
        public DbSet<OrderItemData> OrderItems { get; set; }

        public SalesDbContext([NotNull] DbContextOptions<SalesDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderData>(order =>
            {
                order.HasKey(o => o.Id);
                order.UseXminAsConcurrencyToken();
                order.HasMany(o => o.Items).WithOne().HasForeignKey(nameof(OrderItemData.OrderId));
            });
            modelBuilder.Entity<OrderItemData>(orderItem =>
            {
                orderItem.HasKey(i => new {i.OrderId, i.ProductId, i.AmountUnit});
            });
        }
    }
}