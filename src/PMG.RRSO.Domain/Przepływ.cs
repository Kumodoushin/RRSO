using System;

namespace PMG.RRSO.Domain;

public readonly struct Przepływ
{
	private readonly Kwota _kwota;

	// ReSharper disable once MemberCanBePrivate.Global
	public Przepływ(Kwota kwota, DateTimeOffset timestamp)
	{
		_kwota = kwota;
		Timestamp = timestamp;
	}

	internal DateTimeOffset Timestamp { get; }

	public ZdyskontowanaKwotaBuilder DyskontujWzględem(DateTimeOffset timestamp) =>
		new (this, timestamp);

	public static Przepływ operator *(Przepływ multiplicand, decimal multiplier) =>
		new (multiplicand._kwota * multiplier, multiplicand.Timestamp);
	
	internal (decimal value, Currency currency, DateTimeOffset timestamp)  Decompose()
	{
		(var wartośćKwoty, var walutaKwoty) = _kwota.Decompose();
		return (wartośćKwoty, walutaKwoty, Timestamp);
	}
}