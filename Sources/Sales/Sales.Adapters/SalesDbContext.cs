using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using MyCompany.Crm.Sales.Orders;

namespace MyCompany.Crm.Sales
{
    [UsedImplicitly(ImplicitUseTargetFlags.Members)]
    public class SalesDbContext : DbContext
    {
        public DbSet<SalesDb.Order> Orders { get; set; }
        public DbSet<SalesDb.OrderItem> OrderItems { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderNote> OrderNotes { get; set; }

        public SalesDbContext([NotNull] DbContextOptions<SalesDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SalesDb.Order>(order =>
            {
                order.HasKey(o => o.Id);
                order.UseXminAsConcurrencyToken();
                order.HasMany(o => o.Items).WithOne().HasForeignKey(nameof(SalesDb.OrderItem.OrderId));
            });
            // TODO: concurrency control for nested objects
            modelBuilder.Entity<SalesDb.OrderItem>(orderItem =>
            {
                orderItem.HasKey(i => new {i.OrderId, i.ProductId, i.AmountUnit});
            });
            modelBuilder.Entity<OrderHeader>()
                .OwnsOne(orderHeader => orderHeader.InvoicingDetails);
        }
    }
}