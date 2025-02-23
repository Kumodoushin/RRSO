using PMG.Domain;
using System;

namespace PMG.RRSO.Domain;

public class ZdyskontowanaKwotaBuilder
{
	private readonly Przepływ _przepływ;
	private readonly double _period;
	private readonly DateTimeOffset _timestamp;

	internal ZdyskontowanaKwotaBuilder(Przepływ przepływ, DateTimeOffset timestamp)
	{
		_period = PeriodCalculator.CurrentPolicy.Calculate(timestamp, _przepływ.Timestamp);
		_przepływ = przepływ;
		_timestamp = timestamp;
	}

	ZdyskontowanaKwota UsingRate(Percent discountRate)
	{

		var discountedValue = _przepływ * new WspółczynnikDyskontowania(discountRate, _period);

		return new ZdyskontowanaKwota(discountedValue, _timestamp);
	}
}