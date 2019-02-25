namespace ServiceName.Domain.Base
{
    public interface IRepository<T> where T : IAggregateRoot
    {
    }
}
