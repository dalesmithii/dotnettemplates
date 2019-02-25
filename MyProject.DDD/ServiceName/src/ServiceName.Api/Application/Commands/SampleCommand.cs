using MediatR;

namespace ServiceName.Api.Application.Commands
{
    public class SampleCommand : IRequest<string>
    {
        public string Name { get; private set; }

        public SampleCommand(string name)
        {
            Name = name;
        }
    }
}
