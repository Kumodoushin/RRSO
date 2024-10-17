namespace PMG.Domain;

public static class PercentExtensions
{
	public static Percent AsPercent(this decimal percent) => new (percent / 100m);
}