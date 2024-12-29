using System;

public class Currency
{
    public decimal Value { get; set; }

    public Currency(decimal value)
    {
        Value = value;
    }
}

public class CurrencyUSD : Currency
{
    private const decimal ExchangeRateToEUR = 0.85m; // Пример курса USD к EUR
    private const decimal ExchangeRateToRUB = 73.0m; // Пример курса USD к RUB

    public CurrencyUSD(decimal value) : base(value) { }

    // Неявное преобразование USD в EUR
    public static implicit operator CurrencyEUR(CurrencyUSD usd)
    {
        return new CurrencyEUR(usd.Value * ExchangeRateToEUR);
    }

    // Неявное преобразование USD в RUB
    public static implicit operator CurrencyRUB(CurrencyUSD usd)
    {
        return new CurrencyRUB(usd.Value * ExchangeRateToRUB);
    }
}

public class CurrencyEUR : Currency
{
    private const decimal ExchangeRateToUSD = 1.18m; // Пример курса EUR к USD
    private const decimal ExchangeRateToRUB = 86.0m; // Пример курса EUR к RUB

    public CurrencyEUR(decimal value) : base(value) { }

    // Неявное преобразование EUR в USD
    public static implicit operator CurrencyUSD(CurrencyEUR eur)
    {
        return new CurrencyUSD(eur.Value * ExchangeRateToUSD);
    }

    // Неявное преобразование EUR в RUB
    public static implicit operator CurrencyRUB(CurrencyEUR eur)
    {
        return new CurrencyRUB(eur.Value * ExchangeRateToRUB);
    }
}

public class CurrencyRUB : Currency
{
    private const decimal ExchangeRateToUSD = 0.014m; // Пример курса RUB к USD
    private const decimal ExchangeRateToEUR = 0.012m; // Пример курса RUB к EUR

    public CurrencyRUB(decimal value) : base(value) { }

    // Неявное преобразование RUB в USD
    public static implicit operator CurrencyUSD(CurrencyRUB rub)
    {
        return new CurrencyUSD(rub.Value * ExchangeRateToUSD);
    }

    // Неявное преобразование RUB в EUR
    public static implicit operator CurrencyEUR(CurrencyRUB rub)
    {
        return new CurrencyEUR(rub.Value * ExchangeRateToEUR);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Введите сумму в USD:");
        decimal usdValue = decimal.Parse(Console.ReadLine());
        CurrencyUSD usd = new CurrencyUSD(usdValue);

        CurrencyEUR eur = usd; // Неявное преобразование USD в EUR
        CurrencyRUB rub = usd; // Неявное преобразование USD в RUB

        Console.WriteLine($"Сумма в EUR: {eur.Value}");
        Console.WriteLine($"Сумма в RUB: {rub.Value}");
    }
}
