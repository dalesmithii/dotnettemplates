using MediatR;
using ServiceName.Domain.Aggregates;

namespace ServiceName.Domain.Events
{
    public class GreetedEvent : INotification
    {
        public string Greeting { get; private set; } 
        public Sample Sample { get; private set; }

        public GreetedEvent(Sample sample, string greeting)
        {
            Greeting = greeting;
            Sample = sample;
        }
    }
}
