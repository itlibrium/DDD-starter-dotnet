using FluentMigrator;

namespace Sales.FluentMigrations.Raw._2022;

[Migration(2022_12_01)]
public class AddOrderTables : Migration
{
    private const string SalesSchema = "Sales_RawSql";
    
    public override void Up()
    {
        Create.Schema(SalesSchema);
        Create.Table("Orders")
            .InSchema(SalesSchema)
            .WithColumn("Id").AsGuid().PrimaryKey()
            .WithColumn("Version").AsInt32().NotNullable()
            .WithColumn("IsPlaced").AsBoolean().NotNullable();
        Create.Table("OrderItems")
            .InSchema(SalesSchema)
            .WithColumn("OrderId").AsGuid().NotNullable().ForeignKey("FK_OrderItems_OrderId_Orders_Id", SalesSchema, "Orders", "Id")
            .WithColumn("ProductId").AsGuid().NotNullable()
            .WithColumn("AmountUnit").AsString().NotNullable()
            .WithColumn("AmountValue").AsInt32().NotNullable()
            .WithColumn("PriceAgreementType").AsString().NotNullable()
            .WithColumn("PriceAgreementExpiresOn").AsDateTime().Nullable()
            .WithColumn("Price").AsDecimal(9, 2).Nullable()
            .WithColumn("Currency").AsString().Nullable();
        Create.PrimaryKey()
            .OnTable("OrderItems")
            .WithSchema(SalesSchema)
            .Columns("OrderId", "ProductId", "AmountUnit");
    }

    public override void Down() => throw new NotSupportedException();
}