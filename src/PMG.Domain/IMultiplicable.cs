using System.Numerics;

namespace PMG.Domain;

public interface IMultiplicable<T, T2> : IMultiplyOperators<T, T2, T>, IDivisionOperators<T, T2, T>
	where T : IMultiplyOperators<T, T2, T>, IDivisionOperators<T, T2, T>
	where T2 : INumber<T2>
{
}