using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Bill.ValueObjects;

public sealed class Price : ValueObject
{
    private Price(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public decimal Amount { get; }
    public string Currency { get; }

    public static Price CreateNew(decimal amount, string currency)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(amount);

        if (string.IsNullOrWhiteSpace(currency))
        {
            throw new ArgumentException("Currency cannot be null or white space");
        }

        return new(amount, currency.ToUpperInvariant());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }
}