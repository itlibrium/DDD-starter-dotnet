using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using MyCompany.ECommerce.TechnicalStuff;
using P3Model.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Sales.Commons;

[DddValueObject]
public record Money(decimal Value, Currency Currency)
{
    public static Money Zero(Currency currency) => new(0, currency);
    public static Money Of(decimal value, Currency currency) => new(value, currency);

    public static Money operator +(Money x, Money y) => Calculate(x, y, (a, b) => a + b);
    public static Money operator -(Money x, Money y) => Calculate(x, y, (a, b) => a - b);

    private static Money Calculate(Money x, Money y, Func<decimal, decimal, decimal> calculate)
    {
        CheckCurrencies(x, y);
        return new Money(calculate(x.Value, y.Value), x.Currency);
    }

    public static Money operator *(Money x, int y) => Calculate(x, y, (a, b) => a * b);
    public static Money operator /(Money x, int y) => Calculate(x, y, (a, b) => a / b);
    public static Money operator *(Money x, decimal y) => Calculate(x, y, (a, b) => a * b);
    public static Money operator /(Money x, decimal y) => Calculate(x, y, (a, b) => a / b);

    public static Money operator *(Money x, Percentage y) => Calculate(x, y.Fraction, (a, b) => a * b);

    private static Money Calculate<T>(Money x, T y, Func<decimal, T, decimal> calculate) => 
        x with { Value = calculate(x.Value, y) };

    public static Percentage operator /(Money x, Money y)
    {
        CheckCurrencies(x, y);
        return Percentage.Of((int) Math.Round((x.Value / y.Value) * 100, 0));
    }

    public static Money Max(Money x, Money y) => x > y ? x : y;

    public static bool operator >(Money x, Money y) => Compare(x, y, (a, b) => a > b);
    public static bool operator <(Money x, Money y) => Compare(x, y, (a, b) => a < b);
    public static bool operator >=(Money x, Money y) => Compare(x, y, (a, b) => a >= b);
    public static bool operator <=(Money x, Money y) => Compare(x, y, (a, b) => a <= b);

    private static bool Compare(Money x, Money y, Func<decimal, decimal, bool> compare)
    {
        CheckCurrencies(x, y);
        return compare(x.Value, y.Value);
    }

    [SuppressMessage("ReSharper", "ParameterOnlyUsedForPreconditionCheck.Local")]
    private static void CheckCurrencies(Money x, Money y)
    {
        if (x.Currency != y.Currency)
            throw new DomainError();
    }

    public override string ToString() =>
        $"{Value.ToString("F", CultureInfo.InvariantCulture)} {Currency.ToCode()}";
}