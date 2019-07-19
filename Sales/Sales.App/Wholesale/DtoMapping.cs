using MyCompany.Crm.Sales.Commons;
using MyCompany.Crm.Sales.Pricing;
using MyCompany.Crm.Sales.Products;
using MyCompany.Crm.TechnicalStuff;

namespace MyCompany.Crm.Sales.Wholesale
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

        internal static QuoteDto ToDto(this Quote quote) => new QuoteDto(
            quote.ProductAmount.ProductId.Value,
            quote.ProductAmount.Value,
            quote.ProductAmount.Unit.ToCode(),
            quote.Price.Value,
            quote.Price.Currency.ToCode()); 
    }
}