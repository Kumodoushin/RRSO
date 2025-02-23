using PMG.Domain;
using System;

namespace PMG.RRSO.Domain;

public struct WspółczynnikDyskontowania
{
	private readonly double _stopa;
	private readonly double _okres;

	public WspółczynnikDyskontowania(Percent stopa, double okres)
	{
		_stopa = Convert.ToDouble(1m+stopa);
		_okres = okres;
	}

	public static implicit operator decimal(WspółczynnikDyskontowania w) =>
		Convert.ToDecimal(Math.Pow(w._stopa, -w._okres));
}