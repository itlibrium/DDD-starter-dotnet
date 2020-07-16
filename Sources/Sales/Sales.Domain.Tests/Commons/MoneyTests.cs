using System;
using FluentAssertions;
using ITLIBRIUM.BddToolkit;
using Xunit;

namespace MyCompany.Crm.Sales.Commons
{
    public class MoneyTests
    {
        [Fact]
        public void CanAddSameCurrencies() => Bdd.Scenario<Context>()
            .Given(c => c.FirstValueWas(1.01m, Currency.PLN))
            .And(c => c.SecondValueWas(2.02m, Currency.PLN))
            .When(c => c.FirstValueIsAddedToSecondValue())
            .Then(c => c.ResultIs(3.03m, Currency.PLN))
            .Test();
        
        [Fact]
        public void CanNotAddDifferentCurrencies() => Bdd.Scenario<Context>()
            .Given(c => c.FirstValueWas(1, Currency.PLN))
            .And(c => c.SecondValueWas(2, Currency.EUR))
            .When(c => c.FirstValueIsAddedToSecondValue())
            .Then((c, r) => c.ErrorIsReturned(r))
            .Test();
        
        [Fact]
        public void CanSubtractSameCurrencies() => Bdd.Scenario<Context>()
            .Given(c => c.FirstValueWas(1.01m, Currency.PLN))
            .And(c => c.SecondValueWas(3.03m, Currency.PLN))
            .When(c => c.FirstValueIsSubtractedFromSecondValue())
            .Then(c => c.ResultIs(2.02m, Currency.PLN))
            .Test();
        
        [Fact]
        public void CanNotSubtractDifferentCurrencies() => Bdd.Scenario<Context>()
            .Given(c => c.FirstValueWas(1, Currency.PLN))
            .And(c => c.SecondValueWas(2, Currency.EUR))
            .When(c => c.FirstValueIsSubtractedFromSecondValue())
            .Then((c, r) => c.ErrorIsReturned(r))
            .Test();
        
        [Fact]
        public void CanMultiplyByInteger() => Bdd.Scenario<Context>()
            .Given(c => c.FirstValueWas(1.01m, Currency.PLN))
            .And(c => c.MultiplierWas(2))
            .When(c => c.FirstValueIsMultipliedByInt())
            .Then(c => c.ResultIs(2.02m, Currency.PLN))
            .Test();
        
        [Fact]
        public void CanMultiplyByDecimal() => Bdd.Scenario<Context>()
            .Given(c => c.FirstValueWas(1.10m, Currency.PLN))
            .And(c => c.MultiplierWas(2.5m))
            .When(c => c.FirstValueIsMultipliedByDecimal())
            .Then(c => c.ResultIs(2.75m, Currency.PLN))
            .Test();
        
        [Fact]
        public void CanMultiplyByPercentage() => Bdd.Scenario<Context>()
            .Given(c => c.FirstValueWas(1.10m, Currency.PLN))
            .And(c => c.PercentageMultiplierWas(250), "Multiplier is 250%")
            .When(c => c.FirstValueIsMultipliedByPercentage())
            .Then(c => c.ResultIs(2.75m, Currency.PLN))
            .Test();
        
        [Fact]
        public void CanDividedByInteger() => Bdd.Scenario<Context>()
            .Given(c => c.FirstValueWas(2.02m, Currency.PLN))
            .And(c => c.DividerWas(2))
            .When(c => c.FirstValueIsDividedByInt())
            .Then(c => c.ResultIs(1.01m, Currency.PLN))
            .Test();
        
        [Fact]
        public void CanDividedByDecimal() => Bdd.Scenario<Context>()
            .Given(c => c.FirstValueWas(2.75m, Currency.PLN))
            .And(c => c.DividerWas(2.5m))
            .When(c => c.FirstValueIsDividedByDecimal())
            .Then(c => c.ResultIs(1.10m, Currency.PLN))
            .Test();
        
