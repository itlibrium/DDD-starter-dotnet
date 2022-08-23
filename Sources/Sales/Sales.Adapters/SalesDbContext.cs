using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using MyCompany.Crm.Sales.Orders;
using MyCompany.Crm.TechnicalStuff.Ef.ValueConverters;
using MyCompany.Crm.TechnicalStuff.ValueObjects;

namespace MyCompany.Crm.Sales
{
    [UsedImplicitly(ImplicitUseTargetFlags.Members)]
    public class SalesDbContext : DbContext
    {
        public DbSet<SalesDb.Order> Orders { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderNote> OrderNotes { get; set; }

        public SalesDbContext([NotNull] DbContextOptions<SalesDbContext> options) : base(options) { }

        protected override void ConfigureConventions(ModelConfigurationBuilder configuration)
        {
            foreach (var (type, valueType) in SalesDeepModel.Assembly.GetValueObjectsMeta())
                configuration.Properties(type)
                    .HaveConversion(typeof(ValueObjectConverter<,>).MakeGenericType(type, valueType));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SalesDb.Order>(order =>
            {
                order.HasKey(o => o.Id);
                order.Property(o => o.Version).IsConcurrencyToken();
                order.OwnsMany(o => o.Items, item =>
                {
                    const string orderIdColumnName = "OrderId";
                    item.ToTable("OrderItems");
                    item.WithOwner().HasForeignKey(orderIdColumnName);
                    item.OwnsOne(i => i.ProductAmount, productAmount =>
                    {
                        productAmount.WithOwner();
                        productAmount.OwnsOne(pa => pa.Amount).WithOwner();
                        
                    });
                    item.OwnsOne(i => i.PriceAgreement, priceAgreement =>
                    {
                        priceAgreement.WithOwner();
                        priceAgreement.Property(pa => pa.Type);
                        priceAgreement.Property(pa => pa.ExpiresOn);
                        priceAgreement.OwnsOne(pa => pa.Price).WithOwner();
                    });
                });
            });
            modelBuilder.Entity<OrderHeader>()
                .OwnsOne(orderHeader => orderHeader.InvoicingDetails);
        }
    }
}