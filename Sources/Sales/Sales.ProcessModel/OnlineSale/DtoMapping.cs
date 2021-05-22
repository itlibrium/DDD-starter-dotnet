using MyCompany.Crm.Sales.Commons;
using MyCompany.Crm.Sales.Pricing;
using MyCompany.Crm.Sales.Products;
using MyCompany.Crm.TechnicalStuff;

namespace MyCompany.Crm.Sales.OnlineSale
{
    public static class DtoMapping
    {
        public static ProductAmount ToDomainModel(this CartItemDto cartItemDto) => ProductAmount.Of(
            ProductId.From(cartItemDto.ProductId),
            cartItemDto.Amount,
            AmountUnit.Unit);
        
        public static Quote ToDomainModel(this QuoteDto quoteDto) => Quote.For(
            ProductAmount.Of(
                ProductId.From(quoteDto.ProductId),
                quoteDto.Amount,
                AmountUnit.Unit),
            Money.Of(
                quoteDto.Price, 
                quoteDto.CurrencyCode.ToDomainModel<Currency>()));
        
        public static QuoteDto ToDto(this Quote quote) => new QuoteDto(
            quote.ProductAmount.ProductId.Value,
            quote.ProductAmount.Amount.Value,
            quote.Price.Value,
            quote.Price.Currency.ToCode());
    }
}