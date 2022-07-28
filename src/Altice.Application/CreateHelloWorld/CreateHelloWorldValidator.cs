using FluentValidation;

namespace Altice.Application.CreateHelloWorld
{
    public class CreateHelloWorldValidator : AbstractValidator<CreateHelloWorldCommand>
    {
        public CreateHelloWorldValidator()
        {
            RuleFor(command => command.UserName)
            .NotNull()
            .NotEmpty();
        }
    }
}