using System.Threading.Tasks;
using MyCompany.ECommerce.Sales.Clients;
using MyCompany.ECommerce.Sales.Commons;
using MyCompany.ECommerce.Sales.Pricing;
using MyCompany.ECommerce.Sales.Products;
using MyCompany.ECommerce.Sales.SalesChannels;
using MyCompany.ECommerce.Sales.WholesaleOrdering.OrderCreation;
using MyCompany.ECommerce.TechnicalStuff;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;
using P3Model.Annotations.Domain.DynamicModel;
using P3Model.Annotations.Domain.DynamicModel.DDD;
using P3Model.Annotations.People;

namespace MyCompany.ECommerce.Sales.WholesaleOrdering.ProductPricing
{
    [ProcessStep(nameof(CreateOrder), WholesaleOrderingProcess.Name)]
    [Actor(Actors.WholesaleClient)]
    [DddApplicationService]
    public class GetQuickQuoteHandler : CommandHandler<GetQuickQuote, QuickQuoteCalculated>
    {
        private readonly CalculatePrices _calculatePrices;

        public GetQuickQuoteHandler(CalculatePrices calculatePrices) => _calculatePrices = calculatePrices;

        public async Task<QuickQuoteCalculated> Handle(GetQuickQuote command)
        {
            var (clientId, productAmount, currency) = CreateDomainModelFrom(command);
            var quote = await _calculatePrices.For(clientId, SalesChannel.Wholesale, productAmount, currency);
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
            new(clientId.Value, quote.ToDto());
    }
}