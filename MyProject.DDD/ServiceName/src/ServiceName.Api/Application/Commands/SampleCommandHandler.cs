using MediatR;
using ServiceName.Domain.Aggregates;
using ServiceName.Infrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceName.Api.Application.Commands
{
    public class SampleCommandHandler : IRequestHandler<SampleCommand, string>
    {
        private readonly ISampleRepository _sampleRepository;
        private readonly IMediator _mediator;

        public SampleCommandHandler(ISampleRepository sampleRepository, IMediator mediator)
        {
            _sampleRepository = sampleRepository;
            _mediator = mediator;
        }

        public async Task<string> Handle(SampleCommand request, CancellationToken cancellationToken)
        {
            var sample = new Sample(request.Name);
            var greeting = sample.Greeting();
            _sampleRepository.Add(sample);
            await _mediator.DispatchDomainEventsAsync(sample);
            return greeting;
        }
    }
}
