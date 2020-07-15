using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MyCompany.Crm.Sales
{
    [UsedImplicitly]
    public class SalesDbContextFactory : IDesignTimeDbContextFactory<SalesDbContext>
        
    {
        private const string DatabaseName = "Sales";
        private const string MigrationsHistoryTable = "__Sales_Migrations";

        public SalesDbContext CreateDbContext(string[] args)
        {
            return new SalesDbContext(new DbContextOptionsBuilder<SalesDbContext>()
                .UseNpgsql("Server=localhost;Port=5432;Database=Sales;User Id=postgres;Password=password;",
                    sqlOptions => sqlOptions
                        .MigrationsAssembly(typeof(SalesDbContextFactory).Assembly.FullName)
                        .MigrationsHistoryTable(MigrationsHistoryTable))
                .Options);
        }
    }
    
    [UsedImplicitly]
    public class SalesCrudDbContextFactory : IDesignTimeDbContextFactory<SalesCrudDbContext>
        
    {
        private const string DatabaseName = "Sales";
        private const string MigrationsHistoryTable = "__SalesCrud_Migrations";

        public SalesCrudDbContext CreateDbContext(string[] args)
        {
            return new SalesCrudDbContext(new DbContextOptionsBuilder<SalesCrudDbContext>()
                .UseNpgsql("Server=localhost;Port=5432;Database=Sales;User Id=postgres;Password=password;",
                    sqlOptions => sqlOptions
                        .MigrationsAssembly(typeof(SalesDbContextFactory).Assembly.FullName)
                        .MigrationsHistoryTable(MigrationsHistoryTable))
                .Options);
        }
    }
}