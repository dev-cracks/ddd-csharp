namespace Fractalize.Ddd.SharedKernel;

public interface IReadRepository<TEntity, Tid> where TEntity : AggregateRootBase<Tid>
{
}
