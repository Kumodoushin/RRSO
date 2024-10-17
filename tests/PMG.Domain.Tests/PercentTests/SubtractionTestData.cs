namespace PMG.Domain.Tests;

public partial class PercentTests
{
	public class SubtractionTestData
	{
		public class WithWartoscProcentowaAsSubtrahend : TheoryData<Percent, Percent, Percent>
		{
			public WithWartoscProcentowaAsSubtrahend()
			{
				Add(
					10m.AsPercent(),
					10m.AsPercent(),
					9m.AsPercent());

				Add(
					10m.AsPercent(),
					20m.AsPercent(),
					8m.AsPercent());

				Add(
					10m.AsPercent(),
					30m.AsPercent(),
					7m.AsPercent());
			}
		}

		public class WithPunktProcentowyAsSubtrahend : TheoryData<Percent, PercentPoint, Percent>
		{
			public WithPunktProcentowyAsSubtrahend()
			{
				Add(
					10m.AsPercent(),
					4m.AsPercentPoint(),
					6m.AsPercent());

				Add(
					20m.AsPercent(),
					5m.AsPercentPoint(),
					15m.AsPercent());
			}
		}

		public class WithDecimalAsMinuendAndWartoscProcentowaAsSubtrahend : TheoryData<decimal, Percent, decimal>
		{
			public WithDecimalAsMinuendAndWartoscProcentowaAsSubtrahend()
			{
				Add(
					10m,
					10m.AsPercent(),
					9m);

				Add(
					20m,
					25m.AsPercent(),
					15m);
			}
		}
	}
}