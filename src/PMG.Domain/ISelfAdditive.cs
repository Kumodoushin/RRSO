using System.Numerics;

namespace PMG.Domain;

public interface ISelfAdditive<T> : IAdditionOperators<T, T, T>, ISubtractionOperators<T, T, T>
	where T : IAdditionOperators<T, T, T>, ISubtractionOperators<T, T, T>
{
}
	
public interface IOtherAdditive<T,T2> : IAdditionOperators<T, T2, T>, ISubtractionOperators<T, T2, T>
	where T : IAdditionOperators<T, T2, T>, ISubtractionOperators<T, T2, T>
{
}