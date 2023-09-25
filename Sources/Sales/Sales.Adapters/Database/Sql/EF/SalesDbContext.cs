using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using MyCompany.ECommerce.Sales.Orders;
using MyCompany.ECommerce.TechnicalStuff.Ef.ValueConverters;
using MyCompany.ECommerce.TechnicalStuff.ValueObjects;
using P3Model.Annotations.Technology;

namespace MyCompany.ECommerce.Sales.Database.Sql.EF
{
    [UsedImplicitly(ImplicitUseTargetFlags.Members)]
    [Database("Main", ClusterName = "Postgres")]
    public class SalesDbContext : DbContext
    {
        public DbSet<DbOrder> Orders { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderNote> OrderNotes { get; set; }

        public SalesDbContext([NotNull] DbContextOptions<SalesDbContext> options) : base(options) { }

        protected override void ConfigureConventions(ModelConfigurationBuilder configuration)
        {
            foreach (var (type, valueType) in SalesDeepModelLayerInfo.Assembly.GetValueObjectsMeta())
                configuration.Properties(type)
                    .HaveConversion(typeof(ValueObjectConverter<,>).MakeGenericType(type, valueType));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbOrder>(order =>
            {
                order.HasKey(o => o.Id);
                order.Property(o => o.Version).IsConcurrencyToken();
                order.OwnsMany(o => o.Items, item =>
                {
                    item.ToTable("OrderItems");
                    item.WithOwner().HasForeignKey("OrderId");
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
                    item.Ignore(i => i.Id);
                });
            });
            modelBuilder.Entity<OrderHeader>()
                .OwnsOne(orderHeader => orderHeader.InvoicingDetails);
        }
    }
}