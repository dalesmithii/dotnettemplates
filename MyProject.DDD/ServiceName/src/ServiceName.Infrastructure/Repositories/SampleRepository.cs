using ServiceName.Domain.Aggregates;
using System.Collections.Generic;

namespace ServiceName.Infrastructure.Repositories
{
    public class SampleRepository : ISampleRepository
    {
        private Dictionary<string, Sample> _samples;

        public SampleRepository()
        {
            _samples = new Dictionary<string, Sample>();
        }

        public Sample Add(Sample sample)
        {
            _samples.Add(sample.Id, sample);
            return sample;
        }
    }
}
