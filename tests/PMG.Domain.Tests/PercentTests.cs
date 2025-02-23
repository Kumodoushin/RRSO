namespace PMG.Domain.Tests;

public partial class PercentTests
{
	[Theory]
	[ClassData(typeof(PercentExpectedRepresentation))]
	public void ParticularValue_IsRepresentedAsPercentage(decimal value, string expectedRepresentation)
	{
		Assert.Equal(expectedRepresentation, value.AsPercent().ToString());
	}

	[Theory]
	[ClassData(typeof(AdditionTestData.WithWartoscProcentowaAsAddend))]
	public void AddingAnotherPercentValue(
		Percent augend,
		Percent addend,
		Percent sum)
	{
		Assert.Equal(sum, augend + addend);
	}

	[Theory]
	[ClassData(typeof(AdditionTestData.WithPunktProcentowyAsAddend))]
	public void AddingPercentPointValue(
		Percent augend,
		PercentPoint addend,
		Percent sum)
	{
		Assert.Equal(sum, augend + addend);
	}

	[Theory]
	[ClassData(typeof(AdditionTestData.WithDecimalAsAugendAndWartoscProcentowaAsAddend))]
	public void AddingToDecimal(
		decimal augend,
		Percent addend,
		decimal sum)
	{
		Assert.Equal(sum, augend + addend);
	}

	[Theory]
	[ClassData(typeof(SubtractionTestData.WithWartoscProcentowaAsSubtrahend))]
	public void SubtractingAnotherPercentValue(
		Percent minuend,
		Percent subtrahend,
		Percent difference)
	{
		Assert.Equal(difference, minuend - subtrahend);
	}

	[Theory]
	[ClassData(typeof(SubtractionTestData.WithPunktProcentowyAsSubtrahend))]
	public void SubtractingPercentPointValue(
		Percent minuend,
		PercentPoint subtrahend,
		Percent difference)
	{
		Assert.Equal(difference, minuend - subtrahend);
	}

	[Theory]
	[ClassData(typeof(SubtractionTestData.WithDecimalAsMinuendAndWartoscProcentowaAsSubtrahend))]
	public void SubtractingFromDecimal(
		decimal minuend,
		Percent subtrahend,
		decimal difference)
	{
		Assert.Equal(difference, minuend - subtrahend);
	}

	[Theory]
	[ClassData(typeof(MultiplicationTestData.WithDecimalMultiplicand))]
	public void MultiplyingByDecimal(
		Percent multiplier,
		decimal multiplicand,
		Percent product)
	{
		Assert.Equal(product, multiplier * multiplicand);
	}

	[Theory]
	[ClassData(typeof(MultiplicationTestData.WithDecimalDivisor))]
	public void DividingByDecimal(
		Percent dividend,
		decimal divisor,
		Percent fraction)
	{
		Assert.Equal(fraction, dividend / divisor);
	}
}