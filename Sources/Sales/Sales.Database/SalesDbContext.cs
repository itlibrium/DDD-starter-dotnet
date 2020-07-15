// using System.Threading.Tasks;
// using JetBrains.Annotations;
// using Microsoft.EntityFrameworkCore;
// using MyCompany.Crm.Sales.Orders;
// using TechnicalStuff.Crud.DataAccess;
//
// namespace MyCompany.Crm.Sales
// {
//     [UsedImplicitly(ImplicitUseTargetFlags.Members)]
//     public class SalesDbContext : DbContext, SalesEfContext, SalesCrudEfContext
//     {
//         public DbSet<OrderData> Orders { get; set; }
//         public DbSet<OrderItemData> OrderItems { get; set; }
//
//         public DbSet<OrderHeader> OrderHeaders { get; set; }
//         public DbSet<OrderNote> OrderNotes { get; set; }
//
//         public SalesDbContext([NotNull] DbContextOptions<SalesDbContext> options) : base(options) { }
//
//         protected override void OnModelCreating(ModelBuilder modelBuilder)
//         {
//             modelBuilder.Entity<OrderData>(order =>
//             {
//                 order.HasKey(o => o.Id);
//                 order.UseXminAsConcurrencyToken();
//                 order.HasMany(o => o.Items).WithOne().HasForeignKey(nameof(OrderItemData.OrderId));
//             });
//             modelBuilder.Entity<OrderItemData>(orderItem =>
//             {
//                 orderItem.HasKey(i => new {i.OrderId, i.ProductId, i.AmountUnit});
//             });
//             
//             modelBuilder.Entity<OrderHeader>()
//                 .OwnsOne(orderHeader => orderHeader.InvoicingDetails);
//         }
//
//         DbSet<T> EfCrudContext.SetOf<T>() where T : class => Set<T>();
//
//         Task EfCrudContext.SaveChanges() => SaveChangesAsync();
//
//         Task SalesEfContext.SaveChanges() => SaveChangesAsync();
//     }
// }