using Bogus;
using PMG.RRSO.Domain;
using System;
using Xunit;

namespace PMG.Domain.Tests;

public class PeriodCalculatorTests
{
	[Theory]
	[ClassData(typeof(DefaultPeriodCalculatorTestData))]
	public void t1(double expectedPeriod,DateTimeOffset first, DateTimeOffset last)
	{
		Assert.Equal(expectedPeriod,PeriodCalculator.CurrentPolicy.Calculate(first,last));
	}

	public class DefaultPeriodCalculatorTestData : TheoryData<double,DateTimeOffset,DateTimeOffset>
	{
		public DefaultPeriodCalculatorTestData()
		{
			//trivial examples
			Add(0.0, new(new DateTime(2025,1,1),TimeSpan.Zero), new(new DateTime(2025,1,1),TimeSpan.Zero));
			Add(1.0/365, new(new DateTime(2025,1,1),TimeSpan.Zero), new(new DateTime(2025,1,2),TimeSpan.Zero));
			Add(0.0/366, new(new DateTime(2024,1,1),TimeSpan.Zero), new(new DateTime(2024,1,1),TimeSpan.Zero));
			Add(1.0/366, new(new DateTime(2024,1,1),TimeSpan.Zero), new(new DateTime(2024,1,2),TimeSpan.Zero));

			var d1 = new DateTimeOffset(new DateTime(2025, 1, 1), TimeSpan.Zero);
			var trivialExamples = Enumerable.Range(0, 1461).Select(x => d1.AddDays(x)).ToList();
			foreach (var example in trivialExamples)
			{
				Add(0.0, example, example);
				for (int i = 1; i < 12; i++)
				{
					Add(i, example, example.AddYears(i));
				}
				
			}

			var f = new Faker();
			
			//nontrivial examples
			var d2 = new DateTimeOffset(new DateTime(2025,3,1),TimeSpan.Zero);
			var nontrivialExamples = Enumerable.Range(0, 366).ToList();
			
			foreach (var example in nontrivialExamples)
			{
				var yearDiff = f.Random.Int(0, 35);
				Add(yearDiff+example/365.0, d2, d2.AddYears(yearDiff).AddDays(example));
			}
			
			var d3 = new DateTimeOffset(new DateTime(2024,3,1),TimeSpan.Zero);
			
			foreach (var example in nontrivialExamples)
			{
				var yearDiff = f.Random.Int(0, 35); 
				Add(yearDiff+example/366.0, d3.AddYears(-yearDiff).AddDays(-example), d3);
			}
		}
	}
}