using MyCompany.Crm.TechnicalStuff;
using P3Model.Annotations.Domain.StaticModel.DDD;

namespace MyCompany.Crm.Sales.Products
{
    [DddValueObject]
    public record Amount(int Value, AmountUnit Unit)
    {
        public static Amount Of(int value, AmountUnit unit) => new(value, unit);

        public static Amount operator +(Amount x, Amount y)
        {
            CheckUnits(x, y);
            return new Amount(x.Value + y.Value, x.Unit);
        }
        
        public static Amount operator -(Amount x, Amount y)
        {
            CheckUnits(x, y);
            return new Amount(x.Value - y.Value, x.Unit);
        }

        private static void CheckUnits(Amount x, Amount y)
        {
            if (x.Unit != y.Unit) throw new DomainError();
        }
    }
}