using ServiceName.Domain.Base;

namespace ServiceName.Domain.Aggregates
{
    public interface ISampleRepository : IRepository<Sample>
    {
        Sample Add(Sample sample);
    }
}
