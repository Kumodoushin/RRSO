using PMG.Domain;
using System;
using System.Runtime.CompilerServices;

namespace PMG.RRSO.Domain;

public struct ZdyskontowanaKwota :
	IUnitOf<Currency>,
	IValueOf<decimal>,
	IComparable<ZdyskontowanaKwota>,
	IComparable
{
	private readonly decimal _value;
	private readonly Currency _unit;
	private DateTimeOffset _occuringAt;
	private readonly DateTimeOffset _discountedAgainst;

	public ZdyskontowanaKwota(Przepływ value, DateTimeOffset against)
	{
		(_value,_unit,_occuringAt) = value.Decompose();
		_discountedAgainst = against;
	}

	public override int GetHashCode() => HashCode.Combine(_value, _unit, _occuringAt, _discountedAgainst);

	public override string ToString() => $"";

	decimal IValueOf<decimal>.Value => _value;

	Currency IUnitOf<Currency>.Unit => _unit;

	private void ThrowInCaseOfMismatchedCurrency(Currency currency, [CallerMemberName] string memberName = "")
	{
		if (_unit != currency)
		{
			throw new Currency.ComparingMismatchedCurrencies(
				_unit,
				currency,
				memberName);
		}
	}

	private int CompareTo(IUnitOf<Currency> waluta, IValueOf<decimal> kwota)
	{
		ThrowInCaseOfMismatchedCurrency(waluta.Unit);

		return _value.CompareTo(kwota.Value);
	}

	public int CompareTo(ZdyskontowanaKwota other)
	{
		ThrowInCaseOfMismatchedCurrency(other._unit);

		return _value.CompareTo(other._value);
	}

	public int CompareTo(object? obj)
	{
		if (ReferenceEquals(null, obj))
		{
			return 1;
		}

		if (!(obj is IUnitOf<Currency> && obj is IValueOf<decimal>))
		{
			throw new ArgumentException(
				$"Object must implement {nameof(IUnitOf<Currency>)} and {nameof(IValueOf<decimal>)}");
		}

		return CompareTo(obj as IUnitOf<Currency>, obj as IValueOf<decimal>);
	}

	public static bool operator <(ZdyskontowanaKwota left, ZdyskontowanaKwota right) => left.CompareTo(right) < 0;

	public static bool operator >(ZdyskontowanaKwota left, ZdyskontowanaKwota right) => left.CompareTo(right) > 0;

	public static bool operator <=(ZdyskontowanaKwota left, ZdyskontowanaKwota right) => left.CompareTo(right) <= 0;

	public static bool operator >=(ZdyskontowanaKwota left, ZdyskontowanaKwota right) => left.CompareTo(right) >= 0;

	public static bool operator <(ZdyskontowanaKwota left, Kwota right) => left.CompareTo(right) < 0;

	public static bool operator >(ZdyskontowanaKwota left, Kwota right) => left.CompareTo(right) > 0;

	public static bool operator <=(ZdyskontowanaKwota left, Kwota right) => left.CompareTo(right) <= 0;

	public static bool operator >=(ZdyskontowanaKwota left, Kwota right) => left.CompareTo(right) >= 0;
}