using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace MyCompany.Crm.Sales
{
    [UsedImplicitly(ImplicitUseTargetFlags.Members)]
    public class SalesDbContext : DbContext
    {
        public DbSet<SalesDb.Order> Orders { get; set; }
        public DbSet<SalesDb.OrderItem> OrderItems { get; set; }

        public SalesDbContext([NotNull] DbContextOptions<SalesDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SalesDb.Order>(order =>
            {
                order.HasKey(o => o.Id);
                order.UseXminAsConcurrencyToken();
                order.HasMany(o => o.Items).WithOne().HasForeignKey(nameof(SalesDb.OrderItem.OrderId));
            });
            modelBuilder.Entity<SalesDb.OrderItem>(orderItem =>
            {
                orderItem.HasKey(i => new {i.OrderId, i.ProductId, i.AmountUnit});
            });
        }
    }
}