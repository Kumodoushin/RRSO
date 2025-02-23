using System;
using System.Globalization;
using System.Linq;

namespace PMG.RRSO.Domain;

public abstract partial class PeriodCalculator
{
	public static PeriodCalculator CurrentPolicy = new Lazy<DefaultPolicy>().Value;

	public abstract double Calculate(DateTimeOffset currentDate, DateTimeOffset laterDate);
	public class DefaultPolicy : PeriodCalculator
	{
		public override double Calculate(DateTimeOffset currentDate, DateTimeOffset laterDate)
		{
			var movingYear = currentDate.UtcDateTime;
			int yearDifference = 0;
			while (movingYear.AddYears(yearDifference+1) <= laterDate.UtcDateTime)
			{
				yearDifference++;
			}
			movingYear = movingYear.AddYears(yearDifference);

			var gregCal = new GregorianCalendar();
			var allLeftoverDays = 
				Enumerable
					.Range(1, (laterDate.UtcDateTime.Date - movingYear.Date).Days)
					.Select(x => movingYear.AddDays(x))
					.ToList();

			if (allLeftoverDays.Any(x => gregCal.IsLeapDay(x.Year, x.Month, x.Day)))
			{
				return Convert.ToDouble(yearDifference) + Convert.ToDouble(allLeftoverDays.Count)/Math.Max(gregCal.GetDaysInYear(movingYear.Year), gregCal.GetDaysInYear(laterDate.UtcDateTime.Year));
			}
			
			return Convert.ToDouble(yearDifference) + Convert.ToDouble(allLeftoverDays.Count)/Math.Min(gregCal.GetDaysInYear(movingYear.Year), gregCal.GetDaysInYear(laterDate.UtcDateTime.Year));
			
		}
	}
}