using FluentValidation;
using ServiceName.Api.Application.Commands;

namespace ServiceName.Api.Application.Validations
{
    public class SampleCommandValidator : AbstractValidator<SampleCommand>
    {
        public SampleCommandValidator()
        {
            RuleFor(sample => sample.Name).NotEmpty().WithMessage("Hello cannot be empty.");
        }
    }
}
