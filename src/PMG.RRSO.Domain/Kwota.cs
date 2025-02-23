using PMG.Domain;

namespace PMG.RRSO.Domain;

public struct Kwota :
	IValueOf<decimal>,
	IUnitOf<Currency>
{
	private readonly decimal _value;
	private readonly Currency _unit;

	decimal IValueOf<decimal>.Value => _value;

	Currency IUnitOf<Currency>.Unit => _unit;

	public Kwota(decimal value)
	{
		_unit = Currency.Default;
		_value = decimal.Round(
			value,
			_unit.Precision,
			_unit.Rounding);
	}

	public Kwota(decimal value, Currency currency)
	{
		_unit = currency;
		_value = decimal.Round(
			value,
			_unit.Precision,
			_unit.Rounding);
	}

	public override string ToString() => $"{_value.ToString()} {_unit.CurrencyCode}";

	public static Kwota operator +(Kwota augend, Kwota addend) => new(augend._value + addend._value, augend._unit);

	public static Kwota operator -(Kwota minuend, Kwota subtrahend) => new(minuend._value - subtrahend._value, minuend._unit);

	public static Kwota operator *(Kwota multiplicand, decimal multiplier) =>
		new(multiplicand._value * multiplier, multiplicand._unit);

	public static Kwota operator /(Kwota dividend, decimal divisor) => new(dividend._value / divisor, dividend._unit);

	internal readonly (decimal value, Currency currency) Decompose() => (_value, _unit);
}