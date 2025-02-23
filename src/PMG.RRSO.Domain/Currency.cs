using System;

namespace PMG.RRSO.Domain;

public class Currency : IEquatable<Currency>
{
	internal static Currency Default =
		new Currency(
			2,
			MidpointRounding.AwayFromZero,
			"NRC",
			"Not a Real Currency");
	private readonly string _currencyDescription;
	private readonly byte _precision;

	public Currency(
		byte precision,
		MidpointRounding rounding,
		string ISO4217currencyCode,
		string currencyDescription)
	{
		_precision = precision;
		Rounding = rounding;
		CurrencyCode = ISO4217currencyCode;
		_currencyDescription = currencyDescription;
	}

	public int Precision => _precision;

	public string CurrencyCode { get; }

	public MidpointRounding Rounding { get; }

	public bool Equals(Currency? other) =>
		other is not null
		&& this == other;

	public override bool Equals(object? obj) => 
		obj is not null 
		&& (obj is Currency otherCurr)
		&& this == otherCurr;

	public override int GetHashCode() =>
		HashCode.Combine(
			StringComparer.InvariantCultureIgnoreCase.GetHashCode(CurrencyCode),
			Precision,
			Rounding);

	public static bool operator ==(Currency left, Currency right) =>
		string.Equals(
			left.CurrencyCode,
			right.CurrencyCode,
			StringComparison.InvariantCultureIgnoreCase)
		&& left.Rounding == right.Rounding
		&& left.Precision == right.Precision;

	public static bool operator !=(Currency left, Currency right) => !(left == right);

	public class ComparingMismatchedCurrencies : Exception
	{
		public ComparingMismatchedCurrencies(
			Currency @this,
			Currency other,
			string message) :
			base("You can't compare Two types implementing")
		{
		}
	}
}