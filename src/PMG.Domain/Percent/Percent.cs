using System.Globalization;

namespace PMG.Domain;

public struct Percent :
	IEquatable<Percent>,
	ISelfAdditive<Percent>,
	IOtherAdditive<Percent,PercentPoint>,
	IMultiplicable<Percent,decimal>
{
	internal static byte TO_STRING_PRECISION = 2;
	private static string Format => $"P{TO_STRING_PRECISION}";

	private static CultureInfo culture = CultureInfo.InvariantCulture;
	private readonly decimal _value;

	internal Percent(decimal value)
	{
		_value = value;
	}

	public override string ToString() => _value.ToString(Format, culture);

	public bool Equals(Percent other) => _value == other._value;

	public override bool Equals(object? obj)
	{
		if (obj is null || obj.GetType() != this.GetType())
		{
			return false;
		}

		return Equals((Percent)obj);
	}

	public override int GetHashCode() => _value.GetHashCode();

	public static bool operator ==(Percent left, Percent right) => left._value == right._value;

	public static bool operator !=(Percent left, Percent right)=> left._value != right._value;

	public static Percent operator +(Percent left, PercentPoint right) => new(left._value + right._value);
	public static Percent operator +(Percent left, Percent right) => new (left._value * (1 + right._value));
	public static decimal operator +(decimal left, Percent right) => left * (1 + right._value);
		
	public static Percent operator -(Percent left, PercentPoint right) => new (left._value - right._value);
	public static Percent operator -(Percent left, Percent right) => new (left._value * (1 - right._value));
	public static decimal operator -(decimal left, Percent right) => left * (1 - right._value);

	public static Percent operator *(Percent left, decimal right) => new (left._value * right);
	public static Percent operator /(Percent left, decimal right) => new (left._value / right);
}