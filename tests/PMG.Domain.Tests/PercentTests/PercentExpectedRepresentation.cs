namespace PMG.Domain.Tests;

public partial class PercentTests
{
	public class PercentExpectedRepresentation : TheoryData<decimal, string>
	{
		public PercentExpectedRepresentation()
		{
			Add(10m, "10.00 %");
			Add(12.004m, "12.00 %");
			Add(12.005m, "12.01 %");
		}
	}
}