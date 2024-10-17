namespace PMG.Domain;

public interface IUnitOf<T>
{
	T Unit { get; }
}