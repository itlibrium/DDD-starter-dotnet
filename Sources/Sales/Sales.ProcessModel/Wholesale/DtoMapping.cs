using MyCompany.ECommerce.Sales.Commons;
using MyCompany.ECommerce.Sales.Pricing;
using MyCompany.ECommerce.Sales.Products;
using MyCompany.ECommerce.TechnicalStuff;

namespace MyCompany.ECommerce.Sales.Wholesale
{
    internal static class DtoExtensions
    {
        internal static Quote ToDomainModel(this QuoteDto quoteDto) => Quote.For(
            ProductAmount.Of(
                ProductId.From(quoteDto.ProductId),
                quoteDto.Amount,
                quoteDto.UnitCode.ToDomainModel<AmountUnit>()),
            Money.Of(
                quoteDto.Price, 
                quoteDto.CurrencyCode.ToDomainModel<Currency>()));

        internal static QuoteDto ToDto(this Quote quote) => new(
            quote.ProductAmount.ProductId.Value,
            quote.ProductAmount.Amount.Value,
            quote.ProductAmount.Amount.Unit.ToCode(),
            quote.Price.Value,
            quote.Price.Currency.ToCode()); 
    }
}