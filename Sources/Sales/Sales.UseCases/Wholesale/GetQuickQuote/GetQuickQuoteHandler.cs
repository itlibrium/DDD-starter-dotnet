using System.Threading.Tasks;
using MyCompany.Crm.Sales.Clients;
using MyCompany.Crm.Sales.Commons;
using MyCompany.Crm.Sales.Pricing;
using MyCompany.Crm.Sales.Products;
using MyCompany.Crm.Sales.SalesChannels;
using MyCompany.Crm.TechnicalStuff;
using MyCompany.Crm.TechnicalStuff.Metadata;
using MyCompany.Crm.TechnicalStuff.Metadata.DDD;
using MyCompany.Crm.TechnicalStuff.UseCases;

namespace MyCompany.Crm.Sales.Wholesale.GetQuickQuote
{
    [Stateless]
    [DddAppService]
    public class GetQuickQuoteHandler : CommandHandler<GetQuickQuote, QuickQuoteCalculated>
    {
        private readonly CalculatePrices _calculatePrices;

        public GetQuickQuoteHandler(CalculatePrices calculatePrices) => _calculatePrices = calculatePrices;

        public async Task<QuickQuoteCalculated> Handle(GetQuickQuote command)
        {
            var (clientId, productAmount, currency) = CreateDomainModelFrom(command);
            var quote = await _calculatePrices.For(clientId, SalesChannel.Wholesales, productAmount, currency);
            return CreateEventFrom(clientId, quote);
        }

        private static (ClientId, ProductAmount, Currency) CreateDomainModelFrom(GetQuickQuote command) => (
            ClientId.From(command.ClientId),
            ProductAmount.Of(
                ProductId.From(command.ProductId),
                command.Amount,
                command.UnitCode.ToDomainModel<AmountUnit>()),
            command.CurrencyCode.ToDomainModel<Currency>());

        private static QuickQuoteCalculated CreateEventFrom(ClientId clientId, Quote quote) =>
            new QuickQuoteCalculated(clientId.Value, quote.ToDto());
    }
}