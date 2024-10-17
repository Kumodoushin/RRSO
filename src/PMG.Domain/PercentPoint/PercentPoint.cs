using System.Globalization;

namespace PMG.Domain;

public struct PercentPoint : ISelfAdditive<PercentPoint>
{
	internal decimal _value;

	internal PercentPoint(decimal value)
	{
		_value = value;
	}
	public static PercentPoint operator +(PercentPoint left, PercentPoint right) => new PercentPoint(left._value + right._value);

	public static PercentPoint operator -(PercentPoint left, PercentPoint right) => new PercentPoint(left._value - right._value);

	internal static byte TO_STRING_PRECISION = 2;
	private static string Format => $"P{TO_STRING_PRECISION}";

	private static CultureInfo culture = CultureInfo.InvariantCulture;
	public override string ToString()
	{
		var format = culture.GetFormat(typeof(NumberFormatInfo)) as NumberFormatInfo;
		return 
			_value.ToString(Format, culture).Replace(format.PercentSymbol,"").Trim() + " p.p.";
	}
}