        [Fact]
        public void CanDividedByMoney() => Bdd.Scenario<Context>()
            .Given(c => c.FirstValueWas(2.75m, Currency.PLN))
            .And(c => c.SecondValueWas(2.50m, Currency.PLN))
            .When(c => c.FirstValueIsDividedBySecondValue())
            .Then(c => c.ResultIs(110), "Result is 110%")
            .Test();
        
        [Fact]
        public void CanCalculateMaxValueForSameCurrencies() => Bdd.Scenario<Context>()
            .Given(c => c.FirstValueWas(2.75m, Currency.PLN))
            .And(c => c.SecondValueWas(2.50m, Currency.PLN))
            .When(c => c.MaxValueIsCalculated())
            .Then(c => c.ResultIs(2.75m, Currency.PLN))
            .Test();
        
        [Fact]
        public void CanNotCalculateMaxValueForDifferentCurrencies() => Bdd.Scenario<Context>()
            .Given(c => c.FirstValueWas(2.75m, Currency.PLN))
            .And(c => c.SecondValueWas(2.50m, Currency.EUR))
            .When(c => c.MaxValueIsCalculated())
            .Then((c, r) => c.ErrorIsReturned(r))
            .Test();

        [Theory]
        [InlineData(1.01, 1.01, Comparison.Equal, true)]
        [InlineData(1.01, 1.02, Comparison.Equal, false)]
        [InlineData(1.01, 1.02, Comparison.NotEqual, true)]
        [InlineData(1.01, 1.01, Comparison.NotEqual, false)]
        [InlineData(1.02, 1.01, Comparison.Greater, true)]
        [InlineData(1.01, 1.02, Comparison.Greater, false)]
        [InlineData(1.02, 1.02, Comparison.GreaterOrEqual, true)]
        [InlineData(1.01, 1.02, Comparison.GreaterOrEqual, false)]
        [InlineData(1.01, 1.02, Comparison.Less, true)]
        [InlineData(1.02, 1.01, Comparison.Less, false)]
        [InlineData(1.02, 1.02, Comparison.LessOrEqual, true)]
        [InlineData(1.02, 1.01, Comparison.LessOrEqual, false)]
        public void CanCompareSameCurrencies(decimal firstValue, decimal secondValue, Comparison comparison, 
            bool result) => Bdd.Scenario<Context>()
            .Given(c => c.FirstValueWas(firstValue, Currency.PLN))
            .And(c => c.SecondValueWas(secondValue, Currency.PLN))
            .When(c => c.FirstValueIsComparedToSecondValue(comparison))
            .Then(c => c.ResultIs(result))
            .Test();
        
        [Theory]
        [InlineData(Comparison.Equal, false)]
        [InlineData(Comparison.NotEqual, true)]
        public void ValuesWithDifferentCurrenciesAreNotEqual(Comparison comparison, bool result) => Bdd.Scenario<Context>()
            .Given(c => c.FirstValueWas(1.01m, Currency.PLN))
            .And(c => c.SecondValueWas(1.01m, Currency.EUR))
            .When(c => c.FirstValueIsComparedToSecondValue(comparison))
            .Then(c => c.ResultIs(result))
            .Test();
        
        [Theory]
        [InlineData(Comparison.Greater)]
        [InlineData(Comparison.GreaterOrEqual)]
        [InlineData(Comparison.Less)]
        [InlineData(Comparison.LessOrEqual)]
        public void CanNotCompareDifferentCurrencies(Comparison comparison) => Bdd.Scenario<Context>()
            .Given(c => c.FirstValueWas(1.01m, Currency.PLN))
            .And(c => c.SecondValueWas(1.02m, Currency.EUR))
            .When(c => c.FirstValueIsComparedToSecondValue(comparison))
            .Then((c, r) => c.ErrorIsReturned(r))
            .Test();
        
