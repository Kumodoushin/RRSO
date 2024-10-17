namespace PMG.Domain;

public static class PercentPointExtensions
{
	public static PercentPoint AsPercentPoint(this decimal percentPoint) => new(percentPoint / 100);
}