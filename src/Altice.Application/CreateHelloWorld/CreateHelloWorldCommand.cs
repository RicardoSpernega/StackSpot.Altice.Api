using MediatR;
using Altice.Domain.Enums;

namespace Altice.Application.CreateHelloWorld
{
    public class CreateHelloWorldCommand : IRequest<CreateHelloWorldResult>
    {
        public string UserName { get; set; }
        public UserLevel Level { get; set; }
    }
}