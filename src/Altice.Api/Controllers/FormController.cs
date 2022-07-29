using Altice.Application.CreateForm;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Altice.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FormController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FormController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        [Route("NewForm")]
        [ProducesResponseType(typeof(CreateFormResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(HttpResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateFormCommand command)
        {
            try
            {
                if (!ModelState.IsValid) return Ok(ModelState);

                var result = await _mediator.Send(command);

                return Ok(result);
            }
            catch (System.Exception ex)
            {

                return Ok(ex.Message);
            }
           
        }
    }
}
