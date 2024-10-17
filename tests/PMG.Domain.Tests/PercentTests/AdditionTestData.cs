namespace PMG.Domain.Tests;

public partial class PercentTests
{
	public class AdditionTestData
	{
		public class WithWartoscProcentowaAsAddend : TheoryData<Percent, Percent, Percent>
		{
			public WithWartoscProcentowaAsAddend()
			{
				Add(
					10m.AsPercent(),
					10m.AsPercent(),
					11m.AsPercent());

				Add(
					10m.AsPercent(),
					20m.AsPercent(),
					12m.AsPercent());

				Add(
					10m.AsPercent(),
					30m.AsPercent(),
					13m.AsPercent());
			}
		}

		public class WithPunktProcentowyAsAddend : TheoryData<Percent, PercentPoint, Percent>
		{
			public WithPunktProcentowyAsAddend()
			{
				Add(
					10m.AsPercent(),
					4m.AsPercentPoint(),
					14m.AsPercent());

				Add(
					20m.AsPercent(),
					5m.AsPercentPoint(),
					25m.AsPercent());
			}
		}

		public class WithDecimalAsAugendAndWartoscProcentowaAsAddend : TheoryData<decimal, Percent, decimal>
		{
			public WithDecimalAsAugendAndWartoscProcentowaAsAddend()
			{
				Add(
					10m,
					10m.AsPercent(),
					11m);

				Add(
					20m,
					25m.AsPercent(),
					25m);
			}
		}
	}
}