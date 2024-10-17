namespace PMG.Domain.Tests;

public partial class PercentTests
{
	public partial class MultiplicationTestData
	{
		public class WithDecimalMultiplicand : TheoryData<Percent, decimal, Percent>
		{
			public WithDecimalMultiplicand()
			{
				Add(
					10m.AsPercent(),
					2m,
					20m.AsPercent());

				Add(
					10m.AsPercent(),
					1.5m,
					15m.AsPercent());

				Add(
					10m.AsPercent(),
					0.5m,
					5m.AsPercent());
			}
		}

		public partial class WithDecimalDivisor : TheoryData<Percent, decimal, Percent>
		{
			public WithDecimalDivisor()
			{
				Add(
					10m.AsPercent(),
					10m,
					1m.AsPercent());

				Add(
					20m.AsPercent(),
					2m,
					10m.AsPercent());

				Add(
					20m.AsPercent(),
					0.2m,
					100m.AsPercent());
			}
		}
	}
}