using PMG.RRSO.Domain;
using Xunit;

namespace PMG.RRSO.Tests;

public class ZdyskontowanaKwotaTests
{
	[Fact]
	public void Dyskontowanie_Zera_Zawsze_Daje_Zero()
	{
		//
		// var kwota = new Sum(0m);
		// var jakasInnaData = DateTime.Now;
		// var przeplyw = new CashFlow(kwota, DateTime.Now);
		// var jakasWartoscProcentowa = new WartoscProcentowa(0m);
		//
		// Assert.Equal(new DiscountedCashFlow(),przeplyw.DiscountAgaint(jakasInnaData).Dla(jakasWartoscProcentowa));

	}

	[Fact]
	public void Dyskontowanie_Niezerowej_Kwoty_W_Przyszłości_Dla_Dodatniej_Stopy_Daje_Kwotę_Mniejszą_Od_Wyjściowej()
	{
		var kwota = new Kwota();
		var dataPierwotna = DateTime.Now;
		var dataWPrzyszlosci = DateTime.Now.Add(new TimeSpan());
		
	}
	
	
}