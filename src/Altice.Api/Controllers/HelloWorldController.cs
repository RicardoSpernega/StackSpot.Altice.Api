//using System.Net;
//using System.Threading.Tasks;
//using MediatR;
//using Microsoft.AspNetCore.Mvc;
//using StackSpot.ErrorHandler;
//using Altice.Application.CreateHelloWorld;

//namespace Altice.Api.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class HelloWorldController : ControllerBase
//    {
//        private readonly IMediator _mediator;

//        public HelloWorldController(IMediator mediator)
//        {
//            _mediator = mediator;
//        }

//        [HttpPost]
//        [ProducesResponseType(typeof(CreateHelloWorldResult), (int)HttpStatusCode.OK)]
//        [ProducesResponseType(typeof(HttpResponse), (int)HttpStatusCode.BadRequest)]
//        public async Task<IActionResult> Post([FromBody] CreateHelloWorldCommand command)
//        {
//            var result = await _mediator.Send(command);
//            return Ok(result);
//        }
//    }
//}