        [Theory]
        [InlineData(1.01, Currency.PLN, "1.01 PLN")]
        [InlineData(-1.01, Currency.EUR, "-1.01 EUR")]
        [InlineData(1, Currency.PLN, "1.00 PLN")]
        public void ToStringProducesHumanReadableValue(decimal value, Currency currency, string result) => Bdd.Scenario<Context>()
            .Given(c => c.FirstValueWas(value, currency))
            .When(c => c.StringValueIsCreatedForFirstValue())
            .Then(c => c.ResultIs(result))
            .Test();

        public enum Comparison
        {
            Equal,
            NotEqual,
            Greater,
            GreaterOrEqual,
            Less,
            LessOrEqual,
        }
        
        private class Context
        {
            private Money _firstValue;
            private Money _secondValue;
            private int _intMultiplier;
            private decimal _decimalMultiplier;
            private Percentage _percentageMultiplier;
            private int _intDivider;
            private decimal _decimalDivider;
            private Money _moneyResult;
            private Percentage _percentageResult;
            private bool _boolResult;
            private string _stringResult;
            
            public void FirstValueWas(decimal value, Currency currency) => _firstValue = Money.Of(value, currency);

            public void SecondValueWas(decimal value, Currency currency) => _secondValue = Money.Of(value, currency);

            public void MultiplierWas(int multiplier) => _intMultiplier = multiplier;
            public void MultiplierWas(decimal multiplier) => _decimalMultiplier = multiplier;
            public void PercentageMultiplierWas(int multiplier) => _percentageMultiplier = Percentage.Of(multiplier);
            
            public void DividerWas(int divider) => _intDivider = divider;
            public void DividerWas(decimal divider) => _decimalDivider = divider;
            
            public void FirstValueIsAddedToSecondValue() => _moneyResult = _firstValue + _secondValue;
            
            public void FirstValueIsSubtractedFromSecondValue() => _moneyResult = _secondValue - _firstValue;
            
            public void FirstValueIsMultipliedByInt() => _moneyResult = _firstValue * _intMultiplier;
            
            public void FirstValueIsMultipliedByDecimal() => _moneyResult = _firstValue * _decimalMultiplier;
            
            public void FirstValueIsMultipliedByPercentage() => _moneyResult = _firstValue * _percentageMultiplier;
            
            public void FirstValueIsDividedByInt() => _moneyResult = _firstValue / _intDivider;
            
            public void FirstValueIsDividedByDecimal() => _moneyResult = _firstValue / _decimalDivider;
            
            public void FirstValueIsDividedBySecondValue() => _percentageResult = _firstValue / _secondValue;
            
            public void MaxValueIsCalculated() => _moneyResult = Money.Max(_firstValue, _secondValue);

            public void StringValueIsCreatedForFirstValue() => _stringResult = _firstValue.ToString();

            public void FirstValueIsComparedToSecondValue(Comparison comparison) =>
                _boolResult = comparison switch
                {
                    Comparison.Equal => (_firstValue == _secondValue),
                    Comparison.NotEqual => (_firstValue != _secondValue),
                    Comparison.Greater => (_firstValue > _secondValue),
                    Comparison.GreaterOrEqual => (_firstValue >= _secondValue),
                    Comparison.Less => (_firstValue < _secondValue),
                    Comparison.LessOrEqual => (_firstValue <= _secondValue),
                    _ => throw new ArgumentOutOfRangeException(nameof(comparison))
                };

            public void ResultIs(decimal value, Currency currency) =>
                _moneyResult.Should().Be(Money.Of(value, currency));
            
            public void ResultIs(int value) => _percentageResult.Should().Be(Percentage.Of(value));
            public void ResultIs(bool result) => _boolResult.Should().Be(result);
            
            public void ResultIs(string result) => _stringResult.Should().Be(result);
            
            // ReSharper disable once MemberCanBeMadeStatic.Local
            public void ErrorIsReturned(Result result)
            {
                result.IsSuccessful.Should().BeFalse();
                result.Exception.Should().BeOfType<DomainException>();
            }
        }
    }
}