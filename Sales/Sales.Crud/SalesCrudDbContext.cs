using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using MyCompany.Crm.Sales.Orders;

namespace MyCompany.Crm.Sales
{
    [UsedImplicitly(ImplicitUseTargetFlags.Members)]
    public class SalesCrudDbContext : DbContext
    {
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderNote> OrderNotes { get; set; }

        public SalesCrudDbContext([NotNull] DbContextOptions<SalesCrudDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderHeader>()
                .OwnsOne(orderHeader => orderHeader.InvoicingDetails);
        }
    }
}