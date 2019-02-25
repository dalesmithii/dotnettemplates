using MediatR;
using ServiceName.Domain.Base;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceName.Infrastructure
{
    public static class MediatorExtensions
    {
        public static async Task DispatchDomainEventsAsync(this IMediator mediator, Entity ety)
        {
            var domainEvents = ety.DomainEvents.ToList();

            ety.ClearDomainEvents();

            var tasks = domainEvents
                .Select(async (domainEvent) => {
                    await mediator.Publish(domainEvent);
                });

            await Task.WhenAll(tasks);
        }
    }
}
