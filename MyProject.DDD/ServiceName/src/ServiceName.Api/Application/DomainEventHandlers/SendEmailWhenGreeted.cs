using MediatR;
using ServiceName.Domain.Events;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceName.Api.Application.DomainEventHandlers
{
    public class SendEmailWhenGreeted : INotificationHandler<GreetedEvent>
    {
        public Task Handle(GreetedEvent notification, CancellationToken cancellationToken)
        {
            // Send the email
            return Task.CompletedTask;
        }
    }
}
