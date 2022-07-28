using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Moq;
using Altice.Api.Controllers;
using Altice.Application.CreateHelloWorld;
using Altice.Domain.Enums;
using Xunit;

namespace Altice.Api.UnitTests.Controllers
{
    public class HelloWorldControllerTests
    {
        [Fact]
        public async Task Should_Post_Hello_World_Command_To_Mediator()
        {
            //arrange
            var mediatorMock = new Mock<IMediator>();
            var createHelloWorldResult = new CreateHelloWorldResult();
            var command = new CreateHelloWorldCommand
            {
                UserName = "test",
                Level = UserLevel.Admin
            };

            //act
            mediatorMock.Setup(x => x.Send(command, CancellationToken.None)).ReturnsAsync(createHelloWorldResult);

            var controller = new HelloWorldController(mediatorMock.Object);
            var result = await controller.Post(command);

            //assert
            mediatorMock.VerifyAll();
            Assert.NotNull(result);
        }
    }
}
