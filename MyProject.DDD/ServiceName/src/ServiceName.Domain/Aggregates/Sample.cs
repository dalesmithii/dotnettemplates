using ServiceName.Domain.Base;
using ServiceName.Domain.Events;
using System;

namespace ServiceName.Domain.Aggregates
{
    public class Sample : TypedEntity<string>, IAggregateRoot
    {
        public string Name { get; private set; }

        public Sample(string name)
        {
            Id = Guid.NewGuid().ToString("D");
            Name = name;
        }

        public string Greeting()
        {
            var greeting = $"Hello {Name}!";
            AddDomainEvent(new GreetedEvent(this, greeting));
            return greeting;
        }
    }
}
